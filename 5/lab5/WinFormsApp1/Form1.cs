using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public List<string> words = new List<string>();
        public float time = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog()
            {
                FileName = "Открыть текстовый файл",
                Filter = "Text files (*.txt)|*.txt",
                Title = "Открыть текстовый файл"
            };
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog1.FileName;
                try
                {
                    List<string> wordsFromFile = new List<string>(File.ReadAllText(file).Split().ToArray());
                    wordsFromFile.ForEach(el =>
                    {
                        if (!words.Contains(el))
                        {
                            words.Add(el);
                        }
                    });
                }
                catch (IOException)
                {
                }
            }

            stopWatch.Stop();
            label1.Text = $"Время: {stopWatch.Elapsed.ToString()}";

            listBox1.BeginUpdate();

            words.ForEach(el =>
            {
                listBox1.Items.Add(el);
            });

            listBox1.EndUpdate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            string word = textBox1.Text;
            string foundWord = words.Find(el => el == word);

            if (foundWord == null)
            {
                MessageBox.Show(
                  "Такое слово не найдено",
                  "Ошибка",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Asterisk //
                );
            }
            stopWatch.Stop();
            label3.Text = $"Время: {stopWatch.Elapsed.ToString()}";
            label4.Text = $"Найденное слово: {foundWord}";
        }
    }
}
