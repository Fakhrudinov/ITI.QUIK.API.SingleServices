using DataAbstraction.Interfaces;
using QDealerAPI;
using DataAbstraction.Models;
using Microsoft.Extensions.Logging;
using System.Runtime.InteropServices;


namespace QuikAPIBrlService
{
    public class EDPService : IEdpBrlService
    {
        private const string _spotFIRM = "MC0138200000";
        private const string _fortsFIRM = "SPBFUT";
        private ILogger<EDPService> _logger;
        IQuikApiConnectionService _connection;
        
        public EDPService(ILogger<EDPService> logger, IQuikApiConnectionService connection)
        {
            _logger = logger;
            _connection = connection;
        }

        public ListStringResponseModel GetEDPFortsClientCodeByMatrixCode(MatrixClientCodeModel model)
        {
            _logger.LogInformation($"EDPService GetEDPFortsClientCodeByMatrixCode {model.MatrixClientCode} Called");
            ListStringResponseModel response = new ListStringResponseModel();

            // открыть соединение
            var openResult = _connection.OpenQuikQadminApiToRead(_spotFIRM, response);
            if (!openResult.IsSuccess)
            {
                return response;
            }

            // переделаем код на QUIK формат
            string quikCode = CommonServices.PortfoliosConvertingService.GetQuikSpotPortfolio(model.MatrixClientCode);

            //выполнить работу            
            IntPtr ptr = IntPtr.Zero;
            //получение кода срочного рынка ЕДП по коду клиента
            int resultEditBrl = NativeMethods.QDAPI_GetTrdAccGlobalChangeFutClientCodesByClientCode(_spotFIRM, _fortsFIRM, quikCode, ref ptr);
            _logger.LogInformation($"EDPService GetEDPFortsClientCodeByMatrixCode {model.MatrixClientCode} result : '{Marshal.PtrToStringAnsi(ptr)}'");
            if (resultEditBrl == 0)
            {
                response.Messages.Add(CommonServices.PortfoliosConvertingService.GetMatrixFortsCode(Marshal.PtrToStringAnsi(ptr)));
            }          
            NativeMethods.QDAPI_FreeMemory(ref ptr);

            //закрыть соединение
            return _connection.CloseQuikAPI(resultEditBrl, _spotFIRM, response);
        }
        public ListStringResponseModel GetEDPMatrixClientCodeByFortsCode(FortsClientCodeModel model)
        {
            _logger.LogInformation($"EDPService GetEDPMatrixClientCodeByFortsCode {model.FortsClientCode} Called");
            ListStringResponseModel response = new ListStringResponseModel();

            // открыть соединение
            var openResult = _connection.OpenQuikQadminApiToRead(_spotFIRM, response);
            if (!openResult.IsSuccess)
            {
                return response;
            }

            // переделаем код на QUIK формат
            string quikCode = CommonServices.PortfoliosConvertingService.GetQuikFortsCode(model.FortsClientCode);

            //выполнить работу            
            IntPtr ptr = IntPtr.Zero;
            //получение кода клиента ЕДП по коду срочного рынка
            int resultEditBrl = NativeMethods.QDAPI_GetClientCodeGlobalChangeFutClientCodesByTrdAcc(_spotFIRM, _fortsFIRM, quikCode, ref ptr);
            _logger.LogInformation($"EDPService GetEDPMatrixClientCodeByFortsCode {model.FortsClientCode} result : '{Marshal.PtrToStringAnsi(ptr)}'");
            if (resultEditBrl == 0)
            {
                response.Messages.Add(CommonServices.PortfoliosConvertingService.GetMatrixMOCode(Marshal.PtrToStringAnsi(ptr)));
            }
            NativeMethods.QDAPI_FreeMemory(ref ptr);

            //закрыть соединение
            return _connection.CloseQuikAPI(resultEditBrl, _spotFIRM, response);
        }

