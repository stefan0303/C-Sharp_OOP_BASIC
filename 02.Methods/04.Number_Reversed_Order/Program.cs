using System;

public class DecimalNumber
{
    public DecimalNumber(decimal numberr)
    {
        char[] numToString = Convert.ToString(numberr).ToCharArray();
        for (int i = numToString.Length - 1; i >= 0; i--)
        {
            Console.Write(numToString[i]);
        }
        Console.WriteLine();
    }

}
class Program
{
    static void Main()
    {
        decimal numbers = decimal.Parse(Console.ReadLine());
        DecimalNumber number = new DecimalNumber(numbers);

    }
}

