﻿using DataAbstraction.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using DataAbstraction.Models.Connections;
using Renci.SshNet;
using Renci.SshNet.Sftp;
using CommonServices;
using DataAbstraction.Models;
using System.Xml;
using System.Text;

namespace QuikSftpService
{
    public class SFTPService : ISFTPService
    {
        private ILogger<SFTPService> _logger;
        private SftpConnectionConfiguration _logon;
        private const string _filesFolder = "Temp";
        
        private const string _codesIniPathSFTP = ".\\dealer\\codes.ini";
        private const string _dealLibIniPathSFTP = ".\\dealer\\DealLib.ini";
        private const string _spbfutLibIniPathSFTP = ".\\dealer\\SpbfutLib.ini";
        private const string _allClientsPathSFTP = ".\\database\\qupdateuser\\Export\\CurrClnts.xml";

        private const string _uploadXmlFilesPathSFTP = ".\\database\\qupdateuser\\In";
        private const string _resultOkXmlFilesPathSFTP = ".\\database\\qupdateuser\\Out";
        private const string _resultErrorXmlFilesPathSFTP = ".\\database\\qupdateuser\\Error";

        private const string _messageToAllPathSFTP = ".\\areas\\msg_all";
        private const string _messageToSinglePathSFTP = ".\\areas\\msg_priv";

        public SFTPService(IOptions<SftpConnectionConfiguration> logon, ILogger<SFTPService> logger)
        {
            _logon = logon.Value;
            _logger = logger;
        }

        public StringResponceModel BlockUserByUID(int uid)
        {
            _logger.LogInformation($"SFTPService BlockUserByUID Called, UID=" + uid);

            FortsCodeAndPubringKeyModel model = new FortsCodeAndPubringKeyModel();
            
            return SetTempatesAndUploadToSFTP(uid.ToString(), model, "BlockUserByUID.xml");            
        }

        public StringResponceModel BlockUserByMatrixClientCode(string code)
        {
            _logger.LogInformation($"SFTPService BlockUserByMatrixClientCode Called, code=" + code);

            //из кода матрицы сделаем код quik
            string quikCode = PortfoliosConvertingService.GetSpotPortfolio(code);

            FortsCodeAndPubringKeyModel model = new FortsCodeAndPubringKeyModel();
            return SetTempatesAndUploadToSFTP(quikCode, model, "BlockUserByClientCode.xml");
        }

        public StringResponceModel BlockUserByFortsClientCode(string code)
        {
            _logger.LogInformation($"SFTPService BlockUserByFortsClientCode Called, code=" + code);

            //из кода матрицы сделаем код quik
            string quikCode = PortfoliosConvertingService.GetFortsQuikCode(code);

            FortsCodeAndPubringKeyModel model = new FortsCodeAndPubringKeyModel();
            return SetTempatesAndUploadToSFTP(quikCode, model, "BlockUserByClientCode.xml");
        }

        public StringResponceModel SetNewPubringKeyByMatrixClientCode(MatrixCodeAndPubringKeyModel model)
        {
            _logger.LogInformation($"SFTPService SetNewPubringKeyByMatrixClientCode Called, code=" + model.ClientCode);

            //из кода матрицы сделаем код quik
            string quikCode = PortfoliosConvertingService.GetSpotPortfolio(model.ClientCode.MatrixClientCode);

            FortsCodeAndPubringKeyModel fortsModel = new FortsCodeAndPubringKeyModel();
            fortsModel.Key = model.Key;

            return SetTempatesAndUploadToSFTP(quikCode, fortsModel, "ReplacePubringKeyByClientCode.xml");
        }

        public StringResponceModel SetNewPubringKeyByFortsClientCode(FortsCodeAndPubringKeyModel model)
        {
            _logger.LogInformation($"SFTPService SetNewPubringKeyByFortsClientCode Called, code=" + model.ClientCode);

            //из кода матрицы сделаем код quik
            string quikCode = PortfoliosConvertingService.GetFortsQuikCode(model.ClientCode.FortsClientCode);
            
            return SetTempatesAndUploadToSFTP(quikCode, model, "ReplacePubringKeyByClientCode.xml");
        }


