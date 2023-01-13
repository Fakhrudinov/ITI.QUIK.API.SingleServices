namespace DataAbstraction.Models.Responses
{
    public class DiscountValuesListResponse
    {
        public DiscountValuesListResponse()
        {
            Discounts = new List<DiscountAndSecurityModel>();

            IsSuccess = true;
            Messages = new List<string>();
        }

        public List<DiscountAndSecurityModel> Discounts { get; set; }

        public bool IsSuccess { get; set; }
        public List<string> Messages { get; set; }
    }
}
