using DataAbstraction.Interfaces;
using DataAbstraction.Models;
using DataAbstraction.Models.Connections;
using DataAbstraction.Models.DataBaseModels;
using DataAbstraction.Models.Responses;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Data.SqlClient;

namespace QuikDataBaseRepository
{
    public class QuikDBRepository : IQuikDataBaseRepository
    {
        private ILogger<QuikDBRepository> _logger;
        private DataBaseConnectionConfiguration _connection;

        //check connection requests
        //private const string _checkClientAccounts =     "SELECT COUNT(*) FROM ClientAccounts;";
        //private const string _checkClientInfo = "SELECT COUNT(*) FROM ClientInfo;";
        //private const string _checkContracts = "SELECT COUNT(*) FROM Contracts;";
        //private const string _checkDepoClientAccounts = "SELECT COUNT(*) FROM DepoClientAccounts;";

        //private const string _selectClientAccounts = "SELECT ClientID, Account, SubAccount FROM ClientAccounts t";
        //private const string _selectClientInfo = "SELECT ClientCode, FullName, EMail, ClientType, Resident, Address FROM ClientInfo t";
        //private const string _selectContracts = "SELECT ClientID, Number, RegisterDate, Type, Manager FROM Contracts t";
        //private const string _selectDepoClientAccounts = "SELECT ClientID,AccountNumber,Manager,Owner,Depositary,ContractNo,ContractDate FROM DepoClientAccounts t";

        //private const string _insertClientAccounts = "INSERT INTO ClientAccounts (ClientID, Account, SubAccount) " +
        //                                                                " VALUES (@ClientID, @Account, @SubAccount);";
        //private const string _insertClientInfo = "INSERT INTO ClientInfo (ClientCode, FullName, EMail, ClientType, Resident, Address) " +
        //                                                        " VALUES (@ClientCode, @FullName, @EMail, @ClientType, @Resident, @Address);";
        //private const string _insertContracts = "INSERT INTO Contracts (ClientID, Number, RegisterDate, Type, Manager) " +
        //                                                        "VALUES (@ClientID, @Number, @RegisterDate, @Type, @Manager);";
        //private const string _insertDepoClientAccounts = "INSERT INTO DepoClientAccounts (ClientID,AccountNumber,Manager,Owner,Depositary,ContractNo,ContractDate) " +
        //                                                                        "VALUES (@ClientID,@AccountNumber,@Manager,@Owner,@Depositary,@ContractNo,@ContractDate);";

        public QuikDBRepository(IOptions<DataBaseConnectionConfiguration> connection, ILogger<QuikDBRepository> logger)
        {
            _connection = connection.Value;
            _logger = logger;
        }
        /*
                ClientAccounts
        1;BP39362/01;BP39362-MS-01;
        1;SPBFUT00KIM;BP39362-RF-01;
        BP21195/D01	BP21195-CD-01	
        SELECT* FROM[Instructions].[dbo].[ClientAccounts] t where t.Account like 'BP16297-RF%'
        INSERT INTO[Instructions].[dbo].[ClientAccounts] VALUES('SPBFUT002Tf', 'BP16297-RF-06', '');

                ClientInfo
        1;BP39523/01;Подцатов Эдуард Сергеевич;e.podtsatov@yandex.ru;P;R;РФ, 344022, Ростовская обл, г Ростов-на-Дону, ул Максима Горького, д 259,
        1;SPBFUT00KN9;Подцатов Эдуард Сергеевич;e.podtsatov@yandex.ru;P;R;РФ, 344022, Ростовская обл, г Ростов-на-Дону, ул Максима Горького, д 259,
        BP17178/D01	Еланцев Дмитрий Валерьевич	elancev@me.com	P	N	A35E3P1, Респ. Казахстан, г. Алматы, ул. Баймагамбетова, д. 206
        SELECT* FROM[Instructions].[dbo].[ClientInfo] t where t.ClientCode in ('SPBFUT00MK6','SPBFUT002Tf','SPBFUT002Te','SPBFUT002Tg');
        INSERT INTO[Instructions].[dbo].[ClientInfo] VALUES('SPBFUT002Tf', 'Тихомиров Андрей Александрович', '4444879@mail.ru', 'P', 'R', 'РФ, 192288, г. Санкт-Петербург, ул. Бухарестская, д. 124/56, кв. 335');

                Contracts
        1;BP39362/01;Дог.BP39362;20191218;0
        1;SPBFUT00KIM;Дог.BP39362;20191218;0
        BC20333/D01	Дог. BC20333	20180425	0	NULL
        SELECT* FROM[Instructions].[dbo].[Contracts] t where t.Number like 'Дог.BP16297%'
        INSERT INTO[Instructions].[dbo].[Contracts] VALUES('SPBFUT002Tg', 'Дог.BP16297', '20160112', '0', '');

                DepoClientAccounts
        1;BP39362/01;L01+00000F00;ITinvest;Воронин Р. В.;НДЦ;Дог.BP39362;20191218
        1;SPBFUT00KIM;L01+00000F00;ITinvest;Воронин Р. В.;НДЦ;Дог.BP39362;20191218
        BC20333/D01	L01+00000F00	ITinvest	«Ренесорс Капитал»	НДЦ	Дог. BC20333	20180425
        SELECT* FROM[Instructions].[dbo].[DepoClientAccounts] t where t.ContractNo like 'Дог.BP16297%'
        INSERT INTO[Instructions].[dbo].[DepoClientAccounts] VALUES('SPBFUT002Tf', 'L01+00000F00','ITinvest','Тихомиров А. А.','НДЦ','Дог.BP16297', '20160112');
        */


