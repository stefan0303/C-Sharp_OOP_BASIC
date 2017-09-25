using System;

class Zebra : Mammal
{
    public override void MakeSound()
    {
        Console.WriteLine("Zs");
    }


    public Zebra(string animalName, string animalType, double animalWeight, Food food, string region) 
        : base(animalName, animalType, animalWeight, food, region)
    {

    }
}