        public StringResponceModel SendNewClientOptionWorkshop(NewClientOptionWorkShopModel model)
        {
            _logger.LogInformation($"SFTPService SendNewClientOptionWorkshop Called, Client Name={model.Client.FirstName} {model.Client.LastName}");

            StringResponceModel response = new StringResponceModel();

            //Подгрузить в List шаблон PutNewClientOptionWorkshop.xml
            string templateFile = Path.Combine(Directory.GetCurrentDirectory(), "TemplatesXML", "PutNewClientOptionWorkshop.xml");
            if (!File.Exists(templateFile))
            {
                _logger.LogWarning("SFTPService SendNewClientOptionWorkshop Error - Template file not found: " + templateFile);
                response.IsSuccess = false;
                response.Message = "Error - Template file not found: " + templateFile;
                return response;
            }
            List<string> stringsFromFile = GetAllStringsFromFile(templateFile);

            //сформировать List с quik кодами срочного
            //сформировать Comment == BP17116-RF-02,SPBFUT0036K от 20160704, для Option Workshop.
            string comment = "";
            string listRfCodes = "";
            foreach (MatrixToFortsCodesMappingModel pair in model.CodesPairRF)
            {
                listRfCodes = listRfCodes + $"{PortfoliosConvertingService.GetFortsQuikCode(pair.FortsClientCode)},";
                comment = comment + $"{pair.MatrixClientCode} {PortfoliosConvertingService.GetFortsQuikCode(pair.FortsClientCode)}, ";
            }
            comment = comment + "для Option Workshop";

            //заменить в шаблоне данные из модели
            //подставить данные в шаблон
            for (int i = 0; i < stringsFromFile.Count; i++)
            {
                if (stringsFromFile[i].Contains("**FirstName**"))
                {
                    stringsFromFile[i] = stringsFromFile[i].Replace("**FirstName**", model.Client.FirstName);
                }
                if (stringsFromFile[i].Contains("**MiddleName**"))
                {
                    stringsFromFile[i] = stringsFromFile[i].Replace("**MiddleName**", model.Client.MiddleName);
                }
                if (stringsFromFile[i].Contains("**LastName**"))
                {
                    stringsFromFile[i] = stringsFromFile[i].Replace("**LastName**", model.Client.LastName);
                }
                if (stringsFromFile[i].Contains("**Comment**"))
                {
                    stringsFromFile[i] = stringsFromFile[i].Replace("**Comment**", comment);
                }
                if (stringsFromFile[i].Contains("**EMail**"))
                {
                    stringsFromFile[i] = stringsFromFile[i].Replace("**EMail**", model.Client.EMail);
                }

                if (stringsFromFile[i].Contains("**DateNow**"))                                  //format: 2022-05-05
                {
                    stringsFromFile[i] = stringsFromFile[i].Replace("**DateNow**", DateTime.Now.ToString("yyyy-MM-dd"));
                }
                if (stringsFromFile[i].Contains("**ValidTo**"))                                  //format: 2022-05-05
                {
                    stringsFromFile[i] = stringsFromFile[i].Replace("**ValidTo**", DateTime.Now.AddYears(2).ToString("yyyy-MM-dd"));
                }

                if (stringsFromFile[i].Contains("**CodesRF**"))
                {
                    stringsFromFile[i] = stringsFromFile[i].Replace("**CodesRF**", listRfCodes);
                }

                if (stringsFromFile[i].Contains("**Time**"))
                {
                    stringsFromFile[i] = stringsFromFile[i].Replace("**Time**", model.Key.Time.ToString());
                }
                if (stringsFromFile[i].Contains("**KeyID**"))
                {
                    stringsFromFile[i] = stringsFromFile[i].Replace("**KeyID**", model.Key.KeyID);
                }
                if (stringsFromFile[i].Contains("**RSAKey**"))
                {
                    stringsFromFile[i] = stringsFromFile[i].Replace("**RSAKey**", model.Key.RSAKey);
                }

                if (stringsFromFile[i].Contains("**OrgName**"))
                {
                    stringsFromFile[i] = stringsFromFile[i].Replace("**OrgName**", "Клиент");
                }
            }

            //проверить наличие Temp
            string localFilePath = Path.Combine(Directory.GetCurrentDirectory(), _filesFolder);
            FilesManagementService.CheckCreateDirectory(localFilePath);
            //сохранить файл в Temp
            string fileName = CombineNewFileName("PutNewClientOptionWorkshop.xml", model.CodesPairRF[0].MatrixClientCode); 
            string newFilePath = SaveFileToLocalFolder(localFilePath, fileName, stringsFromFile); 
            if (newFilePath.Contains("Error"))
            {
                response.IsSuccess = false;
                response.Message = newFilePath;
                return response;
            }
            //проверить наличие нового файла
            if (!File.Exists(newFilePath))
            {
                _logger.LogWarning("SFTPService SendNewClientOptionWorkshop Error - file with client data not found: " + newFilePath);
                response.IsSuccess = false;
                response.Message = "Error - file with client data not found: " + newFilePath;
                return response;
            }
            //отправить нв сервер SFTP
            string pathSFTP = Path.Combine(_uploadXmlFilesPathSFTP, fileName);
            return UploadFileToSFTP(newFilePath, pathSFTP, true);
        }

