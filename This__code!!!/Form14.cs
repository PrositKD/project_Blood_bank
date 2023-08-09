using Microsoft.VisualBasic.Logging;
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
    public partial class Form14 : Form
    { public static string email;
        public Form14()
        {
            InitializeComponent();
             BindData();
        }
        public int uId = Form1.userId;
        void BindData()
        {
           


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 ler = new Form1();
            ler.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            email = textBox14.Text;
            this.Hide();
            Form15 mrfk = new Form15();
            mrfk.Show();
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form14_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-9HKN9TN\\SQLEXPRESS;Initial Catalog=BloodBank;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM SgnUpTab WHERE Name = '" + Form1.Text1 + "'", con);
            SqlDataReader reader = cmd.ExecuteReader();
           
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    String Name = Convert.ToString(reader["Name"]);
                    String Id = Convert.ToString(reader["Id"]);
                    String Fname = Convert.ToString(reader["Fname"]);
                    String Mname = Convert.ToString(reader["Mname"]);
                    String Dob   = Convert.ToString(reader["Dob"]);
                    String Gender = Convert.ToString(reader["Gender"]);
                    String Age = Convert.ToString(reader["Age"]);
                    String MblNo = Convert.ToString(reader["MblNo"]);
                    String Email = Convert.ToString(reader["Email"]);
                    String BG = Convert.ToString(reader["BG"]);
                    String CrntCity = Convert.ToString(reader["CrntCity"]);
                    String Permntadrs = Convert.ToString(reader["Permntadrs"]);
                    //String Img = Convert.ToString(reader["Img"]);

                    textBox1.Text = Name;
                    textBox13.Text = Id;
                    textBox2.Text = Fname;
                    textBox3.Text = Mname;
                    textBox4.Text = Dob;
                    //pictureBox1.Image = Img;
                    textBox5.Text = Gender;
                    textBox6.Text = Age;
                    textBox7.Text = MblNo;
                    textBox8.Text = Email;
                    textBox9.Text = BG;
                    textBox10.Text = CrntCity;
                    textBox11.Text = Permntadrs;
                    //pictureBox1.Image = new Bitmap(Img);

                   

                   
                }
            }
            con.Close();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            da.Fill(table);
            da = new SqlDataAdapter(cmd);

            byte[] img = (byte[])table.Rows[0][5];
            MemoryStream ms = new MemoryStream(img);
            pictureBox1.Image = Image.FromStream(ms);
            
            
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            da.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == "Blood Group")
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-9HKN9TN\\SQLEXPRESS;Initial Catalog=BloodBank;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("Select Id,Name,Gender,BG,MblNo,Email,CrntCity,Img from SgnUpTab where BG=@BG", con);
                cmd.Parameters.AddWithValue("BG", (textBox12.Text));
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                
            }
        else
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-9HKN9TN\\SQLEXPRESS;Initial Catalog=BloodBank;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("Select Id,Name,Gender,BG,MblNo,Email,CrntCity,Img from SgnUpTab where CrntCity=@CrntCity", con);
                cmd.Parameters.AddWithValue("CrntCity", (textBox12.Text));
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;

            }
            textBox12.Clear();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
           

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {

            textBox14.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form16 form16 = new Form16();
            form16.Show();
        }
    }
}
