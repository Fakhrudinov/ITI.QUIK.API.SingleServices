using DataAbstraction.Models;

namespace DataAbstraction.Interfaces
{
    public interface IEdpBrlService
    {
        ListStringResponseModel GetEDPFortsClientCodeByMatrixCode(MatrixClientPortfolioModel model);
        ListStringResponseModel GetEDPMatrixClientCodeByFortsCode(FortsClientCodeModel model);
        ListStringResponseModel SetNewEdpRelation(MatrixToFortsCodesMappingModel model);
        ListStringResponseModel DeleteEdpRelation(MatrixClientPortfolioModel model);
        ListStringResponseModel GetAllEdpRelation();
    }
}