        public StringResponceModel SendNewClient(NewClientModel model)
        {
            _logger.LogInformation($"SFTPService SendNewClient Called, Client Name={model.Client.FirstName} {model.Client.LastName}");

            StringResponceModel response = new StringResponceModel();

            //Подгрузить в List шаблон PutNewClientOptionWorkshop.xml
            string templateFile = Path.Combine(Directory.GetCurrentDirectory(), "TemplatesXML", "PutNewClient.xml");
            if (!File.Exists(templateFile))
            {
                _logger.LogWarning("SFTPService SendNewClient Error - Template file not found: " + templateFile);
                response.IsSuccess = false;
                response.Message = "Error - Template file not found: " + templateFile;
                return response;
            }
            List<string> stringsFromFile = GetAllStringsFromFile(templateFile);

            ClientCodesAndCommentModel codesAndComment = SetCodesByMarkets(model);            

            //заменить в шаблоне данные из модели
            //подставить данные в шаблон
            for (int i = 0; i < stringsFromFile.Count; i++)
            {
                if (stringsFromFile[i].Contains("**FirstName**"))
                {
                    stringsFromFile[i] = stringsFromFile[i].Replace("**FirstName**", model.Client.FirstName);
                }
                if (stringsFromFile[i].Contains("**MiddleName**"))
                {
                    stringsFromFile[i] = stringsFromFile[i].Replace("**MiddleName**", model.Client.MiddleName);
                }
                if (stringsFromFile[i].Contains("**LastName**"))
                {
                    stringsFromFile[i] = stringsFromFile[i].Replace("**LastName**", model.Client.LastName);
                }
                if (stringsFromFile[i].Contains("**Comment**"))
                {
                    stringsFromFile[i] = stringsFromFile[i].Replace("**Comment**", codesAndComment.Comment);
                }
                if (stringsFromFile[i].Contains("**EMail**"))
                {
                    stringsFromFile[i] = stringsFromFile[i].Replace("**EMail**", model.Client.EMail);
                }

                if (stringsFromFile[i].Contains("**DateNow**"))                                  //format: 2022-05-05
                {
                    stringsFromFile[i] = stringsFromFile[i].Replace("**DateNow**", DateTime.Now.ToString("yyyy-MM-dd"));
                }
                if (stringsFromFile[i].Contains("**ValidTo**"))                                  //format: 2022-05-05
                {
                    stringsFromFile[i] = stringsFromFile[i].Replace("**ValidTo**", DateTime.Now.AddYears(2).ToString("yyyy-MM-dd"));
                }


                if (stringsFromFile[i].Contains("**DeleteEDP**"))
                {
                    if (model.isEDP)// EDP - delete option classes
                    {
                        stringsFromFile[i] = "";
                    }
                }
                if (stringsFromFile[i].Contains("**DeleteNonEDP**"))
                {
                    if (!model.isEDP)// non EDP - delete RS classes
                    {
                        stringsFromFile[i] = "";
                    }
                }
                if (stringsFromFile[i].Contains("**CodesINSTR**"))
                {
                    string codesINSTR = "";
                    foreach (string code in codesAndComment.CodesUnique)
                    {
                        codesINSTR = codesINSTR +$"{code},";
                    }
                    stringsFromFile[i] = stringsFromFile[i].Replace("**CodesINSTR**", codesINSTR);
                }
                if (stringsFromFile[i].Contains("**FIRM**"))
                {
                    if (model.isEDP)
                    {
                        stringsFromFile[i] = stringsFromFile[i].Replace("**FIRM**", "MC0138200000");
                    }
                    else
                    {
                        stringsFromFile[i] = stringsFromFile[i].Replace("**FIRM**", "SPBFUT");
                    }                    
                }
                if (stringsFromFile[i].Contains("**CodesMS**"))
                {
                    stringsFromFile[i] = stringsFromFile[i].Replace("**CodesMS**", codesAndComment.CodesMS);
                }
                if (stringsFromFile[i].Contains("**CodesCD**"))
                {
                    stringsFromFile[i] = stringsFromFile[i].Replace("**CodesCD**", codesAndComment.CodesCD);
                }
                if (stringsFromFile[i].Contains("**CodesFX**"))
                {
                    stringsFromFile[i] = stringsFromFile[i].Replace("**CodesFX**", codesAndComment.CodesFX);
                }
                if (stringsFromFile[i].Contains("**CodesRS**"))
                {
                    if (codesAndComment.CodesRS.Length < 3)
                    {
                        stringsFromFile[i] = "";
                    }
                    else
                    {
                        stringsFromFile[i] = stringsFromFile[i].Replace("**CodesRS**", codesAndComment.CodesRS);
                    }
                }
                if (stringsFromFile[i].Contains("**CodesRF**"))
                {
                    stringsFromFile[i] = stringsFromFile[i].Replace("**CodesRF**", codesAndComment.CodesRF);
                }



                if (stringsFromFile[i].Contains("**Time**"))
                {
                    stringsFromFile[i] = stringsFromFile[i].Replace("**Time**", model.Key.Time.ToString());
                }
                if (stringsFromFile[i].Contains("**KeyID**"))
                {
                    stringsFromFile[i] = stringsFromFile[i].Replace("**KeyID**", model.Key.KeyID);
                }
                if (stringsFromFile[i].Contains("**RSAKey**"))
                {
                    stringsFromFile[i] = stringsFromFile[i].Replace("**RSAKey**", model.Key.RSAKey);
                }

                if (stringsFromFile[i].Contains("**OrgName**"))
                {
                    stringsFromFile[i] = stringsFromFile[i].Replace("**OrgName**", "Клиент");
                }
            }

            //проверить наличие Temp
            string localFilePath = Path.Combine(Directory.GetCurrentDirectory(), _filesFolder);
            FilesManagementService.CheckCreateDirectory(localFilePath);
            //сохранить файл в Temp
            string fileName = CombineNewFileName("PutNewClient.xml", codesAndComment.CodesUnique[0].Replace("/", ""));
            string newFilePath = SaveFileToLocalFolder(localFilePath, fileName, stringsFromFile);
            if (newFilePath.Contains("Error"))
            {
                response.IsSuccess = false;
                response.Message = newFilePath;
                return response;
            }
            //проверить наличие нового файла
            if (!File.Exists(newFilePath))
            {
                _logger.LogWarning("SFTPService SendNewClient Error - file with client data not found: " + newFilePath);
                response.IsSuccess = false;
                response.Message = "Error - file with client data not found: " + newFilePath;
                return response;
            }
            //отправить нв сервер SFTP
            string pathSFTP = Path.Combine(_uploadXmlFilesPathSFTP, fileName);
            return UploadFileToSFTP(newFilePath, pathSFTP, true);
        }

