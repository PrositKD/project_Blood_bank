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



namespace This__SUCKS___
{
    public partial class Form1 : Form
    {
        public static string Text1;
        public Form1()
        {
            InitializeComponent();
        }



        
        public static int userId;

        public void FindId()
        {
            

        }




        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                textBox1.Focus();
                errorProvider1.SetError(this.textBox1, "UserName Required");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                textBox2.Focus();
                errorProvider2.SetError(this.textBox1, "Password Required");
            }
            else
            {
                errorProvider2.Clear();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Text1 = textBox1.Text;
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-9HKN9TN\\SQLEXPRESS;Initial Catalog=BloodBank;Integrated Security=True"); 

            String username, user_password;
            username = textBox1.Text;
            user_password = textBox2.Text;


            try
            {
                String querry = "SELECT * FROM SgnUpTab WHERE Name = '" +textBox1.Text + "' AND pass = '"+textBox2.Text+"'";
                SqlDataAdapter sda = new SqlDataAdapter(querry, con);

                DataTable dtable = new DataTable();
                sda.Fill(dtable);

                if(dtable.Rows.Count > 0)
                {
                    username =textBox1.Text;
                    user_password = textBox2.Text;

                    Form14 ng = new Form14();
                    ng.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid UserName or Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox1.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Error");
                

            }

            finally
            {
                con.Close();
            }






            if (string.IsNullOrEmpty(textBox1.Text))
            {
                textBox1.Focus();
                errorProvider1.SetError(this.textBox1, "UserName Required");
            }
            else if (string.IsNullOrEmpty(textBox2.Text))
            {
                textBox2.Focus();
                errorProvider2.SetError(this.textBox2, "Password Required");
            }

            else
            {
                MessageBox.Show("successfully Logged in!!!!");
            }
            
            


        }

        private void button2_Click(object sender, EventArgs e)
        {

            this.Hide();
            Form2 sp = new Form2();
            sp.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            this.Hide();
            Form3 la = new Form3();
            la.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox1.Focus();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult res;
            res = MessageBox.Show("Do you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                this.Show();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

       
    }
}