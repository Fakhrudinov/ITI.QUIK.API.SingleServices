namespace DataAbstraction.Models
{
    public class NewClientOptionWorkShopModel
    {
        public ClientInformationModel Client { get; set; }
        public PubringKeyModel Key { get; set; }
        public MatrixToFortsCodesMappingModel [] CodesPairRF { get; set; }
    }
}
