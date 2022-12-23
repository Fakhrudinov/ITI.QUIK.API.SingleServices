using DataAbstraction.Models;
using DataAbstraction.Models.Responses;

namespace DataAbstraction.Interfaces
{
    public interface ISFTPRepository
    {
        BoolResponse CheckIsPathExist(string remoteDirPath);
        ListStringResponseModel GetAllFilesAndFolderNamesFromPath(string remoteDirPath, bool getOnlyNames);
        ListStringResponseModel GetFileTextToStringListFromPath(string file);
        ListStringResponseModel DeleteFileOrFolderByPath(string remoteDirPath);
        ListStringResponseModel CreateFolderByPath(string remoteDirPath);
        ListStringResponseModel CreateFileFromStringByPath(string message, string remoteFilePath);
        ListStringResponseModel GetFileLastWriteTime(string pathOrFileName);
        ListStringResponseModel DownloadFileFromSFTP(string localFilePath, string pathSFTP);
        ListStringResponseModel UploadFileToSFTP(string localFilePath, string pathSFTP, bool v);
    }
}
