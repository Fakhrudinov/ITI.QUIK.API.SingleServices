using DataAbstraction.Interfaces;
using DataAbstraction.Models;
using DataAbstraction.Models.Connections;
using DataAbstraction.Models.Responses;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Renci.SshNet;
using Renci.SshNet.Sftp;
using System.Text;

namespace QuikSftpService
{
    public class SFTPRepository : ISFTPRepository
    {
        private ILogger<SFTPRepository> _logger;
        private SftpConnectionConfiguration _logon;
        private SftpClient _client;

        public SFTPRepository(IOptions<SftpConnectionConfiguration> logon, ILogger<SFTPRepository> logger)
        {
            _logon = logon.Value;
            _logger = logger;
            _client = new SftpClient(_logon.Host, _logon.Port, _logon.Login, _logon.Password);

        }

        public BoolResponse CheckIsPathExist(string remoteDirPath)
        {
            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} SFTPRepository CheckIsPathExist Called for {remoteDirPath}");

            BoolResponse isExist = new BoolResponse();

            try
            {
                _client.Connect();
                _logger.LogDebug($"{DateTime.Now.ToString("HH:mm:ss:fffff")} SFTPRepository CheckIsPathExist {remoteDirPath} Connected");

                if (!_client.Exists(remoteDirPath))
                {
                    _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} SFTPRepository CheckIsPathExist: " +
                        $"File or Dir not found by path {remoteDirPath}");

                    isExist.Messages.Add($"SFTPRepository CheckIsPathExist: File or Dir not found by path {remoteDirPath}");
                    return isExist;
                }

