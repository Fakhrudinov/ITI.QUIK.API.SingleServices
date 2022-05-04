using System.ComponentModel;

namespace DataAbstraction.Models
{
    public class TemplateAndCodesModel
    {
        public string Template { get; set; }

        public MatrixClientCodeModel[] ClientCodes { get; set; }
    }
}
