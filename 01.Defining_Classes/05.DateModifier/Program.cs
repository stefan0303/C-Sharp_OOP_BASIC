using System;
using System.Linq;


class Program
{
    static void Main()
    {
        string dateOne = Console.ReadLine();
        string dateTwo = Console.ReadLine();
        DateModifier date = new DateModifier();
        date.GetDateDifference(dateOne, dateTwo);
    }
}

public class DateModifier
{
    private string dateOne;
    private string dateTwo;

    public void GetDateDifference(string dateOne, string dateTwo)
    {
        string[] dOne = dateOne.Split(' ').ToArray();
        string year = dOne[0];
        string month = dOne[1];
        string day = dOne[2];

        string[] dTwo = dateTwo.Split(' ').ToArray();
        string yearTwo = dTwo[0];
        string monthTwo = dTwo[1];
        string dayTwo = dTwo[2];

        DateTime startDate = DateTime.Parse($"{month}/{day}/{year}");
        DateTime endDate = DateTime.Parse($"{monthTwo}/{dayTwo}/{yearTwo}");
        Console.WriteLine(Math.Abs((endDate - startDate).TotalDays));
    }
}

