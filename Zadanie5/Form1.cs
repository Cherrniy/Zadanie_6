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
    public partial class Form1 : Form
    {
        Query controller;
        public Form1()
        {
            InitializeComponent();
            controller = new Query(ConnectionsString.ConnStr);
        }

        private void Ubdate_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = controller.UpdatePerson();
        }
        private void Delete_Click(object sender, EventArgs e)
        {
            controller.Delete(int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["ID"].Value.ToString()));
        }
        private void Insert_Click(object sender, EventArgs e)
        {
            controller.Add(textBox1.Text, textBox2.Text, int.Parse(textBox3.Text));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = controller.PoiskP(int.Parse(textBox4.Text));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 frm = new Form2();
            frm.Show();
        }
    }
}
