using System;

class Program
{
    static void Main()
    {
        int start = int.Parse(Console.ReadLine());
        int end = int.Parse(Console.ReadLine());
        Fibonacci fibonacci = new Fibonacci();

        long a = 0;
        long b = 1;
        fibonacci.numbers.Add(a);
        fibonacci.numbers.Add(b);
        long c;
        for (int i = 2; i <= end; i++)
        {
            c = a + b;
            fibonacci.numbers.Add(c);
            a = b;
            b = c;
        }

        Console.WriteLine(string.Join(", ", fibonacci.GetNumbersInRange(start, end)));
    }
}
