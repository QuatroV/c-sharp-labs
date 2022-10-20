using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace _4
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string clientName = textBox1.Text;
            int.TryParse(textBox2.Text, out int accountId);

            Client client = Program.bank.FindClientByName(clientName);

            if (client == null)
            {
                MessageBox.Show(
                  "Клиент с таким именем не найден",
                  "Клиент не найден",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Asterisk //
                );

                return;
            }

            Account.OpenAccount(client, Program.bank, accountId);
            Close();
        }
    }
}
