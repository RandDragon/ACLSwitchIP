using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACLSwitchIP
{
    class WorkDataBase
    {
        private List<Client> ClientList = new List<Client>();
        private StreamReader sr = new StreamReader("LoadDB.csv", Encoding.GetEncoding(1251));

        public void StartDB()
        {
            sr.ReadLine();

            while (!sr.EndOfStream)
            {
                try
                {

                    string[] str = sr.ReadLine().Split(';');

                    String[] port = str[0].Split('@');
                    int numport;

                    int.TryParse(port[0], out numport);
                    Client client = new Client(numport, port[1], str[1]);
                    ClientList.Add(client);

                }
                catch (Exception)
                { }
            }
        }
    }
}