                _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} SFTPRepository CheckIsPathExist for {remoteDirPath} is True");
                isExist.IsTrue = true;
            }
            catch (Exception exception)
            {
                _logger.LogWarning($"{DateTime.Now.ToString("HH:mm:ss:fffff")} SFTPRepository CheckIsPathExist Failed with Error: {exception.Message}");

                isExist.IsSuccess = false;
                isExist.Messages.Add($"SFTPRepository CheckIsPathExist Failed with Error: {exception.Message}");
            }
            finally
            {
                _client.Disconnect();
            }

            return isExist;
        }

        public ListStringResponseModel CreateFileFromStringByPath(string message, string remoteFilePath)
        {
            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} SFTPRepository CreateFileFromStringByPath Called for {remoteFilePath}");

            ListStringResponseModel result = new ListStringResponseModel();

            try
            {
                _client.Connect();
                _logger.LogDebug($"{DateTime.Now.ToString("HH:mm:ss:fffff")} SFTPRepository CreateFileFromStringByPath {remoteFilePath} Connected");

                if (_client.Exists(remoteFilePath))
                {
                    _client.DeleteFile(remoteFilePath);
                    //сначала удаляем, т.к. WriteAllText не перезаписывает файл заново,
                    //а делает типа insert - т.е. перезаписывает поверх имеющегося текста
                    //и новый короткий текст не забивает полностью старый длинный текст
                }

                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                _client.WriteAllText(remoteFilePath, message, Encoding.GetEncoding("windows-1251"));
                
                _logger.LogDebug($"{DateTime.Now.ToString("HH:mm:ss:fffff")} SFTPRepository CreateFileFromStringByPath Finished WriteAllText to file [{remoteFilePath}]");
                result.Messages.Add($"SFTPRepository CreateFileFromStringByPath to file {remoteFilePath} success");
            }
            catch (Exception exception)
            {
                _logger.LogWarning($"{DateTime.Now.ToString("HH:mm:ss:fffff")} SFTPRepository CreateFileFromStringByPath Failed with Error: {exception.Message}");

                result.IsSuccess = false;
                result.Messages.Add($"SFTPRepository CreateFileFromStringByPath Failed with Error: {exception.Message}");
            }
            finally
            {
                _client.Disconnect();
            }

            return result;
        }

        public ListStringResponseModel CreateFolderByPath(string remoteDirPath)
        {
            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} SFTPRepository CreateFolderByPath Called for {remoteDirPath}");

            ListStringResponseModel result = new ListStringResponseModel();

            try
            {
                _client.Connect();
                _logger.LogDebug($"{DateTime.Now.ToString("HH:mm:ss:fffff")} SFTPRepository CreateFolderByPath {remoteDirPath} Connected");

                _client.CreateDirectory(remoteDirPath);
            }
            catch (Exception exception)
            {
                _logger.LogWarning($"{DateTime.Now.ToString("HH:mm:ss:fffff")} SFTPRepository CreateFolderByPath " +
                    $"Failed with Error: { exception.Message}");
                
                result.IsSuccess = false;
                result.Messages.Add($"SFTPRepository CreateFolderByPath Failed with Error: {exception.Message}");
            }
            finally
            {
                _client.Disconnect();
            }

            return result;
        }

        public ListStringResponseModel DeleteFileOrFolderByPath(string remoteDirPath)
        {
            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} SFTPRepository DeleteFolderByPath Called for {remoteDirPath}");

            ListStringResponseModel result = new ListStringResponseModel();

            try
            {
                _client.Connect();
                _logger.LogDebug($"{DateTime.Now.ToString("HH:mm:ss:fffff")} SFTPRepository DeleteFolderByPath {remoteDirPath} Connected");

                DeleteRecursively(_client, remoteDirPath, result);

                result.Messages.Add($"SFTPRepository DeleteFolderByPath {remoteDirPath} Success!");
            }
            catch (Exception exception)
            {
                _logger.LogWarning($"{DateTime.Now.ToString("HH:mm:ss:fffff")} SFTPRepository DeleteFolderByPath" +
                    $" Failed with Error: { exception.Message}");
                
                result.IsSuccess = false;
                result.Messages.Add($"SFTPRepository DeleteFolderByPath Failed with Error: {exception.Message}");
            }
            finally
            {
                _client.Disconnect();
            }

            return result;
        }

        private void DeleteRecursively(SftpClient client, string path, ListStringResponseModel result)
        {
            if (client.GetAttributes(path).IsDirectory)
            {
                foreach (SftpFile file in client.ListDirectory(path))
                {
                    if ((file.Name != ".") && (file.Name != ".."))
                    {
                        if (file.IsDirectory)
                        {
                            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} SFTPRepository DeleteRecursively Called for Folder {path}");
                            DeleteRecursively(client, file.FullName, result);
                        }
                        else
                        {
                            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} SFTPRepository Delete Called for File {file.FullName}");

                            try
                            {
                                client.DeleteFile(file.FullName);
                            }
                            catch (Exception ex)
                            {
                                result.IsSuccess=false;
                                result.Messages.Add($"Delete Failed for File {file.FullName}, Exception: {ex.Message}");
                            }
                        }
                    }
                }

                _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} SFTPRepository Delete Called for Folder {path}");
                
                try
                {
                    client.DeleteDirectory(path);
                }
                catch (Exception ex)
                {
                    result.IsSuccess=false;
                    result.Messages.Add($"Delete Failed for Directory {path}, Exception: {ex.Message}");
                }
            }
            else
            {
                _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} SFTPRepository Delete Called for File {path}");
                try
                {
                    client.DeleteFile(path);
                }
                catch (Exception ex)
                {
                    result.IsSuccess=false;
                    result.Messages.Add($"Delete(2) Failed for File {path}, Exception: {ex.Message}");
                }
            }
        }

        public ListStringResponseModel GetAllFilesAndFolderNamesFromPath(string remoteDirPath, bool getOnlyNames)
        {
            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} SFTPRepository GetAllFilesAndFolderFromPath Called for {remoteDirPath}");

            ListStringResponseModel result = new ListStringResponseModel();

            try
            {
                _client.Connect();
                _logger.LogDebug($"{DateTime.Now.ToString("HH:mm:ss:fffff")} SFTPRepository GetAllFilesAndFolderFromPath {remoteDirPath} Connected");

                List<SftpFile> fileList = _client.ListDirectory(remoteDirPath).ToList();
                foreach (SftpFile file in fileList)
                {
                    if (getOnlyNames)
                    {
                        result.Messages.Add(file.Name);
                    }
                    else
                    {
                        result.Messages.Add(file.FullName);
                    }
                }
            }
            catch (Exception exception)
            {
                _logger.LogWarning($"{DateTime.Now.ToString("HH:mm:ss:fffff")} SFTPRepository GetAllFilesAndFolderFromPath Failed with Error: {exception.Message}");

                result.IsSuccess = false;
                result.Messages.Add($"SFTPRepository GetAllFilesAndFolderFromPath Failed with Error: {exception.Message}");
            }
            finally
            {
                _client.Disconnect();
            }

            return result;
        }

        public ListStringResponseModel GetFileLastWriteTime(string pathOrFileName)
        {
            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} SFTPRepository GetFileLastWriteTime Called for {pathOrFileName}");

            ListStringResponseModel result = new ListStringResponseModel();

            try
            {
                _client.Connect();
                _logger.LogDebug($"{DateTime.Now.ToString("HH:mm:ss:fffff")} SFTPRepository GetFileLastWriteTime {pathOrFileName} Connected");

                result.Messages.Add($"GetLastWriteTime={_client.GetLastWriteTime(pathOrFileName)}");

            }
            catch (Exception exception)
            {
                _logger.LogWarning($"{DateTime.Now.ToString("HH:mm:ss:fffff")} SFTPRepository GetFileLastWriteTime Failed with Error: {exception.Message}");

                result.IsSuccess = false;
                result.Messages.Add($"SFTPRepository GetFileLastWriteTime Failed with Error: {exception.Message}");
            }
            finally
            {
                _client.Disconnect();
            }

            return result;
        }

        public ListStringResponseModel GetFileTextToStringListFromPath(string file)
        {
            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} SFTPRepository GetFileTextToStringListFromPath Called for {file}");

            ListStringResponseModel result = new ListStringResponseModel();

            try
            {
                _client.Connect();
                _logger.LogDebug($"{DateTime.Now.ToString("HH:mm:ss:fffff")} SFTPRepository GetFileTextToStringListFromPath {file} Connected");

                if (!_client.GetAttributes(file).IsDirectory)
                {
                    Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                    result.Messages.AddRange(_client.ReadAllLines(file, Encoding.GetEncoding("windows-1251")));
                }
                else
                {
                    result.IsSuccess = false;
                    result.Messages.Add($"Folder: {file}");
                }

            }
            catch (Exception exception)
            {
                _logger.LogWarning($"{DateTime.Now.ToString("HH:mm:ss:fffff")} SFTPRepository GetFileTextToStringListFromPath " +
                    $"Failed with Error: {exception.Message}");

                result.IsSuccess = false;
                result.Messages.Add($"SFTPRepository GetFileTextToStringListFromPath {file} Failed with Error: {exception.Message}");
            }
            finally
            {
                _client.Disconnect();
            }

            return result;
        }

        public ListStringResponseModel DownloadFileFromSFTP(string localFilePath, string pathSFTP)
        {
            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} SFTPRepository DownloadFileFromSFTP Called " +
                $"from {pathSFTP} to {localFilePath}");

            ListStringResponseModel result = new ListStringResponseModel();

            try
            {
                _client.Connect();
                _logger.LogDebug($"{DateTime.Now.ToString("HH:mm:ss:fffff")} SFTPRepository DownloadFileFromSFTP from {pathSFTP} Connected");

                using FileStream newFile = File.Create(localFilePath);
                _client.DownloadFile(pathSFTP, newFile);
                
                _logger.LogDebug($"{DateTime.Now.ToString("HH:mm:ss:fffff")} Finished downloading file {pathSFTP}");

            }
            catch (Exception exception)
            {
                _logger.LogWarning($"{DateTime.Now.ToString("HH:mm:ss:fffff")} SFTPRepository DownloadFileFromSFTP {pathSFTP} " +
                    $"Failed with Error: {exception.Message}");

                result.IsSuccess = false;
                result.Messages.Add($"SFTPRepository DownloadFileFromSFTP {pathSFTP} Failed with Error: {exception.Message}");
            }
            finally
            {
                _client.Disconnect();
            }

            result.Messages.Add(localFilePath);
            return result;
        }

        public ListStringResponseModel UploadFileToSFTP(string localFilePath, string pathSFTP, bool isOverWrite)
        {
            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} SFTPRepository UploadFileToSFTP Called for {localFilePath}");

            ListStringResponseModel result = new ListStringResponseModel();

            try
            {
                _client.Connect();
                _logger.LogDebug($"{DateTime.Now.ToString("HH:mm:ss:fffff")} SFTPRepository UploadFileToSFTP {localFilePath} Connected");

                using (var uplfileStream = File.OpenRead(localFilePath))
                {
                    _client.UploadFile(uplfileStream, pathSFTP, isOverWrite);
                }

                _logger.LogDebug($"{DateTime.Now.ToString("HH:mm:ss:fffff")} SFTPService UploadFileToSFTP succesfully uploaded file={localFilePath}");

            }
            catch (Exception exception)
            {
                _logger.LogWarning($"{DateTime.Now.ToString("HH:mm:ss:fffff")} SFTPRepository UploadFileToSFTP Failed with Error: {exception.Message}");

                result.IsSuccess = false;
                result.Messages.Add($"SFTPRepository UploadFileToSFTP Failed with Error: {exception.Message}");
            }
            finally
            {
                _client.Disconnect();
            }

            result.Messages.Add(localFilePath);
            return result;
        }

        //public ListStringResponseModel template(string remoteDirPath)
        //{
        //    _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} SFTPRepository GetAllFilesAndFolderFromPath Called for {remoteDirPath}");

        //    ListStringResponseModel result = new ListStringResponseModel();

        //    try
        //    {
        //        _client.Connect();
        //        _logger.LogDebug($"{DateTime.Now.ToString("HH:mm:ss:fffff")} SFTPRepository GetAllFilesAndFolderFromPath {remoteDirPath} Connected");



        //    }
        //    catch (Exception exception)
        //    {
        //        _logger.LogWarning($"{DateTime.Now.ToString("HH:mm:ss:fffff")} SFTPRepository GetAllFilesAndFolderFromPath Failed with Error: {exception.Message}");

        //        result.IsSuccess = false;
        //        result.Messages.Add($"SFTPRepository GetAllFilesAndFolderFromPath Failed with Error: {exception.Message}");
        //    }
        //    finally
        //    {
        //        _client.Disconnect();
        //    }

        //    return result;
        //}
    }
}
