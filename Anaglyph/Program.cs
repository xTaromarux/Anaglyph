using System;
using System.Runtime.InteropServices;

class Program
{
    [DllImport("C:\\Users\\slawek\\source\\repos\\Anaglyph\\x64\\Debug\\ASM_Anaglyph.dll")]
    public static extern void matrix_multiply(double[] matrix1, double[] matrix2, double[] result);

    static void Main()
    {
        double[] matrix1 = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        double[] matrix2 = { 1, 2, 3 } ;
        double[] result = { 0, 0, 0 };

        matrix_multiply(matrix1, matrix2, result);

        Console.WriteLine("Wynik mnożenia macierzy:");
        foreach (double b in result)
        {
            Console.Write(b + "\n");
        }
        Console.WriteLine();
    }
}
