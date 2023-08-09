using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace This__SUCKS___
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void updateDonorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form5 up = new Form5();
            up.Show();
        }

        private void allDonorDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form6 lj = new Form6();
            lj.Show();
        }

        private void byIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form7 al = new Form7();
            al.Show();
        }

        private void byLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form8 sm = new Form8();
            sm.Show();
        }

        private void byBloodGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form9 nr  = new Form9();
            nr.Show();
        }

        private void increaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void decreaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form12 koy = new Form12();
            koy.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 kon = new Form1();
            kon.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form17 kox = new Form17();
            kox.Show();
        }
    }
}
