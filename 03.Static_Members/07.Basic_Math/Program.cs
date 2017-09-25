using System;
using System.Collections.Generic;
using System.Linq;

public class MathUtil
{
    static double result;
    public static double Sum(double firstNum, double secondNum)
    {

        return firstNum + secondNum;

    }

    public static double Substract(double firstNum, double secondNum)
    {
        result = firstNum - secondNum;
        return result;
    }
    public static double Multiply(double firstNum, double secondNum)
    {
        result = firstNum * secondNum;
        return result;
    }
    public static double Divide(double firstNum, double secondNum)
    {
        result = firstNum / secondNum;
        return result;
    }
    public static double Percentage(double firstNum, double secondNum)
    {
        result = firstNum * secondNum / 100;
        return result;
    }

}
class Program
{
    static void Main()
    {
        List<string> input = Console.ReadLine().Split().ToList();
        while (input[0] != "End")
        {
            double first = Convert.ToDouble(input[1]);
            double second = Convert.ToDouble(input[2]);
            switch (input[0])
            {

                case "Sum":
                    Console.WriteLine("{0:f2}", MathUtil.Sum(first, second));
                    break;
                case "Subtract":
                    Console.WriteLine("{0:f2}", MathUtil.Substract(first, second));
                    break;
                case "Multiply":
                    Console.WriteLine("{0:f2}", MathUtil.Multiply(first, second));
                    break;
                case "Divide":
                    Console.WriteLine("{0:f2}", MathUtil.Divide(first, second));
                    break;
                case "Percentage":
                    Console.WriteLine("{0:f2}", MathUtil.Percentage(first, second));
                    break;
            }
            input = Console.ReadLine().Split().ToList();
        }

    }
}

