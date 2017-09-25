using System;

class Mouse : Mammal
{

    public Mouse(string animalName, string animalType, double animalWeight, Food food, string livingRegion)
        : base(animalName, animalType, animalWeight, food, livingRegion)
    {

    }
    public override void MakeSound()
    {
        Console.WriteLine("SQUEEEAAAK!");
    }


}

