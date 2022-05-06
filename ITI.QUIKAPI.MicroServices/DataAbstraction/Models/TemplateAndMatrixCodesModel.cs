using System.ComponentModel;

namespace DataAbstraction.Models
{
    public class TemplateAndMatrixCodesModel
    {
        public string Template { get; set; }

        public MatrixClientCodeModel[] ClientCodes { get; set; }
    }
}
