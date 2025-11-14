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
using System.Xml.Linq;

namespace student_DEQUIT_IT13
{
    public partial class StudentTransaction : Form
    {
        public StudentTransaction()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void TextSearch_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT student_id, full_name, course, year_level FROM Students", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvStudents.DataSource = dt;


            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO Students (full_name, course, year_level) VALUES (@name, @course, @year)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", TextName.Text);
                cmd.Parameters.AddWithValue("@course", CourseText.Text);
                cmd.Parameters.AddWithValue("@year", textyearlvl.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Student added successfully!");
                btnLoad_Click(sender, e); 
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (dgvStudents.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvStudents.SelectedRows[0].Cells[0].Value);


                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = "UPDATE Students SET full_name=@name, course=@course, year_level=@year WHERE student_id=@id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@name", TextName.Text);
                    cmd.Parameters.AddWithValue("@course", CourseText.Text);
                    cmd.Parameters.AddWithValue("@year", textyearlvl.Text);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Student updated successfully!");
                    btnLoad_Click(sender, e);
                }
            }
            else
            {
                MessageBox.Show("Please select a row to update.");
            }
        }



        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dgvStudents.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvStudents.SelectedRows[0].Cells[0].Value);

                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = "DELETE FROM Students WHERE student_id=@id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Student deleted successfully!");
                    btnLoad_Click(sender, e);

                }
            }
            else
            {
                MessageBox.Show("Please select a row to delete.");
            }
        }

        private void textyearlvl_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextName_TextChanged(object sender, EventArgs e)
        {

        }

        private void CourseText_TextChanged(object sender, EventArgs e)
        {

        }

        private void StudentTransaction_Load(object sender, EventArgs e)
        {
            this.studentsTableAdapter1.Fill(this.studentDBDataSet1.Students);
            this.studentsTableAdapter.Fill(this.studentDBDataSet.Students);

        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM Students WHERE full_name LIKE @search OR course LIKE @search OR year_level LIKE @search";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@search", "%" + SearchText.Text + "%");

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvStudents.DataSource = dt;
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox)
                {
                    ((TextBox)ctrl).Clear();
                }
                else if (ctrl is ComboBox)
                {
                    ((ComboBox)ctrl).SelectedIndex = -1;
                }
                else if (ctrl is DateTimePicker)
                {
                    ((DateTimePicker)ctrl).Value = DateTime.Now;
                }
            }
        }


        private void SearchText_TextChanged(object sender, EventArgs e)
        {

        }


        private void dgvStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvStudents.Rows[e.RowIndex];
                TextName.Text = row.Cells[1].Value.ToString();
                CourseText.Text = row.Cells[2].Value.ToString();
                textyearlvl.Text = row.Cells[3].Value.ToString();
            }
        }

        private void dgvStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void labelYearlvl_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
