using System.ComponentModel;

namespace DataAbstraction.Models
{
    public class MatrixClientCodeModel
    {
        [DefaultValue("BP12345-MO-01")]
        public string MatrixClientCode { get; set; }
    }
}
