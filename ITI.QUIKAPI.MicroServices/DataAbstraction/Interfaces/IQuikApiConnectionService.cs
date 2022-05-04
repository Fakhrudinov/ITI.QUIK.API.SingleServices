using DataAbstraction.Models;

namespace DataAbstraction.Interfaces
{
    public interface IQuikApiConnectionService
    {
        string OpenQuikQadminApiToWrite(string firm);
        public string OpenQuikQadminApiToRead(string firm);
        public ListStringResponseModel CloseQuikAPI(int resultEditBrl, string firm, ListStringResponseModel response);
    }
}