        private ClientCodesAndCommentModel SetCodesByMarkets(NewClientModel model)
        {
            ClientCodesAndCommentModel result = new ClientCodesAndCommentModel();

            if (model.CodesMatrix is not null)
            {
                foreach (MatrixClientCodeModel code in model.CodesMatrix)
                {
                    string quikCode = "";
                    if (code.MatrixClientCode.Contains("MS"))
                    {
                        quikCode = PortfoliosConvertingService.GetSpotPortfolio(code.MatrixClientCode);
                        result.CodesMS = result.CodesMS + $"{quikCode},";
                    }
                    if (code.MatrixClientCode.Contains("FX"))
                    {
                        quikCode = PortfoliosConvertingService.GetSpotPortfolio(code.MatrixClientCode);
                        result.CodesFX = result.CodesFX +$"{quikCode},";
                    }
                    if (code.MatrixClientCode.Contains("RS"))
                    {
                        quikCode = PortfoliosConvertingService.GetSpotPortfolio(code.MatrixClientCode);
                        result.CodesRS = result.CodesRS + $"{quikCode},";
                    }
                    if (code.MatrixClientCode.Contains("CD"))
                    {
                        quikCode = PortfoliosConvertingService.GetCdPortfolio(code.MatrixClientCode);
                        result.CodesCD = result.CodesCD + $"{quikCode},";
                    }

                    if (!result.CodesUnique.Contains(quikCode))
                    {
                        result.CodesUnique.Add(quikCode);
                        result.Comment = result.Comment + $"{quikCode},";
                    }
                }
            }


            if (model.CodesPairRF is not null)
            {
                foreach (MatrixToFortsCodesMappingModel pair in model.CodesPairRF)
                {
                    string quikCode = PortfoliosConvertingService.GetFortsQuikCode(pair.FortsClientCode);
                    result.CodesRF = result.CodesRF + $"{quikCode},";


                    if (!result.CodesUnique.Contains(quikCode))
                    {
                        result.CodesUnique.Add(quikCode);
                        result.Comment = result.Comment + $"{quikCode},";
                    }
                }
            }

            if (model.isEDP)
            {
                result.Comment = result.Comment + " (Клиент = ЕДП EDP)";
            }

            return result;
        }

