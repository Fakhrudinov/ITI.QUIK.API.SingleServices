namespace DataAbstraction.Models
{
    public class ClientCodesAndCommentModel
    {
        public string CodesMS { get; set; }
        public string CodesFX { get; set; }
        public string CodesCD { get; set; }
        public string CodesRF { get; set; }
        public string CodesRS { get; set; }

        public List<string> CodesUnique { get; set; } = new List<string>();

        public string Comment { get; set; }
    }
}
