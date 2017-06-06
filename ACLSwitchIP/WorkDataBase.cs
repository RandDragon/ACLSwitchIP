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
        private List<Client> XmlClients;
        public List<Client> ClientSort { get; set; }
        private string xmlDB { get; set; }

        private StreamReader sr = new StreamReader("LoadDB.csv", Encoding.GetEncoding(1251));

 
        public WorkDataBase()
        {
            StartDB();
            xmlDB = "xmlDB.xml";
            if (File.Exists(xmlDB))
            {
                ClientList = Update(ClientList);
            }
            if (!File.Exists(xmlDB))
            {
                SaveDB(ClientList);
            }
            ClientSort = ClientList.ToList<Client>();
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

                    int ID;
                    int.TryParse(str[0], out ID);
                    string Name = str[1];
                    if (int.Parse(str[3]) == 4)
                    {
                        String[] port = str[4].Split('@');
                        int numport;
                        int.TryParse(port[0], out numport);
                        string Ip = str[5];

                        if (list == null || !list.Exists(xID => xID.ID == ID))
                        {
                            Client client = new Client(ID, Name);
                            client.Internet = new ClientInternet(numport, port[1], Ip);
                            list.Add(client);
                        }

                        if (list!=null && list.Exists(xID => xID.ID == ID))
                        {
                            list.Find(x => x.ID == ID).Internet = new ClientInternet(numport, port[1], Ip);
                        }

                    }
                    
                    if(int.Parse(str[3]) == 5)
                    {
                        string PhoneNumber = str[4];

                        if(list==null || !list.Exists(xID => xID.ID == ID))
                        {
                            Client client = new Client(ID, Name);
                            client.Phone = new ClientPhone(PhoneNumber);
                            list.Add(client);
                        }

                        if (list != null && list.Exists(xID => xID.ID == ID))
                        {
                            list.Find(x => x.ID == ID).Phone = new ClientPhone(PhoneNumber);
                        }
                    }

                    if(int.Parse(str[3]) == 9)
                    {
                        if (list == null || !list.Exists(xID => xID.ID == ID))
                        {
                            Client client = new Client(ID, Name);
                            client.IPTV = new ClientIPTV();
                            list.Add(client);
                        }

                        if (list != null && list.Exists(xID => xID.ID == ID))
                        {
                            list.Find(x => x.ID == ID).IPTV = new ClientIPTV();
                        }
                    }
                    
                    ClientList = list;
                }
                catch (Exception)
                { }
            }
        }

        public List<Client> Update(List<Client> list)
        {
            int count = 0;
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Client>));
            Stream LoadStream = new FileStream(xmlDB, FileMode.Open, FileAccess.Read);
            XmlClients = (List<Client>)xmlFormat.Deserialize(LoadStream);
            LoadStream.Close();

            

            //Проверяем на наличее новых записей в ClientList
            foreach (Client client in list)
            {
                if(!XmlClients.Exists(x => x.ID==client.ID))
                {
                    XmlClients.Add(client);
                    count++;
                }
            }

            //Проверяем, что в актуальном ClientList не были ли удалены некоторые клиенты
            List<Client> currentXmlList = new List<Client>();
            currentXmlList = XmlClients.ToList<Client>();
            foreach (Client client in currentXmlList)
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
                    XmlClients.Remove(client);
                    count++;
                }
                else index = 0;
            }

            //Проверяем, были ли изменения в клиентах

            foreach (Client xmlClient in currentXmlList)
            {
             if(list.Exists(x=>x.ID==xmlClient.ID))
                {
                    Client NewClient = list.Find(x => x.ID == xmlClient.ID);
                    if (NewClient.Internet != null && xmlClient.Internet != null)
                    {
                        if (!NewClient.Internet.Equals(xmlClient.Internet))
                        {
                            
                            XmlClients.Find(x => x.ID == xmlClient.ID).Internet = NewClient.Internet;
                            count++;
                        }
                    }
                    if (NewClient.Internet!=null&& xmlClient.Internet == null)
                    {
                        XmlClients.Find(x => x.ID == xmlClient.ID).Internet = NewClient.Internet;
                    }
                    if (NewClient.Phone != null && xmlClient.Phone != null)
                    {
                        if (!NewClient.Phone.Equals(xmlClient.Phone))
                        {
                            XmlClients.Find(x => x.ID == xmlClient.ID).Phone = NewClient.Phone;
                            count++;
                        }
                    }
                    if (NewClient.Phone != null && xmlClient.Internet == null)
                    {
                        XmlClients.Find(x => x.ID == xmlClient.ID).Phone = NewClient.Phone;
                    }
                    //Проверка на изменения IPTV.
                    //if (NewClient.IPTV != null && xmlClient.IPTV != null)
                    //{
                    //    if (!NewClient.IPTV.Equals(xmlClient.IPTV))
                    //    {
                    //        XmlClients.Find(x => x.ID == xmlClient.ID).IPTV = NewClient.IPTV;
                    //        count++;
                    //    }
                    //}
                    if (NewClient.IPTV != null && xmlClient.IPTV == null)
                    {
                        XmlClients.Find(x => x.ID == xmlClient.ID).IPTV = NewClient.IPTV;
                    }
                    if (!NewClient.Name.Equals(xmlClient.Name))
                    {
                        XmlClients.Find(x => x.ID == xmlClient.ID).Name = NewClient.Name;
                        count++;
                    }
                }

            }

            currentXmlList = null;
            try
            {
                Stream SaveStream = new FileStream(xmlDB, FileMode.Create, FileAccess.Write);
                xmlFormat.Serialize(SaveStream, XmlClients);
                SaveStream.Close();
            }
            catch { MessageBox.Show("Ошибка при обновлении. Обратитесь к разработчику."); }
            MessageBox.Show(String.Format("Обновлено {0} записей", count), "Обновление завершено", new MessageBoxButtons());
            return XmlClients;

        }

        public void SaveDB(List<Client> list)
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Client>));
            Stream fStream = new FileStream(xmlDB, FileMode.Create, FileAccess.Write);
            xmlFormat.Serialize(fStream, list);
            fStream.Close();
        }

        public void LoadDB()
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Client>));
            Stream fStream = new FileStream(xmlDB, FileMode.Open, FileAccess.Read);
            this.ClientList = (List<Client>)xmlFormat.Deserialize(fStream);
        }

        public void FindClient(string str, int count)
        {
            ClientSort = new List<Client>();
            if (count == 2) str = str.ToLower();
            foreach (Client client in ClientList)
            {
                if (client.Internet != null)
                {
                    switch(count)
                    {
                        case 0:
                            string[] result = str.Split('@');
                            int port;
                            int.TryParse(result[0], out port);
                            if(client.Internet.Commutator.Contains(result[1])&&client.Internet.Port == port)
                            {
                                ClientSort.Add(client);
                            }
                            break;
                        case 1:
                            if (client.Internet.Commutator.Contains(str)) ClientSort.Add(client);
                            break;
                        case 2:

                            if (client.Name.ToLower().Contains(str)) ClientSort.Add(client);

                            break;






                    }
                }
            }
        }

    }
}
