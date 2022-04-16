using DataAbstraction.Interfaces;
using Microsoft.Extensions.Configuration;
using QDealerAPI;
using System.Runtime.InteropServices;

namespace SpotBrlService
{
    public class SpotService : ISpotBrlService
    {
        private readonly IConfiguration _configuration;

        private int _errCode = -100;
        private const string _spotFIRM = "MC0138200000";
        private string _login;// = "QDealerAPI"
        private string _password;// = "1qaZXsw2"

        public SpotService(IConfiguration configuration)
        {
            _configuration = configuration;

            _login = _configuration["QadminLogin"];
            _password = _configuration["QadminPassword"];
        }


        public async Task<string> CheckConnection()
        {
            Task<string> connectionTest = CheckConnectionQadmin();

            return await connectionTest;
        }

        private async Task<string> CheckConnectionQadmin()
        {
            Console.WriteLine(" - Start method  CheckConnectionQadmin");
            try
            {
                IntPtr conErrPtr = IntPtr.Zero;
                int errCode = NativeMethods.QDAPI_Connect(@"QDealerAPI.ini", _login, _password, ref conErrPtr);
                if (errCode != (int)QDAPI_Errors.QDAPI_ERROR_SUCCESS)
                {
                    string? conErr = Marshal.PtrToStringAnsi(conErrPtr);
                    NativeMethods.QDAPI_FreeMemory(ref conErrPtr);

                    if (conErr == null)
                    {
                        return $"Ошибка подключения к серверу QA - conErr is null";
                    }

                    Console.WriteLine("Ошибка подключения к серверу QA: {0}", conErr);
                    return $"Ошибка подключения к серверу QA: {conErr}";
                }
                else
                {
                    Console.WriteLine("Соединение установлено");
                }
                errCode = NativeMethods.QDAPI_DLOpenFile(_spotFIRM, 0);
                if (errCode != (int)QDAPI_Errors.QDAPI_ERROR_SUCCESS)
                {
                    Console.WriteLine("Exception connect to Qadmin. Файл не был открыт. Код ошибки: {0}", errCode);
                    return $"Exception connect to Qadmin. Файл не был открыт. Код ошибки: {errCode}";
                }
                else
                {
                    Console.WriteLine("Файл успешно открыт");


                    var resultClose = await CloseQuikQadminAPI(_spotFIRM);

                    if (resultClose == null)
                    {
                        return "No answer received when close QUIK BRL MC0138200000";
                    }
                    else if (resultClose.Equals("close OK"))
                    {
                        return "OK";
                    }
                    else
                    {
                        return resultClose;
                    }
                }
            }
            catch (Exception con1)
            {
                Console.WriteLine("CheckConnectionQadmin Error " + con1.Message);
                return $"CheckConnectionQadmin Error {con1.Message}";
            }
        }

        private Task<string> CloseQuikQadminAPI(string Firm)
        {
            Console.WriteLine(" - Start method CloseQuikQadminAPI");
            // Сохранение изменений
            _errCode = NativeMethods.QDAPI_DLUpdateFile(Firm);

            if (_errCode != (int)QDAPI_Errors.QDAPI_ERROR_SUCCESS)
            {
                Console.WriteLine("Настройки не были сохранены. Код ошибки: {0}", _errCode);
                //12 = Текущий доступ к настройкам БРЛ не допускает их изменения. ОК при "1" в подключении
                if (_errCode != 12)
                {
                    Console.WriteLine("Ошибка в CloseQuikQadminAPI", "Настройки не были сохранены, код ошибки: " + _errCode);
                    return Task.FromResult($"Ошибка в CloseQuikQadminAPI. Настройки не были сохранены, код ошибки: {_errCode}");
                }
            }
            else
            {
                Console.WriteLine("Настройки успешно сохранены");
            }

            // Закрытие файла настроек
            _errCode = NativeMethods.QDAPI_DLCloseFile(Firm);

            if (_errCode != (int)QDAPI_Errors.QDAPI_ERROR_SUCCESS)
            {
                Console.WriteLine("Файл не был закрыт. Код ошибки: {0}", _errCode);
                return Task.FromResult($"Файл не был закрыт. Код ошибки: {_errCode}");
            }
            else
            {
                Console.WriteLine("Файл успешно закрыт");
            }

            // Отключение от Сервера Quik Administrator
            _errCode = NativeMethods.QDAPI_Disconnect();

            if (_errCode != (int)QDAPI_Errors.QDAPI_ERROR_SUCCESS)
            {
                Console.WriteLine("Ошибка отключения от сервера. Код ошибки: {0}", _errCode);
                return Task.FromResult($"Ошибка отключения от сервера. Код ошибки: {_errCode}");
            }
            else
            {
                Console.WriteLine("Отключение от сервера успешно произведено");
                return Task.FromResult("close OK");
            }
        }
    }
}