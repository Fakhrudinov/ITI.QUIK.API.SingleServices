using DataAbstraction.Interfaces;
using DataAbstraction.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using QDealerAPI;
using System.Runtime.InteropServices;


namespace SpotBrlService
{
    public class QuikApiConnectionService : IQuikApiConnectionService
    {
        private ILogger<QuikApiConnectionService> _logger;
        private QadminLogon _logon;

        public QuikApiConnectionService(IOptions<QadminLogon> logon, ILogger<QuikApiConnectionService> logger)
        {
            _logger = logger;
            _logon = logon.Value;
        }

        public string OpenQuikQadminApiToWrite(string firm)
        {
            _logger.LogInformation("SpotService OpenQuikQadminApiToWrite Called");

            var openResult = OpenQuikQadminAPI();
            if (!openResult.Equals("OK"))
            {
                return openResult;
            }
            // Начало работы с настройками БРЛ
            // Открытие настроек по фирме dealerFirm
            // 0 - чтение/запись
            // 1 - чтение
            int _errCode = NativeMethods.QDAPI_DLOpenFile(firm, 0);
            if (_errCode != (int)QDAPI_Errors.QDAPI_ERROR_SUCCESS)
            {
                string errorText = CommonServices.QuikService.GetErrorDescription(_errCode);
                _logger.LogWarning($"QAS100 Ошибка подключения к Qadmin API. Файл БРЛ не был открыт. Код ошибки: {_errCode} {errorText}");
                return $"QAS100 Ошибка подключения к Qadmin API. Файл БРЛ не был открыт. Код ошибки: {_errCode} {errorText}";
            }

            return "OK";
        }

        public string OpenQuikQadminApiToRead(string firm)
        {
            _logger.LogInformation("SpotService OpenQuikQadminApiToRead Called");

            var openResult = OpenQuikQadminAPI();
            if (!openResult.Equals("OK"))
            {
                return openResult;
            }
            // Начало работы с настройками БРЛ
            // Открытие настроек по фирме dealerFirm
            // 0 - чтение/запись
            // 1 - чтение
            int _errCode = NativeMethods.QDAPI_DLOpenFile(firm, 1);
            if (_errCode != (int)QDAPI_Errors.QDAPI_ERROR_SUCCESS)
            {
                string errorText = CommonServices.QuikService.GetErrorDescription(_errCode);
                _logger.LogWarning($"QAS101 Ошибка подключения к Qadmin API. Файл БРЛ не был открыт. Код ошибки: {_errCode} {errorText}");
                return $"QAS101 Ошибка подключения к Qadmin API. Файл БРЛ не был открыт. Код ошибки: {_errCode} {errorText}";
            }

            return "OK";
        }

        private string OpenQuikQadminAPI()
        {
            _logger.LogInformation("SpotService OpenQuikQadminAPI Called");

            IntPtr conErrPtr = IntPtr.Zero;
            int _errCode = NativeMethods.QDAPI_Connect(@"QDealerAPI.ini", _logon.Login, _logon.Password, ref conErrPtr);
            if (_errCode != (int)QDAPI_Errors.QDAPI_ERROR_SUCCESS)
            {
                string conErr = Marshal.PtrToStringAnsi(conErrPtr);
                NativeMethods.QDAPI_FreeMemory(ref conErrPtr);

                if (conErr == null)
                {
                    _logger.LogWarning("QAS102 Ошибка подключения к Qadmin API - conErr is null");
                    return "QAS102 Ошибка подключения к Qadmin API - conErr is null";
                }

                _logger.LogWarning($"QAS103 Ошибка подключения к Qadmin API: {conErr}");
                return $"QAS103 Ошибка подключения к Qadmin API: {conErr}";
            }
            else
            {
                _logger.LogInformation("Соединение установлено");
                return "OK";
            }
        }

        private string CloseQuikQadminAPI(string firm)
        {
            _logger.LogInformation("SpotService CloseQuikQadminAPI Called");

            try
            {
                // Сохранение изменений
                int _errCode = NativeMethods.QDAPI_DLUpdateFile(firm);

                if (_errCode != (int)QDAPI_Errors.QDAPI_ERROR_SUCCESS)
                {
                    string errorText = CommonServices.QuikService.GetErrorDescription(_errCode);
                    _logger.LogWarning($"QAS104 Qadmin API Настройки не были сохранены. Код ошибки: {_errCode}");
                    //12 = Текущий доступ к настройкам БРЛ не допускает их изменения. ОК при "1" в подключении
                    if (_errCode != 12)
                    {
                        _logger.LogWarning($"QAS105 Qadmin API Ошибка в CloseQuikQadminAPI. Настройки не были сохранены, код ошибки: {_errCode} {errorText}");
                        return $"QAS105 Qadmin API Ошибка в CloseQuikQadminAPI. Настройки не были сохранены, код ошибки: {_errCode} {errorText}";
                    }
                }
                else
                {
                    _logger.LogInformation("Настройки успешно сохранены");
                }

                // Закрытие файла настроек
                _errCode = NativeMethods.QDAPI_DLCloseFile(firm);

                if (_errCode != (int)QDAPI_Errors.QDAPI_ERROR_SUCCESS)
                {
                    string errorText = CommonServices.QuikService.GetErrorDescription(_errCode);
                    _logger.LogWarning($"QAS106 Qadmin API Файл не был закрыт. Код ошибки: {_errCode} {errorText}");
                    return $"QAS106 Qadmin API Файл не был закрыт. Код ошибки: {_errCode} {errorText}";
                }
                else
                {
                    _logger.LogInformation("Qadmin API Файл успешно закрыт");
                }

                // Отключение от Сервера Quik Administrator
                _errCode = NativeMethods.QDAPI_Disconnect();

                if (_errCode != (int)QDAPI_Errors.QDAPI_ERROR_SUCCESS)
                {
                    string errorText = CommonServices.QuikService.GetErrorDescription(_errCode);
                    _logger.LogWarning($"QAS107 Ошибка отключения от сервера. Код ошибки: {_errCode} {errorText}");
                    return $"QAS107 Ошибка отключения от сервера. Код ошибки: {_errCode} {errorText}";
                }
                else
                {
                    _logger.LogInformation("Отключение от сервера успешно произведено");
                    return "OK";
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"QAS108 CheckConnectionQadmin Error {ex.Message}");
                return $"QAS108 CheckConnectionQadmin Error {ex.Message}";
            }
        }

        public string CloseQuikAPI(int resultEditBrl, string firm)
        {
            var resultClose = CloseQuikQadminAPI(firm);

            if (resultClose == null)
            {
                _logger.LogWarning("QAS109 No answer received when close QUIK BRL MC0138200000");
                return "QAS109 No answer received when close QUIK BRL MC0138200000";
            }
            else if (resultClose.Equals("OK"))
            {
                _logger.LogInformation("Файл успешно закрыт");
                if (resultEditBrl == 0)
                {
                    return "OK";
                }
                else
                {
                    string errorText = CommonServices.QuikService.GetErrorDescription(resultEditBrl);
                    return $"QAS110 Ошибка при выполнении = {resultEditBrl} {errorText}";
                }
            }
            else
            {
                _logger.LogWarning("QAS111 Error at close QUIK BRL MC0138200000, error=" + resultClose);
                return "QAS111 Error at close QUIK BRL MC0138200000, error=" + resultClose;
            }
        }
    }
}