        public async Task<ListStringResponseModel> CheckConnections()
        {
            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} QuikDBRepository CheckConnections Called");

            ListStringResponseModel response = new ListStringResponseModel();

            string filePathCheckClientAccounts = Path.Combine(Directory.GetCurrentDirectory(), "SqlQuerys", "queryCheckClientAccounts.sql");
            if (!File.Exists(filePathCheckClientAccounts))
            {
                _logger.LogWarning($"{DateTime.Now.ToString("HH:mm:ss:fffff")} Error! File with SQL script not found at {filePathCheckClientAccounts}");

                response.IsSuccess = false;
                response.Messages.Add("Error! File with SQL script not found at " + filePathCheckClientAccounts);
                return response;
            }
            string queryCheckClientAccounts = File.ReadAllText(filePathCheckClientAccounts);

            string filePathCheckClientInfo = Path.Combine(Directory.GetCurrentDirectory(), "SqlQuerys", "queryCheckClientInfo.sql");
            if (!File.Exists(filePathCheckClientInfo))
            {
                _logger.LogWarning($"{DateTime.Now.ToString("HH:mm:ss:fffff")} Error! File with SQL script not found at {filePathCheckClientInfo}");

                response.IsSuccess = false;
                response.Messages.Add("Error! File with SQL script not found at " + filePathCheckClientInfo);
                return response;
            }
            string queryCheckClientInfo = File.ReadAllText(filePathCheckClientInfo);

            string filePathCheckContracts = Path.Combine(Directory.GetCurrentDirectory(), "SqlQuerys", "queryCheckContracts.sql");
            if (!File.Exists(filePathCheckContracts))
            {
                _logger.LogWarning($"{DateTime.Now.ToString("HH:mm:ss:fffff")} Error! File with SQL script not found at {filePathCheckContracts}");

                response.IsSuccess = false;
                response.Messages.Add("Error! File with SQL script not found at " + filePathCheckContracts);
                return response;
            }
            string queryCheckContracts = File.ReadAllText(filePathCheckContracts);

            string filePathCheckDepoClientAccounts = Path.Combine(Directory.GetCurrentDirectory(), "SqlQuerys", "queryCheckDepoClientAccounts.sql");
            if (!File.Exists(filePathCheckDepoClientAccounts))
            {
                _logger.LogWarning($"{DateTime.Now.ToString("HH:mm:ss:fffff")} Error! File with SQL script not found at {filePathCheckDepoClientAccounts}");

                response.IsSuccess = false;
                response.Messages.Add("Error! File with SQL script not found at " + filePathCheckDepoClientAccounts);
                return response;
            }
            string queryCheckDepoClientAccounts = File.ReadAllText(filePathCheckDepoClientAccounts);

