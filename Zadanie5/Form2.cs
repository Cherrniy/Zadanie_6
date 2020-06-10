using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zadanie5.Controller;

namespace Zadanie5
{
    public partial class Form2 : Form
    {
        Query controller;
        public Form2()
        {
            InitializeComponent();
            controller = new Query(ConnectionsString.ConnStr);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = controller.UpdatePersonO();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 frm = new Form1();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            controller.InsertO(int.Parse(textBox1.Text), int.Parse(textBox2.Text),int.Parse(textBox3.Text), int.Parse(textBox4.Text));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            controller.DeleteO(int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["ID"].Value.ToString()));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = controller.PoiskO(int.Parse(textBox5.Text));
        }
    }
}
