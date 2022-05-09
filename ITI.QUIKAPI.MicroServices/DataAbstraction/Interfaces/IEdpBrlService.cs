using DataAbstraction.Models;

namespace DataAbstraction.Interfaces
{
    public interface IEdpBrlService
    {
        ListStringResponseModel GetEDPFortsClientCodeByMatrixCode(MatrixClientCodeModel model);
        ListStringResponseModel GetEDPMatrixClientCodeByFortsCode(FortsClientCodeModel model);
        ListStringResponseModel SetNewEdpRelation(MatrixToFortsCodesMappingModel model);
        ListStringResponseModel DeleteEdpRelation(MatrixClientCodeModel model);
        ListStringResponseModel GetAllEdpRelation();
    }
}
