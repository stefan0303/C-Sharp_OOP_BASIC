using System;
using System.Linq;

public class BeerCounter
{
    public static int beerInStock;
    public static int beersDrankCount;

    public static int BuyBeer(int bottlesCount)
    {
        beerInStock += bottlesCount;
        return beerInStock;
    }
    public static int DrinkBeer(int drankBeers)
    {
        beersDrankCount += drankBeers;
        return beersDrankCount;
    }
}

class Program
{
    static void Main()
    {
        string[] beers = Console.ReadLine().Split().ToArray();
        while (Convert.ToString(beers[0]) != "End")
        {
            BeerCounter.BuyBeer(Convert.ToInt32(beers[0]));
            BeerCounter.DrinkBeer(Convert.ToInt32(beers[1]));
            beers = Console.ReadLine().Split().ToArray();
        }
        Console.WriteLine((BeerCounter.beerInStock - BeerCounter.beersDrankCount) + " " + BeerCounter.beersDrankCount);
    }
}

