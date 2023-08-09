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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Image";
            ofd.Filter = "All Image File(*.*)|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(ofd.FileName);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ResetControl();
        }
        void ResetControl()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            pictureBox1.Image = Properties.Resources.Interface_Image;
            comboBox1.Text = String.Empty;
            comboBox2.Text = String.Empty;
            comboBox3.Text = String.Empty;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 sn = new Form4();
            sn.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-9HKN9TN\\SQLEXPRESS;Initial Catalog=BloodBank;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM SgnUpTab WHERE Id = '" + textBox1.Text + "'", con);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    String Name = Convert.ToString(reader["Name"]);
                    String Id = Convert.ToString(reader["Id"]);
                    String Fname = Convert.ToString(reader["Fname"]);
                    String Mname = Convert.ToString(reader["Mname"]);
                    String Dob = Convert.ToString(reader["Dob"]);
                    String Gender = Convert.ToString(reader["Gender"]);
                    String Age = Convert.ToString(reader["Age"]);
                    String MblNo = Convert.ToString(reader["MblNo"]);
                    String Email = Convert.ToString(reader["Email"]);
                    String BG = Convert.ToString(reader["BG"]);
                    String CrntCity = Convert.ToString(reader["CrntCity"]);
                    String Permntadrs = Convert.ToString(reader["Permntadrs"]);

                    textBox2.Text = Name;
                    
                    textBox3.Text = Fname;
                    textBox4.Text = Mname;
                    dateTimePicker1.Text = Dob;
                    //pictureBox1.Image = Img;
                    comboBox1.Text = Gender;
                    numericUpDown1.Text = Age;
                    textBox5.Text = MblNo;
                    textBox6.Text = Email;
                    comboBox2.Text = BG;
                    comboBox3.Text = CrntCity;
                    textBox7.Text = Permntadrs;




                    
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
        private byte[] SavePhoto()
        {
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            return ms.GetBuffer();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {


             
               
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-9HKN9TN\\SQLEXPRESS;Initial Catalog=BloodBank;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE SgnUpTab set Name=@Name,Fname=@Fname,Mname=@Mname,Dob=@Dob,Img=@Img,Gender=@Gender,Age=@Age,MblNo=@MblNo,Email=@Email,BG=@BG,CrntCity=@CrntCity,Permntadrs=@Permntadrs WHERE Id='" + textBox1.Text + "'", con);
               
                cmd.Parameters.AddWithValue("@Name", textBox2.Text);
                cmd.Parameters.AddWithValue("@Fname", textBox3.Text);
                cmd.Parameters.AddWithValue("@Mname", textBox4.Text);
                //cmd.Parameters.AddWithValue("@Dob",    textBox9.Text);
                cmd.Parameters.AddWithValue("@Dob", dateTimePicker1.Value);
               // cmd.Parameters.AddWithValue("@Img", SavePhoto());
                cmd.Parameters.AddWithValue("@Gender", comboBox1.SelectedItem);
                cmd.Parameters.AddWithValue("@Age", numericUpDown1.Value);
                cmd.Parameters.AddWithValue("@MblNo", textBox5.Text);
                cmd.Parameters.AddWithValue("@Email", textBox6.Text);
                cmd.Parameters.AddWithValue("@BG", comboBox2.SelectedItem);
                cmd.Parameters.AddWithValue("@CrntCity", comboBox3.SelectedItem);
                cmd.Parameters.AddWithValue("@Permntadrs", textBox7.Text);
                cmd.Parameters.AddWithValue("@Img", SavePhoto());

                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Account Updated Succesfully Done by Admin!!");

            }
            catch (Exception)
            {
                MessageBox.Show("Exception found! Please Enter valid data!");
            }
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }
    }
}
