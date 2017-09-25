using System;

class Calculation
{
    public const double plancConstant = 6.62606896e-34;
    public static double Pi = 3.14159;
}

class Program
{
    static void Main()
    {
        Console.WriteLine(Calculation.plancConstant / (2 * Calculation.Pi));
    }
}

