using System.ComponentModel;

namespace DataAbstraction.Models
{
    public class MoveQuikCodeModel
    {
        public string FromTemplate { get; set; }
        public string ToTemplate { get; set; }
        [DefaultValue("BP12345/01")]
        public string ClientCode { get; set; }
    }
}
