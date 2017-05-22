using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinimalisticTelnet;
using System.Threading;

namespace ACLSwitchIP
{
    class ActionACL
    {

        public static string addACL(Client client)
        {
            //string one = string.Format("create access_profile profile_id 5 profile_name allow_ip ip source_ip_mask 255.255.255.255");
            //string two = string.Format("config access_profile profile_id 5 add access_id {0} ip source_ip {1} port {2} permit", client.Port, client.Ip, client.Port);
            //TelnetConnection tc = new TelnetConnection(client.SwitchName, 23);
            //string s = tc.Login("roman", "hme55cumo", 500);
            //Console.Write(s);
            //string prompt = s.TrimEnd();
            //prompt = s.Substring(prompt.Length - 1, 1);
            //if (prompt != "#" && prompt != ">")
            //    throw new Exception("Connection failed");

            //prompt = "";
            //Console.Write(tc.Read());
            //tc.WriteLine(one);
            //Console.Write(tc.Read());
            //Thread.Sleep(10000);
            //Console.Write(tc.Read());
            //tc.WriteLine(two);
            //Console.Write(tc.Read());
            //Console.ReadLine();

            //client.aclIP = true;

            return "complite";

        }
    }
}
