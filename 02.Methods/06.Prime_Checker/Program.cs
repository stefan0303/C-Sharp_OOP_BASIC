using System;

public class Number
{

    public Number(int number)
    {
        if (number < 0)
        {
            number = 0;
            NotPrime(number, false);
        }

        else if (number == 2 || number == 1 || number == 0 || number == 3 || number == 7)
        {

            NotPrime(number, true);
        }
        else
        {
            if (number % 2 != 0 && number % 3 != 0 && number % 5 != 0 && number % 7 != 0) // Prime Number
            {
                NotPrime(number, true);
            }
            else  //Not Prime Even number     
            {
                NotPrime(number, false);
            }
        }
    }
    public void NotPrime(int number, bool isPrime)
    {

        for (int i = number + 1; i <= 2147483647; i++)
        {

            if (i == 2 || i == 3 || i == 5 || i == 7 || i == 1 || i == 0) // Checks numbers 2, 3, 5, 7
            {
                if (isPrime)
                {
                    Console.WriteLine(i + ", " + "true");
                    break;
                }
        
                    Console.WriteLine(i + ", " + "false");
                    break;
                
            }
            if (i % 2 != 0 && i % 3 != 0 && i % 5 != 0 && i % 7 != 0) // Checks division with reminder
            {
                if (isPrime)
                {
                    Console.WriteLine(i + ", " + "true");
                    break;
                }
        
                    Console.WriteLine(i + ", " + "false");
                    break;                
            }
        }
    }
}
class Program
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        bool isPrime = true;
        Number num = new Number(number);
    }
}

