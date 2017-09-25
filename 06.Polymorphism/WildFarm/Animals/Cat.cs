using System;
using System.Text;

class Cat : CatsFamily
{
    private string catBreed;
    public Cat(string animalName, string animalType, double animalWeight, Food food, string region, string catBreed)
          : base(animalName, animalType, animalWeight, food, region)
    {
        this.CatBreed = catBreed;
    }

    public string CatBreed
    {
        get { return this.catBreed; }
        set { this.catBreed = value; }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(this.animalType + "[") //anymal type
            .Append(this.animalName + ", ")
            .Append(this.catBreed + ", ")
            .Append(this.animalWeight + ", ")
            .Append(this.region + ", ")
            .Append(this.foodEaten + "]");

        return sb.ToString();
    }

    public override void MakeSound()
    {
        Console.WriteLine("Meowwww");
    }
}

