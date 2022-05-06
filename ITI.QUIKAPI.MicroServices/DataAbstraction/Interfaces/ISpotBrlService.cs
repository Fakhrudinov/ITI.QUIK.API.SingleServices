using DataAbstraction.Models;

namespace DataAbstraction.Interfaces
{
    public interface ISpotBrlService
    {
        ListStringResponseModel CheckConnection();
        string GetLogin();

        ListStringResponseModel DeleteCodeFromTemplate(bool itIsPoKomissii, string template, string clientCode, bool needToConvertCode);
        ListStringResponseModel AddClientPortfolioToTemplate(bool itIsPoKomissii, string template, string clientCode);
        ListStringResponseModel GetList(bool itIsTemplatesList, bool itIsPoKomissii, string template);
        ListStringResponseModel MoveQuikClientCodeBetweenTemplates(bool itIsPoKomissii, MoveQuikCodeModel moveModel);
        ListStringResponseModel MoveMatrixClientCodeBetweenTemplates(bool itIsPoKomissii, MoveMatrixCodeModel moveModel);
        ListStringResponseModel ReplaceAllCodesInTemplate(bool itIsPoKomissii, TemplateAndMatrixCodesModel model);
    }
}
