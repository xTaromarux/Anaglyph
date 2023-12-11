using System;
using System.Runtime.InteropServices;

class Program
{
    [DllImport("C:\\Users\\slawek\\source\\repos\\Anaglyph\\x64\\Debug\\ASM_Anaglyph.dll")]
    public static extern int CheckMMX();

    [DllImport("C:\\Users\\slawek\\source\\repos\\Anaglyph\\x64\\Debug\\ASM_Anaglyph.dll")]
    public static extern int CheckSSE();

    [DllImport("C:\\Users\\slawek\\source\\repos\\Anaglyph\\x64\\Debug\\ASM_Anaglyph.dll")]
    public static extern int CheckSSE2();

    [DllImport("C:\\Users\\slawek\\source\\repos\\Anaglyph\\x64\\Debug\\ASM_Anaglyph.dll")]
    public static extern int CheckSSE3();


    static void Main()
    {
        int resultMMX = CheckMMX();
        int resultSSE = CheckSSE();
        int resultSSE2 = CheckSSE2();
        int resultSSE3 = CheckSSE3();

        Console.WriteLine("Obsługa MMX: " + resultMMX);

        Console.WriteLine("Obsługa SSE: " + resultSSE);
        Console.WriteLine("Obsługa SSE2: " + resultSSE2);
        Console.WriteLine("Obsługa SSE3: " + resultSSE3);

        Console.ReadLine();
    }
}