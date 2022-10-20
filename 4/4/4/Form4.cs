using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _4
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string clientName = textBox1.Text;

            List<Client>? clientCandidates = Program.bank.FindAllClientsByName(clientName);

            if (clientCandidates == null)
            {
                richTextBox1.Text = "Не было найдено клиентов с таким именем";
                return;
            }

            richTextBox1.Text = string.Join("; ", clientCandidates.Select(el => el.getInfo()).ToArray());
        }
    }
}
