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



        public Client (int port, string commutator, string ip)
        {
            Port = port;
            Commutator = commutator;
            Ip = ip;
            SwitchName = commutator + ".vs.bcitelecom.ru";
            aclIP = false;
        }

        public Client() { }
    }
}
