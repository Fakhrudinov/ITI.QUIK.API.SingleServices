using DataAbstraction.Models;

namespace DataAbstraction.Interfaces
{
    public interface ISpotBrlService
    {
        ListStringResponseModel CheckConnection();
        string GetLogin();
        ListStringResponseModel AddClientPortfolioToKomissiiCDportfolio(string quikportfolio);
        ListStringResponseModel AddClientPortfolioToLeverageCDportfolio(string quikportfolio);
        ListStringResponseModel GetAllTemplatesPoKomissii();
        ListStringResponseModel GetAllTemplatesPoPlechu();
        ListStringResponseModel GetAllClientsFromTemplatePoKomissii(string templateName);
        ListStringResponseModel GetAllClientsFromTemplatePoPlechu(string templateName);
        ListStringResponseModel DeleteCodeFromTemplatePoKomissii(TemplateAndQuikCodeModel model);
        ListStringResponseModel DeleteCodeFromTemplatePoPlechu(TemplateAndQuikCodeModel model);
        ListStringResponseModel AddClientPortfolioToKomissiiTemplate(string template, string quikportfolio);
        ListStringResponseModel AddClientPortfolioToLeverageTemplate(string template, string quikportfolio);
        ListStringResponseModel MoveClientCodeBetweenTemplatesPoKomissii(MoveCodeModel moveModel);
        ListStringResponseModel MoveClientCodeBetweenTemplatesPoPlechu(MoveCodeModel moveModel);
        ListStringResponseModel ReplaceAllCodesMatrixInLeverageTemplate(TemplateAndCodesModel model);
        ListStringResponseModel ReplaceAllCodesMatrixInPoKomisiiTemplate(TemplateAndCodesModel model);
    }
}