        private StringResponceModel SetTempatesAndUploadToSFTP(string code, FortsCodeAndPubringKeyModel model, string temlateFileName)
        {
            StringResponceModel response = new StringResponceModel();

            //все строки из шаблона в список
            string templateFile = Path.Combine(Directory.GetCurrentDirectory(), "TemplatesXML", temlateFileName);
            if (!File.Exists(templateFile))
            {
                _logger.LogWarning("SFTPService BlockUserByCode Error - Template file not found: " + templateFile);
                response.IsSuccess = false;
                response.Message = "Error - Template file not found: " + templateFile;
                return response;
            }
            List<string> stringsFromFile = GetAllStringsFromFile(templateFile);

            //подставить данные в шаблон
            for (int i = 0; i < stringsFromFile.Count; i++)
            {
                if (stringsFromFile[i].Contains("**QuikClientCode**"))
                {
                    stringsFromFile[i] = stringsFromFile[i].Replace("**QuikClientCode**", code);
                }

                if (stringsFromFile[i].Contains("**UID**"))
                {
                    stringsFromFile[i] = stringsFromFile[i].Replace("**UID**", code);
                }

                if (stringsFromFile[i].Contains("**DateNow**"))                                  //format: 2022-05-05
                {
                    stringsFromFile[i] = stringsFromFile[i].Replace("**DateNow**", DateTime.Now.ToString("yyyy-MM-dd"));
                }

                if (stringsFromFile[i].Contains("**Time**"))                                  
                {
                    stringsFromFile[i] = stringsFromFile[i].Replace("**Time**", model.Key.Time.ToString());
                }

                if (stringsFromFile[i].Contains("**KeyID**"))
                {
                    stringsFromFile[i] = stringsFromFile[i].Replace("**KeyID**", model.Key.KeyID);
                }

                if (stringsFromFile[i].Contains("**RSAKey**"))
                {
                    stringsFromFile[i] = stringsFromFile[i].Replace("**RSAKey**", model.Key.RSAKey);
                }
            }

            //собрать имя нового файла
            string fileName = CombineNewFileName(temlateFileName, code.Replace("/", ""));

            //запишем в новый файл
            string newFilePath = SaveFileToLocalFolder(_filesFolder, fileName, stringsFromFile);
            if (newFilePath.Contains("Error"))
            {
                response.IsSuccess = false;
                response.Message = newFilePath;
                return response;
            }

            //отправить нв сервер SFTP
            string pathSFTP = Path.Combine(_uploadXmlFilesPathSFTP, fileName);
            return UploadFileToSFTP(newFilePath, pathSFTP, true);
        }

        public StringResponceModel BackUpFileCodesIni()
        {
            //codes.ini
            _logger.LogInformation($"SFTPService BackUpFileCodesIni Called");

            string localFilePath = GetSetLocalDownloadPath("codes");

            return DownloadFileFromSFTP(localFilePath, _codesIniPathSFTP);
        }

        public StringResponceModel BackUpFileDealLibIni()
        {
            //DealLib.ini
            _logger.LogInformation($"SFTPService BackUpFileDealLibIni Called");

            string localFilePath = GetSetLocalDownloadPath("DealLib");

            return DownloadFileFromSFTP(localFilePath, _dealLibIniPathSFTP);
        }

        public StringResponceModel BackUpFileSpbfutlibIni()
        {
            //spbfutlib.ini
            //SpbfutLib.ini
            _logger.LogInformation($"SFTPService BackUpFileSpbfutlibIni Called");

            string localFilePath = GetSetLocalDownloadPath("SpbfutLib");

            return DownloadFileFromSFTP(localFilePath, _spbfutLibIniPathSFTP);
        }

        public StringResponceModel DownloadAllClients()
        {
            _logger.LogInformation($"SFTPService DownloadAllClients Called");

            string localFilePath = Path.Combine(Directory.GetCurrentDirectory(), _filesFolder);
            FilesManagementService.CheckCreateDirectory(localFilePath);
            localFilePath = Path.Combine(localFilePath, "CurrClnts.xml");

            return DownloadFileFromSFTP(localFilePath, _allClientsPathSFTP);
        }

        public StringResponceModel AddMAtrixCodesToFileCodesIni(CodesArrayModel model)
        {
            _logger.LogInformation($"SFTPService AddMAtrixCodesToFileCodesIni Called");

            StringResponceModel response = new StringResponceModel();

            // разделим коды по спискам
            List<string> codesMoMsFxCd = new List<string>();
            List<string> codesRs = new List<string>();

            foreach (MatrixClientCodeModel code in model.ClientCodes)
            {
                if (code.MatrixClientCode.Contains("-RS-"))
                {
                    string codeForCodesIni = GenerateRSClientCodeStringForCodesIni(PortfoliosConvertingService.GetSpotPortfolio(code.MatrixClientCode));
                    codesRs.Add(codeForCodesIni);
                }
                else if (code.MatrixClientCode.Contains("-CD-"))
                {
                    string codeForCodesIni = GenerateCDClientCodeStringForCodesIni(PortfoliosConvertingService.GetCdPortfolio(code.MatrixClientCode));
                    codesMoMsFxCd.Add(codeForCodesIni);
                }
                else
                {
                    string codeForCodesIni = GenerateClientCodeStringForCodesIni(PortfoliosConvertingService.GetSpotPortfolio(code.MatrixClientCode));
                    codesMoMsFxCd.Add(codeForCodesIni);
                }
            }

            //скачаем файл codes.ini
            string localFilePath = Path.Combine(Directory.GetCurrentDirectory(), _filesFolder);
            FilesManagementService.CheckCreateDirectory(localFilePath);

            string fileName = "codes" + FilesManagementService.GetCurrentDateTimeString() + ".ini";
            localFilePath = Path.Combine(localFilePath, fileName);

            var downloadResult = DownloadFileFromSFTP(localFilePath, _codesIniPathSFTP);

            if (downloadResult.Message.Contains("Error"))
            {
                _logger.LogWarning(downloadResult.Message);

                response.IsSuccess = false;
                response.Message = downloadResult.Message;
                return response;
            }
            if (!File.Exists(downloadResult.Message))
            {
                _logger.LogWarning("SFTPService AddMAtrixCodesToFileCodesIni Error - Downloaded file not found: " + downloadResult.Message);

                response.IsSuccess = false;
                response.Message = "Error - Downloaded file not found: " + downloadResult.Message;
                return response;
            }

            //все строки из файла в список
            List<string> stringsFromFile = GetAllStringsFromFile(downloadResult.Message);

            //добавим новые строки в список - сначала EQTV - оно ниже в файле
            if (codesMoMsFxCd.Count > 0)
            {
                int indexEQTV = FindIndexinArrayByText(stringsFromFile, "[EQTV]");

                string codes = "";
                foreach(string code in codesMoMsFxCd)
                {
                    codes = codes + code;
                }

                stringsFromFile[indexEQTV + 3] = codes + stringsFromFile[indexEQTV + 3];
            }
            //добавим новые строки в список - теперь RS счета 
            if (codesRs.Count > 0)
            {
                int indexSPBEX = FindIndexinArrayByText(stringsFromFile, "[SPBEX]");

                string codes = "";
                foreach (string code in codesRs)
                {
                    codes = codes + code;
                }

                stringsFromFile[indexSPBEX + 3] = codes + stringsFromFile[indexSPBEX + 3];
            }

            //собрать имя нового файла
            fileName = CombineNewFileName(fileName, "new");

            //запишем в новый файл
            string newFilePath = SaveFileToLocalFolder(_filesFolder, fileName, stringsFromFile);
            if (newFilePath.Contains("Error"))
            {
                response.IsSuccess = false;
                response.Message = newFilePath;
                return response;
            }

            //отправим файл на SFTP
            return UploadFileToSFTP(newFilePath, _codesIniPathSFTP, true);
        }

