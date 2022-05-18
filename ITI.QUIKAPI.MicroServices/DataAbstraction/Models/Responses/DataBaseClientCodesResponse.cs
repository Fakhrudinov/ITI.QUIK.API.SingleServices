using DataAbstraction.Models.DataBaseModels;

namespace DataAbstraction.Models.Responses
{
    public class DataBaseClientCodesResponse
    {
        public DataBaseClientCodesResponse()
        {
            IsSuccess = true;
            Messages = new List<string>();

            ClientInfo = new List<ClientInfoModel>();
            Contracts = new List<ContractsModel>();
            ClientAccounts = new List<ClientAccountsModel>();
            DepoClientAccounts = new List<DepoClientAccountsModel>();
        }

        public List<ClientInfoModel> ClientInfo { get; set; }
        public List<ContractsModel> Contracts { get; set; }
        public List<ClientAccountsModel> ClientAccounts { get; set; }
        public List<DepoClientAccountsModel> DepoClientAccounts { get; set; }

        public bool IsSuccess { get; set; }
        public List<string> Messages { get; set; }
    }
}
