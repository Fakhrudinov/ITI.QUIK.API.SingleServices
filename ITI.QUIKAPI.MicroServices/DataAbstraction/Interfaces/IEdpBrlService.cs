using DataAbstraction.Models;

namespace DataAbstraction.Interfaces
{
    public interface IEdpBrlService
    {
        ListStringResponseModel GetEDPFortsClientCodeByMatrixCode(MatrixClientCodeModel model);
    }
}
