
using System.ComponentModel;

namespace DataAbstraction.Models
{
    public class MoveMatrixFortsCodeModel
    {
        public string FromTemplate { get; set; }
        public string ToTemplate { get; set; }
        [DefaultValue("C000abc")]
        public string FortsClientCode { get; set; }
    }
}
