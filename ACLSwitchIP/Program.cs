using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ACLSwitchIP
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            Application.Run(new BaseMenu());




            //foreach (Client client in GetDB().ClientList)
            //{
            //    //if (client.SwitchName == "br13-des2.vs.bcitelecom.ru") Console.WriteLine(ActionACL.addACL(client));
            //    Console.WriteLine(client.Ip);
            //}
            //Console.ReadLine();


        }

    }
}
