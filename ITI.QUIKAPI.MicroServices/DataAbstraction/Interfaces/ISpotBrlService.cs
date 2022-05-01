using DataAbstraction.Models;

namespace DataAbstraction.Interfaces
{
    public interface ISpotBrlService
    {
        string CheckConnection();
        string GetLogin();
        string AddClientPortfolioToKomissiiCDportfolio(string quikportfolio);
        string AddClientPortfolioToLeverageCDportfolio(string quikportfolio);
        string[] GetAllTemplatesPoKomissii();
        string[] GetAllTemplatesPoPlechu();
        string[] GetAllClientsFromTemplatePoKomissii(string templateName);
        string[] GetAllClientsFromTemplatePoPlechu(string templateName);
        string DeleteCodeFromTemplatePoKomissii(TemplateAndCodeModel model);
        string DeleteCodeFromTemplatePoPlechu(TemplateAndCodeModel model);
        string AddClientPortfolioToKomissiiTemplate(string template, string quikportfolio);
        string AddClientPortfolioToLeverageTemplate(string template, string quikportfolio);
        string MoveClientCodeBetweenTemplatesPoKomissii(MoveCodeModel moveModel);
        string MoveClientCodeBetweenTemplatesPoPlechu(MoveCodeModel moveModel);
        string ReplaceAllCodesMatrixInLeverageTemplate(TemplateAndCodesModel model);
        string ReplaceAllCodesMatrixInPoKomisiiTemplate(TemplateAndCodesModel model);
    }
}
