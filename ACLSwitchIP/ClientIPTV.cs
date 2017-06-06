using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACLSwitchIP
{
    public class ClientIPTV
    {
        public List<string> IPTV { get; set; }

        public ClientIPTV() { }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (ReferenceEquals(this, obj)) return true;
            else
                return false;
        }

    }
}
