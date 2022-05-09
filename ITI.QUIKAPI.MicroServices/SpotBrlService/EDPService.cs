using DataAbstraction.Interfaces;
using QDealerAPI;
using DataAbstraction.Models;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using System.Runtime.InteropServices;
using DataAbstraction.Models.Connections;

namespace QuikAPIBrlService
{
    public class EDPService : IEdpBrlService
    {
        private const string _spotFIRM = "MC0138200000";
        private const string _fortsFIRM = "SPBFUT";
        //private QadminLogon _logon;
        private ILogger<EDPService> _logger;
        IQuikApiConnectionService _connection;
        
        public EDPService(//IOptions<QadminLogon> logon, 
            ILogger<EDPService> logger, IQuikApiConnectionService connection)
        {
            //_logon = logon.Value;
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

            string quikCode = CommonServices.PortfoliosConvertingService.GetQuikSpotPortfolio(model.MatrixClientCode);

            //выполнить работу            
            IntPtr ptr = IntPtr.Zero;

            //получение кода срочного рынка ЕДП по коду клиента
            int resultEditBrl = NativeMethods.QDAPI_GetTrdAccGlobalChangeFutClientCodesByClientCode(_spotFIRM, _fortsFIRM, quikCode, ref ptr);
            //string derAcc = Marshal.PtrToStringAnsi(derivativeAcc);
            //Console.WriteLine("derAcc = " + derAcc);
            response.Messages.Add(CommonServices.PortfoliosConvertingService.GetMatrixFortsCode(Marshal.PtrToStringAnsi(ptr)));

            NativeMethods.QDAPI_FreeMemory(ref ptr);

            //закрыть соединение
            return _connection.CloseQuikAPI(resultEditBrl, _spotFIRM, response);
        }
    }
}
