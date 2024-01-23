using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Anaglyph.UserControls
{
    public partial class UC_CSharp : UserControl
    {
        private int counterOfExecutionTime = 0;
        private double averageExecutionTimeInTicks = 0;
        private double averageExecutionTimeInMs = 0;
        private int numberOfThreads = 0;
        public UC_CSharp()
        {
            InitializeComponent();
            textBox1.Text = "Liczba wątków: " + guna2TrackBar1.Value;
            numberOfThreads = guna2TrackBar1.Value;
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
            numberOfThreads = guna2TrackBar1.Value;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null && pictureBox2.Image != null)
            {
                counterOfExecutionTime++;

                Bitmap bitmapOfFirstImage = new Bitmap(pictureBox1.Image);
                Bitmap bitmapOfSecondImage = new Bitmap(pictureBox2.Image);
                Bitmap resultBitmap = new Bitmap(bitmapOfFirstImage.Width, bitmapOfFirstImage.Height);
                Graphics g = Graphics.FromImage(resultBitmap);
                g.Clear(Color.Black);

                // Check if bitmaps has the same size
                if (bitmapOfFirstImage.Width != bitmapOfSecondImage.Width || bitmapOfFirstImage.Height != bitmapOfSecondImage.Height)
                {
                    Console.WriteLine("Obie bitmapy muszą mieć takie same rozmiary.");
                    return;
                }
                CSharp_Anaglyph.Alghorytm CSharp_Anaglyph_Dll = new CSharp_Anaglyph.Alghorytm();

                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                CSharp_Anaglyph_Dll.AnaglyphAlghorytmCSharp(bitmapOfFirstImage, bitmapOfSecondImage, resultBitmap, numberOfThreads);
                stopWatch.Stop();

                TimeSpan ts = stopWatch.Elapsed;
                averageExecutionTimeInTicks += ts.Ticks;
                averageExecutionTimeInMs += ts.Milliseconds;


                // Możemy także wyświetlić wygenerowaną liczbę
                textBox2.Text = "Czas wykonywania to: " + ts.Ticks + " ticks  => " + ts.Milliseconds + " ms";
                if (counterOfExecutionTime == 5)
                {
                    counterOfExecutionTime = 0;
                    textBox3.Text = "Średni czas wykonywania to: " + (averageExecutionTimeInTicks / 5) + " ticks => " + (averageExecutionTimeInMs / 5) + " ms";
                    averageExecutionTimeInTicks = 0;
                    averageExecutionTimeInMs = 0;
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
