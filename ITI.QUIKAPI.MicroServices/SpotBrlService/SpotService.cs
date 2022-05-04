using DataAbstraction.Interfaces;
using QDealerAPI;
using DataAbstraction.Models;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using System.Runtime.InteropServices;
using DataAbstraction.Models.Connections;

namespace SpotBrlService
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

        public ListStringResponseModel AddClientPortfolioToKomissiiCDportfolio(string quikportfolio)
        {
            _logger.LogInformation($"SpotService AddClientPortfolioToKomissiiCDportfolio {quikportfolio} Called");
            return AddClientToClientTemplate("CD_portfolio", quikportfolio);
        }
        public ListStringResponseModel AddClientPortfolioToKomissiiTemplate(string template, string quikportfolio)
        {
            _logger.LogInformation($"SpotService AddClientPortfolioToKomissiiTemplate Called {template} {quikportfolio}");
            return AddClientToClientTemplate(template, quikportfolio);
        }
        private ListStringResponseModel AddClientToClientTemplate(string template, string quikportfolio)
        {
            ListStringResponseModel response = new ListStringResponseModel();

            var openResult = _connection.OpenQuikQadminApiToWrite(_spotFIRM);
            if (!openResult.Equals("OK"))
            {
                response.IsSuccess = false;
                response.Messages.Add($"SpotService AddClientToClientTemplate Failed: OpenBRL error {openResult}");
                return response;
            }
            //добавление одного кода клиента в клиентский шаблон «По комиссии».
            int resultEditBrl = NativeMethods.QDAPI_AddClientToClientTemplate(_spotFIRM, template, quikportfolio);
            _logger.LogInformation($"Insert result is: {resultEditBrl}");

            return _connection.CloseQuikAPI(resultEditBrl, _spotFIRM, response);
            //if (resultEditBrl != 0)
            //{
            //    response.IsSuccess = false;
            //    response.Messages.Add($"Error! AddClientToClientTemplate result is: {resultEditBrl}");
            //}
            //else
            //{
            //    response.Messages.Add($"OK. AddClientToClientTemplate result is: {resultEditBrl}");
            //}

            //string close = _connection.CloseQuikAPI(resultEditBrl, _spotFIRM);
            //if (!close.Equals("OK"))
            //{
            //    response.IsSuccess = false;
            //    response.Messages.Add(close);
            //}

            //return response;
        }

        public ListStringResponseModel AddClientPortfolioToLeverageCDportfolio(string quikportfolio)
        {
            _logger.LogInformation($"SpotService AddClientPortfolioToLeverageCDportfolio {quikportfolio} Called");
            return AddPortfolioLeverageTemplate("CD_portfolio", quikportfolio);
        }

        public ListStringResponseModel AddClientPortfolioToLeverageTemplate(string template, string quikportfolio)
        {
            _logger.LogInformation($"SpotService AddClientPortfolioToKomissiiTemplate Called {template} {quikportfolio}");
            return AddPortfolioLeverageTemplate(template, quikportfolio);
        }

        private ListStringResponseModel AddPortfolioLeverageTemplate(string template, string quikportfolio)
        {
            ListStringResponseModel response = new ListStringResponseModel();

            var openResult = _connection.OpenQuikQadminApiToWrite(_spotFIRM);
            if (!openResult.Equals("OK"))
            {
                response.IsSuccess = false;
                response.Messages.Add($"SpotService AddPortfolioLeverageTemplate Failed: OpenBRL error {openResult}");
                return response;
            }

            //добавление одного кода клиента в маржинальный шаблон "по Плечу"
            int resultEditBrl = NativeMethods.QDAPI_AddClientToMarginTemplate(_spotFIRM, template, quikportfolio);
            _logger.LogInformation($"Insert result is: {resultEditBrl}");

            return _connection.CloseQuikAPI(resultEditBrl, _spotFIRM, response);
            //if (resultEditBrl != 0)
            //{
            //    response.IsSuccess = false;
            //    response.Messages.Add($"Error! DeleteCodeFromTemplatePoKomissii result is: {resultEditBrl}");
            //}
            //else
            //{
            //    response.Messages.Add($"OK. DeleteCodeFromTemplatePoKomissii result is: {resultEditBrl}");
            //}

            //string close = _connection.CloseQuikAPI(resultEditBrl, _spotFIRM);
            //if (!close.Equals("OK"))
            //{
            //    response.IsSuccess = false;
            //    response.Messages.Add(close);
            //}

            //return response;
        }

        public string GetLogin()
        {
            _logger.LogInformation("SpotService GetLogin Called");
            return _logon.Login;
        }

        public ListStringResponseModel CheckConnection()
        {
            _logger.LogInformation("SpotService CheckConnection Called");
            ListStringResponseModel response = new ListStringResponseModel();

            var openResult = _connection.OpenQuikQadminApiToRead(_spotFIRM);
            if (!openResult.Equals("OK"))
            {
                response.IsSuccess = false;
                response.Messages.Add($"SpotService CheckConnection Failed: OpenBRL error {openResult}");
                return response;
            }

            return _connection.CloseQuikAPI(0, _spotFIRM, response);

            //string close = _connection.CloseQuikAPI(0, _spotFIRM);
            //if (!close.Equals("OK"))
            //{
            //    response.IsSuccess = false;
            //    response.Messages.Add(close);
            //}

            //return response;
        }

        public ListStringResponseModel GetAllTemplatesPoKomissii()
        {
            _logger.LogInformation($"SpotService GetAllTemplatesPoKomissii Called");
            ListStringResponseModel response = new ListStringResponseModel();

            var openResult = _connection.OpenQuikQadminApiToRead(_spotFIRM);
            if (!openResult.Equals("OK"))
            {
                response.IsSuccess = false;
                response.Messages.Add($"SpotService GetAllTemplatesPoKomissii Failed: OpenBRL error {openResult}");
                return response;
            }

            //получения списка всех шаблонов «По комиссии».
            IntPtr templateListPoComissii = IntPtr.Zero;
            NativeMethods.QDAPI_GetListOfClientTemplates(_spotFIRM, ref templateListPoComissii);
            QDAPI_ArrayStrings templateCodes = Marshal.PtrToStructure<QDAPI_ArrayStrings>(templateListPoComissii);

            _logger.LogInformation($"SpotService GetAllTemplatesKomissii Количество шаблонов по комиссии: {templateCodes.count}");

            IntPtr[] templateCodesArrayComiss = new IntPtr[templateCodes.count];
            Marshal.Copy(templateCodes.elems, templateCodesArrayComiss, 0, (int)templateCodes.count);

            for (uint i = 0; i < templateCodes.count; ++i)
            {
                var templateCode = Marshal.PtrToStringAnsi(templateCodesArrayComiss[i]);
                response.Messages.Add(templateCode);
            }
            NativeMethods.QDAPI_FreeMemory(ref templateListPoComissii);

            return _connection.CloseQuikAPI(0, _spotFIRM, response);

            //string close = _connection.CloseQuikAPI(0, _spotFIRM);
            //if (!close.Equals("OK"))
            //{
            //    response.IsSuccess = false;
            //    response.Messages.Add(close);
            //}

            //return response;
        }

        public ListStringResponseModel GetAllTemplatesPoPlechu()
        {
            _logger.LogInformation($"SpotService GetAllTemplatesPoPlechu Called");
            ListStringResponseModel response = new ListStringResponseModel();

            var openResult = _connection.OpenQuikQadminApiToRead(_spotFIRM);
            if (!openResult.Equals("OK"))
            {
                response.IsSuccess = false;
                response.Messages.Add($"SpotService GetAllTemplatesPoPlechu Failed: OpenBRL error {openResult}");
                return response;
            }

            //Получение списка всех шаблонов «По плечу».
            IntPtr templateListPoPlechu = IntPtr.Zero;
            NativeMethods.QDAPI_GetListOfMarginTemplates(_spotFIRM, ref templateListPoPlechu);
            QDAPI_ArrayStrings templateCodes = Marshal.PtrToStructure<QDAPI_ArrayStrings>(templateListPoPlechu);

            _logger.LogInformation($"SpotService GetAllTemplatesPoPlechu Количество шаблонов по плечу: {templateCodes.count}");

            IntPtr[] templateCodesArray = new IntPtr[templateCodes.count];
            Marshal.Copy(templateCodes.elems, templateCodesArray, 0, (int)templateCodes.count);

            for (uint i = 0; i < templateCodes.count; ++i)
            {
                var templateCode = Marshal.PtrToStringAnsi(templateCodesArray[i]);
                response.Messages.Add(templateCode);
            }
            NativeMethods.QDAPI_FreeMemory(ref templateListPoPlechu);

            return _connection.CloseQuikAPI(0, _spotFIRM, response);

            //string close = _connection.CloseQuikAPI(0, _spotFIRM);
            //if (!close.Equals("OK"))
            //{
            //    response.IsSuccess = false;
            //    response.Messages.Add(close);
            //}

            //return response;
        }

        public ListStringResponseModel GetAllClientsFromTemplatePoKomissii(string templateName)
        {
            _logger.LogInformation($"SpotService GetAllClientsFromTemplatePoKomissii Called " + templateName);
            ListStringResponseModel response = new ListStringResponseModel();

            var openResult = _connection.OpenQuikQadminApiToRead(_spotFIRM);
            if (!openResult.Equals("OK"))
            {
                response.IsSuccess = false;
                response.Messages.Add($"SpotService GetAllClientsFromTemplatePoKomissii Failed: OpenBRL error {openResult}");
                return response;
            }

            //получения полного списка клиентов в клиентском шаблоне "По комиссии"
            IntPtr clPtr = IntPtr.Zero;
            NativeMethods.QDAPI_GetClientsListOfClientTemplate(_spotFIRM, templateName, ref clPtr);
            if (clPtr != IntPtr.Zero)
            {
                QDAPI_ArrayStrings templateComissionClientCodes = Marshal.PtrToStructure<QDAPI_ArrayStrings>(clPtr);

                _logger.LogInformation($"SpotService GetAllClientsFromTemplatePoKomissii клиентов в шаблоне По комиссии {templateName} : {templateComissionClientCodes.count}");

                IntPtr[] templateCDCodesArray = new IntPtr[templateComissionClientCodes.count];
                Marshal.Copy(templateComissionClientCodes.elems, templateCDCodesArray, 0, (int)templateComissionClientCodes.count);

                for (uint i = 0; i < templateComissionClientCodes.count; ++i)
                {
                    var templateCode = Marshal.PtrToStringAnsi(templateCDCodesArray[i]);
                    response.Messages.Add(templateCode);
                }
                NativeMethods.QDAPI_FreeMemory(ref clPtr);
            }
            else
            {
                response.IsSuccess = false;
                response.Messages.Add($"SpotService GetAllClientsFromTemplatePoKomissii Failed: Template {templateName} not found");
            }

            return _connection.CloseQuikAPI(0, _spotFIRM, response);

            //string close = _connection.CloseQuikAPI(0, _spotFIRM);
            //if (!close.Equals("OK"))
            //{
            //    response.IsSuccess = false;
            //    response.Messages.Add(close);
            //}

            //return response;
        }

        public ListStringResponseModel GetAllClientsFromTemplatePoPlechu(string templateName)
        {
            _logger.LogInformation($"SpotService GetAllClientsFromTemplatePoPlechu Called " + templateName);
            ListStringResponseModel response = new ListStringResponseModel();

            var openResult = _connection.OpenQuikQadminApiToRead(_spotFIRM);
            if (!openResult.Equals("OK"))
            {
                response.IsSuccess = false;
                response.Messages.Add($"SpotService GetAllClientsFromTemplatePoPlechu Failed: OpenBRL error {openResult}");
                return response;
            }

            //получение полного списка клиентов в маржинальном шаблоне "по Плечу"
            IntPtr clPtr = IntPtr.Zero;
            NativeMethods.QDAPI_GetClientsListOfMarginTemplate(_spotFIRM, templateName, ref clPtr);

            if (clPtr != IntPtr.Zero)
            {
                QDAPI_ArrayStrings templateComissionClientCodes = Marshal.PtrToStructure<QDAPI_ArrayStrings>(clPtr);

                _logger.LogInformation($"SpotService GetAllClientsFromTemplatePoPlechu клиентов в шаблоне По Плечу {templateName} : {templateComissionClientCodes.count}");

                IntPtr[] templateCDCodesArray = new IntPtr[templateComissionClientCodes.count];
                Marshal.Copy(templateComissionClientCodes.elems, templateCDCodesArray, 0, (int)templateComissionClientCodes.count);

                for (uint i = 0; i < templateComissionClientCodes.count; ++i)
                {
                    var templateCode = Marshal.PtrToStringAnsi(templateCDCodesArray[i]);
                    response.Messages.Add(templateCode);
                }
                NativeMethods.QDAPI_FreeMemory(ref clPtr);
            }
            else
            {
                response.IsSuccess = false;
                response.Messages.Add($"SpotService GetAllClientsFromTemplatePoPlechu Failed: Template {templateName} not found");
            }

            return _connection.CloseQuikAPI(0, _spotFIRM, response);

            //string close = _connection.CloseQuikAPI(0, _spotFIRM);
            //if (!close.Equals("OK"))
            //{
            //    response.IsSuccess = false;
            //    response.Messages.Add(close);
            //}

            //return response;
        }

        public ListStringResponseModel DeleteCodeFromTemplatePoKomissii(TemplateAndQuikCodeModel model)
        {
            _logger.LogInformation($"SpotService DeleteCodeFromTemplatePoKomissii Called {model.Template} {model.ClientCode}");
            ListStringResponseModel response = new ListStringResponseModel();

            var openResult = _connection.OpenQuikQadminApiToWrite(_spotFIRM);
            if (!openResult.Equals("OK"))
            {
                response.IsSuccess = false;
                response.Messages.Add($"SpotService DeleteCodeFromTemplatePoKomissii Failed: OpenBRL error {openResult}");
                return response;
            }
            //удаления одного кода клиента из шаблона  "по Комиссии"
            int resultEditBrl = NativeMethods.QDAPI_RemoveClientFromClientTemplate(_spotFIRM, model.Template, model.ClientCode);
            _logger.LogInformation($"Delete result is: {resultEditBrl}");

            return _connection.CloseQuikAPI(resultEditBrl, _spotFIRM, response);

            //if (resultEditBrl != 0)
            //{
            //    response.IsSuccess = false;
            //    response.Messages.Add($"Error! DeleteCodeFromTemplatePoKomissii result is: {resultEditBrl}");
            //}
            //else
            //{
            //    response.Messages.Add($"OK. DeleteCodeFromTemplatePoKomissii result is: {resultEditBrl}");
            //}

            //string close = _connection.CloseQuikAPI(resultEditBrl, _spotFIRM);
            //if (!close.Equals("OK"))
            //{
            //    response.IsSuccess = false;
            //    response.Messages.Add(close);
            //}

            //return response;
        }

        public ListStringResponseModel DeleteCodeFromTemplatePoPlechu(TemplateAndQuikCodeModel model)
        {
            _logger.LogInformation($"SpotService DeleteCodeFromTemplatePoPlechu Called {model.Template} {model.ClientCode}");
            ListStringResponseModel response = new ListStringResponseModel();

            var openResult = _connection.OpenQuikQadminApiToWrite(_spotFIRM);
            if (!openResult.Equals("OK"))
            {
                response.IsSuccess = false;
                response.Messages.Add($"SpotService DeleteCodeFromTemplatePoPlechu Failed: OpenBRL error {openResult}");
                return response;
            }
            //удаления одного кода клиента из шаблона  "по Плечу"
            int resultEditBrl = NativeMethods.QDAPI_RemoveClientFromMarginTemplate(_spotFIRM, model.Template, model.ClientCode);
            _logger.LogInformation($"Delete result is: {resultEditBrl}");

            return _connection.CloseQuikAPI(resultEditBrl, _spotFIRM, response);
            //if (resultEditBrl != 0)
            //{
            //    response.IsSuccess = false;
            //    response.Messages.Add($"Error! DeleteCodeFromTemplatePoPlechu result is: {resultEditBrl}");
            //}
            //else
            //{
            //    response.Messages.Add($"OK. DeleteCodeFromTemplatePoPlechu result is: {resultEditBrl}");
            //}

            //string close = _connection.CloseQuikAPI(resultEditBrl, _spotFIRM);
            //if (!close.Equals("OK"))
            //{
            //    response.IsSuccess = false;
            //    response.Messages.Add(close);
            //}

            //return response;
        }

        public ListStringResponseModel MoveClientCodeBetweenTemplatesPoKomissii(MoveCodeModel moveModel)
        {
            _logger.LogInformation($"SpotService MoveClientCodeBetweenTemplatesPoKomissii Called {moveModel.FromTemplate}->{moveModel.ToTemplate} {moveModel.ClientCode}");
            ListStringResponseModel response = new ListStringResponseModel();

            var openResult = _connection.OpenQuikQadminApiToWrite(_spotFIRM);
            if (!openResult.Equals("OK"))
            {
                response.IsSuccess = false;
                response.Messages.Add($"SpotService MoveClientCodeBetweenTemplatesPoKomissii Failed: OpenBRL error {openResult}");
                return response;
            }

            //перемещения кода клиента из одного шаблона «По комиссии». в другой  шаблон «По комиссии».
            int resultEditBrl = NativeMethods.QDAPI_MoveClientBetweenClientTemplates(_spotFIRM, moveModel.FromTemplate, moveModel.ToTemplate, moveModel.ClientCode);
            _logger.LogInformation($"MoveClientCodeBetweenTemplatesPoKomissii result is: {resultEditBrl}");

            return _connection.CloseQuikAPI(resultEditBrl, _spotFIRM, response);

            //if (resultEditBrl != 0)
            //{
            //    response.IsSuccess = false;
            //    response.Messages.Add($"Error! MoveClientCodeBetweenTemplatesPoKomissii result is: {resultEditBrl}");
            //}
            //else
            //{
            //    response.Messages.Add($"OK. MoveClientCodeBetweenTemplatesPoKomissii result is: {resultEditBrl}");
            //}

            //string close = _connection.CloseQuikAPI(resultEditBrl, _spotFIRM);
            //if (!close.Equals("OK"))
            //{
            //    response.IsSuccess = false;
            //    response.Messages.Add(close);
            //}

            //return response;
        }

        public ListStringResponseModel MoveClientCodeBetweenTemplatesPoPlechu(MoveCodeModel moveModel)
        {
            _logger.LogInformation($"SpotService MoveClientCodeBetweenTemplatesPoPlechu Called {moveModel.FromTemplate}->{moveModel.ToTemplate} {moveModel.ClientCode}");
            ListStringResponseModel response = new ListStringResponseModel();

            var openResult = _connection.OpenQuikQadminApiToWrite(_spotFIRM);
            if (!openResult.Equals("OK"))
            {
                response.IsSuccess = false;
                response.Messages.Add($"SpotService MoveClientCodeBetweenTemplatesPoKomissii Failed: OpenBRL error {openResult}");
                return response;
            }

            //перемещение кода клиента из одного шаблона "по Плечу" в другой  шаблон "по Плечу".
            int resultEditBrl = NativeMethods.QDAPI_MoveClientBetweenMarginTemplates(_spotFIRM, moveModel.FromTemplate, moveModel.ToTemplate, moveModel.ClientCode);
            _logger.LogInformation($"MoveClientCodeBetweenTemplatesPoPlechu result is: {resultEditBrl}");
            //if (resultEditBrl != 0)
            //{
            //    response.IsSuccess = false;
            //    response.Messages.Add($"Error! MoveClientCodeBetweenTemplatesPoPlechu result is: {resultEditBrl}");
            //}
            //else
            //{
            //    response.Messages.Add($"OK. MoveClientCodeBetweenTemplatesPoPlechu result is: {resultEditBrl}");
            //}

            return _connection.CloseQuikAPI(resultEditBrl, _spotFIRM, response);
            //string close = _connection.CloseQuikAPI(resultEditBrl, _spotFIRM);
            //if (!close.Equals("OK"))
            //{
            //    response.IsSuccess = false;
            //    response.Messages.Add(close);
            //}

            //return response;
        }

        public ListStringResponseModel ReplaceAllCodesMatrixInPoKomisiiTemplate(TemplateAndCodesModel model)
        {
            _logger.LogInformation($"SpotService ReplaceAllCodesMatrixInPoKomisiiTemplate Called for {model.Template}");
            ListStringResponseModel response = new ListStringResponseModel();

            var openResult = _connection.OpenQuikQadminApiToWrite(_spotFIRM);
            if (!openResult.Equals("OK"))
            {
                response.IsSuccess = false;
                response.Messages.Add($"SpotService ReplaceAllCodesMatrixInPoKomisiiTemplate Failed: OpenBRL error {openResult}");
                return response;
            }

            //изменения полного списка клиентов в клиентском шаблоне «По комиссии».
            QDAPI_ArrayStrings clStruct = new QDAPI_ArrayStrings
            {
                count = (uint)model.ClientCodes.Length,
                elems = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(IntPtr)) * model.ClientCodes.Length)
            };
            IntPtr[] clPtrArray = new IntPtr[model.ClientCodes.Length];
            for (int i = 0; i < model.ClientCodes.Length; ++i)
            {
                clPtrArray[i] = Marshal.StringToHGlobalAnsi(model.ClientCodes[i].MatrixClientCode);
            }
            Marshal.Copy(clPtrArray, 0, clStruct.elems, clPtrArray.Length);

            int resultEditBrl = NativeMethods.QDAPI_SetClientsListOfClientTemplate(_spotFIRM, model.Template, ref clStruct);
            _logger.LogInformation($"ReplaceAllCodesMatrixInPoKomisiiTemplate result is: {resultEditBrl}");

            //if (resultEditBrl != 0)
            //{
            //    response.IsSuccess = false;
            //    response.Messages.Add($"Error! ReplaceAllCodesMatrixInPoKomisiiTemplate result is: {resultEditBrl}");
            //}
            //else
            //{
            //    response.Messages.Add($"OK. ReplaceAllCodesMatrixInPoKomisiiTemplate result is: {resultEditBrl}");
            //}
            

            Marshal.FreeHGlobal(clStruct.elems);
            for (int i = 0; i < clPtrArray.Length; ++i)
            {
                Marshal.FreeHGlobal(clPtrArray[i]);
            }
            return _connection.CloseQuikAPI(resultEditBrl, _spotFIRM, response);

            //string close = _connection.CloseQuikAPI(resultEditBrl, _spotFIRM);
            //if (!close.Equals("OK"))
            //{
            //    response.IsSuccess = false;
            //    response.Messages.Add(close);
            //}

            //return response;
        }

        public ListStringResponseModel ReplaceAllCodesMatrixInLeverageTemplate(TemplateAndCodesModel model)
        {
            _logger.LogInformation($"SpotService ReplaceAllCodesMatrixInLeverageTemplate Called for {model.Template}");
            ListStringResponseModel response = new ListStringResponseModel();

            var openResult = _connection.OpenQuikQadminApiToWrite(_spotFIRM);
            if (!openResult.Equals("OK"))
            {
                response.IsSuccess = false;
                response.Messages.Add($"SpotService ReplaceAllCodesMatrixInLeverageTemplate Failed: OpenBRL error {openResult}");
                return response;
            }

            //изменения полного списка клиентов в маржинальном шаблоне  "по Плечу"
            QDAPI_ArrayStrings clStruct = new QDAPI_ArrayStrings
            {
                count = (uint) model.ClientCodes.Length,
                elems = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(IntPtr)) * model.ClientCodes.Length)
            };
            IntPtr[] clPtrArray = new IntPtr[model.ClientCodes.Length];
            for (int i = 0; i < model.ClientCodes.Length; ++i)
            {
                clPtrArray[i] = Marshal.StringToHGlobalAnsi(model.ClientCodes[i].MatrixClientCode);
            }
            Marshal.Copy(clPtrArray, 0, clStruct.elems, clPtrArray.Length);

            int resultEditBrl = NativeMethods.QDAPI_SetClientsListOfMarginTemplate(_spotFIRM, model.Template, ref clStruct);
            _logger.LogInformation($"ReplaceAllCodesMatrixInLeverageTemplate result is: {resultEditBrl}");
            
            //if (resultEditBrl != 0)
            //{
            //    response.IsSuccess = false;
            //    response.Messages.Add($"Error! ReplaceAllCodesMatrixInLeverageTemplate result is: {resultEditBrl}");
            //}
            //else
            //{
            //    response.Messages.Add($"OK. ReplaceAllCodesMatrixInLeverageTemplate result is: {resultEditBrl}");
            //}

            Marshal.FreeHGlobal(clStruct.elems);
            for (int i = 0; i < clPtrArray.Length; ++i)
            {
                Marshal.FreeHGlobal(clPtrArray[i]);
            }

            return _connection.CloseQuikAPI(resultEditBrl, _spotFIRM, response);

            //string close = _connection.CloseQuikAPI(resultEditBrl, _spotFIRM);
            //if (!close.Equals("OK"))
            //{
            //    response.IsSuccess = false;
            //    response.Messages.Add(close);
            //}

            //return response;
        }
    }
}