using System;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Anaglyph;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

class Program
{
    [DllImport("C:\\Users\\slawek\\source\\repos\\Anaglyph\\x64\\Debug\\ASM_Anaglyph.dll")]
    public static extern void anaglyph_alghorytm(IntPtr ptrScan0ForResult, IntPtr bitmapOfFirstImage, IntPtr bitmapOfSecondImage, int sizeInBytes);

    [STAThread]

    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new AnaglyphForm());


        Bitmap bitmapOfFirstImage = new Bitmap("C:\\Users\\slawek\\source\\repos\\Anaglyph\\Anaglyph\\Resources\\FirstImage.jpg");
        Bitmap bitmapOfSecondImage = new Bitmap("C:\\Users\\slawek\\source\\repos\\Anaglyph\\Anaglyph\\Resources\\SecondImage.jpg");
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
        Console.WriteLine("Elapsed Time For ASM is {0} s => {1} ms", tsASM.TotalSeconds, tsASM.TotalMilliseconds);


        bitmapOfFirstImage.UnlockBits(dataOfBitmapOfFirstImage);
        bitmapOfSecondImage.UnlockBits(dataOfBitmapOfSecondImage);
        resultBitmap.UnlockBits(dataOfResultBitmap);

        resultBitmap.Save("C:\\Users\\slawek\\source\\repos\\Anaglyph\\Anaglyph\\Resources\\ResultImageASM.jpg");


        double[,] matrix1 = { { 1, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
        double[,] matrix2 = { { 0, 0, 0 }, { 0, 1, 0 }, { 0, 0, 1 } };

        DateTime startCSharp = DateTime.Now;
        AnaglyphAlghorytm(bitmapOfFirstImage, bitmapOfSecondImage, resultBitmap, matrix1, matrix2);
        DateTime endCSharp = DateTime.Now;
        TimeSpan tsCSharp = (endCSharp - startCSharp);
        Console.WriteLine("Elapsed Time For C# is {0} s => {1} ms", tsCSharp.TotalSeconds, tsCSharp.TotalMilliseconds);

        resultBitmap.Save("C:\\Users\\slawek\\source\\repos\\Anaglyph\\Anaglyph\\Resources\\ResultImageC#.jpg");

    }

    static void AnaglyphAlghorytm(Bitmap bitmapOfFirstImage, Bitmap bitmapOfSecondImage, Bitmap resultBitmap, double[,] matrix1, double[,] matrix2) {
        // Przetwórz każdy piksel
        for (int x = 0; x < bitmapOfFirstImage.Width; x++)
        {
            for (int y = 0; y < bitmapOfFirstImage.Height; y++)
            {
                Color pixel1 = bitmapOfFirstImage.GetPixel(x, y);
                Color pixel2 = bitmapOfSecondImage.GetPixel(x, y);

                // Wykonaj mnożenie macierzowe i dodawanie
                double[] resultArray = MatrixMultiply(matrix1, new double[] { pixel1.R, pixel1.G, pixel1.B });
                resultArray = VectorAdd(resultArray, MatrixMultiply(matrix2, new double[] { pixel2.R, pixel2.G, pixel2.B }));

                // Ustaw wynikowy piksel w wynikowej bitmapie
                resultBitmap.SetPixel(x, y, Color.FromArgb((int)resultArray[0], (int)resultArray[1], (int)resultArray[2]));
            }
        }
    }

    // Funkcja do mnożenia macierzy 3x3 przez wektor 3x1
    static double[] MatrixMultiply(double[,] matrix, double[] vector)
    {
        double[] result = new double[3];

        for (int i = 0; i < 3; i++)
        {
            result[i] = 0;
            for (int j = 0; j < 3; j++)
            {
                result[i] += matrix[i, j] * vector[j];
            }
        }

        return result;
    }

    // Funkcja do dodawania dwóch wektorów
    static double[] VectorAdd(double[] vector1, double[] vector2)
    {
        double[] result = new double[3];

        for (int i = 0; i < 3; i++)
        {
            result[i] = vector1[i] + vector2[i];
        }

        return result;
    }
}
