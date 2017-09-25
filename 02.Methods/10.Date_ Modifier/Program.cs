using System;
using System.Linq;

/*Create a class DateModifier which stores the
 *  difference of the days between two Dates.
 *   It should have a method which takes two string parameters
 *    representing a date as strings
 *  and calculates the difference in the days between them*/

public class DateModifier
{

    public DateModifier(string start,string end)
    {
        int[] startDateSplit = start.Split().Select(int.Parse).ToArray();
        
        int[] endDateSplit = end.Split().Select(int.Parse).ToArray();

        DateTime startDate = new DateTime(startDateSplit[0], startDateSplit[1], startDateSplit[2]);
        DateTime endDate = new DateTime(endDateSplit[0], endDateSplit[1], endDateSplit[2]);
        Console.WriteLine(Math.Abs((endDate-startDate).TotalDays));
    }
}
class Program
{
    static void Main()
    {
        string start = Console.ReadLine();
        string end = Console.ReadLine();

        DateModifier makeDifference=new DateModifier(start, end);
    }
}