        public StringResponceModel RequestFileAllClients()
        {
            _logger.LogInformation($"SFTPService GetAllClients Called");

            StringResponceModel response = new StringResponceModel();

            //все строки из шаблона в список
            string templateFile = Path.Combine(Directory.GetCurrentDirectory(), "TemplatesXML", "GetAllClients.xml");
            if (!File.Exists(templateFile))
            {
                _logger.LogWarning("SFTPService GetAllClients Error - Template file not found: " + templateFile);
                response.IsSuccess = false;
                response.Message = "Error - Template file not found: " + templateFile;
                return response;
            }

            //скопируем файл запроса с новым именем для отслеживания выполнения
            string localFilePath = Path.Combine(Directory.GetCurrentDirectory(), _filesFolder);
            FilesManagementService.CheckCreateDirectory(localFilePath);
            //вставим в имя файла дату/время
            string newTemplateFile = CombineNewFileName("GetAllClients.xml", FilesManagementService.GetCurrentDateTimeString());
            //получим путь - куда копировать.
            localFilePath = Path.Combine(localFilePath, newTemplateFile);
            //Скопировать с новым именем
            File.Copy(templateFile, localFilePath);
            if (!File.Exists(localFilePath))
            {
                _logger.LogWarning("SFTPService GetAllClients Error - Renamed Template file not found: " + localFilePath);
                response.IsSuccess = false;
                response.Message = "Error - Renamed Template file not found: " + localFilePath;
                return response;
            }
            string pathSFTP = Path.Combine(_uploadXmlFilesPathSFTP, newTemplateFile);
            return UploadFileToSFTP(localFilePath, pathSFTP, true);
        }

        public StringResponceModel CheckConnections()
        {
            _logger.LogInformation($"SFTPService CheckConnections Called");

            StringResponceModel response = new StringResponceModel();

            string result = "";
            List<string> filesAtSFTP = GetFilesArrayFromPathSFTP(".");
            if (filesAtSFTP.Count >= 2)
            {
                foreach (string file in filesAtSFTP)
                {
                    result = result + file + " / ";
                }
            }
            else
            {
                response.IsSuccess = false;
                response.Message = filesAtSFTP[0];
                return response;
            }           

            response.Message = "OK, dirs = " + result;
            return response;
        }

