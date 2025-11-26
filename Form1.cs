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

namespace StudentSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            try
            {
                SqlConnection conn = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename =C:\\Users\\STI\\source\\repos\\StudentSystem\\StudentSystem\\studentInfo.mdf; Integrated Security = True");
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO [Table] (StudentID, FirstName, LastName, Program, Age) VALUES (@StudentID, @FirstName, @LastName, @Program, @Age)", conn);
                cmd.Parameters.AddWithValue("@StudentID", int.Parse(tb_id.Text));
                cmd.Parameters.AddWithValue("@FirstName", tb_fn.Text);
                cmd.Parameters.AddWithValue("@LastName", tb_ln.Text);
                cmd.Parameters.AddWithValue("@Program", cb_program.Text);
                cmd.Parameters.AddWithValue("@Age", int.Parse(tb_age.Text));
                cmd.ExecuteNonQuery();

                
                conn.Close();
                MessageBox.Show("Data Inserted");
                load();
            } catch (Exception ex )
            {
                MessageBox.Show(ex.Message);
            }

        }
        public void load()
        {
            SqlConnection conn = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename =C:\\Users\\STI\\source\\repos\\StudentSystem\\StudentSystem\\studentInfo.mdf; Integrated Security = True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM [Table]", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            dataGridView1.DataSource = dt;


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            load();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try {
                SqlConnection conn = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename =C:\\Users\\STI\\source\\repos\\StudentSystem\\StudentSystem\\studentInfo.mdf; Integrated Security = True");
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE [Table] SET  StudentID = @StudentID, FirstName = @FirstName, LastName = @LastName, Program = @Program, Age = @Age WHERE StudentID = @StudentID", conn);
                cmd.Parameters.AddWithValue("@StudentID", int.Parse(tb_id.Text));
                cmd.Parameters.AddWithValue("@FirstName", tb_fn.Text);
                cmd.Parameters.AddWithValue("@LastName", tb_ln.Text);
                cmd.Parameters.AddWithValue("@Program", cb_program.Text);
                cmd.Parameters.AddWithValue("@Age", int.Parse(tb_age.Text));
                cmd.ExecuteNonQuery();

                conn.Close();
                load();
                MessageBox.Show("Updated Succesfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
    
}
