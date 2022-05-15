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
        private const string _checkClientAccounts =     "SELECT COUNT(*) FROM ClientAccounts;";
        private const string _checkClientInfo =         "SELECT COUNT(*) FROM ClientInfo;";
        private const string _checkContracts =          "SELECT COUNT(*) FROM Contracts;";
        private const string _checkDepoClientAccounts = "SELECT COUNT(*) FROM DepoClientAccounts;";

        private const string _selectClientAccounts =    "SELECT ClientID, Account, SubAccount FROM ClientAccounts t";
        private const string _selectClientInfo =        "SELECT ClientCode, FullName, EMail, ClientType, Resident, Address FROM ClientInfo t";
        private const string _selectContracts =         "SELECT ClientID, Number, RegisterDate, Type, Manager FROM Contracts t";
        private const string _selectDepoClientAccounts ="SELECT ClientID,AccountNumber,Manager,Owner,Depositary,ContractNo,ContractDate FROM DepoClientAccounts t";

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
            _logger.LogInformation($"QuikDBRepository CheckConnections Called");

            ListStringResponseModel response = new ListStringResponseModel();

            try
            {
                using (SqlConnection connect = new SqlConnection(_connection.ConnectionString))
                {
                    await connect.OpenAsync();

                    using (SqlCommand command = new SqlCommand(_checkClientAccounts, connect))
                    {
                        response.Messages.Add("Records in ClientAccounts table = " + (int)await command.ExecuteScalarAsync());
                    }
                    using (SqlCommand command = new SqlCommand(_checkClientInfo, connect))
                    {
                        response.Messages.Add("Records in ClientInfo table = " + (int)await command.ExecuteScalarAsync());
                    }
                    using (SqlCommand command = new SqlCommand(_checkContracts, connect))
                    {
                        response.Messages.Add("Records in Contracts table = " + (int)await command.ExecuteScalarAsync());
                    }
                    using (SqlCommand command = new SqlCommand(_checkDepoClientAccounts, connect))
                    {
                        response.Messages.Add("Records in DepoClientAccounts table = " + (int)await command.ExecuteScalarAsync());
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"QuikDBRepository CheckConnections Failed, Exception: " + ex.Message);

                response.IsSuccess = false;
                response.Messages.Add("Exception at DataBase: " + ex.Message);
                return response;
            }

            _logger.LogInformation($"QuikDBRepository CheckConnections Success");
            return response;
        }

        public async Task<DataBaseClientCodesResponse> GetRegisteredCodes(IEnumerable<string> codes)
        {
            _logger.LogInformation($"QuikDBRepository GetRegisteredCodes Called");

            //List<string> uniqueCodes = GetUniqueCodes(codes);
            string codesAtRequest = GetCodesString(GetUniqueCodes(codes));

            string suffixClientID = $" where t.ClientID in ({codesAtRequest});";
            string suffixClientCode = $" where t.ClientCode in ({codesAtRequest});";

            DataBaseClientCodesResponse response = new DataBaseClientCodesResponse();

            try
            {
                using (SqlConnection connect = new SqlConnection(_connection.ConnectionString))
                {
                    await connect.OpenAsync();

                    using (SqlCommand command = new SqlCommand(_selectClientAccounts + suffixClientID, connect))
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

                    using (SqlCommand command = new SqlCommand(_selectClientInfo + suffixClientCode, connect))
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

                    using (SqlCommand command = new SqlCommand(_selectContracts + suffixClientID, connect))
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
;
                    using (SqlCommand command = new SqlCommand(_selectDepoClientAccounts + suffixClientID, connect))
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
                _logger.LogWarning($"QuikDBRepository GetRegisteredCodes Failed, Exception: " + ex.Message);

                response.IsSuccess = false;
                response.Messages.Add("Exception at DataBase: " + ex.Message);
                return response;
            }

            _logger.LogInformation($"QuikDBRepository GetRegisteredCodes Success");

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
    }
}