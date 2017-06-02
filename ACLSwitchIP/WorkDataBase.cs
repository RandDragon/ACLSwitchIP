using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ACLSwitchIP
{
    class WorkDataBase
    {
        public List<Client> ClientList = new List<Client>();
        private List<Client> SaveClients;
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

        public void Update(List<Client> list)
        {
            int count = 0;
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Client>));
            Stream LoadStream = new FileStream(xmlDB, FileMode.Open, FileAccess.Read);
            SaveClients = (List<Client>)xmlFormat.Deserialize(LoadStream);
            LoadStream.Close();

            //Проверяем на наличее новых записей в ClientList
            foreach (Client client in list)
            {
                int index = 0;
                foreach (Client client2 in SaveClients )
                {
                    if (client.Equals(client2)) index++;
                }
                if (index == 1) index = 0;
                else
                {
                    SaveClients.Add(client);
                    count++;
                }
            }

            //Проверяем, что в актуальном ClientList не были ли удалены некоторые клиенты
            List<Client> testList = new List<Client>();
            testList = SaveClients.ToList<Client>();
            foreach (Client client in testList)
            {
                int index = 0;
                foreach(Client client2 in list)
                {
                    if (index > 0) break;
                    if (client.Equals(client2))
                    {
                        index++;
                    }
                }
                if (index == 0)
                {
                    SaveClients.Remove(client);
                    count++;
                }
                else index = 0;
            }

            //Проверяем, были ли изменения в клиентах

            //foreach(Client client in testList)
            //{
                
            //    foreach(Client client2 in list)
            //    {
                    
            //        if (client.ID == client2.ID && !client.Equals(client2))
            //        {
            //            SaveClients.Remove(client);
            //            SaveClients.Add(client2);
            //            count++;
            //        }
            //    }
                
            //}

            testList = null;
            Stream SaveStream = new FileStream(xmlDB, FileMode.Create, FileAccess.Write);
            xmlFormat.Serialize(SaveStream, SaveClients);
            SaveStream.Close();
            MessageBox.Show(String.Format("Обновлено {0} записей", count), "Обновление завершено", new MessageBoxButtons());

        }

        public void SaveDB(List<Client> list)
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Client>));
            Stream fStream = new FileStream(xmlDB, FileMode.Create, FileAccess.Write);
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
                //if (client.Commutator.Contains(str)) ClientSort.Add(client);
            }
        }

    }
}
