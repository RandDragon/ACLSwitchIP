using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACLSwitchIP
{
    public class Client
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool ACL { get; set; }
        
        public ClientInternet Internet { get; set; }
        public ClientIPTV IPTV { get; set; }
        public ClientPhone Phone { get; set; }
        

        public Client (int id, string name)
        {
            ID = id;
            Name = name;
            ACL = false;
        }

        

        public Client() { }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (this.ID == (obj as Client).ID) return true;
            else 
            return false;
        }
    }
}
