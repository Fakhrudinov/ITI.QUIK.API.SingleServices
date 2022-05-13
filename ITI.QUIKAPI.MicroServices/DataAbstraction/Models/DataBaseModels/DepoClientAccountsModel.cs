namespace DataAbstraction.Models.DataBaseModels
{
    public class DepoClientAccountsModel
    {
        public string ClientID { get; set; }
        public string AccountNumber { get; set; }
        public string Manager { get; set; }
        public string Owner { get; set; }
        public string Depositary { get; set; }
        public string ContractNo { get; set; }
        public int ContractDate { get; set; }
    }
}
