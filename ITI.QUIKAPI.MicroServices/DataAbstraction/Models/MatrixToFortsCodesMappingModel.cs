using System.ComponentModel;

namespace DataAbstraction.Models
{
    public class MatrixToFortsCodesMappingModel
    {
        [DefaultValue("BP12345-RF-01")]
        public string MatrixClientCode { get; set; }
        [DefaultValue("C0000abc")]
        public string FortsClientCode { get; set; }
    }
}
