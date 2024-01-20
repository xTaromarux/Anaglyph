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

namespace Anaglyph.UserControls
{
    public partial class UC_Assembly : UserControl
    {
        
        [DllImport("C:\\Users\\slawek\\source\\repos\\Anaglyph\\x64\\Debug\\ASM_Anaglyph.dll")]
        private static extern void anaglyph_alghorytm(byte[] preparedArrayOfFirstImage, byte[] preparedArrayOfSecondImage, IntPtr ptrScan0ForResult, int sizeInBytes);

        private int counterOfExecutionTime = 0;
        private double averageExecutionTimeInTicks = 0;
        private double averageExecutionTimeInMs = 0;

        public UC_Assembly()
        {

            InitializeComponent();
        }

        private void UC_Assembly_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            unsafe
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
                    bitmapOfFirstImage.UnlockBits(dataOfBitmapOfFirstImage);


                    // Inicjalizuj wektory dla składowych R, G i B
                    byte[] preparedArrayOfFirstImage = new byte[bitmapOfFirstImage.Width * bitmapOfFirstImage.Height*3];
                    byte[] preparedArrayOfSecondImage = new byte[bitmapOfFirstImage.Width * bitmapOfFirstImage.Height*3];
                    int indexv1 = 0;
                    int indexv2 = 0;


                    // Iteruj po pikselach obrazu
                    for (int y = 0; y < bitmapOfFirstImage.Height; y++)
                    {
                        for (int x = 0; x < bitmapOfFirstImage.Width; x++)
                        {
                            // Pobierz wartości składowych koloru piksela
                            Color pixelColorOfFirstImage = bitmapOfFirstImage.GetPixel(x, y);

                            // Pobierz wartości składowych koloru piksela
                            Color pixelColorOfSecondImage = bitmapOfSecondImage.GetPixel(x, y);

                            // Zapisujemy wartości kolorów do jednowymiarowej tablicy

                            if (indexv1 < preparedArrayOfFirstImage.Length)
                                preparedArrayOfFirstImage[indexv1++] = (byte)0;
                            if (indexv1 < preparedArrayOfFirstImage.Length)
                                preparedArrayOfFirstImage[indexv1++] = (byte)0;
                            if (indexv1 < preparedArrayOfFirstImage.Length)
                                preparedArrayOfFirstImage[indexv1++] = (byte)pixelColorOfFirstImage.R;

                            // Zapisujemy wartości kolorów do jednowymiarowej tablicy
                            if (indexv2 < preparedArrayOfSecondImage.Length)
                                preparedArrayOfSecondImage[indexv2++] = (byte)pixelColorOfSecondImage.B;
                            if (indexv2 < preparedArrayOfSecondImage.Length)
                                preparedArrayOfSecondImage[indexv2++] = (byte)pixelColorOfSecondImage.G;
                            if (indexv2 < preparedArrayOfSecondImage.Length)
                                preparedArrayOfSecondImage[indexv2++] = (byte)0;

                        }
                    }

                    Stopwatch stopWatch = new Stopwatch();
                    stopWatch.Start();
                    anaglyph_alghorytm(preparedArrayOfFirstImage, preparedArrayOfSecondImage, ptrScan0ForResult, bytes);
                    stopWatch.Stop();

                    TimeSpan ts = stopWatch.Elapsed;
                    averageExecutionTimeInTicks += ts.Ticks;
                    averageExecutionTimeInMs += ts.Milliseconds;
                    resultBitmap.UnlockBits(dataOfResultBitmap);

                    try
                    {
                        resultBitmap.Save("C:\\Users\\slawek\\source\\repos\\Anaglyph\\Anaglyph\\Resources\\Result.jpg");
                    }
                    catch
                    {
                        Bitmap bitmap = new Bitmap(resultBitmap.Width, resultBitmap.Height, resultBitmap.PixelFormat);
                        Graphics g = Graphics.FromImage(bitmap);
                        g.DrawImage(resultBitmap, new Point(0, 0));
                        g.Dispose();
                        resultBitmap.Dispose();

                        bitmap.Save("C:\\Users\\slawek\\source\\repos\\Anaglyph\\Anaglyph\\Resources\\Result.jpg");
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
        }

    }
}
