using DataAbstraction.Interfaces;
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

        public ListStringResponseModel DeleteStartMessageForUID(int uid)
        {
            _logger.LogInformation($"SFTPService DeleteStartMessage/ForUID/{uid} Called");

            return DeleteStartMessage(uid, false);
        }

        public ListStringResponseModel GetStartMessageforAll()
        {
            _logger.LogInformation($"SFTPService GetStartMessage/forAll Called");

            return GetStartMessage(0, true);
        }
        public ListStringResponseModel GetStartMessageforUID(int uid)
        {
            _logger.LogInformation($"SFTPService GetStartMessage/forUID Called");

            return GetStartMessage(uid, false);
        }

        private ListStringResponseModel GetStartMessage(int uid, bool forAll)
        {
            ListStringResponseModel response = new ListStringResponseModel();

            //путь SFTP            
            string remoteDirPath = Path.Combine(_messageToSinglePathSFTP, uid.ToString());
            if (forAll)
            {
                remoteDirPath = _messageToAllPathSFTP;
            }

            //получаем
            using var client = new SftpClient(_logon.Host, _logon.Port, _logon.Login, _logon.Password);
            try
            {
                client.Connect();

                if (!forAll)
                {
                    if (!client.Exists(remoteDirPath))
                    {
                        _logger.LogWarning($"SFTP GetStartMessage/forUID/{uid} Failed: Message not found by path {remoteDirPath}");

                        response.IsSuccess = false;
                        response.Messages.Add($"SFTP GetStartMessage/forUID/{uid} Failed: Message not found by path {remoteDirPath}");
                        return response;
                    }
                }

                List<SftpFile> fileList = client.ListDirectory(remoteDirPath).ToList();
                foreach (SftpFile file in fileList)
                {
                    if (!file.IsDirectory)
                    {
                        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                        response.Messages.Add(client.ReadAllText(file.FullName, Encoding.GetEncoding("windows-1251")));
                    }
                }

                if (response.Messages is null)
                {
                    response.IsSuccess = false;
                    response.Messages.Add($"SFTP GetStartMessage /forAll/{forAll} {uid} Failed: Message not found");
                    return response;
                }
            }
            catch (Exception exception)
            {
                _logger.LogWarning($"SFTP GetStartMessage/forAll/{forAll} {uid} Failed with Error: {exception.Message}");

                response.IsSuccess = false;
                response.Messages.Add($"SFTP GetStartMessage/forAll/{forAll} {uid} Failed with Error: {exception.Message}");
                return response;
            }
            finally
            {
                client.Disconnect();
            }

            return response;
        }

        public ListStringResponseModel DeleteStartMessageForAll()
        {
            _logger.LogInformation($"SFTPService DeleteStartMessage/ForAll Called");

            return DeleteStartMessage(1, true);
        }

        private ListStringResponseModel DeleteStartMessage(int uid, bool forAll)
        {
            ListStringResponseModel response = new ListStringResponseModel();

            //путь SFTP            
            string remoteDirPath = Path.Combine(_messageToSinglePathSFTP, uid.ToString());            
            if (forAll)
            {
                remoteDirPath = _messageToAllPathSFTP;
            }
 
            //удаляем 
            using var client = new SftpClient(_logon.Host, _logon.Port, _logon.Login, _logon.Password);
            try
            {
                client.Connect();

                List<SftpFile> fileList = client.ListDirectory(remoteDirPath).ToList();
                foreach (SftpFile file in fileList)
                {
                    if (!file.IsDirectory)
                    {
                        client.DeleteFile(file.FullName);
                    }
                }

                if (!forAll)
                {
                    if (client.Exists(remoteDirPath))
                    {
                        client.DeleteDirectory(remoteDirPath);
                    }
                    else
                    {
                        _logger.LogWarning($"SFTP DeleteStartMessage/{forAll} {uid} Failed: Dir not found by path {remoteDirPath}");

                        response.IsSuccess = false;
                        response.Messages.Add($"SFTP DeleteStartMessage/forAll/{forAll} {uid} Failed: Dir not found by path {remoteDirPath}");
                        return response;
                    }
                }

            }
            catch (Exception exception)
            {
                _logger.LogWarning($"SFTP DeleteStartMessage/forAll/{forAll} {uid} Failed with Error: {exception.Message}");

                response.IsSuccess = false;
                response.Messages.Add($"SFTP DeleteStartMessage/forAll/{forAll} {uid} Failed with Error: {exception.Message}");
                return response;
            }
            finally
            {
                client.Disconnect();
            }

            response.Messages.Add($"SFTP DeleteStartMessage success");
            return response;
        }

        public ListStringResponseModel SetStartMessage(StartMessageModel model)
        {
            _logger.LogInformation($"SFTPService SetStartMessageToSingleUID Called, ToAll={model.ToAll} UID={model.UID}");
            ListStringResponseModel response = new ListStringResponseModel();

            //путь SFTP            
            string remoteDirPath = Path.Combine(_messageToSinglePathSFTP, model.UID.ToString());
            if (model.ToAll)
            {
                remoteDirPath = _messageToAllPathSFTP;
            }
            string remoteFilePath = Path.Combine(remoteDirPath, "message.txt");

            //отправляем файл
            using var client = new SftpClient(_logon.Host, _logon.Port, _logon.Login, _logon.Password);
            try
            {
                client.Connect();

                if (!client.Exists(remoteDirPath))
                {
                    client.CreateDirectory(remoteDirPath);
                }

                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                client.WriteAllText(remoteFilePath, model.Message, Encoding.GetEncoding("windows-1251"));
                _logger.LogInformation($"Finished WriteAllText to file [{remoteFilePath}]");
            }
            catch (Exception exception)
            {
                _logger.LogWarning("SFTP WriteAllText to file Failed with Error: " + exception.Message);

                response.IsSuccess = false;
                response.Messages.Add("SFTP WriteAllText to file Failed with Error: " + exception.Message);
                return response;
            }
            finally
            {
                client.Disconnect();
            }

            response.Messages.Add($"SFTP WriteAllText to file {remoteFilePath} success");
            return response;
        }

        public ListStringResponseModel GetUIDByMatrixCode(string code)
        {
            _logger.LogInformation($"SFTPService GetUIDByMatrixCode Called, code=" + code);

            //из кода матрицы сделаем код quik
            string quikCode = PortfoliosConvertingService.GetQuikSpotPortfolio(code);

            return GetUIDFromCurrClnts(quikCode);
        }

        public ListStringResponseModel GetUIDByFortsCode(string code)
        {
            _logger.LogInformation($"SFTPService GetUIDByFortsCode Called, code=" + code);

            //из кода матрицы сделаем код quik
            string quikCode = PortfoliosConvertingService.GetQuikFortsCode(code);

            return GetUIDFromCurrClnts(quikCode);
        }

        private ListStringResponseModel GetUIDFromCurrClnts(string quikCode)
        {
            ListStringResponseModel response = new ListStringResponseModel();
            //сначала проверить что файл есть
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), _filesFolder, "CurrClnts.xml");
            if (!File.Exists(filePath))
            {
                _logger.LogWarning("SFTPService GetUIDFromCurrClnts Error - file not found: " + filePath);
                response.IsSuccess = false;
                response.Messages.Add("Error - file not found: " + filePath);
                return response;
            }

            //открыть файл
            XmlDocument xmlConfig = new XmlDocument();
            XmlNamespaceManager nsmanager = new XmlNamespaceManager(xmlConfig.NameTable);
            nsmanager.AddNamespace("qx", "urn:quik:user-rights-import");
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            xmlConfig.Load(filePath);
            
            XmlNodeList nodeSearchResult = xmlConfig.SelectNodes("//qx:Classes[contains(@ClientCodes,'" + quikCode + "')]", nsmanager);
            if (nodeSearchResult.Count > 0)
            {
                List<XmlNode> nodeResult = new List<XmlNode>();

                foreach (XmlNode node in nodeSearchResult)
                {
                    response.IsSuccess = true;
                    if (node.ParentNode is not null)
                    {
                        if (!nodeResult.Contains(node.ParentNode))
                        {
                            nodeResult.Add(node.ParentNode);
                        }
                    }                    
                }

                foreach (XmlNode node in nodeResult)
                {
                    response.Messages.Add(node.OuterXml);
                }
            }
            else
            {
                response.IsSuccess = false;
                response.Messages.Add("Code not found at file " + filePath);
            }
            return response;
        }

        public ListStringResponseModel SetAllTradesByMatrixClientCode(MatrixClientCodeModel model)
        {
            _logger.LogInformation($"SFTPService SetAllTradesByMatrixClientCode Called, code=" + model.MatrixClientCode);

            //из кода матрицы сделаем код quik
            string quikCode = PortfoliosConvertingService.GetQuikSpotPortfolio(model.MatrixClientCode);

            return SetAllTradesByQuikCode(quikCode);
        }
        public ListStringResponseModel SetAllTradesByFortsClientCode(FortsClientCodeModel model)
        {
            _logger.LogInformation($"SFTPService SetAllTradesByFortsClientCode Called, code=" + model.FortsClientCode);

            //из кода матрицы сделаем код quik
            string quikCode = PortfoliosConvertingService.GetQuikFortsCode(model.FortsClientCode);

            return SetAllTradesByQuikCode(quikCode);
        }
        private ListStringResponseModel SetAllTradesByQuikCode(string quikCode)
        {
            ListStringResponseModel response = new ListStringResponseModel();
            //сначала проверить что файл CurrClnts есть
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), _filesFolder, "CurrClnts.xml");
            if (!File.Exists(filePath))
            {
                _logger.LogWarning("SFTPService SetAllTradesByQuikCode Error - file not found: " + filePath);
                response.IsSuccess = false;
                response.Messages.Add("Error - file not found: " + filePath);
                return response;
            }

            //сначала проверить что файл шаблона есть
            string filePathTempl = Path.Combine(Directory.GetCurrentDirectory(), "TemplatesXML", "UpdateClientSetAllTradesByClientCode.xml");
            if (!File.Exists(filePathTempl))
            {
                _logger.LogWarning("SFTPService SetAllTradesByQuikCode Error - Template file not found: " + filePathTempl);
                response.IsSuccess = false;
                response.Messages.Add("Error - Template file not found: " + filePathTempl);
                return response;
            }

            //открыть файл CurrClnts
            XmlDocument xmlDoc = new XmlDocument();
            XmlNamespaceManager nsmanager = new XmlNamespaceManager(xmlDoc.NameTable);
            nsmanager.AddNamespace("qx", "urn:quik:user-rights-import");
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            xmlDoc.Load(filePath);

            XmlNodeList nodeSearchResult = xmlDoc.SelectNodes("//qx:Classes[contains(@ClientCodes,'" + quikCode + "')]", nsmanager);
            List<XmlNode> nodeResult = new List<XmlNode>();

            //получим уникальные ноды
            if (nodeSearchResult.Count > 0)
            {
                foreach (XmlNode node in nodeSearchResult)
                {
                    if (node.ParentNode is not null)
                    {
                        if (!nodeResult.Contains(node.ParentNode))
                        {
                            nodeResult.Add(node.ParentNode);
                        }
                    }
                }
            }
            else
            {
                response.IsSuccess = false;
                response.Messages.Add("Code not found at file " + filePath);
                return response;
            }

            if (nodeResult.Count != 1)
            {
                response.IsSuccess = false;
                response.Messages.Add($"Error: Can't process request - user codes {quikCode} finded in many UID:");

                foreach (XmlNode node in nodeResult)
                {
                    response.Messages.Add(node.OuterXml);
                }               
                
                return response;
            }

            // Подгрузить в List строки из шаблона
            List<string> stringsFromFile = GetAllStringsFromFile(filePathTempl);

            //сформировать строку с классами
            string classes = "";
            XmlAttribute attr = xmlDoc.CreateAttribute("UpdateMode");
            attr.Value = "replace";
            foreach (XmlNode node in nodeResult[0])
            {
                if (node.Name.Equals("Classes"))
                {
                    node.Attributes.Append(attr);
                    node.Attributes["Rights"].Value = node.Attributes["Rights"].Value.Replace("c", "");

                    // xmlns="urn:quik:user-rights-import"
                    classes = classes + node.OuterXml.Replace(" xmlns=\"urn:quik:user-rights-import\"", "") + "\r\n";
                }
            }

            //подставить данные в шаблон
            for (int i = 0; i < stringsFromFile.Count; i++)
            {
                if (stringsFromFile[i].Contains("**QuikClientCode**"))
                {
                    stringsFromFile[i] = stringsFromFile[i].Replace("**QuikClientCode**", quikCode);
                }

                if (stringsFromFile[i].Contains("**Classes**"))
                {
                    stringsFromFile[i] = stringsFromFile[i].Replace("**Classes**", classes);
                }
            }

            //проверить наличие Temp
            string localFilePath = Path.Combine(Directory.GetCurrentDirectory(), _filesFolder);
            FilesManagementService.CheckCreateDirectory(localFilePath);
            //сохранить файл в Temp
            string fileName = CombineNewFileName("UpdateClientSetAllTradesByClientCode.xml", quikCode.Replace("/", ""));
            string newFilePath = SaveFileToLocalFolder(localFilePath, fileName, stringsFromFile);
            if (newFilePath.Contains("Error"))
            {
                response.IsSuccess = false;
                response.Messages.Add(newFilePath);
                return response;
            }
            //проверить наличие нового файла
            if (!File.Exists(newFilePath))
            {
                _logger.LogWarning("SFTPService SendNewClientOptionWorkshop Error - file with client data not found: " + newFilePath);
                response.IsSuccess = false;
                response.Messages.Add("Error - file with client data not found: " + newFilePath);
                return response;
            }

            //отправить нв сервер SFTP
            string pathSFTP = Path.Combine(_uploadXmlFilesPathSFTP, fileName);
            return UploadFileToSFTP(newFilePath, pathSFTP, true);
        }

        public ListStringResponseModel BlockUserByUID(int uid)
        {
            _logger.LogInformation($"SFTPService BlockUserByUID Called, UID=" + uid);

            FortsCodeAndPubringKeyModel model = new FortsCodeAndPubringKeyModel();
            
            return SetTempatesAndUploadToSFTP(uid.ToString(), model, "BlockUserByUID.xml");            
        }

        public ListStringResponseModel BlockUserByMatrixClientCode(string code)
        {
            _logger.LogInformation($"SFTPService BlockUserByMatrixClientCode Called, code=" + code);

            //из кода матрицы сделаем код quik
            string quikCode = PortfoliosConvertingService.GetQuikSpotPortfolio(code);

            FortsCodeAndPubringKeyModel model = new FortsCodeAndPubringKeyModel();
            return SetTempatesAndUploadToSFTP(quikCode, model, "BlockUserByClientCode.xml");
        }

        public ListStringResponseModel BlockUserByFortsClientCode(string code)
        {
            _logger.LogInformation($"SFTPService BlockUserByFortsClientCode Called, code=" + code);

            //из кода матрицы сделаем код quik
            string quikCode = PortfoliosConvertingService.GetQuikFortsCode(code);

            FortsCodeAndPubringKeyModel model = new FortsCodeAndPubringKeyModel();
            return SetTempatesAndUploadToSFTP(quikCode, model, "BlockUserByClientCode.xml");
        }

        public ListStringResponseModel SetNewPubringKeyByMatrixClientCode(MatrixCodeAndPubringKeyModel model)
        {
            _logger.LogInformation($"SFTPService SetNewPubringKeyByMatrixClientCode Called, code=" + model.ClientCode);

            //из кода матрицы сделаем код quik
            string quikCode = PortfoliosConvertingService.GetQuikSpotPortfolio(model.ClientCode.MatrixClientCode);

            FortsCodeAndPubringKeyModel fortsModel = new FortsCodeAndPubringKeyModel();
            fortsModel.Key = model.Key;

            return SetTempatesAndUploadToSFTP(quikCode, fortsModel, "ReplacePubringKeyByClientCode.xml");
        }

        public ListStringResponseModel SetNewPubringKeyByFortsClientCode(FortsCodeAndPubringKeyModel model)
        {
            _logger.LogInformation($"SFTPService SetNewPubringKeyByFortsClientCode Called, code=" + model.ClientCode);

            //из кода матрицы сделаем код quik
            string quikCode = PortfoliosConvertingService.GetQuikFortsCode(model.ClientCode.FortsClientCode);
            
            return SetTempatesAndUploadToSFTP(quikCode, model, "ReplacePubringKeyByClientCode.xml");
        }


        public ListStringResponseModel SendNewClientOptionWorkshop(NewClientOptionWorkShopModel model)
        {
            _logger.LogInformation($"SFTPService SendNewClientOptionWorkshop Called, Client Name={model.Client.FirstName} {model.Client.LastName}");

            ListStringResponseModel response = new ListStringResponseModel();

            //Подгрузить в List шаблон PutNewClientOptionWorkshop.xml
            string templateFile = Path.Combine(Directory.GetCurrentDirectory(), "TemplatesXML", "PutNewClientOptionWorkshop.xml");
            if (!File.Exists(templateFile))
            {
                _logger.LogWarning("SFTPService SendNewClientOptionWorkshop Error - Template file not found: " + templateFile);
                response.IsSuccess = false;
                response.Messages.Add("Error - Template file not found: " + templateFile);
                return response;
            }
            List<string> stringsFromFile = GetAllStringsFromFile(templateFile);

            //сформировать List с quik кодами срочного
            //сформировать Comment == BP17116-RF-02,SPBFUT0036K от 20160704, для Option Workshop.
            string comment = "";
            string listRfCodes = "";
            foreach (MatrixToFortsCodesMappingModel pair in model.CodesPairRF)
            {
                listRfCodes = listRfCodes + $"{PortfoliosConvertingService.GetQuikFortsCode(pair.FortsClientCode)},";
                comment = comment + $"{pair.MatrixClientCode} {PortfoliosConvertingService.GetQuikFortsCode(pair.FortsClientCode)}, ";
            }
            comment = comment + "для Option Workshop";

            //подставить данные в шаблон
            for (int i = 0; i < stringsFromFile.Count; i++)
            {
                if (stringsFromFile[i].Contains("**Comment**"))
                {
                    stringsFromFile[i] = stringsFromFile[i].Replace("**Comment**", comment);
                }

                if (stringsFromFile[i].Contains("**CodesRF**"))
                {
                    stringsFromFile[i] = stringsFromFile[i].Replace("**CodesRF**", listRfCodes);
                }

                stringsFromFile[i] = SetClientData(model.Client, stringsFromFile[i]);
                stringsFromFile[i] = SetPubringKeyData(model.Key, stringsFromFile[i]);
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
                response.Messages.Add(newFilePath);
                return response;
            }
            //проверить наличие нового файла
            if (!File.Exists(newFilePath))
            {
                _logger.LogWarning("SFTPService SendNewClientOptionWorkshop Error - file with client data not found: " + newFilePath);
                response.IsSuccess = false;
                response.Messages.Add("Error - file with client data not found: " + newFilePath);
                return response;
            }
            //отправить нв сервер SFTP
            string pathSFTP = Path.Combine(_uploadXmlFilesPathSFTP, fileName);
            return UploadFileToSFTP(newFilePath, pathSFTP, true);
        }

        public ListStringResponseModel SendNewClient(NewClientModel model)
        {
            _logger.LogInformation($"SFTPService SendNewClient Called, Client Name={model.Client.FirstName} {model.Client.LastName}");

            ListStringResponseModel response = new ListStringResponseModel();

            //Подгрузить в List шаблон PutNewClientOptionWorkshop.xml
            string templateFile = Path.Combine(Directory.GetCurrentDirectory(), "TemplatesXML", "PutNewClient.xml");
            if (!File.Exists(templateFile))
            {
                _logger.LogWarning("SFTPService SendNewClient Error - Template file not found: " + templateFile);
                response.IsSuccess = false;
                response.Messages.Add("Error - Template file not found: " + templateFile);
                return response;
            }
            List<string> stringsFromFile = GetAllStringsFromFile(templateFile);

            ClientCodesAndCommentModel codesAndComment = SetCodesByMarkets(model);            

            //подставить данные в шаблон
            for (int i = 0; i < stringsFromFile.Count; i++)
            {
                stringsFromFile[i] = SetClientData(model.Client, stringsFromFile[i]);

                if (stringsFromFile[i].Contains("**Comment**"))
                {
                    stringsFromFile[i] = stringsFromFile[i].Replace("**Comment**", codesAndComment.Comment);
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


                stringsFromFile[i] = SetPubringKeyData(model.Key, stringsFromFile[i]);
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
                response.Messages.Add(newFilePath);
                return response;
            }
            //проверить наличие нового файла
            if (!File.Exists(newFilePath))
            {
                _logger.LogWarning("SFTPService SendNewClient Error - file with client data not found: " + newFilePath);
                response.IsSuccess = false;
                response.Messages.Add("Error - file with client data not found: " + newFilePath);
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
                        quikCode = PortfoliosConvertingService.GetQuikSpotPortfolio(code.MatrixClientCode);
                        result.CodesMS = result.CodesMS + $"{quikCode},";
                    }
                    if (code.MatrixClientCode.Contains("FX"))
                    {
                        quikCode = PortfoliosConvertingService.GetQuikSpotPortfolio(code.MatrixClientCode);
                        result.CodesFX = result.CodesFX +$"{quikCode},";
                    }
                    if (code.MatrixClientCode.Contains("RS"))
                    {
                        quikCode = PortfoliosConvertingService.GetQuikSpotPortfolio(code.MatrixClientCode);
                        result.CodesRS = result.CodesRS + $"{quikCode},";
                    }
                    if (code.MatrixClientCode.Contains("CD"))
                    {
                        quikCode = PortfoliosConvertingService.GetQuikCdPortfolio(code.MatrixClientCode);
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
                    string quikCode = PortfoliosConvertingService.GetQuikFortsCode(pair.FortsClientCode);
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

        private ListStringResponseModel SetTempatesAndUploadToSFTP(string code, FortsCodeAndPubringKeyModel model, string temlateFileName)
        {
            ListStringResponseModel response = new ListStringResponseModel();

            //все строки из шаблона в список
            string templateFile = Path.Combine(Directory.GetCurrentDirectory(), "TemplatesXML", temlateFileName);
            if (!File.Exists(templateFile))
            {
                _logger.LogWarning("SFTPService BlockUserByCode Error - Template file not found: " + templateFile);
                response.IsSuccess = false;
                response.Messages.Add("Error - Template file not found: " + templateFile);
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

                stringsFromFile[i] = SetPubringKeyData(model.Key, stringsFromFile[i]);
            }

            //собрать имя нового файла
            string fileName = CombineNewFileName(temlateFileName, code.Replace("/", ""));

            //запишем в новый файл
            string newFilePath = SaveFileToLocalFolder(_filesFolder, fileName, stringsFromFile);
            if (newFilePath.Contains("Error"))
            {
                response.IsSuccess = false;
                response.Messages.Add(newFilePath);
                return response;
            }

            //отправить нв сервер SFTP
            string pathSFTP = Path.Combine(_uploadXmlFilesPathSFTP, fileName);
            return UploadFileToSFTP(newFilePath, pathSFTP, true);
        }

        public ListStringResponseModel BackUpFileCodesIni()
        {
            //codes.ini
            _logger.LogInformation($"SFTPService BackUpFileCodesIni Called");

            string localFilePath = GetSetLocalDownloadPath("codes");

            return DownloadFileFromSFTP(localFilePath, _codesIniPathSFTP);
        }

        public ListStringResponseModel BackUpFileDealLibIni()
        {
            //DealLib.ini
            _logger.LogInformation($"SFTPService BackUpFileDealLibIni Called");

            string localFilePath = GetSetLocalDownloadPath("DealLib");

            return DownloadFileFromSFTP(localFilePath, _dealLibIniPathSFTP);
        }

        public ListStringResponseModel BackUpFileSpbfutlibIni()
        {
            //spbfutlib.ini
            //SpbfutLib.ini
            _logger.LogInformation($"SFTPService BackUpFileSpbfutlibIni Called");

            string localFilePath = GetSetLocalDownloadPath("SpbfutLib");

            return DownloadFileFromSFTP(localFilePath, _spbfutLibIniPathSFTP);
        }

        public ListStringResponseModel DownloadCurrClnts()
        {
            _logger.LogInformation($"SFTPService DownloadAllClients Called");

            string localFilePath = Path.Combine(Directory.GetCurrentDirectory(), _filesFolder);
            FilesManagementService.CheckCreateDirectory(localFilePath);
            localFilePath = Path.Combine(localFilePath, "CurrClnts.xml");

            return DownloadFileFromSFTP(localFilePath, _allClientsPathSFTP);
        }

        public ListStringResponseModel AddMAtrixCodesToFileCodesIni(CodesArrayModel model)
        {
            _logger.LogInformation($"SFTPService AddMAtrixCodesToFileCodesIni Called");

            ListStringResponseModel response = new ListStringResponseModel();

            // разделим коды по спискам
            List<string> codesMoMsFxCd = new List<string>();
            List<string> codesRs = new List<string>();

            foreach (MatrixClientCodeModel code in model.ClientCodes)
            {
                if (code.MatrixClientCode.Contains("-RS-"))
                {
                    string codeForCodesIni = GenerateRSClientCodeStringForCodesIni(PortfoliosConvertingService.GetQuikSpotPortfolio(code.MatrixClientCode));
                    codesRs.Add(codeForCodesIni);
                }
                else if (code.MatrixClientCode.Contains("-CD-"))
                {
                    string codeForCodesIni = GenerateCDClientCodeStringForCodesIni(PortfoliosConvertingService.GetQuikCdPortfolio(code.MatrixClientCode));
                    codesMoMsFxCd.Add(codeForCodesIni);
                }
                else
                {
                    string codeForCodesIni = GenerateClientCodeStringForCodesIni(PortfoliosConvertingService.GetQuikSpotPortfolio(code.MatrixClientCode));
                    codesMoMsFxCd.Add(codeForCodesIni);
                }
            }

            //скачаем файл codes.ini
            string localFilePath = Path.Combine(Directory.GetCurrentDirectory(), _filesFolder);
            FilesManagementService.CheckCreateDirectory(localFilePath);

            string fileName = "codes" + FilesManagementService.GetCurrentDateTimeString() + ".ini";
            localFilePath = Path.Combine(localFilePath, fileName);

            var downloadResult = DownloadFileFromSFTP(localFilePath, _codesIniPathSFTP);

            if (downloadResult.Messages.Contains("Error"))
            {
                _logger.LogWarning(downloadResult.Messages[0]);

                response.IsSuccess = false;
                return response;
            }
            if (!File.Exists(downloadResult.Messages[0]))
            {
                _logger.LogWarning("SFTPService AddMAtrixCodesToFileCodesIni Error - Downloaded file not found: " + downloadResult.Messages[0]);

                response.IsSuccess = false;
                response.Messages.Add("Error - Downloaded file not found: " + downloadResult.Messages[0]);
                return response;
            }

            //все строки из файла в список
            List<string> stringsFromFile = GetAllStringsFromFile(downloadResult.Messages[0]);

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
                response.Messages.Add(newFilePath);
                return response;
            }

            //отправим файл на SFTP
            return UploadFileToSFTP(newFilePath, _codesIniPathSFTP, true);
        }

        public ListStringResponseModel RequestFileCurrClnts()
        {
            _logger.LogInformation($"SFTPService GetAllClients Called");

            ListStringResponseModel response = new ListStringResponseModel();

            //все строки из шаблона в список
            string templateFile = Path.Combine(Directory.GetCurrentDirectory(), "TemplatesXML", "GetAllClients.xml");
            if (!File.Exists(templateFile))
            {
                _logger.LogWarning("SFTPService GetAllClients Error - Template file not found: " + templateFile);
                response.IsSuccess = false;
                response.Messages.Add("Error - Template file not found: " + templateFile);
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
                response.Messages.Add("Error - Renamed Template file not found: " + localFilePath);
                return response;
            }
            string pathSFTP = Path.Combine(_uploadXmlFilesPathSFTP, newTemplateFile);
            return UploadFileToSFTP(localFilePath, pathSFTP, true);
        }

        public ListStringResponseModel CheckConnections()
        {
            _logger.LogInformation($"SFTPService CheckConnections Called");

            ListStringResponseModel response = new ListStringResponseModel();

            List<string> filesAtSFTP = GetFilesArrayFromPathSFTP(".");
            if (filesAtSFTP.Count >= 2)
            {
                foreach (string file in filesAtSFTP)
                {
                    response.Messages.Add(file);
                }
            }
            else
            {
                response.IsSuccess = false;
                response.Messages.Add(filesAtSFTP[0]);
                return response;
            }           

            return response;
        }

        public ListStringResponseModel GetResultOfXMLFileUpload(string file)
        {
            _logger.LogInformation($"SFTPService GetResultOfXMLFileUpload Called " + file);
            ListStringResponseModel response = new ListStringResponseModel();

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
                            response.Messages.Add($"Файл {file} еще не обработан. Повторите запрос позже.");
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

                            response.Messages.Add($"Файл {file} обработан и исполнен. {textFromXML}");
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

                            response.Messages.Add($"Внимание! Файл {file} {textFromXML}");
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
            response.Messages.Add($"Файл {file} нигде не найден.");
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

            if (downloadedFilePath.Messages.Contains("Error"))
            {
                return downloadedFilePath.Messages[0];
            }

            //открываем XML
            string text = GetTextFromXml(downloadedFilePath.Messages[0]);
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
             * possible xml:
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

        private ListStringResponseModel GetFilesArrayFromPathSFTPError(string errorText)
        {
            ListStringResponseModel response = new ListStringResponseModel();
            response.IsSuccess = false;
            response.Messages.Add(errorText);
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

        private ListStringResponseModel UploadFileToSFTP(string fileToUploadPath, string sftpPath, bool isOverWrite)
        {
            ListStringResponseModel response = new ListStringResponseModel();

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
                response.Messages.Add("SFTPService Upload Failed with Error: " + exception.Message);
                return response;
            }
            finally
            {
                client.Disconnect();
            }

            response.Messages.Add(fileToUploadPath);
            return response;
        }
        private ListStringResponseModel DownloadFileFromSFTP(string localFilePath, string remoteFilePath)
        {
            _logger.LogInformation($"SFTPService DownloadFileFromSFTP Called from {remoteFilePath} to {localFilePath}");

            ListStringResponseModel response = new ListStringResponseModel();

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
                response.Messages.Add("SFTP Download File Failed with Error: " + exception.Message);
                return response;
            }
            finally
            {
                client.Disconnect();
            }

            response.Messages.Add(localFilePath);
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

        private string SetPubringKeyData(PubringKeyModel key, string incomingString)
        {

            if (incomingString.Contains("**Time**"))
            {
                incomingString = incomingString.Replace("**Time**", key.Time.ToString());
            }
            if (incomingString.Contains("**KeyID**"))
            {
                incomingString = incomingString.Replace("**KeyID**", key.KeyID);
            }
            if (incomingString.Contains("**RSAKey**"))
            {
                incomingString = incomingString.Replace("**RSAKey**", key.RSAKey);
            }

            if (incomingString.Contains("**OrgName**"))
            {
                incomingString = incomingString.Replace("**OrgName**", "Клиент");
            }

            return incomingString;
        }
        private string SetClientData(ClientInformationModel client, string incomingString)
        {
            if (incomingString.Contains("**FirstName**"))
            {
                incomingString = incomingString.Replace("**FirstName**", client.FirstName);
            }
            if (incomingString.Contains("**MiddleName**"))
            {
                incomingString = incomingString.Replace("**MiddleName**", client.MiddleName);
            }
            if (incomingString.Contains("**LastName**"))
            {
                incomingString = incomingString.Replace("**LastName**", client.LastName);
            }
            if (incomingString.Contains("**EMail**"))
            {
                incomingString = incomingString.Replace("**EMail**", client.EMail);
            }

            if (incomingString.Contains("**DateNow**"))
            {
                incomingString = incomingString.Replace("**DateNow**", DateTime.Now.ToString("yyyy-MM-dd"));
            }
            if (incomingString.Contains("**ValidTo**"))
            {
                incomingString = incomingString.Replace("**ValidTo**", DateTime.Now.AddYears(2).ToString("yyyy-MM-dd"));
            }

            return incomingString;
        }
    }
}