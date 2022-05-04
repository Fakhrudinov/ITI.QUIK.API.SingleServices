using System.ComponentModel;

namespace DataAbstraction.Models
{
    public class MoveCodeModel
    {
        public string FromTemplate { get; set; }
        public string ToTemplate { get; set; }
        [DefaultValue("BP12345-MO-01")]
        public string ClientCode { get; set; }
    }
}
