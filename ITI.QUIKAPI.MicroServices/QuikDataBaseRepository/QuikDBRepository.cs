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

        public async Task<DataBaseClientCodesResponse> GetRegisteredCodes(IEnumerable<string> code)
        {
            _logger.LogInformation($"QuikDBRepository GetRegisteredCodes Called");

            //string suffixClientID = GenerateRequestSuffixString(true, model);
            //string suffixClientCode = GenerateRequestSuffixString(false, model);

            DataBaseClientCodesResponse response = new DataBaseClientCodesResponse();

            try
            {
                using (SqlConnection connect = new SqlConnection(_connection.ConnectionString))
                {
                    await connect.OpenAsync();

                    //using (SqlCommand command = new SqlCommand(_checkClientAccounts, connect))
                    //{
                    //    response.Messages.Add("Records in ClientAccounts table = " + (int)await command.ExecuteScalarAsync());
                    //}

                    /*
                     * where t.ClientID like 'BP17178/%' or t.ClientID in ('SPBFUT002LP');
                     * where t.ClientCode like 'BP17178/%' or t.ClientCode in ('SPBFUT002LP');
                     * 
SELECT [ClientID],[Number] ,[RegisterDate],[Type],[Manager] FROM [TEST_Instructions].[dbo].[Contracts] t where t.ClientID like 'BP17178/%' or t.ClientID in ('SPBFUT002LP');
SELECT [ClientID] ,[AccountNumber] ,[Manager] ,[Owner] ,[Depositary] ,[ContractNo] ,[ContractDate]  FROM [TEST_Instructions].[dbo].[DepoClientAccounts] t where t.ClientID like 'BP17178/%' or t.ClientID in ('SPBFUT002LP');
SELECT [ClientID] ,[Account] ,[SubAccount]  FROM [TEST_Instructions].[dbo].[ClientAccounts] t where t.ClientID like 'BP17178/%' or t.ClientID in ('SPBFUT002LP');
SELECT [ClientCode],[FullName],[EMail],[ClientType],[Resident],[Address] FROM [TEST_Instructions].[dbo].[ClientInfo] t where t.ClientCode like 'BP17178/%' or t.ClientCode in ('SPBFUT002LP');
                     * */

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
            return response;
        }


        //private string GenerateRequestSuffixString(bool isClientID, DBClientRecordsRequestModel model)
        //{
        //    /* result must be like
        //    * where t.ClientID like 'BP17178/%' or t.ClientID in ('SPBFUT002LP');
        //    * where t.ClientID like 'BP17178/%' or t.ClientID like 'BP12345/%' or t.ClientID in ('SPBFUT002LP', 'SPBFUT00abc');
        //    * where t.ClientID like 'BP17178/%';
        //    * where t.ClientID in ('SPBFUT002LP');
        //    * 
        //    * where t.ClientCode like 'BP17178/%' or t.ClientCode in ('SPBFUT002LP');
        //    * where t.ClientCode like 'BP17178/%' or t.ClientCode like 'BP17178/%' or t.ClientCode in ('SPBFUT002LP', 'SPBFUT00abc');
        //    * where t.ClientCode like 'BP17178/%';
        //    * where t.ClientCode in ('SPBFUT002LP');
        //    */

        //    List<string> spotCodes = new List<string>();
        //    List<string> fortsCodes = new List<string>();

        //    string fieldName = "ClientID";

        //    if (!isClientID)
        //    {
        //        fieldName = "ClientCode";
        //    }

        //    string result = " where t." + fieldName;

        //    if (model.CodesMatrix is not null) 
        //    {
        //        foreach (var code in model.CodesMatrix)
        //        {
        //            string newCode = code.MatrixClientCode.Split('-').First();

        //            if (!spotCodes.Contains(newCode))
        //            {
        //                spotCodes.Add(newCode);
        //            }
        //        }
        //    }

        //    if (model.CodesPairRF is not null)
        //    {
        //        foreach (var code in model.CodesPairRF)
        //        {
        //            string newCode = CommonServices.PortfoliosConvertingService.GetQuikFortsCode(code.FortsClientCode);

        //            if (!fortsCodes.Contains(newCode))
        //            {
        //                fortsCodes.Add(newCode);
        //            }
        //        }
        //    }


        //    return result;
        //}
    }
}