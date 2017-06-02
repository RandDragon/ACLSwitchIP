using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACLSwitchIP
{
    public class Client
    {

        public int Port { get; set; }
        public string Commutator { get; set; }
        public string Ip { get; set; }
        public string SwitchName { get; set; }
        public bool aclIP { get; set; }
        public int ID { get; }



        public Client (int port, string commutator, string ip)
        {
            Port = port;
            Commutator = commutator;
            Ip = ip;
            SwitchName = commutator + ".vs.bcitelecom.ru";
            aclIP = false;
        }

        public Client() { }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (ReferenceEquals(this, obj)) return true;
            //if (this.ID == (obj as Client).ID) return true;
            if (this.Ip == (obj as Client).Ip && this.SwitchName == (obj as Client).SwitchName && this.Ip == (obj as Client).Ip) return true;
            else 
            return false;
        }
    }
}
