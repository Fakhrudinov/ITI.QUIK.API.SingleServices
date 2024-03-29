﻿using DataAbstraction.Interfaces;
using DataAbstraction.Models;
using DataAbstraction.Models.Connections;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using QDealerAPI;
using System.Runtime.InteropServices;


namespace QuikAPIBrlService
{
    public class QuikApiConnectionService : IQuikApiConnectionService
    {
        private ILogger<QuikApiConnectionService> _logger;
        private QadminLogon _logon;
        private int _errCode = -100;

        public QuikApiConnectionService(IOptions<QadminLogon> logon, ILogger<QuikApiConnectionService> logger)
        {
            _logger = logger;
            _logon = logon.Value;
        }

        public ListStringResponseModel OpenQuikQadminApiToWrite(string firm, ListStringResponseModel response)
        {
            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} QuikAPIBrlService OpenQuikQadminApiToWrite Called");

            var openResult = OpenQuikQadminAPI();
            if (!openResult.Equals("OK"))
            {
                response.IsSuccess = false;
                response.Messages.Add(openResult);
                return response;
            }
            // Начало работы с настройками БРЛ
            // Открытие настроек по фирме dealerFirm
            // 0 - чтение/запись
            // 1 - чтение
            _errCode = NativeMethods.QDAPI_DLOpenFile(firm, 0);
            if (_errCode != (int)QDAPI_Errors.QDAPI_ERROR_SUCCESS)
            {
                string errorText = CommonServices.QuikService.GetErrorDescription(_errCode);
                _logger.LogWarning($"{DateTime.Now.ToString("HH:mm:ss:fffff")} QAS100 Ошибка подключения к Qadmin API. Файл БРЛ {firm} не был открыт. Код ошибки: {_errCode} {errorText}");

                response.IsSuccess = false;
                response.Messages.Add($"QAS100 Ошибка подключения к Qadmin API. Файл БРЛ {firm} не был открыт. Код ошибки: {_errCode} {errorText}");
                return response;
            }

            return response;
        }

        public ListStringResponseModel OpenQuikQadminApiToRead(string firm, ListStringResponseModel response)
        {
            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} QuikAPIBrlService OpenQuikQadminApiToRead Called");

            var openResult = OpenQuikQadminAPI();
            if (!openResult.Equals("OK"))
            {
                response.IsSuccess = false;
                response.Messages.Add(openResult);
                return response;
            }
            // Начало работы с настройками БРЛ
            // Открытие настроек по фирме dealerFirm
            // 0 - чтение/запись
            // 1 - чтение
            _errCode = NativeMethods.QDAPI_DLOpenFile(firm, 1);
            if (_errCode != (int)QDAPI_Errors.QDAPI_ERROR_SUCCESS)
            {
                string errorText = CommonServices.QuikService.GetErrorDescription(_errCode);
                _logger.LogWarning($"{DateTime.Now.ToString("HH:mm:ss:fffff")} QAS101 Ошибка подключения к Qadmin API. Файл БРЛ {firm} не был открыт. Код ошибки: {_errCode} {errorText}");

                response.IsSuccess = false;
                response.Messages.Add($"QAS101 Ошибка подключения к Qadmin API. Файл БРЛ {firm} не был открыт. Код ошибки: {_errCode} {errorText}");
                return response;
            }

