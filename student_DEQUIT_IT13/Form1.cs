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

namespace student_DEQUIT_IT13
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }


        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text.Trim();
            string password = textPass.Text.Trim();

            if (username == "" || password == "")
            {
                lblMsg.Text = "Please enter username and password.";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }

            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Users WHERE username=@user AND password=@pass";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@user", username);
                cmd.Parameters.AddWithValue("@pass", password);
                int count = (int)cmd.ExecuteScalar();

                if (count > 0)
                {
                    lblMsg.Text = "Login successful!";
                    lblMsg.ForeColor = System.Drawing.Color.Green;



                    this.Hide();
                    StudentTransaction mainForm = new StudentTransaction();
                    mainForm.ShowDialog();
                    this.Close();
                }
                else
                {
                    lblMsg.Text = "Invalid username or password!";
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
            private void btnLogin_Click(object sender, EventArgs e)
        {
         
        }
   


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {

        }
    }
}
