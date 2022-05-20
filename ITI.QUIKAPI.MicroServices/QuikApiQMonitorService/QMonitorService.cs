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
                    _logger.LogWarning("QMonitorService CheckConnections failed, QMonitorAPI.WQCTL_STATUS_CONNECTING=" + QMonitorAPI.WQCTL_STATUS_CONNECTING);
                    response.Messages.Add("QMonitorService CheckConnections failed, QMonitorAPI.WQCTL_STATUS_CONNECTING=" + QMonitorAPI.WQCTL_STATUS_CONNECTING);
                    response.IsSuccess = false;
                    break;
                }
            }

            if (QMonitorAPI.WQCTL_STATUS_CONNECTING == 0)
            {
                _logger.LogInformation("QMonitorService CheckConnections OK, QMonitorAPI.WQCTL_STATUS_CONNECTING=" + QMonitorAPI.WQCTL_STATUS_CONNECTING);
                response.Messages.Add("Connection OK, QMonitorAPI.WQCTL_STATUS_CONNECTING=" + QMonitorAPI.WQCTL_STATUS_CONNECTING);
                //System.Threading.Thread.Sleep(3000);
                //Int32 usersCount = 0;
                //IntPtr users = IntPtr.Zero;
                //// выделяем память на 5000 пользователей, если нужно больше, то подставляем нужное количество
                //int size = Marshal.SizeOf(typeof(QMonitorAPI.wqctl_user));
                //users = Marshal.AllocHGlobal(5000 * size);

                //// Получить список пользователей.
                //QMonitorAPI.GetUsers(handle, ref usersCount, users);
                //IntPtr currentUser = users;
                //for (int i = 0; i < usersCount; i++)
                //{
                //    QMonitorAPI.wqctl_user user = (QMonitorAPI.wqctl_user)Marshal.PtrToStructure(currentUser, typeof(QMonitorAPI.wqctl_user));


                //    response.Messages.Add(user.UserID + " " + user.UserName + " " + user.ip_address + " Entry=" + user.Entry + " CUserID=" + user.CUserID +
                //        " ConnectTime=" + user.ConnectTime + " FirmName=" + user.FirmName + " Flag=" + user.Flag);

                //    Console.WriteLine(user.UserID + " " + user.UserName + " " + user.ip_address + " Entry=" + user.Entry + " CUserID=" + user.CUserID +
                //        " ConnectTime=" + user.ConnectTime + " FirmName=" + user.FirmName + " Flag=" + user.Flag);

                //    currentUser = (IntPtr)((int)currentUser + size);
                //}
                //Console.WriteLine("usersCount=" + usersCount);


                //DateTime dt = DateTime.Now;

                //ok, работает отправка конкретному connectID            
                //int sendMessageResult = QMonitorAPI.SendMessage(handle, -1, "Сообщение в QUIK от " + dt.ToString("HH:mm"));
                //Console.WriteLine("sendMessageResult= " + sendMessageResult);

                /*
                // ok, работает
                int reloadResult = QMonitorAPI.ReloadDealLib(handle, "1111111");//MC0138200000
                Console.WriteLine("reloadResult= " + reloadResult);
                */

                //ok, работает
                //int resultRecalcLimits = QMonitorAPI.RecalcLimits(handle, "MC0138200000", "BP0593");//MC0138200000
                //Console.WriteLine("resultRecalcLimits= " + resultRecalcLimits);

                /*
                //ok, работает
                //int resultUserControl = QMonitorAPI.UserControl(handle, 2, 435651, "Disconnect in time " + dt.ToString("HH:mm"));//disconnect
                int resultUserControl = QMonitorAPI.UserControl(handle, 0, 50, "MC0138200000");//1=запрет торговли //0=разрешение торговли
                Console.WriteLine("resultUserControl= " + resultUserControl);
                */


            }

            _logger.LogInformation("QMonitorService CheckConnections Disconnect");
            QMonitorAPI.Disconnect(handle);

            return response;
        }
    }
}