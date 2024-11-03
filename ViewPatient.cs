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
namespace BBMS
{
    public partial class ViewPatient : Form
    {
        public ViewPatient()
        {
            InitializeComponent();
            Populate();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\AHMAD\Documents\BloodBankDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void Populate()
        {
            Con.Open();
            string Query = "select * from PatientTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            PatientDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void ViewPatient_Load(object sender, EventArgs e)
        {

        }
        
        int key = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            if (PatientDGV.Rows.Count == 0 || PatientDGV.SelectedRows.Count == 0)
            {
                MessageBox.Show("There is no data to edit in the database.");
                return;
            }

            // Proceed if there's data and a row is selected
            if (PatientDGV.SelectedRows[0].Cells[1].Value == null ||
                PatientDGV.SelectedRows[0].Cells[1].Value.ToString() == "")
            {
                MessageBox.Show("There is no data to edit in the database.");
            }
            else
            {
                PNameTb.Text = PatientDGV.SelectedRows[0].Cells[1].Value.ToString();
                PAgeTb.Text = PatientDGV.SelectedRows[0].Cells[2].Value.ToString();
                PPhoneTb.Text = PatientDGV.SelectedRows[0].Cells[3].Value.ToString();
                PGenCb.SelectedItem = PatientDGV.SelectedRows[0].Cells[4].Value.ToString();
                PBGroupCb.SelectedItem = PatientDGV.SelectedRows[0].Cells[5].Value.ToString();
                PAddressTb.Text = PatientDGV.SelectedRows[0].Cells[6].Value.ToString();

            }
            
            if (PNameTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(PatientDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }
        private void Reset()
        {
            PNameTb.Text = "";
            PAgeTb.Text = "";
            PPhoneTb.Text = "";
            PGenCb.SelectedIndex = -1;
            PBGroupCb.SelectedIndex = -1;
            PAddressTb.Text = "";
            key = 0;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select Item to Delete");
            }
            else
            {
                try
                {
                    string query = "Delete from PatientTbl where PNum="+key+";";
                    Con.Open();
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Patient Successfully Deleted");

                    Con.Close();
                    Reset();
                    Populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }

        }

        private void label5_Click(object sender, EventArgs e)
        {
            ViewPatient vp = new ViewPatient();
            vp.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Patient pat = new Patient();
            pat.Show();
            this.Hide();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (PNameTb.Text == "" || PAgeTb.Text == "" || PPhoneTb.Text == "" || PGenCb.SelectedIndex == -1 || PBGroupCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    string query = "update PatientTbl set Pname='"+PNameTb.Text+"',Page='"+PAgeTb.Text+"',Pphone='"+PPhoneTb.Text+"',PGender='"+PGenCb.SelectedItem.ToString()+"',PBGroup='"+PBGroupCb.SelectedItem.ToString()+"',PAddress='"+PAddressTb.Text+"' where PNum="+key+";";
                    Con.Open();
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Patient Successfully Updated");

                    Con.Close();
                    Reset();
                    Populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void PatientDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
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

        private void label6_Click(object sender, EventArgs e)
        {
            BloodStock bloodStock = new BloodStock();
            bloodStock.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            BloodTransfert bloodTransfert = new BloodTransfert();
            bloodTransfert.Show();
            this.Hide();
        }
    }
}
