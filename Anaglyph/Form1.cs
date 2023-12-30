using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Anaglyph
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void button3_Click(object sender, EventArgs e)
        {
            // Tworzymy obiekt do generowania liczb losowych
            Random random = new Random();

            // Generujemy losową liczbę
            int wygenerowanaLiczba = random.Next();

            // Możemy także wyświetlić wygenerowaną liczbę
            textBox1.Text = "Czas wykonania to: " + wygenerowanaLiczba + " ms";
        }

    }
}

