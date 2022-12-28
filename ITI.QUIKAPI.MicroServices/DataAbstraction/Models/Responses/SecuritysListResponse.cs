namespace DataAbstraction.Models.Responses
{
    public class SecuritysListResponse
    {
        public SecuritysListResponse()
        {
            IsSuccess = true;
            Messages = new List<string>();

            Securitys = new List<string>();
        }
        public List<string> Securitys { get; set; }

        public bool IsSuccess { get; set; }
        public List<string> Messages { get; set; }
    }
}
