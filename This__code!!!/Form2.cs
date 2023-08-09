using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Data;
using System.IO;


namespace This__SUCKS___
{
    public partial class Form2 : Form
    {
        int count = 120;
        public Form2()
        {
            InitializeComponent();
        }
        string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";

        public object NumericUpDown1 { get; private set; }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                textBox1.Focus();
                errorProvider1.SetError(this.textBox1, "name Required");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                textBox2.Focus();
                errorProvider2.SetError(this.textBox2, "F name Required");
            }
            else
            {
                errorProvider2.Clear();
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox3.Text))
            {
                textBox3.Focus();
                errorProvider3.SetError(this.textBox1, "M name Required");
            }
            else
            {
                errorProvider3.Clear();
            }
        }

        private void comboBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox1.Text))
            {
                comboBox1.Focus();
                errorProvider5.SetError(this.comboBox1, "Required");
            }
            else
            {
                errorProvider5.Clear();
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox4.Text))
            {
                textBox4.Focus();
                errorProvider4.SetError(this.textBox4, "Required");
            }
            else
            {
                errorProvider4.Clear();
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox5.Text))
            {
            textBox5.Focus();
                errorProvider6.SetError(this.textBox5, "Required");
            }
            else 
            {
                errorProvider6.Clear();
            }

             if(Regex.IsMatch(textBox5.Text,pattern)==false)
            {
                textBox5.Focus();
                errorProvider10.SetError(this.textBox5,"Invalid Email");
            }
            else
            {
                errorProvider10.Clear();
            }
        }

        private void comboBox2_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox2.Text))
            {
                comboBox2.Focus();
                errorProvider7.SetError(this.comboBox2, "Required");
            }
            else
            {
                errorProvider7.Clear();
            }
        }

        private void comboBox3_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox3.Text))
            {
                comboBox3.Focus();
                errorProvider8.SetError(this.comboBox3, "Required");
            }
            else
            {
                errorProvider8.Clear();
            }
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(textBox6.Text))
            {
                textBox6.Focus();
                errorProvider9.SetError(this.textBox6, "Required");
            }
            else
            {
                errorProvider9.Clear();
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox7.Text))
            {
                textBox7.Focus();
                errorProvider11.SetError(this.textBox7, "Generate Id");
            }
            else
            {
                errorProvider11.Clear();
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(textBox8.Text))
            {
                textBox8.Focus();
                errorProvider12.SetError(this.textBox8, "Required");
            }
            else
            {
                errorProvider12.Clear();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title  = "Select Image";
            ofd.Filter = "All Image File(*.*)|*.*";

            if(ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(ofd.FileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {



                SqlConnection con = new SqlConnection("Data Source=DESKTOP-9HKN9TN\\SQLEXPRESS;Initial Catalog=BloodBank;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into SgnUpTab values(@Id,@Name,@Fname,@Mname,@Dob,@Img,@Gender,@Age,@MblNo,@Email,@BG,@CrntCity,@Permntadrs,@pass)", con);
                cmd.Parameters.AddWithValue("@Id", int.Parse(textBox7.Text));
                cmd.Parameters.AddWithValue("@Name", textBox1.Text);
                cmd.Parameters.AddWithValue("@Fname", textBox2.Text);
                cmd.Parameters.AddWithValue("@Mname", textBox3.Text);
                //cmd.Parameters.AddWithValue("@Dob",    textBox9.Text);
                cmd.Parameters.AddWithValue("@Dob", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@Img", SavePhoto());
                cmd.Parameters.AddWithValue("@Gender", comboBox1.SelectedItem);
                cmd.Parameters.AddWithValue("@Age", numericUpDown1.Value);
                cmd.Parameters.AddWithValue("@MblNo", textBox4.Text);
                cmd.Parameters.AddWithValue("@Email", textBox5.Text);
                cmd.Parameters.AddWithValue("@BG", comboBox2.SelectedItem);
                cmd.Parameters.AddWithValue("@CrntCity", comboBox3.SelectedItem);
                cmd.Parameters.AddWithValue("@Permntadrs", textBox6.Text);
                cmd.Parameters.AddWithValue("@pass", textBox8.Text);

                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Account Created Succesfully!!");

                ResetControl();
            }
            catch (Exception)
            {

                if (string.IsNullOrEmpty(textBox1.Text))
                {
                    textBox1.Focus();
                    errorProvider1.SetError(this.textBox1, "name Required");
                }
                else if (string.IsNullOrEmpty(textBox2.Text))
                {
                    textBox2.Focus();
                    errorProvider2.SetError(this.textBox2, "F name Required");
                }
                else if (string.IsNullOrEmpty(textBox3.Text))
                {
                    textBox3.Focus();
                    errorProvider3.SetError(this.textBox1, "M name Required");
                }
                else if (string.IsNullOrEmpty(comboBox1.Text))
                {
                    comboBox1.Focus();
                    errorProvider5.SetError(this.comboBox1, "Required");
                }
                else if (string.IsNullOrEmpty(textBox4.Text))
                {
                    textBox4.Focus();
                    errorProvider4.SetError(this.textBox4, "Required");
                }
                else if (string.IsNullOrEmpty(textBox5.Text))
                {
                    textBox5.Focus();
                    errorProvider6.SetError(this.textBox5, "Required");
                }
                else if (Regex.IsMatch(textBox5.Text, pattern) == false)
                {
                    textBox5.Focus();
                    errorProvider10.SetError(this.textBox5, "Invalid Email");
                }
                //  else if (Regex.IsMatch(textBox5.Text, pattern) == true)
                //{
                // errorProvider10.Clear();
                // }
                else if (string.IsNullOrEmpty(comboBox2.Text))
                {
                    comboBox2.Focus();
                    errorProvider7.SetError(this.comboBox2, "Required");
                }
                else if (string.IsNullOrEmpty(comboBox3.Text))
                {
                    comboBox3.Focus();
                    errorProvider8.SetError(this.comboBox3, "Required");
                }
                else if (string.IsNullOrEmpty(textBox6.Text))
                {
                    textBox6.Focus();
                    errorProvider9.SetError(this.textBox6, "Required");
                }
                else if (string.IsNullOrEmpty(textBox7.Text))
                {
                    textBox7.Focus();
                    errorProvider11.SetError(this.textBox7, "Generate Id");
                }
                else if (string.IsNullOrEmpty(textBox8.Text))
                {
                    textBox8.Focus();
                    errorProvider12.SetError(this.textBox8, "Required");
                }

                else
                {
                    MessageBox.Show("Success!!!");
                    ResetControl();
                }

            }
        


        }

        private byte[] SavePhoto()
        {
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            return ms.GetBuffer();
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
            textBox8.Clear();
            pictureBox1.Image = Properties.Resources.Interface_Image;
            comboBox1.Text = String.Empty;
            comboBox2.Text = String.Empty;
            comboBox3.Text = String.Empty;
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        public void autogen()
        {
          
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            
            count++;
            textBox7.Text = count.ToString();
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 ndt = new Form1();
            ndt.Show();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
