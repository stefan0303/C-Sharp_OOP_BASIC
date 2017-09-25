using System;

class Tiger : CatsFamily
{
    public Tiger(string animalName, string animalType, double animalWeight, Food food, string region)
        : base(animalName, animalType, animalWeight, food, region)
    {

    }

    public override void MakeSound()
    {
        Console.WriteLine("ROAAR!!!");
    }
}