            try
            {
                using (SqlConnection connect = new SqlConnection(_connection.ConnectionString))
                {
                    await connect.OpenAsync();

                    using (SqlCommand command = new SqlCommand(queryCheckClientAccounts, connect))
                    {
                        response.Messages.Add("Records in ClientAccounts table = " + (int)await command.ExecuteScalarAsync());
                    }
                    using (SqlCommand command = new SqlCommand(queryCheckClientInfo, connect))
                    {
                        response.Messages.Add("Records in ClientInfo table = " + (int)await command.ExecuteScalarAsync());
                    }
                    using (SqlCommand command = new SqlCommand(queryCheckContracts, connect))
                    {
                        response.Messages.Add("Records in Contracts table = " + (int)await command.ExecuteScalarAsync());
                    }
                    using (SqlCommand command = new SqlCommand(queryCheckDepoClientAccounts, connect))
                    {
                        response.Messages.Add("Records in DepoClientAccounts table = " + (int)await command.ExecuteScalarAsync());
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"{DateTime.Now.ToString("HH:mm:ss:fffff")} QuikDBRepository CheckConnections Failed, Exception: " + ex.Message);

                response.IsSuccess = false;
                response.Messages.Add("Exception at DataBase: " + ex.Message);
                return response;
            }

            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} QuikDBRepository CheckConnections Success");
            return response;
        }

        public async Task<DataBaseClientCodesResponse> GetRegisteredCodes(IEnumerable<string> codes)
        {
            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} QuikDBRepository GetRegisteredCodes Called");

            string codesAtRequest = GetCodesString(GetUniqueCodes(codes));

            //string suffixClientID = $" where t.ClientID in ({codesAtRequest});";
            //string suffixClientCode = $" where t.ClientCode in ({codesAtRequest});";

            DataBaseClientCodesResponse response = new DataBaseClientCodesResponse();


            //SelectClientAccounts
            string filePathClientAccounts = Path.Combine(Directory.GetCurrentDirectory(), "SqlQuerys", "querySelectClientAccounts.sql");
            if (!File.Exists(filePathClientAccounts))
            {
                _logger.LogWarning($"{DateTime.Now.ToString("HH:mm:ss:fffff")} Error! File with SQL script not found at {filePathClientAccounts}");

                response.IsSuccess = false;
                response.Messages.Add("Error! File with SQL script not found at " + filePathClientAccounts);
                return response;
            }
            string queryClientAccounts = File.ReadAllText(filePathClientAccounts);

