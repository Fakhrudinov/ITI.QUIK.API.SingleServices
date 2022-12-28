using DataAbstraction.Models;
using DataAbstraction.Models.Responses;

namespace DataAbstraction.Interfaces
{
    public interface IDiscountsService
    {
        ListStringResponseModel DeleteSingleDiscountFromGlobal(string security);
        ListStringResponseModel DeleteSingleDiscountFromMarginTemplate(string template, string security);
        SecuritysListResponse GetListOfDiscountSecuritiesFromGlobal();
        SecuritysListResponse GetListOfDiscountSecuritiesFromMarginTemplate(string template);
        DiscountSingleResponse GetSingleDiscountFromGlobal(string security);
        DiscountSingleResponse GetSingleDiscountFromMarginTemplate(string template, string security);
        ListStringResponseModel PostSingleDiscountToGlobal(DiscountAndSecurityModel model);
        ListStringResponseModel PostSingleDiscountToMarginTemplate(string template, DiscountAndSecurityModel model);
    }
}
