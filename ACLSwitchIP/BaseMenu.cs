using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ACLSwitchIP
{
    public partial class BaseMenu : Form
    {
        WorkDataBase useDB;
       
        
        
        

        public BaseMenu()
        {
            InitializeComponent();
            useDB = new WorkDataBase();
            
            
            
      
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            useDB.resultFind(tboxSwitch.Text);
            grid.DataSource = null;
            grid.DataSource = useDB.ClientSort;
            
        }

        private void saveAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            useDB.SaveDB(useDB.ClientList);
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            useDB.Update(useDB.ClientList);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(ActionACL.addACL(useDB.ClientSort));
            
        }

       
    }
}
