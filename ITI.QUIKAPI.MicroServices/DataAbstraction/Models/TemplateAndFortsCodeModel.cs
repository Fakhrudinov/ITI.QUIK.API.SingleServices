using System.ComponentModel;

namespace DataAbstraction.Models
{
    public class TemplateAndFortsCodeModel
    {
        public string Template { get; set; }
        [DefaultValue("C000abc")]
        public string ClientCode { get; set; }
    }
}
