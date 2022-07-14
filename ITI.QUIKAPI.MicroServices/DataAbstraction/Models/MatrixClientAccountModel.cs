using System.ComponentModel;

namespace DataAbstraction.Models
{
    public class MatrixClientAccountModel
    {
        [DefaultValue("BP12345")]
        public string MatrixClientAccount { get; set; }
    }
}
