using DataAbstraction.Models;

namespace DataAbstraction.Interfaces
{
    public interface IQMonitorService
    {
        ListStringResponseModel CheckConnections();
    }
}
