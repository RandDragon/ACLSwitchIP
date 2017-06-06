using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACLSwitchIP
{
     public class ClientInternet
    {

        public string Ip { get; set; }
        public int Port { get; set; }
        public string Commutator { get; set; }
        


        public ClientInternet (int port, string commutator, string ip)
        {
            Port = port;
            Commutator = commutator + ".vs.bcitelecom.ru";
            Ip = ip;
            
            
        }

        public ClientInternet () { }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if ((obj as ClientInternet) != null)
            {
                if (this.Ip == (obj as ClientInternet).Ip && this.Commutator == (obj as ClientInternet).Commutator && this.Port == (obj as ClientInternet).Port) return true;
                else return false;
            }
            else
                return false;
        }

        public override string ToString()
        {
            return Ip;
        }
    }
}
