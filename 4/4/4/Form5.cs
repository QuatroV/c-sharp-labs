using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace _4
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int.TryParse(textBox1.Text, out int accountId);

            Account account = Program.bank.FindAccountById(accountId);

            if (account == null)
            {
                richTextBox1.Text = "Не был найден счет с таким id";
                return;
            }

            richTextBox1.Text = account.getInfo();
        }
    }
}
