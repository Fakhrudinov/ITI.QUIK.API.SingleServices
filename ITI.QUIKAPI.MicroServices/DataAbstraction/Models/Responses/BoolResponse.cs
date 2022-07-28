namespace DataAbstraction.Models.Responses
{
    public class BoolResponse
    {
        public BoolResponse()
        {
            IsSuccess = true;
            Messages = new List<string>();
            IsTrue = false;
        }
        public bool IsSuccess { get; set; }
        public List<string> Messages { get; set; }

        public bool IsTrue { get; set; } = false;
    }
}
