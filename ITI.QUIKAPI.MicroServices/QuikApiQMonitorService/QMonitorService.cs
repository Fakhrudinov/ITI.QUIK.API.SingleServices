using DataAbstraction.Interfaces;
using DataAbstraction.Models;
using DataAbstraction.Models.Connections;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using QMonitor.API;
using System.Text;

namespace QuikApiQMonitorService
{
    public unsafe class QMonitorService : IQMonitorService
    {
        private int _tryConnect = 5;
        private ILogger<QMonitorService> _logger;
        private QadminLogon _logon;

        public QMonitorService(IOptions<QadminLogon> logon, ILogger<QMonitorService> logger)
        {
            _logger = logger;
            _logon = logon.Value;
        }

        public ListStringResponseModel CheckConnections()
        {
            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} QMonitorService CheckConnections Called");

            ListStringResponseModel response = new ListStringResponseModel();

            void* handle = QMonitorConnect();

            if (QMonitorAPI.GetStatus(handle) == QMonitorAPI.WQCTL_STATUS_CONNECTED)
            {
                // do our job
                response.Messages.Add("Connection to QMonitor OK");
            }
            else
            {
                return ReturnError(response, handle);
            }

            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} QMonitorService CheckConnections Disconnect");
            QMonitorAPI.Disconnect(handle);

            return response;
        }

        public ListStringResponseModel ReloadDealerLib(string library)
        {
            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} QMonitorService ReloadDealerLib {library} Called");

            ListStringResponseModel response = new ListStringResponseModel();

            void* handle = QMonitorConnect();

            if (QMonitorAPI.GetStatus(handle) == QMonitorAPI.WQCTL_STATUS_CONNECTED)
            {
                // do our job
                int reloadResult = QMonitorAPI.ReloadDealLib(handle, library);//MC0138200000
                
                if (reloadResult != 0)
                {
                    _logger.LogWarning($"{DateTime.Now.ToString("HH:mm:ss:fffff")} Error! QMonitorService ReloadDealerLib {library} failed, result={reloadResult}");
                    response.Messages.Add($"Error! QMonitorService ReloadDealerLib {library} failed, result={reloadResult}");
                    response.IsSuccess = false;
                }
                else
                {
                    _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} QMonitorService ReloadDealerLib {library} OK");
                }
            }
            else
            {
                return ReturnError(response, handle);
            }

            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} QMonitorService CheckConnections Disconnect");
            QMonitorAPI.Disconnect(handle);

            return response;
        }

        private ListStringResponseModel ReturnError(ListStringResponseModel response, void* handle)
        {

            int status = QMonitorAPI.GetStatus(handle);
            string statusDescription = "";
            /*
            2.1.7 Константы для определения статуса соединения
            Константа Возможные значения Описание
            WQCTL_STATUS_CONNECTING 0 Подключение
            WQCTL_STATUS_CONNECTED 1 Подключен
            WQCTL_STATUS_DISCONNECTING 2 Отключение
            WQCTL_STATUS_DISCONNECTED 3 Отключен
            WQCTL_STATUS_INVALID_HANDLE - 1 Подключение не установлено
            */
            switch (status)
            {
                case 0:
                    statusDescription = "Подключение";
                    break;
                case 1:
                    statusDescription = "Подключен";
                    break;
                case 2:
                    statusDescription = "Отключение";
                    break;
                case 3:
                    statusDescription = "Отключен";
                    break;
                case -1:
                    statusDescription = "Подключение не установлено";
                    break;
            }

            _logger.LogWarning($"{DateTime.Now.ToString("HH:mm:ss:fffff")} QMonitorService connection failed, status={status} ({statusDescription})");
            response.Messages.Add($"QMonitorService connection failed, status={status} ({statusDescription})");
            response.IsSuccess = false;

            return response;
        }

        private void* QMonitorConnect()
        {
            // Инициализировать библиотеку.
            QMonitorAPI.Init();

            // Получить параметры для подключения.
            StringBuilder settingsFileName = new StringBuilder(Path.Combine(Directory.GetCurrentDirectory(), "client.ini"));
            StringBuilder sectionName = new StringBuilder("testQuik");
            StringBuilder userName = new StringBuilder(_logon.Login);
            StringBuilder password = new StringBuilder(_logon.Password);

            // Подключиться.
            void* handle = QMonitorAPI.Connect(settingsFileName, sectionName, userName, password);
            while (QMonitorAPI.GetStatus(handle) == QMonitorAPI.WQCTL_STATUS_CONNECTING)
            {
                System.Threading.Thread.Sleep(1000);
                _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} QMonitorService QMonitorConnect try to connect, attempt left = " + _tryConnect);                
                if (_tryConnect == 0)
                {
                    break;
                }
                _tryConnect--;
            }

            if (QMonitorAPI.GetStatus(handle) == QMonitorAPI.WQCTL_STATUS_CONNECTED)
            {
                _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} QMonitorService QMonitorConnect: Connection to QMonitor OK");
                System.Threading.Thread.Sleep(2000);// нужно для корректного подключения. Без него следующий запрос зависает или не получаем данные                
            }

            return handle;
        }
    }
}