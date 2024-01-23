using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;

namespace CSharp_Anaglyph
{
    public class Alghorytm
    {
        [STAThread]
        static void Main()
        {

        }

        public void AnaglyphAlghorytmCSharp(Bitmap processedBitmapv1, Bitmap processedBitmapv2, Bitmap resultBitmap, int numberOfThreadsTemp)
        {
            unsafe
            {
                ParallelOptions options = new ParallelOptions
                {
                    MaxDegreeOfParallelism = numberOfThreadsTemp
                };

                BitmapData bitmapDatav1 = processedBitmapv1.LockBits(new Rectangle(0, 0, processedBitmapv1.Width, processedBitmapv1.Height),
                    ImageLockMode.ReadWrite, processedBitmapv1.PixelFormat);
                BitmapData bitmapDatav2 = processedBitmapv2.LockBits(new Rectangle(0, 0, processedBitmapv2.Width, processedBitmapv2.Height),
                    ImageLockMode.ReadWrite, processedBitmapv2.PixelFormat);
                BitmapData resultBitmapData = resultBitmap.LockBits(new Rectangle(0, 0, resultBitmap.Width, resultBitmap.Height),
                    ImageLockMode.ReadWrite, resultBitmap.PixelFormat);

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
            }
        }
    }
}
