using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACLSwitchIP
{
    public class ClientPhone
    {
        public List<string> PhoneIP { get; set; }
        public string PhoneNumber { get; set; }
        
        public ClientPhone() { }

        public ClientPhone(string phoneNumber)
        {
            PhoneNumber = phoneNumber;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if ((obj as ClientPhone) != null)
            {
                if (this.PhoneNumber == (obj as ClientPhone).PhoneNumber) return true;
                else return false;
            }
            else
                return false;
        }

        public override string ToString()
        {
            return PhoneNumber;
        }
    }
}
