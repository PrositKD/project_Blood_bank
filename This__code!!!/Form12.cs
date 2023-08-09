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

namespace This__SUCKS___
{
    public partial class Form12 : Form
    {
        public Form12()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 khg = new Form4();
            khg.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-9HKN9TN\\SQLEXPRESS;Initial Catalog=BloodBank;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from SgnUpTab where Id=@Id", con);
            cmd.Parameters.AddWithValue("Id", int.Parse(textBox1.Text));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult res;
            res = MessageBox.Show("Are you sure you want to DELETE?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-9HKN9TN\\SQLEXPRESS;Initial Catalog=BloodBank;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("Delete SgnUpTab where ID=@ID", con);
                cmd.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Successfully Deleted");

                textBox1.Clear();
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
            }
            else
            {
                this.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
        }
    }
}
