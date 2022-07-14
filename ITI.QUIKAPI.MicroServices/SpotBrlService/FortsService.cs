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
            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} FortsService GetLogin Called");
            return _logon.Login;
        }

        public ListStringResponseModel CheckConnection()
        {
            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} FortsService CheckConnection Called");
            ListStringResponseModel response = new ListStringResponseModel();

            // открыть соединение
            var openResult = _connection.OpenQuikQadminApiToRead(_fortsFIRM, response);
            if (!openResult.IsSuccess)
            {
                return response;
            }

            //закрыть соединение
            return _connection.CloseQuikAPI(0, _fortsFIRM, response);
        }

        public ListStringResponseModel GetList(bool itIsTemplatesList, bool itIsPoKomissii, string template)
        {
            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} FortsService GetList Called, itIsTemplatesList={itIsTemplatesList}, itIsPoKomissii={itIsPoKomissii}, template={template}");
            ListStringResponseModel response = new ListStringResponseModel();

            // открыть соединение
            var openResult = _connection.OpenQuikQadminApiToRead(_fortsFIRM, response);
            if (!openResult.IsSuccess)
            {
                return response;
            }

            //выполнить работу
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

                _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} FortsService GetList result count : {resultArrStr.count}");

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

            //закрыть соединение
            return _connection.CloseQuikAPI(0, _fortsFIRM, response);
        }

        public ListStringResponseModel AddFortsCodeToTemplate(bool itIsPoKomissii, string template, string clientCode)
        {
            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} FortsService AddFortsCodeToTemplate {clientCode} to {template} Called, poKomissii={itIsPoKomissii}");

            //// код матрицы - преобразовать в формат Quik
            string quikCode = CommonServices.PortfoliosConvertingService.GetQuikFortsCode(clientCode);

            ListStringResponseModel response = new ListStringResponseModel();

            // открыть соединение
            var openResult = _connection.OpenQuikQadminApiToWrite(_fortsFIRM, response);
            if (!openResult.IsSuccess)
            {
                return response;
            }

            //выполнить работу
            int resultEditBrl = -1;
            if (itIsPoKomissii)
            {
                //добавление одного кода клиента в клиентский шаблон «По комиссии».
                resultEditBrl = NativeMethods.QDAPI_AddClientToClientTemplate(_fortsFIRM, template, quikCode);
            }
            else
            {
                //добавление одного кода клиента в маржинальный шаблон "по Плечу"
                resultEditBrl = NativeMethods.QDAPI_AddClientToMarginTemplate(_fortsFIRM, template, quikCode);
            }

            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} FortsService AddFortsCodeToTemplate result is: {resultEditBrl}");

            //закрыть соединение
            return _connection.CloseQuikAPI(resultEditBrl, _fortsFIRM, response);
        }

        public ListStringResponseModel DeleteCodeFromTemplate(bool itIsPoKomissii, string template, string clientCode, bool needToConvertCode)
        {
            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} FortsService DeleteCode {clientCode} FromTemplate {template} Called, " +
                $"poKomissii={itIsPoKomissii}, needConvertCodeToQuik={needToConvertCode}");

            // если прислан код матрицы - преобразовать в формат Quik
            string quikCode = clientCode;
            if (needToConvertCode)
            {
                quikCode = CommonServices.PortfoliosConvertingService.GetQuikFortsCode(clientCode);
            }

            ListStringResponseModel response = new ListStringResponseModel();

            // открыть соединение
            var openResult = _connection.OpenQuikQadminApiToWrite(_fortsFIRM, response);
            if (!openResult.IsSuccess)
            {
                return response;
            }

            //выполнить работу
            int resultEditBrl = -1;
            if (itIsPoKomissii)
            {
                //удаления одного кода клиента из шаблона  "по Комиссии"
                resultEditBrl = NativeMethods.QDAPI_RemoveClientFromClientTemplate(_fortsFIRM, template, quikCode);
            }
            else
            {
                //удаления одного кода клиента из шаблона  "по Плечу"
                resultEditBrl = NativeMethods.QDAPI_RemoveClientFromMarginTemplate(_fortsFIRM, template, quikCode);
            }

            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} FortsService DeleteCode result is: {resultEditBrl}");

            //закрыть соединение
            return _connection.CloseQuikAPI(resultEditBrl, _fortsFIRM, response);
        }

        public ListStringResponseModel MoveMatrixFortsCodeBetweenTemplates(bool itIsPoKomissii, MoveMatrixFortsCodeModel moveModel)
        {
            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} SpotService MoveMatrixFortsCodeBetweenTemplates Called {moveModel.FromTemplate}->{moveModel.ToTemplate} {moveModel.FortsClientCode}" +
                $" itIsTemplatesList={itIsPoKomissii}");
            ListStringResponseModel response = new ListStringResponseModel();

            // код матрицы - преобразовать в формат Quik
            string quikCode = CommonServices.PortfoliosConvertingService.GetQuikFortsCode(moveModel.FortsClientCode);

            // открыть соединение
            var openResult = _connection.OpenQuikQadminApiToWrite(_fortsFIRM, response);
            if (!openResult.IsSuccess)
            {
                return response;
            }

            //выполнить работу
            int resultEditBrl = -1;
            if (itIsPoKomissii)
            {
                //перемещения кода клиента из одного шаблона «По комиссии». в другой  шаблон «По комиссии».
                resultEditBrl = NativeMethods.QDAPI_MoveClientBetweenClientTemplates(_fortsFIRM, moveModel.FromTemplate, moveModel.ToTemplate, quikCode);
            }
            else
            {
                //перемещение кода клиента из одного шаблона "по Плечу" в другой  шаблон "по Плечу".
                resultEditBrl = NativeMethods.QDAPI_MoveClientBetweenMarginTemplates(_fortsFIRM, moveModel.FromTemplate, moveModel.ToTemplate, quikCode);
            }
            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} MoveMatrixFortsCodeBetweenTemplates result is: {resultEditBrl}");
            
            //закрыть соединение
            return _connection.CloseQuikAPI(resultEditBrl, _fortsFIRM, response);
        }


        public ListStringResponseModel ReplaceAllMatrixFortsCodesInTemplate(bool itIsPoKomissii, TemplateAndMatrixFortsCodesModel model)
        {
            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} SpotService ReplaceAllMatrixFortsCodesInTemplate Called for {model.Template}, itIsPoKomissii={itIsPoKomissii}");

            // код матрицы - преобразовать в формат Quik
            for (int i = 0; i < model.FortsClientCodes.Length; i++)
            {
                model.FortsClientCodes[i].FortsClientCode = CommonServices.PortfoliosConvertingService.GetQuikFortsCode(model.FortsClientCodes[i].FortsClientCode);
            }

            ListStringResponseModel response = new ListStringResponseModel();

            // открыть соединение
            var openResult = _connection.OpenQuikQadminApiToWrite(_fortsFIRM, response);
            if (!openResult.IsSuccess)
            {
                return response;
            }

            //выполнить работу
            QDAPI_ArrayStrings clStruct = new QDAPI_ArrayStrings
            {
                count = (uint)model.FortsClientCodes.Length,
                elems = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(IntPtr)) * model.FortsClientCodes.Length)
            };
            IntPtr[] clPtrArray = new IntPtr[model.FortsClientCodes.Length];
            for (int i = 0; i < model.FortsClientCodes.Length; ++i)
            {
                clPtrArray[i] = Marshal.StringToHGlobalAnsi(model.FortsClientCodes[i].FortsClientCode);
            }
            Marshal.Copy(clPtrArray, 0, clStruct.elems, clPtrArray.Length);

            int resultEditBrl = -1;
            if (itIsPoKomissii)
            {
                //изменения полного списка клиентов в клиентском шаблоне «По комиссии».
                resultEditBrl = NativeMethods.QDAPI_SetClientsListOfClientTemplate(_fortsFIRM, model.Template, ref clStruct);
            }
            else
            {
                //изменения полного списка клиентов в маржинальном шаблоне  "по Плечу"
                resultEditBrl = NativeMethods.QDAPI_SetClientsListOfMarginTemplate(_fortsFIRM, model.Template, ref clStruct);
            }

            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} ReplaceAllMatrixFortsCodesInTemplate result is: {resultEditBrl}");

            Marshal.FreeHGlobal(clStruct.elems);
            for (int i = 0; i < clPtrArray.Length; ++i)
            {
                Marshal.FreeHGlobal(clPtrArray[i]);
            }

            //закрыть соединение
            return _connection.CloseQuikAPI(resultEditBrl, _fortsFIRM, response);
        }

    }
}
