using System;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    [DllImport("C:\\Users\\slawek\\source\\repos\\Anaglyph\\x64\\Debug\\ASM_Anaglyph.dll")]
    public static extern void matrix_multiply(double[] matrix1, double[] matrix2, double[] result);

    [DllImport("C:\\Users\\slawek\\source\\repos\\Anaglyph\\x64\\Debug\\ASM_Anaglyph.dll")]
    public static extern void matrix_addition(double[] matrix1, double[] matrix2, double[] result);

    static void Main()
    {
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



        /*double[] matrixForAddition1 = { 1, 2, 3 };
        double[] matrixForAddition2 = { 1, 2, 3 };
        double[] resultOfAddition = { 0, 0, 0 };

        matrix_addition(matrixForAddition1, matrixForAddition2, resultOfAddition);

        Console.WriteLine("Wynik dodawania macierzy:");
        foreach (double b in resultOfAddition)
        {
            Console.Write(b + "\n");
        }
        Console.WriteLine();*/
    }
}
