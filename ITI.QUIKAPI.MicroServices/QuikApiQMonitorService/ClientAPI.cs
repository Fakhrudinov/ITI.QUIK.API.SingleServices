
using System.Runtime.InteropServices;
using System.Text;
using System;
namespace QMonitor.API
{

    /// <summary>
    /// Обертки для библиотек Квика.
    /// </summary>
    public static unsafe class QMonitorAPI
    {
        /// <summary>
        /// Поля располагаются последовательно. В данной реализации структуры возвращается только первый пользователь.
        /// </summary>
        /// <remarks>Pack = 4 - выравнивание по границе 4 байт (по умолчанию тоже 4), тогда размер структуры 308 байт, данные (по первому пользователю) корректные.</remarks>
        [StructLayout(LayoutKind.Sequential, Pack = 4)]
        public struct wqctl_user
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
            public string UserName;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
            public string FirmName;

            public int UserID;			//user identifier in Quik database - ID пользователя в базе квика
            public int CUserID;			//for users that are connected to access servers this is an identifier of such server, and 0 otherwise - для пользователей, подключенных к серверам - ID сервера, для остальных 0
            public int Entry;			//identifier of this connection - unique number of session.  0 for disconnected users - ID соединения - уникальный номер сессии, для неподключенных 0
            public short Flag;			//WQCTL_USTATUS_*   defines Logged/Disocnnected, Disconnect status, access server flag - определяет статус залогиненный или неподключенный, статус подключения/разрыва подключения, сервер доступа

            public int ConnectTime;		//Either DisconnectTime - также время разрыва подключения

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string ip_address;
        };

        public const int WQCTL_STATUS_CONNECTING = 0;
        public const int WQCTL_STATUS_CONNECTED = 1;
        public const int WQCTL_STATUS_DISCONNECTING = 2;
        public const int WQCTL_STATUS_DISCONNECTED = 3;
        public const int WQCTL_STATUS_INVALID_HANDLE = -1;

        /// <summary>
        /// Производит подключение.
        /// </summary>
        [DllImport("ClientApi.DLL", EntryPoint = "wqctl_connect", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto)]
        public static extern void* Connect(
            [MarshalAs(UnmanagedType.LPStr)]StringBuilder settingsFile,
            [MarshalAs(UnmanagedType.LPStr)]StringBuilder settingsSection,
            [MarshalAs(UnmanagedType.LPStr)]StringBuilder name,
            [MarshalAs(UnmanagedType.LPStr)]StringBuilder password
            );

        /// <summary>
        /// Производит инициализацию.
        /// </summary>
        [DllImport("ClientApi.dll", EntryPoint = "wqctl_init", CallingConvention = CallingConvention.StdCall)]
        public static extern void Init();

        /// <summary>
        /// Получает состояние подключения.
        /// </summary>
        [DllImport("ClientApi.dll", EntryPoint = "wqctl_get_status", CallingConvention = CallingConvention.StdCall)]
        public static extern int GetStatus(void* handle);

        /// <summary>
        /// Получает список подключенных пользователей.
        /// </summary>
        [DllImport("ClientApi.dll", EntryPoint = "wqctl_get_users", CallingConvention = CallingConvention.StdCall)]
        public static extern int GetUsers(void* handle, ref int usercount, IntPtr users);

        /// <summary>
        /// Закрывает соединение.
        /// </summary>
        [DllImport("ClientApi.dll", EntryPoint = "wqctl_disconnect", CallingConvention = CallingConvention.StdCall)]
        public static extern int Disconnect(void* handle);
    };
}
