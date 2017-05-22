using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ACLSwitchIP
{
    class WorkDataBase
    {
        public List<Client> ClientList = new List<Client>();
        public List<Client> ClientSort { get; set; }
        private string xmlDB { get; set; }

        private StreamReader sr = new StreamReader("LoadDB.csv", Encoding.GetEncoding(1251));

 
        public WorkDataBase()
        {
            StartDB();
            xmlDB = "DateBase";
        }

        public void StartDB()
        {
            sr.ReadLine();
            List<Client> list = new List<Client>();

            while (!sr.EndOfStream)
            {
                try
                {

                    string[] str = sr.ReadLine().Split(';');

                    String[] port = str[0].Split('@');
                    int numport;

                    int.TryParse(port[0], out numport);
                    Client client = new Client(numport, port[1], str[1]);
                    list.Add(client);
                    ClientList = list;
                }
                catch (Exception)
                { }
            }
        }

        public void SaveDB(List<Client> list)
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Client>));
            Stream fStream = new FileStream(xmlDB, FileMode.Append, FileAccess.Write);
            xmlFormat.Serialize(fStream, list);
            fStream.Close();
        }

        public void LoadDB(WorkDataBase DataBase)
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Client>));
            Stream fStream = new FileStream(xmlDB, FileMode.Open, FileAccess.Read);
            DataBase.ClientList = (List<Client>)xmlFormat.Deserialize(fStream);
        }

        public void resultFind(string str)
        {
            ClientSort = new List<Client>();
            foreach(Client client in ClientList)
            {
                if (str.Equals(client.Commutator)) ClientSort.Add(client); 
            }
        }

    }
}