        public StringResponceModel GetResultOfXMLFileUpload(string file)
        {
            _logger.LogInformation($"SFTPService GetResultOfXMLFileUpload Called " + file);
            StringResponceModel response = new StringResponceModel();

            //взять только имя файла
            if (file.Contains('/'))
            {
                file = file.Substring(file.LastIndexOf('/') + 1);
            }
            if (file.Contains('\\'))
            {
                file = file.Substring(file.LastIndexOf('\\') + 1);
            }

            //из папки In - не выполнялось
            List<string> filesAtSFTP = GetFilesArrayFromPathSFTP(_uploadXmlFilesPathSFTP);
            if (filesAtSFTP.Count >= 2) // 2 это '.' и '..'
            {
                if (filesAtSFTP.Count > 2)//пробуем найти
                {
                    for(int i = 2; i < filesAtSFTP.Count; i++)
                    {
                        if (filesAtSFTP[i].Equals(file))
                        {
                            response.Message = $"Файл {file} еще не обработан. Повторите запрос позже.";
                            return response;
                        }
                    }
                }
            }
            else
            {
                return GetFilesArrayFromPathSFTPError(filesAtSFTP[0]);
            }

            //из папки Out - исполнено
            filesAtSFTP = GetFilesArrayFromPathSFTP(_resultOkXmlFilesPathSFTP);
            if (filesAtSFTP.Count >= 2) // 2 это '.' и '..'
            {
                if (filesAtSFTP.Count > 2)//пробуем найти
                {
                    for (int i = 2; i < filesAtSFTP.Count; i++)
                    {
                        if (filesAtSFTP[i].Equals(file))
                        {
                            string textFromXML = GetResultTextFromXmlSFTP(_resultOkXmlFilesPathSFTP, file);

                            response.Message = $"Файл {file} обработан и исполнен. {textFromXML}";
                            return response;
                        }
                    }
                }
            }
            else
            {
                return GetFilesArrayFromPathSFTPError(filesAtSFTP[0]);
            }

            //из папки Error - ошибка при выполнении
            filesAtSFTP = GetFilesArrayFromPathSFTP(_resultErrorXmlFilesPathSFTP);
            if (filesAtSFTP.Count >= 2) // 2 это '.' и '..'
            {
                if (filesAtSFTP.Count > 2)//пробуем найти
                {
                    for (int i = 2; i < filesAtSFTP.Count; i++)
                    {
                        if (filesAtSFTP[i].Equals(file))
                        {
                            string textFromXML = GetResultTextFromXmlSFTP(_resultErrorXmlFilesPathSFTP, file);

                            response.Message = $"Внимание! Файл {file} {textFromXML}";
                            return response;
                        }
                    }
                }
            }
            else
            {
                return GetFilesArrayFromPathSFTPError(filesAtSFTP[0]);
            }

            // нигде не найдено
            response.IsSuccess = false;
            response.Message =  $"Файл {file} нигде не найден.";
            return response;
        }

        private string GetResultTextFromXmlSFTP(string folderSourceSFTP, string fileName)
        {
            //формируем имена файлов
            string pathSFTP = folderSourceSFTP + "/" + fileName;//Path.Combine(folderSourceSFTP, fileName);
            string localFilePath = Path.Combine(Directory.GetCurrentDirectory(), _filesFolder);
            FilesManagementService.CheckCreateDirectory(localFilePath);

            fileName = CombineNewFileName(fileName, "result");
            localFilePath = Path.Combine(localFilePath, fileName);

            //скачиваем 
            var downloadedFilePath = DownloadFileFromSFTP(localFilePath, pathSFTP);

            if (downloadedFilePath.Message.Contains("Error"))
            {
                return downloadedFilePath.Message;
            }

            //открываем XML
            string text = GetTextFromXml(downloadedFilePath.Message);
            return text;
        }

        private string GetTextFromXml(string filePath)
        {
            XmlDocument xmlConfig = new XmlDocument();
            XmlNamespaceManager nsmanager = new XmlNamespaceManager(xmlConfig.NameTable);
            nsmanager.AddNamespace("qx", "urn:quik:user-rights-import");
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            xmlConfig.Load(filePath);

            XmlNode nodeResult = xmlConfig.SelectSingleNode("//qx:Result", nsmanager);

            /*
            <Result Status="ERROR" ProcessTime="2022-04-26T08:16:18">
                <ErrorMsg> File[BlockUserByClientCode_BP56646.xml]. Command[UpdateUser]. Error on: [UpdateUser. User=0] Error description: [not specified userID.]</ErrorMsg>
            </Result>
            или 
            <Result Status="OK" UID="148" ProcessTime="2022-04-26T08:20:22"/>
            */

            string result = "";

            foreach (XmlAttribute attr in nodeResult.Attributes)
            {
                result = result + $" {attr.Name}={attr.Value}";
            }

            foreach (XmlNode node in nodeResult.ChildNodes)
            {
                result = result + $", {node.InnerText}";
            }

            return result;
        }

        private StringResponceModel GetFilesArrayFromPathSFTPError(string errorText)
        {
            StringResponceModel response = new StringResponceModel();
            response.IsSuccess = false;
            response.Message = errorText;
            return response;
        }

        private List<string> GetFilesArrayFromPathSFTP(string uploadXmlFilesPathSFTP)
        {
            List<SftpFile> fileList;
            List<string> result = new List<string>();

            using var client = new SftpClient(_logon.Host, _logon.Port, _logon.Login, _logon.Password);
            try
            {
                client.Connect();
                fileList = client.ListDirectory(uploadXmlFilesPathSFTP).ToList();
            }
            catch (Exception exception)
            {
                _logger.LogWarning($"SFTP Read catalog {uploadXmlFilesPathSFTP} Failed with Error: {exception.Message}");

                result.Add($"SFTP Read catalog {uploadXmlFilesPathSFTP} Failed with Error: {exception.Message}");
                return result;
            }
            finally
            {
                client.Disconnect();
            }

            foreach (SftpFile file in fileList)
            {
                result.Add(file.Name);
            }
            return result;
        }

