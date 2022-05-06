using System.ComponentModel;

namespace DataAbstraction.Models
{
    public class TemplateAndMatrixCodeModel
    {
        public string Template { get; set; }
        [DefaultValue("BP12345-MO-01")]
        public string ClientCode { get; set; }
    }
}
