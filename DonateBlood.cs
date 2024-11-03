using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace BBMS
{
    public partial class DonateBlood : Form
    {
        public DonateBlood()
        {
            InitializeComponent();
            populate();
            BloodStock();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\AHMAD\Documents\BloodBankDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void populate()
        {
            Con.Open();
            string Query = "select * from DonorTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            DonorDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void BloodStock()
        {
            Con.Open();
            string Query = "select * from BloodTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            BloodStockDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void DonorDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DNameTb.Text = DonorDGV.SelectedRows[0].Cells[1].Value.ToString();
            DBGroupTb.Text = DonorDGV.SelectedRows[0].Cells[6].Value.ToString();
            

        }
        int oldstock;
        private void GetStock(string Bgroup)
        {
            Con.Open();
            string query = "select * from BloodTbl where BGroup='" + Bgroup + "'";
            SqlCommand cmd = new SqlCommand(query, Con);
            DataTable dt=new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                oldstock = Convert.ToInt32(dr["Bstock"].ToString());
            }
            Con.Close();
        }


        int key = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            if (DonorDGV.Rows.Count == 0 || DonorDGV.SelectedRows.Count == 0)
            {
                MessageBox.Show("There is no data to edit in the database.");
                return;
            }

            // Proceed if there's data and a row is selected
            if (DonorDGV.SelectedRows[0].Cells[1].Value == null ||
                DonorDGV.SelectedRows[0].Cells[1].Value.ToString() == "")
            {
                MessageBox.Show("There is no data to edit in the database.");
            }
            else
            {
                DNameTb.Text = DonorDGV.SelectedRows[0].Cells[1].Value.ToString();
                
                DBGroupTb.Text =DonorDGV.SelectedRows[0].Cells[6].Value.ToString();
                GetStock(DBGroupTb.Text);


            }

            if (DNameTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(DonorDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }
        private void Reset()
        {
            DNameTb.Text = "";
            DBGroupTb.Text = "";
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (DNameTb.Text == "")
            {
                MessageBox.Show("Select A Donor");
            }
            else
            {
                
                try
                {
                    int stock = oldstock + 1;
                    string query = "update BloodTbl set BStock = " + stock + " where BGroup='" + DBGroupTb.Text + "';";
                    Con.Open();
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Donation Successfull");

                    Con.Close();
                    Reset();
                    BloodStock();
                    

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void DonateBlood_Load(object sender, EventArgs e)
        {

        }
    }
}
