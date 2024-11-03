using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BBMS
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            login log=new login();  
            log.Show(); 
            log.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (AdminPassTb.Text == "")
            {
                MessageBox.Show("Please enter the Password");

            }
            else if (AdminPassTb.Text =="123")
            {
                Employes Emp=new Employes();    
                Emp.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong Password.Contact the System Admin");
                AdminPassTb.Text = "";
            }
        }
    }
}
