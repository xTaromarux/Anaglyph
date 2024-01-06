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

class Program
{
    [DllImport("C:\\Users\\slawek\\source\\repos\\Anaglyph\\x64\\Debug\\ASM_Anaglyph.dll")]
    public static extern void matrix_multiply(double[] matrix1, double[] matrix2, double[] result);

    [DllImport("C:\\Users\\slawek\\source\\repos\\Anaglyph\\x64\\Debug\\ASM_Anaglyph.dll")]
    public static extern void matrix_addition(double[] matrix1, double[] matrix2, double[] result);

    [DllImport("C:\\Users\\slawek\\source\\repos\\Anaglyph\\x64\\Debug\\ASM_Anaglyph.dll")]
    public static extern void matrix_addition_on_ptr(float[] matrix1, float[] matrix2, float[] result);

    [STAThread]

    static void Main()
    {
        /*Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new AnaglyphForm());*/


        double[] matrixForMultiplication1 = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        double[] matrixForMultiplication2 = { 1, 2, 3 };
        double[] resultOfMultiplication = new double[3];

        if (ThreadPool.SetMaxThreads(2000, 100))
        {
            Console.Write("The minimum number of threads was set successfully. \n");
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            // Określenie liczby wątków
            int numThreads = 5;

            // Wywołanie funkcji wielowątkowo
            /*            Parallel.For(0, numThreads, i =>
                        {
                            matrix_multiply(matrixForMultiplication1, matrixForMultiplication2, resultOfMultiplication, i, numThreads);
                        });*/
            matrix_multiply(matrixForMultiplication1, matrixForMultiplication2, resultOfMultiplication);
            stopWatch.Stop();

            Console.WriteLine("Wynik mnożenia macierzy:");
            foreach (double a in resultOfMultiplication)
            {
                Console.Write(a + "\n");
            }
            Console.WriteLine();

            TimeSpan ts = stopWatch.Elapsed;

            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);
        }
        else
        {
            Console.Write("The minimum number of threads was not changed. \n");
        }



        float[] matrixForAddition1 = { 1, 2, 3 };
        float[] matrixForAddition2 = { 1, 2, 3 };
        float[] resultOfAddition = { 0, 0, 0 };

        matrix_addition_on_ptr(matrixForAddition1, matrixForAddition2, resultOfAddition);

        Console.WriteLine("Wynik dodawania macierzy:");
        foreach (float res in resultOfAddition)
        {
            Console.Write(res + "\n");
        }
        Console.WriteLine();

        Bitmap bitmapOfFirstImage = new Bitmap("C:\\Users\\slawek\\source\\repos\\Anaglyph\\Anaglyph\\Resources\\FirstImage.jpg");
        Bitmap bitmapOfSecondImage = new Bitmap("C:\\Users\\slawek\\source\\repos\\Anaglyph\\Anaglyph\\Resources\\SecondImage.jpg");
        Bitmap resultBitmap = new Bitmap(bitmapOfFirstImage.Width, bitmapOfFirstImage.Height);
        // Sprawdź, czy obie bitmapy mają takie same rozmiary
        if (bitmapOfFirstImage.Width != bitmapOfSecondImage.Width || bitmapOfFirstImage.Height != bitmapOfSecondImage.Height)
        {
            Console.WriteLine("Obie bitmapy muszą mieć takie same rozmiary.");
            return;
        }

        // Przygotuj macierze do mnożenia
        double[,] matrix1 = { { 1, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
        double[,] matrix2 = { { 0, 0, 0 }, { 0, 1, 0 }, { 0, 0, 1 } };

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

        // Zapisz wynikową bitmapę
        resultBitmap.Save("C:\\Users\\slawek\\source\\repos\\Anaglyph\\Anaglyph\\Resources\\ResultImage.jpg");
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
