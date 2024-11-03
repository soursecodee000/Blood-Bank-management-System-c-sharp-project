using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BBMS
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            GetData();      
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\AHMAD\Documents\BloodBankDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void GetData()
        {
            Con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("Select Count(*) from DonorTbl",Con);
            DataTable dt= new DataTable();  
            adapter.Fill(dt);
            Donorlbl.Text = dt.Rows[0][0].ToString();


            SqlDataAdapter ada = new SqlDataAdapter("Select Count(*) from TransferTbl", Con);
            DataTable dt1 = new DataTable();
            ada.Fill(dt1);
            Transferlbl.Text = dt1.Rows[0][0].ToString();


            SqlDataAdapter ada1 = new SqlDataAdapter("Select Count(*) from EmployeTbl", Con);
            DataTable dt11 = new DataTable();
            ada1.Fill(dt11);
            userlbl.Text = dt11.Rows[0][0].ToString();


            SqlDataAdapter ada12 = new SqlDataAdapter("Select Count(*) from BloodTbl", Con);
            DataTable dt12 = new DataTable();
            ada12.Fill(dt12);
            int BStock = Convert.ToInt32(dt12.Rows[0][0].ToString());
            Toal.Text = "" + BStock;
            //userlbl.Text = dt11.Rows[0][0].ToString();



            SqlDataAdapter bl = new SqlDataAdapter("Select BStock from BloodTbl where BGroup='"+ "AB+" +"'", Con);
            DataTable dl = new DataTable();
            bl.Fill(dl);
            ABpluslbl.Text = dl.Rows[0][0].ToString();
            double ABplusepercentage=(Convert.ToDouble(dl.Rows[0][0].ToString())/BStock)*100;
            ABplusprogress.Value= Convert.ToInt32(ABplusepercentage);

            SqlDataAdapter bl1 = new SqlDataAdapter("Select BStock from BloodTbl where BGroup='" + "A+" + "'", Con);
            DataTable dl1 = new DataTable();
            bl1.Fill(dl1);
            Aplus.Text = dl1.Rows[0][0].ToString();
            double Aplusepercentage = (Convert.ToDouble(dl1.Rows[0][0].ToString()) / BStock) * 100;
            Aplusprogress.Value = Convert.ToInt32(Aplusepercentage);



            SqlDataAdapter bl2 = new SqlDataAdapter("Select BStock from BloodTbl where BGroup='" + "B+" + "'", Con);
            DataTable dl2 = new DataTable();
            bl2.Fill(dl2);
            Bplus.Text = dl2.Rows[0][0].ToString();
            double Bplusepercentage = (Convert.ToDouble(dl2.Rows[0][0].ToString()) / BStock) * 100;
            Bplusprogress.Value = Convert.ToInt32(Bplusepercentage);


            SqlDataAdapter bl3 = new SqlDataAdapter("Select BStock from BloodTbl where BGroup='" + "AB-" + "'", Con);
            DataTable dl3 = new DataTable();
            bl3.Fill(dl3);
            ABmin.Text = dl3.Rows[0][0].ToString();
            double ABminepercentage = (Convert.ToDouble(dl3.Rows[0][0].ToString()) / BStock) * 100;
            ABminprogress.Value = Convert.ToInt32(ABminepercentage);

            SqlDataAdapter bl4 = new SqlDataAdapter("Select BStock from BloodTbl where BGroup='" + "O+" + "'", Con);
            DataTable dl4 = new DataTable();
            bl4.Fill(dl4);
            Oplus.Text = dl4.Rows[0][0].ToString();
            double Opluspercentage = (Convert.ToDouble(dl4.Rows[0][0].ToString()) / BStock) * 100;
            Oplusprogress.Value = Convert.ToInt32(Opluspercentage);



            SqlDataAdapter bl5 = new SqlDataAdapter("Select BStock from BloodTbl where BGroup='" + "O-" + "'", Con);
            DataTable dl5 = new DataTable();
            bl5.Fill(dl5);
            Omin.Text = dl5.Rows[0][0].ToString();
            double Ominpercentage = (Convert.ToDouble(dl5.Rows[0][0].ToString()) / BStock) * 100;
            Ominprogress.Value = Convert.ToInt32(Ominpercentage);



            Con.Close();
        }
        
        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {
            //BloodStock bd= new BloodStock();
            //bd.Show();
            //this.Hide();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            //Donor donor = new Donor();
            //donor.Show();
            //this.Hide();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            //BloodTransfert bt=new BloodTransfert();
            //bt.Show();
            //this.Hide();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();  
            dashboard.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Donor donor = new Donor();
            donor.Show();   
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            ViewDonor donor = new ViewDonor();
            donor.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Patient patient = new Patient();
            patient.Show(); 
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            ViewPatient patient = new ViewPatient();
            patient.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            BloodStock stock = new BloodStock();    
            stock.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            BloodTransfert bloodTransfert = new BloodTransfert();
            bloodTransfert.Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            login login = new login();
            login.Show();
            this.Hide();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
