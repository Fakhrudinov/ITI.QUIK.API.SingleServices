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
            _logger.LogInformation("QMonitorService CheckConnections Called");

            ListStringResponseModel response = new ListStringResponseModel();

            void* handle = QMonitorConnect();

            //// Инициализировать библиотеку.
            //QMonitorAPI.Init();

            //// Получить параметры для подключения.
            //StringBuilder settingsFileName = new StringBuilder(Path.Combine(Directory.GetCurrentDirectory(), "client.ini"));
            //StringBuilder sectionName = new StringBuilder("testQuik");
            //StringBuilder userName = new StringBuilder(_logon.Login);
            //StringBuilder password = new StringBuilder(_logon.Password);

            //// Подключиться.
            //void* handle = QMonitorAPI.Connect(settingsFileName, sectionName, userName, password);
            //while (QMonitorAPI.GetStatus(handle) == QMonitorAPI.WQCTL_STATUS_CONNECTING)
            //{
            //    System.Threading.Thread.Sleep(1000);
            //    _logger.LogInformation("QMonitorService CheckConnections try to connect, attempt left = " + _tryConnect);

            //    _tryConnect--;
            //    if (_tryConnect < 0)
            //    {
            //        break;
            //    }
            //}

            if (QMonitorAPI.GetStatus(handle) == QMonitorAPI.WQCTL_STATUS_CONNECTED)
            {
                _logger.LogInformation("QMonitorService CheckConnections: Connection to QMonitor OK");
                response.Messages.Add("Connection to QMonitor OK");
                System.Threading.Thread.Sleep(2000);// нужно для корректного подключения. Без него следующий запрос зависает или не получаем данные                
            }
            else
            {
                _logger.LogWarning("QMonitorService CheckConnections failed, QMonitorAPI.GetStatus(handle)=" + QMonitorAPI.GetStatus(handle));
                response.Messages.Add("QMonitorService CheckConnections failed, QMonitorAPI.GetStatus(handle)=" + QMonitorAPI.GetStatus(handle));
                response.IsSuccess = false;
/*
2.1.7 Константы для определения статуса соединения
Константа Возможные значения Описание
WQCTL_STATUS_CONNECTING 0 Подключение
WQCTL_STATUS_CONNECTED 1 Подключен
WQCTL_STATUS_DISCONNECTING 2 Отключение
WQCTL_STATUS_DISCONNECTED 3 Отключен
WQCTL_STATUS_INVALID_HANDLE - 1 Подключение не установлено
*/
            }

            _logger.LogInformation("QMonitorService CheckConnections Disconnect");
            QMonitorAPI.Disconnect(handle);

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
                _logger.LogInformation("QMonitorService CheckConnections try to connect, attempt left = " + _tryConnect);

                _tryConnect--;
                if (_tryConnect < 0)
                {
                    break;
                }
            }

            return handle;
        }
    }
}