            try
            {
                using (SqlConnection connect = new SqlConnection(_connection.ConnectionString))
                {
                    await connect.OpenAsync();

                    queryClientAccounts = queryClientAccounts.Replace("@UniqueCodes", codesAtRequest);

                    using (SqlCommand command = new SqlCommand(queryClientAccounts, connect))
                    {
                        SqlDataReader reader = await command.ExecuteReaderAsync();
                        while (await reader.ReadAsync())
                        {
                            ClientAccountsModel newModel = new ClientAccountsModel();

                            int indexClientID = reader.GetOrdinal("ClientID");
                            int indexAccount = reader.GetOrdinal("Account");
                            int indexSubAccount = reader.GetOrdinal("SubAccount");

                            newModel.ClientID = reader.GetString(indexClientID);
                            newModel.Account = reader.GetString(indexAccount);
                            newModel.SubAccount = reader.GetString(indexSubAccount);

                            response.ClientAccounts.Add(newModel);
                        }
                        await reader.CloseAsync();
                    }


                    //SelectClientInfo
                    string filePathSelectClientInfo = Path.Combine(Directory.GetCurrentDirectory(), "SqlQuerys", "querySelectClientInfo.sql");
                    if (!File.Exists(filePathSelectClientInfo))
                    {
                        _logger.LogWarning($"{DateTime.Now.ToString("HH:mm:ss:fffff")} Error! File with SQL script not found at {filePathSelectClientInfo}");

                        response.IsSuccess = false;
                        response.Messages.Add("Error! File with SQL script not found at " + filePathSelectClientInfo);
                        return response;
                    }
                    string querySelectClientInfo = File.ReadAllText(filePathSelectClientInfo);

                    querySelectClientInfo = querySelectClientInfo.Replace("@UniqueCodes", codesAtRequest);

                    using (SqlCommand command = new SqlCommand(querySelectClientInfo, connect))
                    {
                        SqlDataReader reader = await command.ExecuteReaderAsync();
                        while (await reader.ReadAsync())
                        {
                            ClientInfoModel newModel= new ClientInfoModel();

                            int indexClientCode = reader.GetOrdinal("ClientCode");
                            int indexFullName = reader.GetOrdinal("FullName");
                            int indexEMail = reader.GetOrdinal("EMail");
                            int indexClientType = reader.GetOrdinal("ClientType");
                            int indexResident = reader.GetOrdinal("Resident");
                            int indexAddress = reader.GetOrdinal("Address");

                            newModel.ClientCode = reader.GetString(indexClientCode);
                            newModel.FullName = reader.IsDBNull(indexFullName) ? null : reader.GetString(indexFullName);
                            newModel.EMail = reader.IsDBNull(indexEMail) ? null : reader.GetString(indexEMail);
                            newModel.ClientType = reader.GetString(indexClientType);
                            newModel.Resident = reader.GetString(indexResident);
                            newModel.Address = reader.IsDBNull(indexAddress) ? null : reader.GetString(indexAddress);

                            response.ClientInfo.Add(newModel);
                        }
                        await reader.CloseAsync();
                    }

                    //SelectContracts
                    string filePathSelectContracts = Path.Combine(Directory.GetCurrentDirectory(), "SqlQuerys", "querySelectContracts.sql");
                    if (!File.Exists(filePathSelectContracts))
                    {
                        _logger.LogWarning($"{DateTime.Now.ToString("HH:mm:ss:fffff")} Error! File with SQL script not found at {filePathSelectContracts}");

                        response.IsSuccess = false;
                        response.Messages.Add("Error! File with SQL script not found at " + filePathSelectContracts);
                        return response;
                    }
                    string querySelectContracts = File.ReadAllText(filePathSelectContracts);

                    querySelectContracts = querySelectContracts.Replace("@UniqueCodes", codesAtRequest);

                    using (SqlCommand command = new SqlCommand(querySelectContracts, connect))
                    {
                        SqlDataReader reader = await command.ExecuteReaderAsync();
                        while (await reader.ReadAsync())
                        {
                            ContractsModel newModel = new ContractsModel();

                            int indexClientID = reader.GetOrdinal("ClientID");
                            int indexNumber = reader.GetOrdinal("Number");
                            int indexRegisterDate = reader.GetOrdinal("RegisterDate");
                            int indexType = reader.GetOrdinal("Type");
                            int indexManager = reader.GetOrdinal("Manager");

                            newModel.ClientID = reader.GetString(indexClientID);
                            newModel.Number = reader.GetString(indexNumber);
                            newModel.RegisterDate = reader.GetInt32(indexRegisterDate);
                            newModel.Type = reader.GetInt32(indexType);
                            newModel.Manager = reader.IsDBNull(indexManager) ? null : reader.GetString(indexManager);

                            response.Contracts.Add(newModel);
                        }
                        await reader.CloseAsync();
                    }

                    //SelectDepoClientAccounts
                    string filePathDepoClientAccounts = Path.Combine(Directory.GetCurrentDirectory(), "SqlQuerys", "querySelectDepoClientAccounts.sql");
                    if (!File.Exists(filePathDepoClientAccounts))
                    {
                        _logger.LogWarning($"{DateTime.Now.ToString("HH:mm:ss:fffff")} Error! File with SQL script not found at {filePathDepoClientAccounts}");

                        response.IsSuccess = false;
                        response.Messages.Add("Error! File with SQL script not found at " + filePathDepoClientAccounts);
                        return response;
                    }
                    string querySelectDepoClientAccounts = File.ReadAllText(filePathDepoClientAccounts);

                    querySelectDepoClientAccounts = querySelectDepoClientAccounts.Replace("@UniqueCodes", codesAtRequest);

                    using (SqlCommand command = new SqlCommand(querySelectDepoClientAccounts, connect))
                    {
                        SqlDataReader reader = await command.ExecuteReaderAsync();
                        while (await reader.ReadAsync())
                        {
                            DepoClientAccountsModel newModel = new DepoClientAccountsModel();

                            int indexClientID = reader.GetOrdinal("ClientID");
                            int indexAccountNumber = reader.GetOrdinal("AccountNumber");
                            int indexManager = reader.GetOrdinal("Manager");
                            int indexOwner = reader.GetOrdinal("Owner");
                            int indexDepositary = reader.GetOrdinal("Depositary");
                            int indexContractNo = reader.GetOrdinal("ContractNo");
                            int indexContractDate = reader.GetOrdinal("ContractDate");

                            newModel.ClientID = reader.GetString(indexClientID);
                            newModel.AccountNumber = reader.GetString(indexAccountNumber);
                            newModel.Manager = reader.GetString(indexManager);
                            newModel.Owner = reader.GetString(indexOwner);
                            newModel.Depositary = reader.GetString(indexDepositary);
                            newModel.ContractNo = reader.GetString(indexContractNo);
                            newModel.ContractDate = reader.GetInt32(indexContractDate);

                            response.DepoClientAccounts.Add(newModel);
                        }
                        await reader.CloseAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"{DateTime.Now.ToString("HH:mm:ss:fffff")} QuikDBRepository GetRegisteredCodes Failed, Exception: " + ex.Message);

                response.IsSuccess = false;
                response.Messages.Add("Exception: Select from DataBase: " + ex.Message);
                return response;
            }

            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} QuikDBRepository GetRegisteredCodes Success");

