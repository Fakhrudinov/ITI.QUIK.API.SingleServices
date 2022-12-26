using DataAbstraction.Models;
using DataAbstraction.Models.Responses;

namespace DataAbstraction.Interfaces
{
    public interface IDiscountsService
    {
        DiscountSingleResponse GetSingleDiscountFromGlobal(string security);
        DiscountSingleResponse GetSingleDiscountFromMarginTemplate(string template, string security);
        ListStringResponseModel PostSingleDiscountToGlobal(DiscountAndSecurityModel model);
        ListStringResponseModel PostSingleDiscountToMarginTemplate(string template, DiscountAndSecurityModel model);
    }
}
