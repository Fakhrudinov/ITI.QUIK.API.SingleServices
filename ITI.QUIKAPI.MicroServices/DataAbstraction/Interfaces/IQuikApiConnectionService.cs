namespace DataAbstraction.Interfaces
{
    public interface IQuikApiConnectionService
    {
        string OpenQuikQadminApiToWrite(string firm);
        public string OpenQuikQadminApiToRead(string firm);
        public string CloseQuikAPI(int resultEditBrl, string firm);
    }
}
