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

        public string AddClientPortfolioToKomissiiCDportfolio(string quikportfolio)
        {
            _logger.LogInformation($"SpotService AddClientPortfolioToKomissiiCDportfolio {quikportfolio} Called");
            return AddPortfolioKomissiiTemplate("CD_portfolio", quikportfolio);
        }
        public string AddClientPortfolioToKomissiiTemplate(string template, string quikportfolio)
        {
            _logger.LogInformation($"SpotService AddClientPortfolioToKomissiiTemplate Called {template} {quikportfolio}");
            return AddPortfolioKomissiiTemplate(template, quikportfolio);
        }
        private string AddPortfolioKomissiiTemplate(string template, string quikportfolio)
        {
            var openResult = _connection.OpenQuikQadminApiToWrite(_spotFIRM);
            if (!openResult.Equals("OK"))
            {
                return openResult;
            }
            //добавление одного кода клиента в клиентский шаблон «По комиссии».
            int resultEditBrl = NativeMethods.QDAPI_AddClientToClientTemplate(_spotFIRM, template, quikportfolio);
            _logger.LogInformation($"Insert result is: {resultEditBrl}");

            return _connection.CloseQuikAPI(resultEditBrl, _spotFIRM);
        }

        public string AddClientPortfolioToLeverageCDportfolio(string quikportfolio)
        {
            _logger.LogInformation($"SpotService AddClientPortfolioToLeverageCDportfolio {quikportfolio} Called");
            return AddPortfolioLeverageTemplate("CD_portfolio", quikportfolio);
        }

        public string AddClientPortfolioToLeverageTemplate(string template, string quikportfolio)
        {
            _logger.LogInformation($"SpotService AddClientPortfolioToKomissiiTemplate Called {template} {quikportfolio}");
            return AddPortfolioLeverageTemplate(template, quikportfolio);
        }

        private string AddPortfolioLeverageTemplate(string template, string quikportfolio)
        {
            var openResult = _connection.OpenQuikQadminApiToWrite(_spotFIRM);
            if (!openResult.Equals("OK"))
            {
                return openResult;
            }

            //добавление одного кода клиента в маржинальный шаблон "по Плечу"
            int resultEditBrl = NativeMethods.QDAPI_AddClientToMarginTemplate(_spotFIRM, template, quikportfolio);
            _logger.LogInformation($"Insert result is: {resultEditBrl}");

            return _connection.CloseQuikAPI(resultEditBrl, _spotFIRM);
        }

        public string GetLogin()
        {
            _logger.LogInformation("SpotService GetLogin Called");
            return _logon.Login;
        }

        public string CheckConnection()
        {
            _logger.LogInformation("SpotService CheckConnection Called");

            var openResult = _connection.OpenQuikQadminApiToRead(_spotFIRM);
            if (!openResult.Equals("OK"))
            {
                return openResult;
            }
            return _connection.CloseQuikAPI(0, _spotFIRM);
        }

        public string[] GetAllTemplatesPoKomissii()
        {
            _logger.LogInformation($"SpotService GetAllTemplatesPoKomissii Called");
            
            List<string> result = new List<string>();

            var openResult = _connection.OpenQuikQadminApiToRead(_spotFIRM);
            if (!openResult.Equals("OK"))
            {
                result.Add(openResult);
                return result.ToArray();
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
                result.Add(templateCode);
            }
            NativeMethods.QDAPI_FreeMemory(ref templateListPoComissii);

            string close = _connection.CloseQuikAPI(0, _spotFIRM);
            if (!close.Equals("OK"))
            {
                result.Add(close);
            }

            return result.ToArray();
        }

        public string[] GetAllTemplatesPoPlechu()
        {
            _logger.LogInformation($"SpotService GetAllTemplatesPoPlechu Called");

            List<string> result = new List<string>();

            var openResult = _connection.OpenQuikQadminApiToRead(_spotFIRM);
            if (!openResult.Equals("OK"))
            {
                result.Add(openResult);
                return result.ToArray();
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
                result.Add(templateCode);
            }
            NativeMethods.QDAPI_FreeMemory(ref templateListPoPlechu);

            string close = _connection.CloseQuikAPI(0, _spotFIRM);
            if (!close.Equals("OK"))
            {
                result.Add(close);
            }

            return result.ToArray();
        }

        public string[] GetAllClientsFromTemplatePoKomissii(string templateName)
        {
            _logger.LogInformation($"SpotService GetAllClientsFromTemplatePoKomissii Called " + templateName);

            List<string> result = new List<string>();

            var openResult = _connection.OpenQuikQadminApiToRead(_spotFIRM);
            if (!openResult.Equals("OK"))
            {
                result.Add(openResult);
                return result.ToArray();
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
                    result.Add(templateCode);
                }
                NativeMethods.QDAPI_FreeMemory(ref clPtr);
            }
            else
            {
                result.Add($"Template {templateName} not found");
            }

            string close = _connection.CloseQuikAPI(0, _spotFIRM);
            if (!close.Equals("OK"))
            {
                result.Add(close);
            }

            return result.ToArray();
        }

        public string[] GetAllClientsFromTemplatePoPlechu(string templateName)
        {
            _logger.LogInformation($"SpotService GetAllClientsFromTemplatePoPlechu Called " + templateName);

            List<string> result = new List<string>();

            var openResult = _connection.OpenQuikQadminApiToRead(_spotFIRM);
            if (!openResult.Equals("OK"))
            {
                result.Add(openResult);
                return result.ToArray();
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
                    result.Add(templateCode);
                }
                NativeMethods.QDAPI_FreeMemory(ref clPtr);
            }
            else
            {
                result.Add($"Template {templateName} not found");
            }

            string close = _connection.CloseQuikAPI(0, _spotFIRM);
            if (!close.Equals("OK"))
            {
                result.Add(close);
            }

            return result.ToArray();
        }

        public string DeleteCodeFromTemplatePoKomissii(TemplateAndCodeModel model)
        {
            _logger.LogInformation($"SpotService DeleteCodeFromTemplatePoKomissii Called {model.Template} {model.ClientCode}");

            var openResult = _connection.OpenQuikQadminApiToWrite(_spotFIRM);
            if (!openResult.Equals("OK"))
            {
                return openResult;
            }
            //удаления одного кода клиента из шаблона  "по Комиссии"
            int resultEditBrl = NativeMethods.QDAPI_RemoveClientFromClientTemplate(_spotFIRM, model.Template, model.ClientCode);
            _logger.LogInformation($"Delete result is: {resultEditBrl}");

            return _connection.CloseQuikAPI(resultEditBrl, _spotFIRM);
        }

        public string DeleteCodeFromTemplatePoPlechu(TemplateAndCodeModel model)
        {
            _logger.LogInformation($"SpotService DeleteCodeFromTemplatePoPlechu Called {model.Template} {model.ClientCode}");

            var openResult = _connection.OpenQuikQadminApiToWrite(_spotFIRM);
            if (!openResult.Equals("OK"))
            {
                return openResult;
            }
            //удаления одного кода клиента из шаблона  "по Плечу"
            int resultEditBrl = NativeMethods.QDAPI_RemoveClientFromMarginTemplate(_spotFIRM, model.Template, model.ClientCode);
            _logger.LogInformation($"Delete result is: {resultEditBrl}");

            return _connection.CloseQuikAPI(resultEditBrl, _spotFIRM);
        }

        public string MoveClientCodeBetweenTemplatesPoKomissii(MoveCodeModel moveModel)
        {
            _logger.LogInformation($"SpotService MoveClientCodeBetweenTemplatesPoKomissii Called {moveModel.FromTemplate}->{moveModel.ToTemplate} {moveModel.ClientCode}");

            var openResult = _connection.OpenQuikQadminApiToWrite(_spotFIRM);
            if (!openResult.Equals("OK"))
            {
                return openResult;
            }

            //перемещения кода клиента из одного шаблона «По комиссии». в другой  шаблон «По комиссии».
            int resultEditBrl = NativeMethods.QDAPI_MoveClientBetweenClientTemplates(_spotFIRM, moveModel.FromTemplate, moveModel.ToTemplate, moveModel.ClientCode);
            _logger.LogInformation($"Move result is: {resultEditBrl}");

            return _connection.CloseQuikAPI(resultEditBrl, _spotFIRM);
        }

        public string MoveClientCodeBetweenTemplatesPoPlechu(MoveCodeModel moveModel)
        {
            _logger.LogInformation($"SpotService MoveClientCodeBetweenTemplatesPoPlechu Called {moveModel.FromTemplate}->{moveModel.ToTemplate} {moveModel.ClientCode}");

            var openResult = _connection.OpenQuikQadminApiToWrite(_spotFIRM);
            if (!openResult.Equals("OK"))
            {
                return openResult;
            }

            //перемещение кода клиента из одного шаблона "по Плечу" в другой  шаблон "по Плечу".
            int resultEditBrl = NativeMethods.QDAPI_MoveClientBetweenMarginTemplates(_spotFIRM, moveModel.FromTemplate, moveModel.ToTemplate, moveModel.ClientCode);
            _logger.LogInformation($"Move result is: {resultEditBrl}");

            return _connection.CloseQuikAPI(resultEditBrl, _spotFIRM);
        }

        public string ReplaceAllCodesMatrixInPoKomisiiTemplate(TemplateAndCodesModel model)
        {
            _logger.LogInformation($"SpotService ReplaceAllCodesMatrixInPoKomisiiTemplate Called for {model.Template}");

            var openResult = _connection.OpenQuikQadminApiToWrite(_spotFIRM);
            if (!openResult.Equals("OK"))
            {
                return openResult;
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
                clPtrArray[i] = Marshal.StringToHGlobalAnsi(model.ClientCodes[i]);
            }
            Marshal.Copy(clPtrArray, 0, clStruct.elems, clPtrArray.Length);

            int resultEditBrl = NativeMethods.QDAPI_SetClientsListOfClientTemplate(_spotFIRM, model.Template, ref clStruct);
            _logger.LogInformation($"Move result is: {resultEditBrl}");

            Marshal.FreeHGlobal(clStruct.elems);
            for (int i = 0; i < clPtrArray.Length; ++i)
            {
                Marshal.FreeHGlobal(clPtrArray[i]);
            }

            return _connection.CloseQuikAPI(resultEditBrl, _spotFIRM);
        }

        public string ReplaceAllCodesMatrixInLeverageTemplate(TemplateAndCodesModel model)
        {
            _logger.LogInformation($"SpotService ReplaceAllCodesMatrixInLeverageTemplate Called for {model.Template}");

            var openResult = _connection.OpenQuikQadminApiToWrite(_spotFIRM);
            if (!openResult.Equals("OK"))
            {
                return openResult;
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
                clPtrArray[i] = Marshal.StringToHGlobalAnsi(model.ClientCodes[i]);
            }
            Marshal.Copy(clPtrArray, 0, clStruct.elems, clPtrArray.Length);

            int resultEditBrl = NativeMethods.QDAPI_SetClientsListOfMarginTemplate(_spotFIRM, model.Template, ref clStruct);
            _logger.LogInformation($"Move result is: {resultEditBrl}");

            Marshal.FreeHGlobal(clStruct.elems);
            for (int i = 0; i < clPtrArray.Length; ++i)
            {
                Marshal.FreeHGlobal(clPtrArray[i]);
            }

            return _connection.CloseQuikAPI(resultEditBrl, _spotFIRM);
        }
    }
}