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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start(); 
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
        int startPos=0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            startPos += 1;
            Splachtimer.Value= startPos;
            if (Splachtimer.Value == 100)
            {
                Splachtimer.Value = 0;
                timer1.Stop();
                login login = new login();
                login.Show();
                this.Hide();
            }
        }
    }
}
