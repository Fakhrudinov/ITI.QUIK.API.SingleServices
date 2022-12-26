﻿namespace DataAbstraction.Models.Responses
{
    public class DiscountSingleResponse
    {
        public DiscountSingleResponse()
        {
            IsSuccess = true;
            Messages = new List<string>();

            Discount = new DiscountModel();
        }

        public DiscountModel ? Discount { get; set; }
        public bool IsSuccess { get; set; }
        public List<string> Messages { get; set; }
    }
}
