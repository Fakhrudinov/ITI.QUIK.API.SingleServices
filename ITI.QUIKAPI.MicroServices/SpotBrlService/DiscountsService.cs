using DataAbstraction.Interfaces;
using DataAbstraction.Models;
using DataAbstraction.Models.Responses;
using Microsoft.Extensions.Logging;
using QDealerAPI;

namespace QuikAPIBrlService
{
    public class DiscountsService : IDiscountsService
    {
        private const string _spotFIRM = "MC0138200000";
        private ILogger<DiscountsService> _logger;
        IQuikApiConnectionService _connection;

        public DiscountsService(ILogger<DiscountsService> logger, IQuikApiConnectionService connection)
        {
            _logger = logger;
            _connection = connection;
        }

        public DiscountSingleResponse GetSingleDiscountFromGlobal(string security)
        {
            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} DiscountsService GetSingleDiscountFromGlobal " +
                $"Called for {security}");

            DiscountSingleResponse result = GetDiscountValues(security);
            return result;
        }

        public DiscountSingleResponse GetSingleDiscountFromMarginTemplate(string template, string security)
        {
            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} DiscountsService GetSingleDiscountFromMarginTemplate Called for {template} {security}");

            DiscountSingleResponse result = GetDiscountValues(security, template);
            return result;
        }

        private DiscountSingleResponse GetDiscountValues(string security, string template = "")
        {
            DiscountSingleResponse result = new DiscountSingleResponse();

            // открываем соединение
            ListStringResponseModel response = new ListStringResponseModel();
            ListStringResponseModel openResult = _connection.OpenQuikQadminApiToRead(_spotFIRM, response);
            if (!openResult.IsSuccess)
            {
                result.IsSuccess = false;
                result.Messages.AddRange(openResult.Messages);

                return result;
            }

            // запрашиваем данные
            int getResult = -1;
            QDAPI_Discounts discounts = new QDAPI_Discounts();

            if (template != "") // запрос из шаблона
            {
                getResult = NativeMethods.QDAPI_GetSecurityDiscountsFromMarginTemplate(_spotFIRM, template, 0, security, ref discounts);
            }
            else // запрос из global
            {
                getResult = NativeMethods.QDAPI_GetSecurityDiscountsFromGlobal(_spotFIRM, security, ref discounts);
            }
            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} DiscountsService GetDiscountValues " +
                $"for {security} {template} result is {getResult}");

            if (getResult == 0) // 0=success
            {
                result.Discount.KShort = discounts.KShort;
                result.Discount.KLong = discounts.KLong;
                result.Discount.DShort = discounts.DShort;
                result.Discount.DLong = discounts.DLong;
                result.Discount.DShort_min = discounts.DShort_min;
                result.Discount.DLong_min= discounts.DLong_min;
            }
            else
            {
                result.Discount = null;
            }

            // закрываем соединение
            ListStringResponseModel closeResult = _connection.CloseQuikAPI(getResult, _spotFIRM, response);
            result.IsSuccess = closeResult.IsSuccess;
            result.Messages.AddRange(closeResult.Messages);
            return result;
        }

        public ListStringResponseModel PostSingleDiscountToGlobal(DiscountAndSecurityModel model)
        {
            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} DiscountsService PostSingleDiscountToGlobal Called " +
                $"for {model.Security}");

            ListStringResponseModel response = PostDiscount(model);
            return response;
        }

        public ListStringResponseModel PostSingleDiscountToMarginTemplate(string template, DiscountAndSecurityModel model)
        {
            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} DiscountsService PostSingleDiscountToMarginTemplate Called" +
                $" for {template} {model.Security}");

            ListStringResponseModel response = PostDiscount(model, template);
            return response;
        }

        private ListStringResponseModel PostDiscount(DiscountAndSecurityModel model, string template = "")
        {
            ListStringResponseModel response = new ListStringResponseModel();

            ListStringResponseModel openResult = _connection.OpenQuikQadminApiToWrite(_spotFIRM, response);
            if (!openResult.IsSuccess)
            {
                return response;
            }

            // set
            QDAPI_Discounts discounts = new QDAPI_Discounts();
            discounts.KLong = model.KLong;
            discounts.KShort = model.KShort;
            discounts.DLong = model.DLong;
            discounts.DShort = model.DShort;
            discounts.DLong_min = model.DLong_min;
            discounts.DShort_min = model.DShort_min;

            int resultEditBrl = -1;

            if (template != "") // post to template
            {
                resultEditBrl = NativeMethods.QDAPI_SetSecurityDiscountsToMarginTemplate(_spotFIRM, template, 0, model.Security, ref discounts);
            }
            else // post to global
            {
                resultEditBrl = NativeMethods.QDAPI_SetSecurityDiscountsToGlobal(_spotFIRM, model.Security, ref discounts);
            }            
            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} DiscountsService PostDiscount " +
                $" {template} {model.Security} result is: {resultEditBrl}");

            // close connection
            return _connection.CloseQuikAPI(resultEditBrl, _spotFIRM, response);
        }
    }
}