        private string CombineNewFileName(string fileName, string suffix)
        {
            int dotIndex = fileName.LastIndexOf('.');
            return fileName.Substring(0, dotIndex) + "_" + suffix + fileName.Substring(dotIndex);
        }

        private string SaveFileToLocalFolder(string localFolder, string fileName, List<string> fileSource)
        {
            //сначала проверить наличие папки
            string localFilePath = Path.Combine(Directory.GetCurrentDirectory(), localFolder);
            FilesManagementService.CheckCreateDirectory(localFilePath);

            string newFileName = Path.Combine(localFilePath, fileName);

            //записать файл
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            File.WriteAllLines(newFileName, fileSource, Encoding.GetEncoding("windows-1251"));

            if (!File.Exists(newFileName))
            {
                _logger.LogWarning("SFTPService Error - New file not found: " + newFileName);
                return "Error - New file not found: " + newFileName;
            }
            FileInfo fi = new FileInfo(newFileName);
            if (fi.Length < 300)
            {
                _logger.LogWarning($"SFTPService Error - New file size({fi.Length}) is too small: " + newFileName);
                return $"Error - New file size({fi.Length}) is too small: " + newFileName;
            }

            return newFileName;
        }
        private List<string> GetAllStringsFromFile(string filePath)
        {
            List<string> strings = new List<string>();
            using (StreamReader sr = new StreamReader(filePath, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    strings.Add(line);
                }
            }

            return strings;
        }

        private StringResponceModel UploadFileToSFTP(string fileToUploadPath, string sftpPath, bool isOverWrite)
        {
            StringResponceModel response = new StringResponceModel();

            using var client = new SftpClient(_logon.Host, _logon.Port, _logon.Login, _logon.Password);
            try
            {
                client.Connect();

                using (var uplfileStream = File.OpenRead(fileToUploadPath))
                {
                    client.UploadFile(uplfileStream, sftpPath, isOverWrite);
                }

                _logger.LogInformation($"SFTPService succesfully uploaded file={fileToUploadPath}");
            }
            catch (Exception exception)
            {
                _logger.LogWarning("SFTP Upload Failed with Error: " + exception.Message);

                response.IsSuccess = false;
                response.Message = "SFTPService Upload Failed with Error: " + exception.Message;
                return response;
            }
            finally
            {
                client.Disconnect();
            }

            response.Message = fileToUploadPath;
            return response;
        }
        private StringResponceModel DownloadFileFromSFTP(string localFilePath, string remoteFilePath)
        {
            _logger.LogInformation($"SFTPService DownloadFileFromSFTP Called from {remoteFilePath} to {localFilePath}");

            StringResponceModel response = new StringResponceModel();

            using var client = new SftpClient(_logon.Host, _logon.Port, _logon.Login, _logon.Password);
            try
            {
                client.Connect();

                using var newFile = File.Create(localFilePath);
                client.DownloadFile(remoteFilePath, newFile);
                _logger.LogInformation($"Finished downloading file [{remoteFilePath}]");
            }
            catch (Exception exception)
            {
                _logger.LogWarning("SFTP BackUpFileCodesIni Download File Failed with Error: " + exception.Message);

                response.IsSuccess = false;
                response.Message = "SFTP Download File Failed with Error: " + exception.Message;
                return response;
            }
            finally
            {
                client.Disconnect();
            }

            response.Message = localFilePath;
            return response;
        }

        private int FindIndexinArrayByText(List<string> list, string searchTerm)
        {
            return list.FindIndex(s =>
                string.Equals(s, searchTerm, StringComparison.CurrentCultureIgnoreCase));
        }

        private string GenerateClientCodeStringForCodesIni(string code)
        {
            // template: BP68585/01=BP68585/01#
            return code + "=" + code + "#\r\n";
        }
        private string GenerateCDClientCodeStringForCodesIni(string code)
        {
            // template: BP68585/D01=BP68585/BP68585D01#
            var splittedCode = code.Split("/");
            return code + "=" + splittedCode[0] + "/" + splittedCode[0] + splittedCode[1] + "#\r\n";
        }
        private string GenerateRSClientCodeStringForCodesIni(string code)
        {
            // template: BP19195/01=BP19195/BP19195/01#
            var splittedCode = code.Split("/");
            return code + "=" + splittedCode[0] + "/" + code + "#\r\n";
        }
        private string GetSetLocalDownloadPath(string name)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), _filesFolder);
            FilesManagementService.CheckCreateDirectory(path);
            path = Path.Combine(path, name + FilesManagementService.GetCurrentDateTimeString() + ".ini");

            return path;
        }

    }
}