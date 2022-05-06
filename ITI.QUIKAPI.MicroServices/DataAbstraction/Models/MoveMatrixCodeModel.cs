using System.ComponentModel;

namespace DataAbstraction.Models
{
    public class MoveMatrixCodeModel
    {
        public string FromTemplate { get; set; }
        public string ToTemplate { get; set; }
        [DefaultValue("BP12345-MS-01")]
        public string ClientCode { get; set; }
    }
}
