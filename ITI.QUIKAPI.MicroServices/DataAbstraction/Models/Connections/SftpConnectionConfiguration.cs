namespace DataAbstraction.Models.Connections
{
    public class SftpConnectionConfiguration
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
