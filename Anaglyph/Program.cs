using System;
using System.Runtime.InteropServices;

class Program
{
    [DllImport("C:\\Users\\slawek\\source\\repos\\Anaglyph\\x64\\Debug\\ASM_Anaglyph.dll")]
    public static extern void matrix_multiply(float[] matrix1, float[] matrix2, float[] result);

    static void Main()
    {
        float[] matrix1 = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        float[] matrix2 = { 1, 2, 3 };
        float[] result = new float[3];

        matrix_multiply(matrix1, matrix2, result);

        Console.WriteLine("Wynik mnożenia macierzy:");
        for (int i = 0; i < result.Length; i++)
        {
            Console.WriteLine(result[i]);
        }

        Console.ReadLine();
    }
}
