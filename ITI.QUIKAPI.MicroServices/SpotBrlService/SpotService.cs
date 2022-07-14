using DataAbstraction.Interfaces;
using QDealerAPI;
using DataAbstraction.Models;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using System.Runtime.InteropServices;
using DataAbstraction.Models.Connections;

namespace QuikAPIBrlService
{
    public class SpotService : ISpotBrlService
    {        
        private const string _spotFIRM = "MC0138200000";
        private QadminLogon _logon;
        private ILogger<SpotService> _logger;
        IQuikApiConnectionService _connection;

        public SpotService(IOptions<QadminLogon> logon, ILogger<SpotService> logger, IQuikApiConnectionService connection)
        {
            _logon = logon.Value;
            _logger = logger;
            _connection = connection;
        }


        public string GetLogin()
        {
            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} SpotService GetLogin Called");
            return _logon.Login;
        }

        public ListStringResponseModel CheckConnection()
        {
            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} SpotService CheckConnection Called");
            ListStringResponseModel response = new ListStringResponseModel();

            var openResult = _connection.OpenQuikQadminApiToRead(_spotFIRM, response);
            if (!openResult.IsSuccess)
            {
                return response;
            }

            return _connection.CloseQuikAPI(0, _spotFIRM, response);
        }

        public ListStringResponseModel GetList(bool itIsTemplatesList, bool itIsPoKomissii, string template)
        {
            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} SpotService GetList Called, itIsTemplatesList={itIsTemplatesList}, itIsPoKomissii={itIsPoKomissii}, template={template}");
            ListStringResponseModel response = new ListStringResponseModel();

            var openResult = _connection.OpenQuikQadminApiToRead(_spotFIRM, response);
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
                    NativeMethods.QDAPI_GetListOfClientTemplates(_spotFIRM, ref clPtr);
                }
                else
                {
                    //Получение списка всех шаблонов «По плечу».
                    NativeMethods.QDAPI_GetListOfMarginTemplates(_spotFIRM, ref clPtr);
                }
            }
            else
            {
                if (itIsPoKomissii)
                {
                    //получения полного списка клиентов в клиентском шаблоне "По комиссии"
                    NativeMethods.QDAPI_GetClientsListOfClientTemplate(_spotFIRM, template, ref clPtr);
                }
                else
                {
                    //получение полного списка клиентов в маржинальном шаблоне "по Плечу"
                    NativeMethods.QDAPI_GetClientsListOfMarginTemplate(_spotFIRM, template, ref clPtr);
                }
            }

            if (clPtr != IntPtr.Zero)
            {
                QDAPI_ArrayStrings resultArrStr = Marshal.PtrToStructure<QDAPI_ArrayStrings>(clPtr);

                _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} SpotService GetList result count : {resultArrStr.count}");

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
                response.Messages.Add($"SpotService GetList Failed: Template {template} not found");
            }

            return _connection.CloseQuikAPI(0, _spotFIRM, response);
        }
        public ListStringResponseModel MoveMatrixClientCodeBetweenTemplates(bool itIsPoKomissii, MoveMatrixCodeModel moveModel)
        {
            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} SpotService MoveMatrixClientCodeBetweenTemplates Called {moveModel.FromTemplate}->{moveModel.ToTemplate} {moveModel.MatrixClientPortfolio}" +
                $" itIsTemplatesList={itIsPoKomissii}");

            MoveQuikCodeModel moveQuikModel = new MoveQuikCodeModel();
            moveQuikModel.FromTemplate = moveModel.FromTemplate;
            moveQuikModel.ToTemplate = moveModel.ToTemplate;
            moveQuikModel.QuikClientCode = CommonServices.PortfoliosConvertingService.GetQuikSpotPortfolio(moveModel.MatrixClientPortfolio);
            if (moveModel.MatrixClientPortfolio.Contains("-CD-"))
            {
                moveQuikModel.QuikClientCode = CommonServices.PortfoliosConvertingService.GetQuikCdPortfolio(moveModel.MatrixClientPortfolio);
            }

            return MoveQuikClientCodeBetweenTemplates(itIsPoKomissii, moveQuikModel);
        }
        public ListStringResponseModel MoveQuikClientCodeBetweenTemplates(bool itIsPoKomissii, MoveQuikCodeModel moveModel)
        {
            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} SpotService MoveQuikClientCodeBetweenTemplates Called {moveModel.FromTemplate}->{moveModel.ToTemplate} {moveModel.QuikClientCode}" +
                $" itIsTemplatesList={itIsPoKomissii}");
            ListStringResponseModel response = new ListStringResponseModel();

            var openResult = _connection.OpenQuikQadminApiToWrite(_spotFIRM, response);
            if (!openResult.IsSuccess)
            {
                return response;
            }

            int resultEditBrl = -1;
            if (itIsPoKomissii)
            {
                //перемещения кода клиента из одного шаблона «По комиссии». в другой  шаблон «По комиссии».
                resultEditBrl = NativeMethods.QDAPI_MoveClientBetweenClientTemplates(_spotFIRM, moveModel.FromTemplate, moveModel.ToTemplate, moveModel.QuikClientCode);
            }
            else
            {
                //перемещение кода клиента из одного шаблона "по Плечу" в другой  шаблон "по Плечу".
                resultEditBrl = NativeMethods.QDAPI_MoveClientBetweenMarginTemplates(_spotFIRM, moveModel.FromTemplate, moveModel.ToTemplate, moveModel.QuikClientCode);
            }


            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} MoveQuikClientCodeBetweenTemplates result is: {resultEditBrl}");

            return _connection.CloseQuikAPI(resultEditBrl, _spotFIRM, response);
        }

        public ListStringResponseModel ReplaceAllCodesInTemplate(bool itIsPoKomissii, TemplateAndMatrixCodesModel model)
        {
            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} SpotService ReplaceAllCodesInTemplate Called for {model.Template}, itIsPoKomissii={itIsPoKomissii}");

            // переделаем коды на QUIK формат
            for (int i = 0; i < model.MatrixClientPortfolio.Length; i++)
            {
                if (model.MatrixClientPortfolio[i].MatrixClientPortfolio.Contains("CD"))
                {
                    model.MatrixClientPortfolio[i].MatrixClientPortfolio = CommonServices.PortfoliosConvertingService.GetQuikCdPortfolio(model.MatrixClientPortfolio[i].MatrixClientPortfolio);
                }
                else
                {
                    model.MatrixClientPortfolio[i].MatrixClientPortfolio = CommonServices.PortfoliosConvertingService.GetQuikSpotPortfolio(model.MatrixClientPortfolio[i].MatrixClientPortfolio);
                }
            }

            ListStringResponseModel response = new ListStringResponseModel();

            var openResult = _connection.OpenQuikQadminApiToWrite(_spotFIRM, response);
            if (!openResult.IsSuccess)
            {
                return response;
            }            

            QDAPI_ArrayStrings clStruct = new QDAPI_ArrayStrings
            {
                count = (uint)model.MatrixClientPortfolio.Length,
                elems = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(IntPtr)) * model.MatrixClientPortfolio.Length)
            };
            IntPtr[] clPtrArray = new IntPtr[model.MatrixClientPortfolio.Length];
            for (int i = 0; i < model.MatrixClientPortfolio.Length; ++i)
            {
                clPtrArray[i] = Marshal.StringToHGlobalAnsi(model.MatrixClientPortfolio[i].MatrixClientPortfolio);
            }
            Marshal.Copy(clPtrArray, 0, clStruct.elems, clPtrArray.Length);

            int resultEditBrl = -1;
            if (itIsPoKomissii)
            {
                //изменения полного списка клиентов в клиентском шаблоне «По комиссии».
                resultEditBrl = NativeMethods.QDAPI_SetClientsListOfClientTemplate(_spotFIRM, model.Template, ref clStruct);
            }
            else
            {
                //изменения полного списка клиентов в маржинальном шаблоне  "по Плечу"
                resultEditBrl = NativeMethods.QDAPI_SetClientsListOfMarginTemplate(_spotFIRM, model.Template, ref clStruct);
            }

            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} ReplaceAllCodesInTemplate result is: {resultEditBrl}");

            Marshal.FreeHGlobal(clStruct.elems);
            for (int i = 0; i < clPtrArray.Length; ++i)
            {
                Marshal.FreeHGlobal(clPtrArray[i]);
            }

            return _connection.CloseQuikAPI(resultEditBrl, _spotFIRM, response);
        }

        public ListStringResponseModel DeleteCodeFromTemplate(bool itIsPoKomissii, string template, string clientCode, bool needToConvertCode)
        {
            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} SpotService DeleteCode {clientCode} FromTemplate {template} Called, " +
                $"poKomissii={itIsPoKomissii}, needConvertCodeToQuik={needToConvertCode}");

            // если прислан код матрицы - преобразовать в формат Quik
            string quikCode = clientCode;
            if (needToConvertCode)
            {
                quikCode = CommonServices.PortfoliosConvertingService.GetQuikSpotPortfolio(clientCode);

                if (clientCode.Contains("-CD-"))
                {
                    quikCode = CommonServices.PortfoliosConvertingService.GetQuikCdPortfolio(clientCode);
                }
            }          

            ListStringResponseModel response = new ListStringResponseModel();

            // открыть соединение
            var openResult = _connection.OpenQuikQadminApiToWrite(_spotFIRM, response);
            if (!openResult.IsSuccess)
            {
                return response;
            }

            //выполнить работу
            int resultEditBrl = -1;
            if (itIsPoKomissii)
            {
                //удаления одного кода клиента из шаблона  "по Комиссии"
                resultEditBrl = NativeMethods.QDAPI_RemoveClientFromClientTemplate(_spotFIRM, template, quikCode);
            }
            else
            {
                //удаления одного кода клиента из шаблона  "по Плечу"
                resultEditBrl = NativeMethods.QDAPI_RemoveClientFromMarginTemplate(_spotFIRM, template, quikCode);
            }

            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} Delete result is: {resultEditBrl}");

            //закрыть соединение
            return _connection.CloseQuikAPI(resultEditBrl, _spotFIRM, response);
        }

        public ListStringResponseModel AddClientPortfolioToTemplate(bool itIsPoKomissii, string template, string clientCode)
        {
            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} SpotService AddClientPortfolioToTemplate {clientCode} to {template} Called, poKomissii={itIsPoKomissii}");

            // код матрицы - преобразовать в формат Quik
            string quikCode = CommonServices.PortfoliosConvertingService.GetQuikSpotPortfolio(clientCode);
            if (clientCode.Contains("-CD-"))
            {
                quikCode = CommonServices.PortfoliosConvertingService.GetQuikCdPortfolio(clientCode);
            }

            ListStringResponseModel response = new ListStringResponseModel();

            // открыть соединение
            var openResult = _connection.OpenQuikQadminApiToWrite(_spotFIRM, response);
            if (!openResult.IsSuccess)
            {
                return response;
            }

            //выполнить работу
            int resultEditBrl = -1;
            if (itIsPoKomissii)
            {
                //добавление одного кода клиента в клиентский шаблон «По комиссии».
                resultEditBrl = NativeMethods.QDAPI_AddClientToClientTemplate(_spotFIRM, template, quikCode);
            }
            else
            {
                //добавление одного кода клиента в маржинальный шаблон "по Плечу"
                resultEditBrl = NativeMethods.QDAPI_AddClientToMarginTemplate(_spotFIRM, template, quikCode);
            }

            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} AddClientPortfolioToTemplate result is: {resultEditBrl}");

            //закрыть соединение
            return _connection.CloseQuikAPI(resultEditBrl, _spotFIRM, response);
        }

    }
}