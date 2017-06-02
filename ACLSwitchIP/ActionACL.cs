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
        static string[] commands = new string[3];

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

            catch {  }
            sw.Write(str);
            return false;
            
            
        }


        public static string addACL(List<Client> clients)
        {
            
            DateTime time = DateTime.Now;
            String FileName = "LogACL" + time.ToShortDateString() + ".";
            sw = new StreamWriter(FileName, true, Encoding.GetEncoding(1251));
            

            if (clients.Count > 0)
            {
                try
                {
                    foreach (Client client in clients)
                    {

                        try
                        {
                            commands[0] = string.Format("create access_profile profile_id 4 profile_name allow_ip ip source_ip_mask 255.255.255.255");
                            commands[1] = string.Format("config access_profile profile_id 4 add access_id {0} ip source_ip {1} port {2} permit", client.Port, client.Ip, client.Port);
                            commands[2] = string.Format("config access_profile profile_id 4 add access_id {0} ip source_ip {1} mask {2} port {3} deny", client.Port + 100, "0.0.0.0", "0.0.0.0", client.Port);

                            tc = new TelnetConnection(client.SwitchName, 23);
                            string s = tc.Login("roman", "hme55cumo", 600);
                            //sw.Write(s);
                            string prompt = s.TrimEnd();
                            prompt = s.Substring(prompt.Length - 1, 1);
                            if (prompt != "#" && prompt != ">")
                                throw new Exception("Connection failed");

                            prompt = "";

                            for (int i = 0; i < commands.Length; i++)
                            {
                                if (CommandUse(commands[i]))
                                {
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

                            sw.Close();
                            //StreamReader sr = new StreamReader(FileName);

                            //while (!sr.EndOfStream)
                            //{
                            //    try
                            //    {
                            //        if (sr.ReadLine().Contains("Fail"))
                            //        {
                            //            return string.Format("Возникла проблема, при добавлении ACL для клиента : {0}", client.ID);
                            //            throw new Exception("Read log file");
                            //        }
                            //    }

                            //    catch ( Exception e)
                            //    {
                            //        break;
                            //    }

                            //}
                            //sr.Close();

                            client.aclIP = true;
                        }
                        catch (Exception e)
                        {
                            throw e;
                        }
                    }
                }
                catch (Exception e)
                {
                    return e.Message;
                }
            }
            return "Complite";

        }

        
    }
}
