using System.ComponentModel;

namespace DataAbstraction.Models
{
    public class PubringKeyModel
    {
        [DefaultValue(1650809567)]
        public int Time { get; set; }
        [DefaultValue("A37F2EAAF3316475")]
        public string KeyID { get; set; }
        [DefaultValue("99001D0462655ADF0000010080BE92B3BDB54D9574A37F2EAAF3316475000511")]
        public string RSAKey { get; set; }
    }
}

