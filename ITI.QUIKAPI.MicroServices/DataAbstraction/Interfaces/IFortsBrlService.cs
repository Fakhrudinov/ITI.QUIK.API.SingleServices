using DataAbstraction.Models;

namespace DataAbstraction.Interfaces
{
    public interface IFortsBrlService
    {
        ListStringResponseModel CheckConnection();
        string GetLogin();

        ListStringResponseModel DeleteCodeFromTemplate(bool itIsPoKomissii, string template, string clientCode, bool needToConvertCode);
        ListStringResponseModel AddFortsCodeToTemplate(bool itIsPoKomissii, string template, string clientCode);
        ListStringResponseModel GetList(bool itIsTemplatesList, bool itIsPoKomissii, string template);
        ListStringResponseModel MoveMatrixFortsCodeBetweenTemplates(bool itIsPoKomissii, MoveMatrixFortsCodeModel moveModel);
        ListStringResponseModel ReplaceAllMatrixFortsCodesInTemplate(bool itIsPoKomissii, TemplateAndMatrixFortsCodesModel model);
    }
}
