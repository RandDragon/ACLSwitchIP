using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACLSwitchIP
{
    class Client
    {

        public int Port { get; private set; }
        public string Commutator { get; private set; }
        public string Ip { get; private set; }
        public string SwitchName { get; private set; }
        public bool aclIP { get; set; }



        public Client (int port, string commutator, string ip)
        {
            Port = port;
            Commutator = commutator;
            Ip = ip;
            SwitchName = commutator + ".vs.bcitelecom.ru";
            aclIP = false;
        }
    }
}
