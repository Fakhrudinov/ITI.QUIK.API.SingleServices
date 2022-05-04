using System.ComponentModel;

namespace DataAbstraction.Models
{
    public class TemplateAndQuikCodeModel
    {
        public string Template { get; set; }
        [DefaultValue("BP12345/01")]
        public string ClientCode { get; set; }
    }
}
