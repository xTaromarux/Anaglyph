using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Anaglyph.UserControls
{
    public partial class UC_CSharp : UserControl
    {
        private int counterOfExecutionTime = 0;
        private double averageExecutionTimeInS = 0;
        private double averageExecutionTimeInMs = 0;

        public UC_CSharp()
        {
            InitializeComponent();
            textBox1.Text = "Liczba wątków: " + guna2TrackBar1.Value;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg; *.jpeg; *.png; *.bmp;)|*.jpg; *.jpeg; *.png; *.bmp;";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
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

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null && pictureBox2.Image != null)
            {
                counterOfExecutionTime++;

                Bitmap bitmapOfFirstImage = new Bitmap(pictureBox1.Image);
                Bitmap bitmapOfSecondImage = new Bitmap(pictureBox2.Image);
                Bitmap resultBitmap = new Bitmap(bitmapOfFirstImage.Width, bitmapOfFirstImage.Height);

                // Check if bitmaps has the same size
                if (bitmapOfFirstImage.Width != bitmapOfSecondImage.Width || bitmapOfFirstImage.Height != bitmapOfSecondImage.Height)
                {
                    Console.WriteLine("Obie bitmapy muszą mieć takie same rozmiary.");
                    return;
                }

                DateTime startCSharp = DateTime.Now;
                AnaglyphAlghorytmCSharp(bitmapOfFirstImage, bitmapOfSecondImage, resultBitmap);
                DateTime endCSharp = DateTime.Now;
                TimeSpan tsCSharp = (endCSharp - startCSharp);

                averageExecutionTimeInS += tsCSharp.TotalSeconds;
                averageExecutionTimeInMs += tsCSharp.TotalMilliseconds;

                resultBitmap.Save("C:\\Users\\igor\\source\\repos\\Anaglyph\\Anaglyph\\Resources\\ResultImage.jpg");

                // Możemy także wyświetlić wygenerowaną liczbę
                textBox2.Text = "Czas wykonywania to: " + tsCSharp.TotalSeconds + " s => " + tsCSharp.TotalMilliseconds + " ms";
                if (counterOfExecutionTime == 5)
                {
                    counterOfExecutionTime = 0;
                    textBox3.Text = "Średni czas wykonywania to: " + (averageExecutionTimeInS / 5) + " s => " + (averageExecutionTimeInMs / 5) + " ms";
                }
            }
        }

        static void AnaglyphAlghorytmCSharp(Bitmap bitmapOfFirstImage, Bitmap bitmapOfSecondImage, Bitmap resultBitmap)
        {
            // Przetwórz każdy piksel
            for (int x = 0; x < bitmapOfFirstImage.Width; x++)
            {
                for (int y = 0; y < bitmapOfFirstImage.Height; y++)
                {
                    Color pixel1 = bitmapOfFirstImage.GetPixel(x, y);
                    Color pixel2 = bitmapOfSecondImage.GetPixel(x, y);


                    // Ustaw wynikowy piksel w wynikowej bitmapie
                    resultBitmap.SetPixel(x, y, Color.FromArgb((int)pixel1.R, (int)pixel2.G, (int)pixel2.B));
                }
            }
        }

    }
}
