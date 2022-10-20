using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace _4
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String surname = textBox1.Text;
            String name = textBox2.Text;
            String patronymic = textBox3.Text;
            int.TryParse(textBox4.Text, out int age);
            String workplace = textBox5.Text;
            Client client = new Client(name, surname, patronymic, 21, workplace, Program.bank);
            this.Close();
        }
    }
}
