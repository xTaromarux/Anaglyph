using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Media3D;

namespace Anaglyph.UserControls
{
    public partial class UC_CSharp : UserControl
    {
        private int counterOfExecutionTime = 0;
        private double averageExecutionTimeInS = 0;
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

                DateTime startCSharp = DateTime.Now;
                AnaglyphAlghorytmCSharp(bitmapOfFirstImage, bitmapOfSecondImage, resultBitmap, numberOfThreads);
                             DateTime endCSharp = DateTime.Now;
                TimeSpan tsCSharp = (endCSharp - startCSharp);

                averageExecutionTimeInS += tsCSharp.TotalSeconds;
                averageExecutionTimeInMs += tsCSharp.TotalMilliseconds;


                // Możemy także wyświetlić wygenerowaną liczbę
                textBox2.Text = "Czas wykonywania to: " + tsCSharp.TotalSeconds + " s => " + tsCSharp.TotalMilliseconds + " ms";
                if (counterOfExecutionTime == 5)
                {
                    counterOfExecutionTime = 0;
                    textBox3.Text = "Średni czas wykonywania to: " + (averageExecutionTimeInS / 5) + " s => " + (averageExecutionTimeInMs / 5) + " ms";
                    averageExecutionTimeInS = 0;
                    averageExecutionTimeInMs = 0;
                }
            }
        }

        private void AnaglyphAlghorytmCSharp(Bitmap processedBitmapv1, Bitmap processedBitmapv2, Bitmap resultBitmap, int numberOfThreadsTemp)
        {
            unsafe
            {
                ParallelOptions options = new ParallelOptions
                {
                    MaxDegreeOfParallelism = numberOfThreadsTemp
                };

                BitmapData bitmapDatav1 = processedBitmapv1.LockBits(new Rectangle(0, 0, processedBitmapv1.Width, processedBitmapv1.Height), ImageLockMode.ReadWrite, processedBitmapv1.PixelFormat);
                BitmapData bitmapDatav2 = processedBitmapv2.LockBits(new Rectangle(0, 0, processedBitmapv2.Width, processedBitmapv2.Height), ImageLockMode.ReadWrite, processedBitmapv2.PixelFormat);
                BitmapData resultBitmapData = resultBitmap.LockBits(new Rectangle(0, 0, resultBitmap.Width, resultBitmap.Height), ImageLockMode.ReadWrite, resultBitmap.PixelFormat);

                int bytesPerPixel = System.Drawing.Bitmap.GetPixelFormatSize(processedBitmapv1.PixelFormat) / 8;
                int heightInPixels = bitmapDatav1.Height;
                int widthInBytes = bitmapDatav1.Width * bytesPerPixel;
                byte* PtrFirstPixelv1 = (byte*)bitmapDatav1.Scan0;
                byte* PtrFirstPixelv2 = (byte*)bitmapDatav2.Scan0;
                byte* PtrFirstPixelForResult = (byte*)resultBitmapData.Scan0;

                Parallel.For(0, heightInPixels, options, y =>
                {
                    byte* currentLinev1 = PtrFirstPixelv1 + (y * bitmapDatav1.Stride);
                    byte* currentLinev2 = PtrFirstPixelv2 + (y * bitmapDatav2.Stride);
                    byte* currentLineForResult = PtrFirstPixelForResult + (y * resultBitmapData.Stride);
                    for (int x = 0; x < widthInBytes; x = x + bytesPerPixel)
                    {
                        int oldBlue = currentLinev2[x];
                        int oldGreen = currentLinev2[x + 1];
                        int oldRed = currentLinev1[x + 2];

                        currentLineForResult[x] = (byte)oldBlue;
                        currentLineForResult[x + 1] = (byte)oldGreen;
                        currentLineForResult[x + 2] = (byte)oldRed;
                    }
                });
                processedBitmapv1.UnlockBits(bitmapDatav1);
                processedBitmapv2.UnlockBits(bitmapDatav2);
                resultBitmap.UnlockBits(resultBitmapData);
                resultBitmap.Save("C:\\Users\\slawek\\source\\repos\\Anaglyph\\Anaglyph\\Resources\\Result.jpg");
            }
        }
    }
}
