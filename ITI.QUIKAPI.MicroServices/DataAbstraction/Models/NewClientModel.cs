using System.ComponentModel;

namespace DataAbstraction.Models
{
    public class NewClientModel
    {
        [DefaultValue("false")]
        public bool isEDP { get; set; } = false;
        public ClientInformationModel Client { get; set; }
        public PubringKeyModel Key { get; set; }
        public MatrixClientCodeModel []? CodesMatrix { get; set; }
        public MatrixToFortsCodesMappingModel []? CodesPairRF { get; set; }
    }
}
