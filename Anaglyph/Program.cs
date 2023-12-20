using System;
using System.Runtime.InteropServices;

class Program
{
    [DllImport("C:\\Users\\slawek\\source\\repos\\Anaglyph\\x64\\Debug\\ASM_Anaglyph.dll")]
    public static extern void matrix_multiply(Int16[] matrix1, Int16[] matrix2, Int16[] result);

    static void Main()
    {
        Int16[] matrix1 = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        Int16[] matrix2 = { 1, 2, 3 } ;
        Int16[] result = { 0, 0, 0 };

        matrix_multiply(matrix1, matrix2, result);

        Console.WriteLine("Wynik mnożenia macierzy:");
        foreach (float b in result)
        {
            Console.Write(b + "\n");
        }
        Console.WriteLine();
    }
}