            if (response.IsSuccess 
                && response.ClientInfo.Count == 0 
                && response.ClientAccounts.Count == 0 
                && response.Contracts.Count == 0 
                && response.DepoClientAccounts.Count == 0)
            {
                response.Messages.Add("Error 404: Not Found");
            }

            return response;
        }

        private string GetCodesString(List<string> uniqueCodes)
        {
            string codesAtRequest = "";
            foreach (string uCode in uniqueCodes)
            {
                codesAtRequest = codesAtRequest + $"'{uCode}',";
            }

            codesAtRequest = codesAtRequest.Substring(0, codesAtRequest.Length - 1);

            return codesAtRequest;
        }
        private List<string> GetUniqueCodes(IEnumerable<string> codes)
        {
            List<string> uniqueCodes = new List<string>();
            foreach (string str in codes)
            {
                string quikCode = "";

                if (str.Contains("-CD-"))
                {
                    quikCode = CommonServices.PortfoliosConvertingService.GetQuikCdPortfolio(str);
                }                
                else if(str.StartsWith("C0"))
                {
                    quikCode = CommonServices.PortfoliosConvertingService.GetQuikFortsCode(str);
                }
                else
                {
                    quikCode = CommonServices.PortfoliosConvertingService.GetQuikSpotPortfolio(str);
                }

                if (!uniqueCodes.Contains(quikCode))
                {
                    uniqueCodes.Add(quikCode);
                }
            }

            return uniqueCodes;
        }

        public async Task<ListStringResponseModel> SetNewClientToMNP(NewMNPClientModel model)
        {
            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} QuikDBRepository SetNewClientToMNP Called for {model.Client.LastName} {model.Client.FirstName}");

            //список всех уникальных MATRIX портфелей спот и фортс вместе
            //список всех уникальных QUIK кодов       спот и фортс вместе
            //сравнить список - чтобы это был только один клиент
            List<string> uniqMatrixPortfolios = new List<string>();
            List<string> uniqQuikCodes = new List<string>();

            ListStringResponseModel response = GetUniquePortfolio(model, uniqMatrixPortfolios, uniqQuikCodes);
            if (!response.IsSuccess)
            {
                return response;
            }

            //создадим массивы с моделями
            ClientAccountsModel[] clientAccountsModels = new ClientAccountsModel[uniqMatrixPortfolios.Count];
            ClientInfoModel[] clientInfoModels = new ClientInfoModel[uniqQuikCodes.Count];
            ContractsModel[] contractsModels = new ContractsModel[uniqQuikCodes.Count];
            DepoClientAccountsModel[] depoClientAccountsModels = new DepoClientAccountsModel[uniqQuikCodes.Count];

            //заполним [ClientAccounts]
            for (int i = 0; i < uniqMatrixPortfolios.Count; i++)
            {
                clientAccountsModels[i] = new ClientAccountsModel();

                clientAccountsModels[i].Account = uniqMatrixPortfolios[i];

                string quikCode = "";
                if (uniqMatrixPortfolios[i].Contains("-CD-"))
                {
                    quikCode = CommonServices.PortfoliosConvertingService.GetQuikCdPortfolio(uniqMatrixPortfolios[i]);
                }
                else if (uniqMatrixPortfolios[i].Contains("-RF-"))
                {
                    for (int j = 0; j < model.CodesPairRF.Length; j++)
                    {
                        if (model.CodesPairRF[j].MatrixClientCode.Equals(uniqMatrixPortfolios[i]))
                        {
                            quikCode = CommonServices.PortfoliosConvertingService.GetQuikFortsCode(model.CodesPairRF[j].FortsClientCode);
                            break;
                        }
                    }
                }
                else
                {
                    quikCode = CommonServices.PortfoliosConvertingService.GetQuikSpotPortfolio(uniqMatrixPortfolios[i]);
                }
                clientAccountsModels[i].ClientID = quikCode;

                clientAccountsModels[i].SubAccount = model.SubAccount;
            }

            //заполним [Contracts] [DepoClientAccounts] [ClientInfo]
            for (int i = 0; i < uniqQuikCodes.Count; i++)
            {
                clientInfoModels[i] = new ClientInfoModel();
                depoClientAccountsModels[i] = new DepoClientAccountsModel();
                contractsModels[i] = new ContractsModel();

                // первая колонка
                clientInfoModels[i].ClientCode = uniqQuikCodes[i];
                contractsModels[i].ClientID = uniqQuikCodes[i];
                depoClientAccountsModels[i].ClientID = uniqQuikCodes[i];
                
                // Дог.BP12345
                string number = "Дог." + uniqMatrixPortfolios[0].Split('-').First();
                contractsModels[i].Number = number;
                depoClientAccountsModels[i].ContractNo = number;

                // 20220515
                contractsModels[i].RegisterDate = model.RegisterDate;
                depoClientAccountsModels[i].ContractDate = model.RegisterDate;

                // Type: Тип договора: 0 – договор обслуживания, 1 – депозитарный договор.
                if (model.isClientDepo)
                {
                    contractsModels[i].Type = 1;
                }
                else // по умолчанию должно быть 0
                {
                    contractsModels[i].Type = 0;
                }

                // Manager 
                contractsModels[i].Manager = model.Manager;

                // L01+00000F00
                depoClientAccountsModels[i].AccountNumber = "L01+00000F00";

                // ITinvest
                depoClientAccountsModels[i].Manager = model.DepoClientAccountsManager;

                // Иванов И.С.
                if (model.isClientPerson) // ФИО
                {
                    depoClientAccountsModels[i].Owner = $"{model.Client.LastName} {model.Client.FirstName[0]}.";
                    if (model.Client.MiddleName.Length > 0)
                    {
                        depoClientAccountsModels[i].Owner = depoClientAccountsModels[i].Owner + $" {model.Client.MiddleName[0]}.";
                    }
                }
                else // Организация
                {
                    depoClientAccountsModels[i].Owner = $"{model.Client.LastName} {model.Client.FirstName} {model.Client.MiddleName}";
                }

                // НДЦ
                depoClientAccountsModels[i].Depositary = model.Depositary;

                // Full Name
                clientInfoModels[i].FullName = $"{model.Client.LastName} {model.Client.FirstName} {model.Client.MiddleName}";

                // client@domen.ru
                clientInfoModels[i].EMail = model.Client.EMail;

                // P | O
                if (model.isClientPerson)
                {
                    clientInfoModels[i].ClientType = "P";
                }
                else
                {
                    clientInfoModels[i].ClientType = "O";
                }

                // Resident
                if (model.isClientResident)
                {
                    clientInfoModels[i].Resident = "R";
                }
                else
                {
                    clientInfoModels[i].Resident = "N";
                }

                // Adress
                clientInfoModels[i].Address = model.Address;
            }

            //проверим наличие файлов с sql запросами
            string filePathInsertClientInfo = Path.Combine(Directory.GetCurrentDirectory(), "SqlQuerys", "queryInsertClientInfo.sql");
            if (!File.Exists(filePathInsertClientInfo))
            {
                _logger.LogWarning($"{DateTime.Now.ToString("HH:mm:ss:fffff")} Error! File with SQL script not found at {filePathInsertClientInfo}");

                response.IsSuccess = false;
                response.Messages.Add("Error! File with SQL script not found at " + filePathInsertClientInfo);
                return response;
            }
            string queryInsertClientInfo = File.ReadAllText(filePathInsertClientInfo);

            string filePathInsertContracts = Path.Combine(Directory.GetCurrentDirectory(), "SqlQuerys", "queryInsertContracts.sql");
            if (!File.Exists(filePathInsertContracts))
            {
                _logger.LogWarning($"{DateTime.Now.ToString("HH:mm:ss:fffff")} Error! File with SQL script not found at {filePathInsertContracts}");

                response.IsSuccess = false;
                response.Messages.Add("Error! File with SQL script not found at " + filePathInsertContracts);
                return response;
            }
            string queryInsertContracts = File.ReadAllText(filePathInsertContracts);

            string filePathInsertDepoClientAccounts = Path.Combine(Directory.GetCurrentDirectory(), "SqlQuerys", "queryInsertDepoClientAccounts.sql");
            if (!File.Exists(filePathInsertDepoClientAccounts))
            {
                _logger.LogWarning($"{DateTime.Now.ToString("HH:mm:ss:fffff")} Error! File with SQL script not found at {filePathInsertDepoClientAccounts}");

                response.IsSuccess = false;
                response.Messages.Add("Error! File with SQL script not found at " + filePathInsertDepoClientAccounts);
                return response;
            }
            string queryInsertDepoClientAccounts = File.ReadAllText(filePathInsertDepoClientAccounts);

            string filePathInsertClientAccounts = Path.Combine(Directory.GetCurrentDirectory(), "SqlQuerys", "queryInsertClientAccounts.sql");
            if (!File.Exists(filePathInsertClientAccounts))
            {
                _logger.LogWarning($"{DateTime.Now.ToString("HH:mm:ss:fffff")} Error! File with SQL script not found at {filePathInsertClientAccounts}");

                response.IsSuccess = false;
                response.Messages.Add("Error! File with SQL script not found at " + filePathInsertClientAccounts);
                return response;
            }
            string queryInsertClientAccounts = File.ReadAllText(filePathInsertClientAccounts);

            // запишем данные в БД
            try
            {
                using (SqlConnection connect = new SqlConnection(_connection.ConnectionString))
                {
                    await connect.OpenAsync();

                    foreach (var record in clientAccountsModels)
                    {
                        using (SqlCommand command = new SqlCommand(queryInsertClientAccounts, connect))
                        {
                            command.Parameters.AddWithValue("@ClientID", record.ClientID);
                            command.Parameters.AddWithValue("@Account", record.Account);
                            command.Parameters.AddWithValue("@SubAccount", record.SubAccount);
                            try
                            {
                                await command.ExecuteNonQueryAsync();
                            }
                            catch (Exception cx)
                            {
                                _logger.LogWarning($"{DateTime.Now.ToString("HH:mm:ss:fffff")} Exception Insert ClientAccount {record.ClientID} at DataBase: " + cx.Message);

                                response.IsSuccess = false;
                                response.Messages.Add($"Exception Insert ClientAccount {record.ClientID} at DataBase: " + cx.Message);
                            }                            
                        }
                    }

                    foreach (var record in clientInfoModels)
                    {
                        using (SqlCommand command = new SqlCommand(queryInsertClientInfo, connect))
                        {
                            command.Parameters.AddWithValue("@ClientCode", record.ClientCode);
                            command.Parameters.AddWithValue("@FullName", record.FullName);
                            command.Parameters.AddWithValue("@EMail", record.EMail);
                            command.Parameters.AddWithValue("@ClientType", record.ClientType);
                            command.Parameters.AddWithValue("@Resident", record.Resident);
                            command.Parameters.AddWithValue("@Address", record.Address);
                            try
                            {
                                await command.ExecuteNonQueryAsync();
                            }
                            catch (Exception cx)
                            {
                                _logger.LogWarning($"{DateTime.Now.ToString("HH:mm:ss:fffff")} Exception Insert ClientInfo {record.ClientCode} at DataBase: " + cx.Message);

                                response.IsSuccess = false;
                                response.Messages.Add($"Exception Insert ClientInfo {record.ClientCode} at DataBase: " + cx.Message);
                            }
                        }
                    }

                    foreach (var record in contractsModels)
                    {
                        using (SqlCommand command = new SqlCommand(queryInsertContracts, connect))
                        {
                            command.Parameters.AddWithValue("@ClientID", record.ClientID);
                            command.Parameters.AddWithValue("@Number", record.Number);
                            command.Parameters.AddWithValue("@RegisterDate", record.RegisterDate);
                            command.Parameters.AddWithValue("@Type", record.Type);
                            command.Parameters.AddWithValue("@Manager", record.Manager ?? Convert.DBNull);
                            try
                            {
                                await command.ExecuteNonQueryAsync();
                            }
                            catch (Exception cx)
                            {
                                _logger.LogWarning($"{DateTime.Now.ToString("HH:mm:ss:fffff")} Exception Insert Contracts {record.ClientID} at DataBase: " + cx.Message);

                                response.IsSuccess = false;
                                response.Messages.Add($"Exception Insert Contracts {record.ClientID} at DataBase: " + cx.Message);
                            }
                        }
                    }

                    foreach (var record in depoClientAccountsModels)
                    {
                        using (SqlCommand command = new SqlCommand(queryInsertDepoClientAccounts, connect))
                        {
                            command.Parameters.AddWithValue("@ClientID", record.ClientID);
                            command.Parameters.AddWithValue("@AccountNumber", record.AccountNumber);
                            command.Parameters.AddWithValue("@Manager", record.Manager);
                            command.Parameters.AddWithValue("@Owner", record.Owner);
                            command.Parameters.AddWithValue("@Depositary", record.Depositary);
                            command.Parameters.AddWithValue("@ContractNo", record.ContractNo);
                            command.Parameters.AddWithValue("@ContractDate", record.ContractDate);
                            try
                            {
                                await command.ExecuteNonQueryAsync();
                            }
                            catch (Exception cx)
                            {
                                _logger.LogWarning($"{DateTime.Now.ToString("HH:mm:ss:fffff")} Exception Insert DepoClientAccounts {record.ClientID} at DataBase: " + cx.Message);

                                response.IsSuccess = false;
                                response.Messages.Add($"Exception Insert DepoClientAccounts {record.ClientID} at DataBase: " + cx.Message);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"{DateTime.Now.ToString("HH:mm:ss:fffff")} QuikDBRepository SetNewClientToMNP Failed, Exception: " + ex.Message);

                response.IsSuccess = false;
                response.Messages.Add("Exception SetNewClientToMNP Connect at DataBase: " + ex.Message);
                return response;
            }

            return response;
        }

        private ListStringResponseModel GetUniquePortfolio(NewMNPClientModel model, List<string> uniqMatrixPortfolios, List<string> uniqQuikCodes)
        {
            ListStringResponseModel response = new ListStringResponseModel();

            if (model.CodesMatrix is not null)
            {
                foreach (MatrixClientCodeModel portfolio in model.CodesMatrix)
                {
                    if (!uniqMatrixPortfolios.Contains(portfolio.MatrixClientCode))
                    {
                        uniqMatrixPortfolios.Add(portfolio.MatrixClientCode);
                    }

                    //Добавить QUIK код
                    string quikCode = CommonServices.PortfoliosConvertingService.GetQuikSpotPortfolio(portfolio.MatrixClientCode);
                    if (portfolio.MatrixClientCode.Contains("-CD-"))
                    {
                        quikCode = CommonServices.PortfoliosConvertingService.GetQuikCdPortfolio(portfolio.MatrixClientCode);
                    }

                    if (!uniqQuikCodes.Contains(quikCode))
                    {
                        uniqQuikCodes.Add(quikCode);
                    }
                }
            }

            if (model.CodesPairRF is not null)
            {
                foreach (MatrixToFortsCodesMappingModel pair in model.CodesPairRF)
                {
                    if (!uniqMatrixPortfolios.Contains(pair.MatrixClientCode))
                    {
                        uniqMatrixPortfolios.Add(pair.MatrixClientCode);
                    }

                    //Добавить QUIK код
                    string quikCode = CommonServices.PortfoliosConvertingService.GetQuikFortsCode(pair.FortsClientCode);
                    if (!uniqQuikCodes.Contains(quikCode))
                    {
                        uniqQuikCodes.Add(quikCode);
                    }
                }
            }

            //проверить, что в портфелях только один клиент
            string clientAgreement = uniqMatrixPortfolios[0].Split('-').First();
            foreach (string portfolio in uniqMatrixPortfolios)
            {
                if (!portfolio.Split('-').First().Equals(clientAgreement))
                {
                    _logger.LogWarning($"{DateTime.Now.ToString("HH:mm:ss:fffff")} MNP200 Portfolio {portfolio} is not belong to agreement {clientAgreement}");

                    response.IsSuccess = false;
                    response.Messages.Add($"MNP200 Portfolio {portfolio} is not belong to agreement {clientAgreement}");
                }
            }

            return response;
        }
    }
}