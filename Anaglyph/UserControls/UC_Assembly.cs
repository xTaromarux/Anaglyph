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

namespace Anaglyph.UserControls
{
    public partial class UC_Assembly : UserControl
    {
        [DllImport("C:\\Users\\igor\\source\\repos\\Anaglyph\\x64\\Debug\\ASM_Anaglyph.dll")]
        private static extern void anaglyph_alghorytm(IntPtr ptrScan0ForResult, IntPtr bitmapOfFirstImage, IntPtr bitmapOfSecondImage, int sizeInBytes);

        private int counterOfExecutionTime = 0;
        private double averageExecutionTimeInS = 0;
        private double averageExecutionTimeInMs = 0;

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
                Rectangle rectOfBitmapOfFirstImage = new Rectangle(0, 0, resultBitmap.Width, resultBitmap.Height);
                BitmapData dataOfBitmapOfFirstImage = bitmapOfFirstImage.LockBits(rectOfBitmapOfFirstImage, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                int bytes = Math.Abs(dataOfBitmapOfFirstImage.Stride) * bitmapOfFirstImage.Height;
                // Get the address of the first line.
                IntPtr ptrScan0ForBitmapOfFirstImage = dataOfBitmapOfFirstImage.Scan0;

                // Lock the bitmap's bits.  
                Rectangle rectOfBitmapOfSecondImage = new Rectangle(0, 0, resultBitmap.Width, resultBitmap.Height);
                BitmapData dataOfBitmapOfSecondImage = bitmapOfSecondImage.LockBits(rectOfBitmapOfSecondImage, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                // Get the address of the first line.
                IntPtr ptrScan0ForBitmapOfSecondImage = dataOfBitmapOfSecondImage.Scan0;

                // Lock the bitmap's bits.  
                Rectangle rectOfResultBitmap = new Rectangle(0, 0, resultBitmap.Width, resultBitmap.Height);
                BitmapData dataOfResultBitmap = resultBitmap.LockBits(rectOfResultBitmap, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                // Get the address of the first line.
                IntPtr ptrScan0ForResult = dataOfResultBitmap.Scan0;

                DateTime startASM = DateTime.Now;
                anaglyph_alghorytm(ptrScan0ForResult, ptrScan0ForBitmapOfFirstImage, ptrScan0ForBitmapOfSecondImage, bytes);
                DateTime endASM = DateTime.Now;
                TimeSpan tsASM = (endASM - startASM);

                averageExecutionTimeInS += tsASM.TotalSeconds;
                averageExecutionTimeInMs += tsASM.TotalMilliseconds;

                bitmapOfFirstImage.UnlockBits(dataOfBitmapOfFirstImage);
                bitmapOfSecondImage.UnlockBits(dataOfBitmapOfSecondImage);
                resultBitmap.UnlockBits(dataOfResultBitmap);

                resultBitmap.Save("C:\\Users\\igor\\source\\repos\\Anaglyph\\Anaglyph\\Resources\\ResultImage.jpg");
                // Możemy także wyświetlić wygenerowaną liczbę
                textBox2.Text = "Czas wykonywania to: " + tsASM.TotalSeconds + " s" + tsASM.TotalMilliseconds + " ms";

                if (counterOfExecutionTime == 5)
                {
                    counterOfExecutionTime = 0;
                    textBox3.Text = "Średni czas wykonywania to: " + (averageExecutionTimeInS / 5) + " s => " + (averageExecutionTimeInMs / 5) + " ms";
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
            textBox1.Text = "Liczba wątków: " + guna2TrackBar1.Value;
        }

    }
}
