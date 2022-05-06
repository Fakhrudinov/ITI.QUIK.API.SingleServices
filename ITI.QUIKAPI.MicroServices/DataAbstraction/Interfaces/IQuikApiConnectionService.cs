using DataAbstraction.Models;

namespace DataAbstraction.Interfaces
{
    public interface IQuikApiConnectionService
    {
        public ListStringResponseModel OpenQuikQadminApiToWrite(string firm, ListStringResponseModel response);
        public ListStringResponseModel OpenQuikQadminApiToRead(string firm, ListStringResponseModel response);
        public ListStringResponseModel CloseQuikAPI(int resultEditBrl, string firm, ListStringResponseModel response);
    }
}
