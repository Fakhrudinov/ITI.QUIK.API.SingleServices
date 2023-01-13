using DataAbstraction.Interfaces;
using DataAbstraction.Models;
using DataAbstraction.Models.Responses;
using Microsoft.Extensions.Logging;
using QDealerAPI;
using System.Reflection;
using System.Runtime.InteropServices;

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
            discounts.KLong = model.Discount.KLong;
            discounts.KShort = model.Discount.KShort;
            discounts.DLong = model.Discount.DLong;
            discounts.DShort = model.Discount.DShort;
            discounts.DLong_min = model.Discount.DLong_min;
            discounts.DShort_min = model.Discount.DShort_min;

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

        public SecuritysListResponse GetListOfDiscountSecuritiesFromGlobal()
        {
            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} DiscountsService GetListOfDiscountSecuritiesFromGlobal Called");

            SecuritysListResponse result = GetListOfDiscountSecurities();
            return result;
        }

        public SecuritysListResponse GetListOfDiscountSecuritiesFromMarginTemplate(string template)
        {
            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} DiscountsService GetListOfDiscountSecuritiesFromMarginTemplate " +
                $"{template} Called");

            SecuritysListResponse result = GetListOfDiscountSecurities(template);
            return result;
        }

        private SecuritysListResponse GetListOfDiscountSecurities(string template = "")
        {
            SecuritysListResponse result = new SecuritysListResponse();

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
            IntPtr lsInstrumentsPtr = IntPtr.Zero;
            int getResult = -1;

            if (template == "") // from global
            {
                getResult = NativeMethods.QDAPI_GetInstrumentListFromGlobalSecurityDiscounts(_spotFIRM, ref lsInstrumentsPtr);
            }
            else // from template
            {
                getResult = NativeMethods.QDAPI_GetInstrumentListFromMarginTemplateSecurityDiscounts(_spotFIRM, template, 0, ref lsInstrumentsPtr);
            }

            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} DiscountsService GetListOfDiscountSecurities " +
                $" {template} result is: {getResult}");

            if (getResult == 0)//если успешно
            {
                QDAPI_ArrayStrings lsInstruments = Marshal.PtrToStructure<QDAPI_ArrayStrings>(lsInstrumentsPtr);
                IntPtr[] instrumentsArray = new IntPtr[lsInstruments.count];
                Marshal.Copy(lsInstruments.elems, instrumentsArray, 0, (int)lsInstruments.count);

                for (uint i = 0; i < lsInstruments.count; i++)
                {
                    if (Marshal.PtrToStringAnsi(instrumentsArray[i]) != null)
                    {
                        result.Securitys.Add(Marshal.PtrToStringAnsi(instrumentsArray[i]));
                    }
                }
            }
            NativeMethods.QDAPI_FreeMemory(ref lsInstrumentsPtr);            

            // закрываем соединение
            ListStringResponseModel closeResult = _connection.CloseQuikAPI(getResult, _spotFIRM, response);
            result.IsSuccess = closeResult.IsSuccess;
            result.Messages.AddRange(closeResult.Messages);
            return result;
        }

        public ListStringResponseModel DeleteSingleDiscountFromGlobal(string security)
        {
            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} DiscountsService DeleteSingleDiscountFromGlobal Called " +
                $"for {security}");

            ListStringResponseModel response = DeleteSingleDiscount(security);
            return response;
        }

        public ListStringResponseModel DeleteSingleDiscountFromMarginTemplate(string template, string security)
        {
            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} DiscountsService DeleteSingleDiscountFromMarginTemplate Called " +
                $"for {template} {security}");

            ListStringResponseModel response = DeleteSingleDiscount(security, template);
            return response;
        }

        private ListStringResponseModel DeleteSingleDiscount(string security, string template = "")
        {
            ListStringResponseModel response = new ListStringResponseModel();

            ListStringResponseModel openResult = _connection.OpenQuikQadminApiToWrite(_spotFIRM, response);
            if (!openResult.IsSuccess)
            {
                return response;
            }

            // set
            int resultEditBrl = -1;
            if (template != "") // delete from template
            {
                resultEditBrl = NativeMethods.QDAPI_RemoveSecurityDiscountsFromMarginTemplate(_spotFIRM, template, 0, security);
            }
            else // delete from global
            {
                resultEditBrl = NativeMethods.QDAPI_RemoveSecurityDiscountsFromGlobal(_spotFIRM, security);
            }
            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} DiscountsService DeleteSingleDiscount " +
                $" {template} {security} result is: {resultEditBrl}");

            // close connection
            return _connection.CloseQuikAPI(resultEditBrl, _spotFIRM, response);
        }

        public DiscountValuesListResponse GetListOfDiscountValuesFromGlobal(DiscountValuesListResponse result, List<string> securitys)
        {
            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} DiscountsService GetListOfDiscountValuesFromGlobal Called");

            result = GetListOfDiscountValues(result, securitys, "");
            return result;
        }
        public DiscountValuesListResponse GetListOfDiscountValuesFromMarginTemplate(string template, DiscountValuesListResponse result, List<string> securitys)
        {
            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} DiscountsService GetListOfDiscountValuesFromMarginTemplate {template} Called");

            result = GetListOfDiscountValues(result, securitys, template);
            return result;
        }

        private DiscountValuesListResponse GetListOfDiscountValues(DiscountValuesListResponse result, IEnumerable<string> securitys, string template)
        {
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
            foreach (string security in securitys) 
            {
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
                    DiscountAndSecurityModel newDiscount = new DiscountAndSecurityModel();
                    DiscountModel discountValues = new DiscountModel();
                    newDiscount.Security = security;
                    discountValues.KShort = discounts.KShort;
                    discountValues.KLong = discounts.KLong;
                    discountValues.DShort = discounts.DShort;
                    discountValues.DLong = discounts.DLong;
                    discountValues.DShort_min = discounts.DShort_min;
                    discountValues.DLong_min= discounts.DLong_min;

                    newDiscount.Discount = discountValues;
                    result.Discounts.Add(newDiscount);
                }
                else
                {
                    if (getResult == 1015) // нет тьакого шаблона, прерываем выполнение
                    {
                        break;
                    }

                    result.Messages.Add($"For {security} discount values result is {getResult}");
                }
            }

            // если не нашли какую то бумагу - ну и фиг с ней. В остальных случаях успешность убирается.
            if (getResult == 1004)
            {
                getResult = 0;
            }

            // закрываем соединение
            ListStringResponseModel closeResult = _connection.CloseQuikAPI(getResult, _spotFIRM, response);
            result.IsSuccess = closeResult.IsSuccess;
            result.Messages.AddRange(closeResult.Messages);
            return result;
        }
    }
}
