namespace DataAbstraction.Models
{
    public class StringResponceModel
    {
        public StringResponceModel()
        {
            IsSuccess = true;
        }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
