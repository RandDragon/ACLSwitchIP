using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Resources;

namespace ACLSwitchIP
{
    public partial class BaseMenu : Form
    {
        WorkDataBase useDB;
        BindingSource bindingS;
        
        
        

        public BaseMenu()
        {
            InitializeComponent();
            
            useDB = new WorkDataBase();
            //useDB.LoadDB();
            bindingS = new BindingSource();

            
            
      
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if(tboxPortSwitch.Text!="" || tboxSwitch.Text!="" || tboxName.Text!="")
            {
                if(tboxPortSwitch.Text!="")
                {
                    useDB.FindClient(tboxPortSwitch.Text, 0);
                }
                if(tboxSwitch.Text!="")
                {
                    useDB.FindClient(tboxSwitch.Text, 1);
                }
                if(tboxName.Text!="")
                {
                    useDB.FindClient(tboxName.Text, 2);
                }
            }


            bindingS.DataSource = useDB.ClientSort;
            grid.DataSource = useDB.ClientSort;
            //grid.DataMember = "ClientSort";

            grid.AutoSizeRowsMode =
               DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
        }

        private void saveAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            useDB.SaveDB(useDB.ClientList);
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            useDB.Update(useDB.ClientList);
        }




        private void btnACL_Click(object sender, EventArgs e)
        {
            
            MessageBox.Show(ActionACL.aclAddPort(useDB.ClientSort));

        }

        public  static void CreateMess(string str)
        {
            MessageBox.Show(str);
        }

        
    }
}
