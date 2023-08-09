using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace This__SUCKS___
{
    public partial class Form17 : Form
    {
        public Form17()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                MailMessage mail = new MailMessage("prosit.kd@gmail.com",textBox1.Text,textBox2.Text,textBox3.Text);
                mail.Attachments.Add(new Attachment(textBox4.Text.ToString()));

                SmtpClient client = new SmtpClient("smtp.gmail.com");
                client.Port = 587;
                client.Credentials = new NetworkCredential("prosit.kd@gmail.com", "zwwfhpyecehlrlsa");
                client.EnableSsl = true;
                client.Send(mail);
                MessageBox.Show("Email Sent Successfully!!!", "Success", MessageBoxButtons.OK);
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Faild" + ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
        
                ResetControl();
            }
        void ResetControl()
            {

                textBox1.Clear();
                textBox2.Clear();


                textBox3.Clear();
                textBox4.Clear();



            }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select File";
            ofd.Filter = "Image File(*.png;*.jpg;*.bmp;*.gif)|*.png;*.jpg;*.bmp;*.gif|All files(*.*)|*.*";
            ofd.ShowDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string path = ofd.FileName.ToString();
                textBox4.Text = path;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 ubn = new Form1();
            ubn.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 ndt = new Form4();
            ndt.Show();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
