using System.ComponentModel;

namespace DataAbstraction.Models
{
    public class MatrixToFortsCodesMappingModel
    {
        //used in QuikSftpServerController   [HttpPost("NewClient/OptionWorkshop")]
        //used in QuikSftpServerController   [HttpPost("NewClient")]
        //used in QuikQAdminEDPApiController [HttpPost("SetNewEdpRelation")]
        [DefaultValue("BP12345-RF-01")]
        public string MatrixClientCode { get; set; }
        [DefaultValue("C000abc")]
        public string FortsClientCode { get; set; }
    }
}
