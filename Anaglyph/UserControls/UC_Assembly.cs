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
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Reflection;
using System.Net;

namespace Anaglyph.UserControls
{
    public unsafe partial class UC_Assembly : UserControl
    {
        [DllImport("C:\\Users\\slawek\\source\\repos\\Anaglyph\\x64\\Debug\\ASM_Anaglyph.dll")]
        private static extern void anaglyph_alghorytm(byte[] preparedArrayOfFirstImage, byte[] preparedArrayOfSecondImage, IntPtr ptrScan0ForResult, int startPoint, int endPoint);

        private int counterOfExecutionTime = 0;
        private double averageExecutionTimeInTicks = 0;
        private double averageExecutionTimeInMs = 0;
        private int numberOfThreads = 0;
        private byte[] preparedArrayOfFirstImage = null;
        private byte[] preparedArrayOfSecondImage = null;
        public UC_Assembly()
        {

            InitializeComponent();
            textBox1.Text = "Liczba wątków: " + guna2TrackBar1.Value;
            numberOfThreads = guna2TrackBar1.Value;
            preparedArrayOfFirstImage = new byte[0];
            preparedArrayOfSecondImage = new byte[0];
        }

        private void button3_Click(object sender, EventArgs e)
        {

            ParallelOptions options = new ParallelOptions
            {
                MaxDegreeOfParallelism = numberOfThreads
            };

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

                // Lock the bitmap's bits.  
                Rectangle rectOfResultBitmap = new Rectangle(0, 0, resultBitmap.Width, resultBitmap.Height);
                BitmapData dataOfResultBitmap = resultBitmap.LockBits(rectOfResultBitmap, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                // Get the address of the first line.
                IntPtr ptrScan0ForResult = dataOfResultBitmap.Scan0;

                // Lock the bitmap's bits.  
                Rectangle rectOfBitmapOfFirstImage = new Rectangle(0, 0, resultBitmap.Width, resultBitmap.Height);
                BitmapData dataOfBitmapOfFirstImage = bitmapOfFirstImage.LockBits(rectOfBitmapOfFirstImage, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                int bytes = Math.Abs(dataOfBitmapOfFirstImage.Stride) * bitmapOfFirstImage.Height;
                // Get the address of the first line.

                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();

                Parallel.For(0, numberOfThreads, options, i =>
                {
                    int analyzedFragment = bytes / numberOfThreads;
                    int remainder = bytes % numberOfThreads;

                    int startPoint = analyzedFragment * i + remainder;
                    int endPoint = startPoint + analyzedFragment + remainder;

                    anaglyph_alghorytm(preparedArrayOfFirstImage, preparedArrayOfSecondImage, ptrScan0ForResult, startPoint, endPoint);

                });

                stopWatch.Stop();

                TimeSpan ts = stopWatch.Elapsed;
                averageExecutionTimeInTicks += ts.Ticks;
                averageExecutionTimeInMs += ts.Milliseconds;
                resultBitmap.UnlockBits(dataOfResultBitmap);
                bitmapOfFirstImage.UnlockBits(dataOfBitmapOfFirstImage);
                CSharp_Anaglyph.Alghorytm CSharp_Anaglyph_Dll = new CSharp_Anaglyph.Alghorytm();


                try
                {
                    string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    string parentDirectory = CSharp_Anaglyph_Dll.GoUpDirectories(currentDirectory, 3);
                    resultBitmap.Save(parentDirectory+"\\Resources\\Result.jpg");
                }
                catch
                {
                    string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    string parentDirectory = CSharp_Anaglyph_Dll.GoUpDirectories(currentDirectory, 3);
                    Bitmap bitmap = new Bitmap(resultBitmap.Width, resultBitmap.Height, resultBitmap.PixelFormat);
                    Graphics g = Graphics.FromImage(bitmap);
                    g.DrawImage(resultBitmap, new Point(0, 0));
                    g.Dispose();
                    resultBitmap.Dispose();

                    bitmap.Save(parentDirectory+"\\Resources\\Result.jpg");
                    resultBitmap = bitmap; // preserve clone        
                }


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

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg; *.jpeg; *.png; *.bmp;)|*.jpg; *.jpeg; *.png; *.bmp;";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(openFileDialog.FileName);
                pictureBox1.BorderStyle = BorderStyle.None;

            }
            if (pictureBox1.Image != null)
            {
                Bitmap bitmapOfSecondImage = new Bitmap(pictureBox1.Image);
                byte[] tempPreparedArrayOfSecondImage = new byte[bitmapOfSecondImage.Width * bitmapOfSecondImage.Height * 3];
                int indexv2 = 0;

                // Iteruj po pikselach obrazu
                for (int y = 0; y < bitmapOfSecondImage.Height; y++)
                {
                    for (int x = 0; x < bitmapOfSecondImage.Width; x++)
                    {

                        // Pobierz wartości składowych koloru piksela
                        Color pixelColorOfSecondImage = bitmapOfSecondImage.GetPixel(x, y);

                        // Zapisujemy wartości kolorów do jednowymiarowej tablicy
                        if (indexv2 < tempPreparedArrayOfSecondImage.Length)
                            tempPreparedArrayOfSecondImage[indexv2++] = (byte)pixelColorOfSecondImage.B;
                        if (indexv2 < tempPreparedArrayOfSecondImage.Length)
                            tempPreparedArrayOfSecondImage[indexv2++] = (byte)pixelColorOfSecondImage.G;
                        if (indexv2 < tempPreparedArrayOfSecondImage.Length)
                            tempPreparedArrayOfSecondImage[indexv2++] = (byte)0;

                    }
                }
                Array.Resize(ref preparedArrayOfSecondImage, tempPreparedArrayOfSecondImage.Length);
                Array.Copy(tempPreparedArrayOfSecondImage, preparedArrayOfSecondImage, tempPreparedArrayOfSecondImage.Length);
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
            if (pictureBox1.Image != null)
            {
                Bitmap bitmapOfFirstImage = new Bitmap(pictureBox2.Image);
                byte[] tempPreparedArrayOfFirstImage = new byte[bitmapOfFirstImage.Width * bitmapOfFirstImage.Height * 3];
                int indexv1 = 0;

                // Iteruj po pikselach obrazu
                for (int y = 0; y < bitmapOfFirstImage.Height; y++)
                {
                    for (int x = 0; x < bitmapOfFirstImage.Width; x++)
                    {
                        // Pobierz wartości składowych koloru piksela
                        Color pixelColorOfFirstImage = bitmapOfFirstImage.GetPixel(x, y);

                        if (indexv1 < tempPreparedArrayOfFirstImage.Length)
                            tempPreparedArrayOfFirstImage[indexv1++] = (byte)0;
                        if (indexv1 < tempPreparedArrayOfFirstImage.Length)
                            tempPreparedArrayOfFirstImage[indexv1++] = (byte)0;
                        if (indexv1 < tempPreparedArrayOfFirstImage.Length)
                            tempPreparedArrayOfFirstImage[indexv1++] = (byte)pixelColorOfFirstImage.R;

                    }
                }
                Array.Resize(ref preparedArrayOfFirstImage, tempPreparedArrayOfFirstImage.Length);
                Array.Copy(tempPreparedArrayOfFirstImage, preparedArrayOfFirstImage, tempPreparedArrayOfFirstImage.Length);
            }
        }

        private void guna2TrackBar1_Scroll(object sender, ScrollEventArgs e)
        {
            textBox1.Text = "Liczba wątków: " + guna2TrackBar1.Value;
            numberOfThreads = guna2TrackBar1.Value;
        }
    }
}
