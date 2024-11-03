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
    public partial class Employes : Form
    {
        public Employes()
        {
            InitializeComponent();
            populate();
        }

        private void Employes_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Employes emp=new Employes();
            emp.Show();
            this.Hide();

        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\AHMAD\Documents\BloodBankDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void Reset()
        {
            EmpName.Text = "";
            //PatientidCb.SelectedIndex = -1;
            EmpPassword.Text = "";
            key = 0;
        }

        private void populate()
        {
            Con.Open();
            string Query = "select * from EmployeTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            EmpDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (EmpName.Text == "" || EmpPassword.Text == "" )
            {
                MessageBox.Show("Missing Information");

            }
            else
            {
                try
                {
                    string query = "insert into EmployeTbl values('" + EmpName.Text + "','" + EmpPassword.Text + "')";
                    Con.Open();
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee Successfully Saved");

                    Con.Close();
                    Reset();
                    populate(); 
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }
        
        private void EmpDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        int key = 0;
        private void button3_Click(object sender, EventArgs e)
        {
            if (EmpDGV.Rows.Count == 0 || EmpDGV.SelectedRows.Count == 0)
            {
                MessageBox.Show("There is no data to edit in the database.");
                return;
            }

            // Proceed if there's data and a row is selected
            if (EmpDGV.SelectedRows[0].Cells[1].Value == null ||
                EmpDGV.SelectedRows[0].Cells[1].Value.ToString() == "")
            {
                MessageBox.Show("There is no data to edit in the database.");
            }
            else
            {
                EmpName.Text = EmpDGV.SelectedRows[0].Cells[1].Value.ToString();
                EmpPassword.Text = EmpDGV.SelectedRows[0].Cells[2].Value.ToString();
                
            }

            if (EmpName.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(EmpDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select Item to Delete");
            }
            else
            {
                try
                {
                    string query = "Delete from EmployeTbl where EmpNum=" + key + ";";
                    Con.Open();
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee Successfully Deleted");

                    Con.Close();
                    Reset();
                    //Populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (EmpName.Text == "" || EmpPassword.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    string query = "update EmployeTbl set EmName='" + EmpName.Text + "',EmpPass='" + EmpPassword.Text + "' where EmpNum=" + key + ";";
                    Con.Open();
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Emplyee Successfully Updated");

                    Con.Close();
                    Reset();
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {
            login login = new login();
            login.Show();
            this.Hide();

        }
    }
}
