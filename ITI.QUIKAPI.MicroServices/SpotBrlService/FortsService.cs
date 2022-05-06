using DataAbstraction.Interfaces;
using QDealerAPI;
using DataAbstraction.Models;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using System.Runtime.InteropServices;
using DataAbstraction.Models.Connections;

namespace QuikAPIBrlService
{
    public class FortsService : IFortsBrlService
    {
        private const string _fortsFIRM = "SPBFUT";
        private QadminLogon _logon;
        private ILogger<SpotService> _logger;
        IQuikApiConnectionService _connection;

        public FortsService(IOptions<QadminLogon> logon, ILogger<SpotService> logger, IQuikApiConnectionService connection)
        {
            _logon = logon.Value;
            _logger = logger;
            _connection = connection;
        }


        public string GetLogin()
        {
            _logger.LogInformation("FortsService GetLogin Called");
            return _logon.Login;
        }

        public ListStringResponseModel CheckConnection()
        {
            _logger.LogInformation("FortsService CheckConnection Called");
            ListStringResponseModel response = new ListStringResponseModel();

            var openResult = _connection.OpenQuikQadminApiToRead(_fortsFIRM, response);
            if (!openResult.IsSuccess)
            {
                return response;
            }

            return _connection.CloseQuikAPI(0, _fortsFIRM, response);
        }

        public ListStringResponseModel GetList(bool itIsTemplatesList, bool itIsPoKomissii, string template)
        {
            _logger.LogInformation($"FortsService GetList Called, itIsTemplatesList={itIsTemplatesList}, itIsPoKomissii={itIsPoKomissii}, template={template}");
            ListStringResponseModel response = new ListStringResponseModel();

            var openResult = _connection.OpenQuikQadminApiToRead(_fortsFIRM, response);
            if (!openResult.IsSuccess)
            {
                return response;
            }

            IntPtr clPtr = IntPtr.Zero;

            if (itIsTemplatesList)
            {
                if (itIsPoKomissii)
                {
                    //получения списка всех шаблонов «По комиссии».
                    NativeMethods.QDAPI_GetListOfClientTemplates(_fortsFIRM, ref clPtr);
                }
                else
                {
                    //Получение списка всех шаблонов «По плечу».
                    NativeMethods.QDAPI_GetListOfMarginTemplates(_fortsFIRM, ref clPtr);
                }
            }
            else
            {
                if (itIsPoKomissii)
                {
                    //получения полного списка клиентов в клиентском шаблоне "По комиссии"
                    NativeMethods.QDAPI_GetClientsListOfClientTemplate(_fortsFIRM, template, ref clPtr);
                }
                else
                {
                    //получение полного списка клиентов в маржинальном шаблоне "по Плечу"
                    NativeMethods.QDAPI_GetClientsListOfMarginTemplate(_fortsFIRM, template, ref clPtr);
                }
            }

            if (clPtr != IntPtr.Zero)
            {
                QDAPI_ArrayStrings resultArrStr = Marshal.PtrToStructure<QDAPI_ArrayStrings>(clPtr);

                _logger.LogInformation($"FortsService GetList result count : {resultArrStr.count}");

                IntPtr[] resultArray = new IntPtr[resultArrStr.count];
                Marshal.Copy(resultArrStr.elems, resultArray, 0, (int)resultArrStr.count);

                for (uint i = 0; i < resultArrStr.count; ++i)
                {
                    var code = Marshal.PtrToStringAnsi(resultArray[i]);
                    response.Messages.Add(code);
                }
                NativeMethods.QDAPI_FreeMemory(ref clPtr);
            }
            else
            {
                response.IsSuccess = false;
                response.Messages.Add($"FortsService GetList Failed: Template {template} not found");
            }

            return _connection.CloseQuikAPI(0, _fortsFIRM, response);
        }
    }
}
