using DataAbstraction.Models;
using DataAbstraction.Models.DataBaseModels;
using DataAbstraction.Models.Responses;

namespace DataAbstraction.Interfaces
{
    public interface IQuikDataBaseRepository
    {
        Task<ListStringResponseModel> CheckConnections();
        Task<DataBaseClientCodesResponse> GetRegisteredCodes(IEnumerable<string> code);
    }
}
