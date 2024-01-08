using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Anaglyph.UserControls
{
    public partial class UC_Assembly : UserControl
    {
        public UC_Assembly()
        {
            InitializeComponent();
            textBox1.Text = "Liczba wątków: " + guna2TrackBar1.Value;
        }

        private void UC_Assembly_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Tworzymy obiekt do generowania liczb losowych
            Random random = new Random();

            // Generujemy losową liczbę
            int wygenerowanaLiczba = random.Next();

            // Możemy także wyświetlić wygenerowaną liczbę
            textBox2.Text = "Czas wykonania to: " + wygenerowanaLiczba + " ms";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg; *.jpeg; *.png; *.bmp;)|*.jpg; *.jpeg; *.png; *.bmp;";
            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                pictureBox1.Image = new Bitmap(openFileDialog.FileName);
                pictureBox1.BorderStyle = BorderStyle.None;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg; *.jpeg; *.png; *.bmp;)|*.jpg; *.jpeg; *.png; *.bmp;";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image = new Bitmap(openFileDialog.FileName);
                pictureBox2.BorderStyle = BorderStyle.None;
            }
        }

        private void guna2TrackBar1_Scroll(object sender, ScrollEventArgs e)
        {
            textBox1.Text = "Liczba wątków: " + guna2TrackBar1.Value;
        }
    }
}
