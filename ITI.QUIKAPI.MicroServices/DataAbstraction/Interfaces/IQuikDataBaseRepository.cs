using DataAbstraction.Models;

namespace DataAbstraction.Interfaces
{
    public interface IQuikDataBaseRepository
    {
        ListStringResponseModel CheckConnections();
    }
}
