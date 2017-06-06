using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinimalisticTelnet;
using System.Threading;
using System.IO;

namespace ACLSwitchIP
{
    class ActionACL
    {
        static private StreamWriter sw;
        static private TelnetConnection tc;


        private static bool CommandUse(string command)
        {
            tc.WriteLine(command);
            string str = tc.Read();
            try
            {
                if (str.Contains("Fail"))
                {
                    sw.Write(str);
                    return true;
                }

            }

            catch { }
            sw.Write(str);
            return false;
        }


        public static string aclAddPort(List<Client> clients)
        {

            DateTime time = DateTime.Now;
            String FileName = "LogACL" + time.ToShortDateString() + ".";
            try
            {
                sw = new StreamWriter(FileName, true, Encoding.GetEncoding(1251));
            }
            catch { throw new Exception("Проблема доступа к лог-файлу"); }

            if (clients.Count > 0)
            {
                try
                {
                    foreach (Client client in clients)
                    {
                        
                        if (client.Internet!=null && client.Phone == null && client.IPTV == null)
                        {
                            try
                            {
                                string[] commandsInt = CreateCommandInternet(client);
                                
                                sw.WriteLine(LogClientData(client));

                                tc = new TelnetConnection(client.Internet.Commutator, 23);
                                string s = tc.Login("roman", "hme55cumo", 600);
                                //sw.Write(s);
                                string prompt = s.TrimEnd();
                                prompt = s.Substring(prompt.Length - 1, 1);
                                if (prompt != "#" && prompt != ">")
                                    throw new Exception("Connection failed");

                                prompt = "";

                                for (int i = 0; i < commandsInt.Length; i++)
                                {
                                    if (i != 1)
                                    {
                                        if (CommandUse(commandsInt[i]))
                                        {
                                            if (i == 5) Thread.CurrentThread.Join(1000);
                                            try
                                            {
                                                sw.Close();
                                            }
                                            catch { }
                                            finally
                                            {
                                                throw new Exception(string.Format("Возникла проблема, при добавлении ACL для клиента : {0}", client.ID));
                                            }
                                        }
                                    }
                                    else
                                    {
                                        tc.WriteLine(commandsInt[1]);
                                        string str = tc.Read();
                                        str = null;
                                    }

                                }

                                sw.Close();


                                client.ACL = true;
                            }
                            catch (Exception e)
                            {
                                throw e;
                            }
                        }
                        else BaseMenu.CreateMess("Приложение работает лишь для клиентов ТОЛЬКО с услугой Интернет");
                    }
                }
                catch (Exception e)
                {
                    return e.Message;
                }
            }
            return "Complite";

        }

        private static string LogClientData(Client client)
        {
            return String.Format("Создание ACL для клиента {0}. Коммутатор - {1}. Порт {2}", client.Name, client.Internet.Commutator, client.Internet.Port);
        }

        private static string[] CreateCommandInternet(Client client)
        {
            string[] command = new string[6];
            command[0] = "config filter extensive_netbios 1-28 state disable";
            command[1] = string.Format("create access_profile profile_id 4 profile_name allow_ip ip source_ip_mask 255.255.255.255");
            command[2] = string.Format("config access_profile profile_id 4 add access_id {0} ip source_ip {1} port {2} permit", client.Internet.Port, client.Internet.Ip, client.Internet.Port);
            command[3] = string.Format("config access_profile profile_id 4 add access_id {0} ip source_ip {1} mask {2} port {3} deny", client.Internet.Port + 200, "0.0.0.0", "0.0.0.0", client.Internet.Port);
            command[4] = "save all";
            command[5] = "exit";
            return command;
        }

        //private static string[] CreateCommandPhone(Client client)
        //{
        //    string[] command = new string[4];
        //    if (client.Internet == null)
        //    {
        //        command[0] = "config filter extensive_netbios 1-28 state disable";
        //        command[1] = string.Format("create access_profile profile_id 4 profile_name allow_ip ip source_ip_mask 255.255.255.255");
        //    }
        //}

        //private static string[] CreateCommandIPTV(Client client)
        //{

        //}

        private static void StartUseCommand(string[] commands)
        {
            for (int i = 0; i < commands.Length; i++)
            {
                if (i != 1)
                {
                    if (CommandUse(commands[i]))
                    {
                        try
                        {
                            sw.Close();
                        }
                        catch { throw new Exception(string.Format("Возникла проблема, при добавлении ACL для клиента")); }
                    }
                }
                else
                {
                    tc.WriteLine(commands[1]);
                    Thread.CurrentThread.Join(30);
                    string str = tc.Read();
                    str = null;
                }

            }
            
        }
    }
}