        public ListStringResponseModel SetNewEdpRelation(MatrixToFortsCodesMappingModel model)
        {
            _logger.LogInformation($"EDPService SetNewEdpRelation {model.MatrixClientCode} Called");
            ListStringResponseModel response = new ListStringResponseModel();

            // открыть соединение
            var openResult = _connection.OpenQuikQadminApiToWrite(_spotFIRM, response);
            if (!openResult.IsSuccess)
            {
                return response;
            }

            //выполнить работу            
            QDAPI_StringToString clCodeTrdAccStruct = new QDAPI_StringToString
            {
                fst = CommonServices.PortfoliosConvertingService.GetQuikSpotPortfolio(model.MatrixClientCode),
                snd = CommonServices.PortfoliosConvertingService.GetQuikFortsCode(model.FortsClientCode)
            };
            //добавление нового соответствия ЕДП клиента
            int resultEditBrl = NativeMethods.QDAPI_AddCorrespToGlobalChangeFutClientCodes(_spotFIRM, _fortsFIRM, ref clCodeTrdAccStruct);
            _logger.LogInformation($"EDPService SetNewEdpRelation {model.MatrixClientCode} result : '{resultEditBrl}'");

            //закрыть соединение
            return _connection.CloseQuikAPI(resultEditBrl, _spotFIRM, response);
        }


        public ListStringResponseModel DeleteEdpRelation(MatrixClientCodeModel model)
        {
            _logger.LogInformation($"EDPService DeleteEdpRelation {model.MatrixClientCode} Called");
            ListStringResponseModel response = new ListStringResponseModel();

            // открыть соединение
            var openResult = _connection.OpenQuikQadminApiToWrite(_spotFIRM, response);
            if (!openResult.IsSuccess)
            {
                return response;
            }

            // переделаем код на QUIK формат
            string quikCode = CommonServices.PortfoliosConvertingService.GetQuikSpotPortfolio(model.MatrixClientCode);

            //выполнить работу
            //удаление соответствия ЕДП по коду клиента
            int resultEditBrl = NativeMethods.QDAPI_RemoveCorrespFromGlobalChangeFutClientCodesByClientCode(_spotFIRM, _fortsFIRM, quikCode);

            _logger.LogInformation($"EDPService DeleteEdpRelation {model.MatrixClientCode} result : '{resultEditBrl}'");

            //закрыть соединение
            return _connection.CloseQuikAPI(resultEditBrl, _spotFIRM, response);
        }

        public ListStringResponseModel GetAllEdpRelation()
        {
            _logger.LogInformation($"EDPService GetAllEdpRelation Called");
            ListStringResponseModel response = new ListStringResponseModel();

            // открыть соединение
            var openResult = _connection.OpenQuikQadminApiToRead(_spotFIRM, response);
            if (!openResult.IsSuccess)
            {
                return response;
            }

            //выполнить работу
            IntPtr lsPtr = IntPtr.Zero;
            //Функция предназначена для получения всех соответствий клиентских кодов и торговых счетов срочного рынка для указанной фирмы.                                
            int resultEditBrl = NativeMethods.QDAPI_GetChangeFutClientCodesByFirmFromGlobal(_spotFIRM, _fortsFIRM, ref lsPtr);

            QDAPI_ArrayClientCodeToTrdAcc clientCodesToTrdAccs = (QDAPI_ArrayClientCodeToTrdAcc)Marshal.
                PtrToStructure(lsPtr, typeof(QDAPI_ArrayClientCodeToTrdAcc));
                
            IntPtr ptr = clientCodesToTrdAccs.elems;
            for (uint i = 0; i < clientCodesToTrdAccs.count; i++)
            {
                QDAPI_ClientCodeToTrdAcc clientCodeToTrdAcc = (QDAPI_ClientCodeToTrdAcc)Marshal.
                    PtrToStructure(ptr, typeof(QDAPI_ClientCodeToTrdAcc));

                response.Messages.Add($"{CommonServices.PortfoliosConvertingService.GetMatrixMOCode(clientCodeToTrdAcc.clientCode)}=" +
                    $"{CommonServices.PortfoliosConvertingService.GetMatrixFortsCode(clientCodeToTrdAcc.tradeAcc)}");

                ptr += Marshal.SizeOf(typeof(QDAPI_ClientCodeToTrdAcc));
            }
                
            NativeMethods.QDAPI_FreeMemory(ref lsPtr);

            _logger.LogInformation($"EDPService GetAllEdpRelation result : {resultEditBrl}' count={clientCodesToTrdAccs.count}");

            //закрыть соединение
            return _connection.CloseQuikAPI(resultEditBrl, _spotFIRM, response);
        }
    }
}
