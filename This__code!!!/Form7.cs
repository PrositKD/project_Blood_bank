using DGVPrinterHelper;
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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 af = new Form4();
            af.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-9HKN9TN\\SQLEXPRESS;Initial Catalog=BloodBank;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select Id,Name,Fname,Mname,Dob,Gender ,Age,MblNo,Email,BG,CrntCity,Permntadrs from SgnUpTab where Id=@Id", con);
            cmd.Parameters.AddWithValue("Id", int.Parse(textBox1.Text));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;



            /*//Image column
            DataGridViewImageColumn dgv = new DataGridViewImageColumn();
            dgv = (DataGridViewImageColumn)dataGridView1.Columns[5];
            dgv.ImageLayout = DataGridViewImageCellLayout.Stretch; */

            /// Autosize Table Column
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            ///Image Row Height
            dataGridView1.RowTemplate.Height = 180;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DGVPrinter print = new DGVPrinter();
            print.Title = "Donor Details";
            print.SubTitle = "Print Date: " + DateTime.Now.ToShortDateString();
            print.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            print.PageNumbers = true;
            print.PageNumberInHeader = false;
            print.PorportionalColumns = true;
            print.HeaderCellAlignment = StringAlignment.Near;
            print.Footer = "Blood Bank Management System";
            print.FooterSpacing = 15;
            print.PrintDataGridView(dataGridView1);
        }
    }
}
