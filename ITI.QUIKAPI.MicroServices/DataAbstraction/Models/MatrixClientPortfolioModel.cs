using System.ComponentModel;

namespace DataAbstraction.Models
{
    public class MatrixClientPortfolioModel
    {
        [DefaultValue("BP12345-MO-01")]
        public string MatrixClientPortfolio { get; set; }
    }
}