            return response;
        }

        private string OpenQuikQadminAPI()
        {
            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} QuikAPIBrlService OpenQuikQadminAPI Called");

            IntPtr conErrPtr = IntPtr.Zero;
            _errCode = NativeMethods.QDAPI_Connect(@"QDealerAPI.ini", _logon.Login, _logon.Password, ref conErrPtr);
            if (_errCode != (int)QDAPI_Errors.QDAPI_ERROR_SUCCESS)
            {
                string conErr = Marshal.PtrToStringAnsi(conErrPtr);
                NativeMethods.QDAPI_FreeMemory(ref conErrPtr);

                if (conErr == null)
                {
                    _logger.LogWarning($"{DateTime.Now.ToString("HH:mm:ss:fffff")} QAS102 Ошибка подключения к Qadmin API - conErr is null");
                    return "QAS102 Ошибка подключения к Qadmin API - conErr is null";
                }

                _logger.LogWarning($"{DateTime.Now.ToString("HH:mm:ss:fffff")} QAS103 Ошибка подключения к Qadmin API: {conErr}");
                return $"QAS103 Ошибка подключения к Qadmin API: {conErr}";
            }
            else
            {
                _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} Соединение установлено");
                return "OK";
            }
        }

        private string CloseQuikQadminAPI(string firm)
        {
            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} QuikAPIBrlService CloseQuikQadminAPI Called");

            try
            {
                // Сохранение изменений
                _errCode = NativeMethods.QDAPI_DLUpdateFile(firm);

                if (_errCode != (int)QDAPI_Errors.QDAPI_ERROR_SUCCESS)
                {
                    string errorText = CommonServices.QuikService.GetErrorDescription(_errCode);
                    _logger.LogWarning($"{DateTime.Now.ToString("HH:mm:ss:fffff")} QAS104 Qadmin API Настройки не были сохранены. Код ошибки: {_errCode}");
                    //12 = Текущий доступ к настройкам БРЛ не допускает их изменения. ОК при "1" в подключении
                    if (_errCode != 12)
                    {
                        _logger.LogWarning($"{DateTime.Now.ToString("HH:mm:ss:fffff")} QAS105 Qadmin API Ошибка в CloseQuikQadminAPI. Настройки не были сохранены, код ошибки: {_errCode} {errorText}");
                        return $"QAS105 Qadmin API Ошибка в CloseQuikQadminAPI. Настройки не были сохранены, код ошибки: {_errCode} {errorText}";
                    }
                }
                else
                {
                    _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} Настройки успешно сохранены");
                }

                // Закрытие файла настроек
                _errCode = NativeMethods.QDAPI_DLCloseFile(firm);

                if (_errCode != (int)QDAPI_Errors.QDAPI_ERROR_SUCCESS)
                {
                    string errorText = CommonServices.QuikService.GetErrorDescription(_errCode);
                    _logger.LogWarning($"{DateTime.Now.ToString("HH:mm:ss:fffff")} QAS106 Qadmin API Файл не был закрыт. Код ошибки: {_errCode} {errorText}");
                    return $"QAS106 Qadmin API Файл не был закрыт. Код ошибки: {_errCode} {errorText}";
                }
                else
                {
                    _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} Qadmin API Файл успешно закрыт");
                }

                // Отключение от Сервера Quik Administrator
                _errCode = NativeMethods.QDAPI_Disconnect();

                if (_errCode != (int)QDAPI_Errors.QDAPI_ERROR_SUCCESS)
                {
                    string errorText = CommonServices.QuikService.GetErrorDescription(_errCode);
                    _logger.LogWarning($"{DateTime.Now.ToString("HH:mm:ss:fffff")} QAS107 Ошибка отключения от сервера. Код ошибки: {_errCode} {errorText}");
                    return $"QAS107 Ошибка отключения от сервера. Код ошибки: {_errCode} {errorText}";
                }
                else
                {
                    _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} Отключение от сервера успешно произведено");
                    return "OK";
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"{DateTime.Now.ToString("HH:mm:ss:fffff")} QAS108 CheckConnectionQadmin Error {ex.Message}");
                return $"QAS108 CheckConnectionQadmin Error {ex.Message}";
            }
        }

        public ListStringResponseModel CloseQuikAPI(int resultEditBrl, string firm, ListStringResponseModel response)
        {
            var resultClose = CloseQuikQadminAPI(firm);

            if (resultClose == null)
            {
                _logger.LogWarning($"{DateTime.Now.ToString("HH:mm:ss:fffff")} QAS109 No answer received when close QUIK BRL " + firm);
                response.IsSuccess = false;
                response.Messages.Add($"QAS109 Error at close QUIK BRL {firm}, error={resultClose}");
            }
            else if (resultClose.Equals("OK"))
            {
                _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} Файл успешно закрыт");
                if (resultEditBrl == 0)
                {
                    return response;
                }
                else
                {
                    string errorText = CommonServices.QuikService.GetErrorDescription(resultEditBrl);

                    _logger.LogWarning($"{DateTime.Now.ToString("HH:mm:ss:fffff")} QAS110 Error! при выполнении задачи = {resultEditBrl} {errorText}");

                    response.IsSuccess = false;
                    response.Messages.Add($"QAS110 Error! при выполнении задачи = {resultEditBrl} {errorText}");
                }
            }
            else
            {
                _logger.LogWarning($"{DateTime.Now.ToString("HH:mm:ss:fffff")} QAS111 Error at close QUIK BRL {firm}, error={resultClose}");

                response.IsSuccess = false;
                response.Messages.Add($"QAS111 Error at close QUIK BRL {firm}, error={resultClose}");
            }

            return response;
        }
    }
}
