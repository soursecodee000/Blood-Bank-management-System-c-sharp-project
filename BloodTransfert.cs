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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace BBMS
{
    public partial class BloodTransfert : Form
    {
        public BloodTransfert()
        {
            InitializeComponent();
            fillPatientCb();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\AHMAD\Documents\BloodBankDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void fillPatientCb()
        {
            Con.Open();
            SqlCommand cmd= new SqlCommand("SELECT PNum from PatientTbl", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable(); 
            dt.Columns.Add("PNum",typeof(string)); 
            dt.Load(rdr);
            PatientidCb.ValueMember = "PNum";
            PatientidCb.DataSource = dt;
            Con.Close();
        }
        private void GetData()
        {
            Con.Open();
            string query = "select * from PatientTbl where PNum='" + PatientidCb.SelectedValue.ToString() + "'";
            SqlCommand cmd = new SqlCommand(query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                PNameTb.Text = (dr["PName"].ToString());
                PGenCb.Text = (dr["PBGroup"].ToString());
            }
            Con.Close();
        }
        int stock=0;
        private void GetStock(string Bgroup)
        {
            Con.Open();
            string query = "select * from BloodTbl where BGroup='" + Bgroup + "'";
            SqlCommand cmd = new SqlCommand(query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                stock = Convert.ToInt32(dr["Bstock"].ToString());
            }
            Con.Close();
        }
        private void BloodTransfert_Load(object sender, EventArgs e)
        {

        }

        private void PatientidCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetData();
            GetStock(PGenCb.Text);
            if (stock > 0)
            {
                Transfer.Visible = true;
                Availablelbl.Text = "Available Stock";
                Availablelbl.Visible = true;
            }
            else 
            {
                Availablelbl.Text = "Stock not Available";
                Availablelbl.Visible = false;
            }
        }
        private void Reset()
        {
            PNameTb.Text = "";
            //PatientidCb.SelectedIndex = -1;
            PGenCb.Text = "";
            Availablelbl.Visible = false;
            Transfer.Visible= false;    
        }
        private void label4_Click(object sender, EventArgs e)
        {
            Patient pat = new Patient();
            pat.Show();
            this.Hide();

        }
        //int oldstock;
        //private void GetStock(string Bgroup)
        //{
        //    Con.Open();
        //    string query = "select * from BloodTbl where BGroup='" + Bgroup + "'";
        //    SqlCommand cmd = new SqlCommand(query, Con);
        //    DataTable dt = new DataTable();
        //    SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //    sda.Fill(dt);
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        oldstock = Convert.ToInt32(dr["Bstock"].ToString());
        //    }
        //    Con.Close();
        //}

        private void updateStock()
        {
            int newstock =stock -1;
            try
            {
                string query = "update BloodTbl set BStock=" + newstock + " where BGroup='" + PGenCb.Text + "';";
                Con.Open();
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                //MessageBox.Show("Patient Successfully Updated");

                Con.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        private void Transfer_Click(object sender, EventArgs e)
        {
            if (PNameTb.Text == "" )
            {
                MessageBox.Show("Missing Information");

            }
            else
            {
                try
                {
                    string query = "insert into TransferTbl values('" + PNameTb.Text + "','" + PGenCb.Text + "')";
                    Con.Open();
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Successfully Transfer");

                    Con.Close();
                    GetStock(PGenCb.Text);
                    updateStock();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            BloodStock Bstock = new BloodStock();
            Bstock.Show();
            this.Hide();
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

        private void label5_Click(object sender, EventArgs e)
        {
            ViewPatient donor = new ViewPatient();
            donor.Show();
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
    }
}
