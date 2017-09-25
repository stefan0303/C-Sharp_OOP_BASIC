using System;
using System.Linq;


class ConvertTemperature
{
    public static string CelsiusToFahrenheit(int degreesInCelsius)
    {
        double degreesInFahrenheit = degreesInCelsius * 1.8 + 32;
        Console.WriteLine("{0:f2} Fahrenheit", degreesInFahrenheit);
        return Convert.ToString(degreesInFahrenheit); // String.Format("{0:F2} Celsius", degreesInCelsius);

    }
    public static string FahrenheitToCelsius(int degreesInFahrenheit)
    {
        double degreesInCelsius = (degreesInFahrenheit - 32) * (5.0 / 9);
        Console.WriteLine("{0:f2} Celsius", degreesInCelsius);
        return Convert.ToString(degreesInCelsius);

    }
}
class Program
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split().ToArray();

        while (input[0] != "End")
        {
            if (input[1] == "Celsius")
            {
                ConvertTemperature.CelsiusToFahrenheit(Convert.ToInt32(input[0]));

            }
            else
            {
                ConvertTemperature.FahrenheitToCelsius(Convert.ToInt32(input[0]));
            }
            input = Console.ReadLine().Split().ToArray();
        }
    }
}

