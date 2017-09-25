
using System.Text;

public abstract class Animal
{
    protected string animalName;
    protected string animalType;
    protected double animalWeight;
    protected double foodEaten;
    protected string foodType;

    protected string region;
    //Eat food abstract
    protected Animal(string animalName, string animalType, double animalWeight, Food food, string region)
    {
        this.foodEaten = food.GetQuantity();
        this.foodType = food.GetType();

        if (this.GetType().Name == "Tiger" && this.foodType == "Vegetable")
        {
            this.foodEaten = 0;
        }
        if (this.GetType().Name == "Mouse" && this.foodType == "Meat")
        {
            this.foodEaten = 0;
        }
        if (this.GetType().Name == "Zebra" && this.foodType == "Meat")
        {
            this.foodEaten = 0;
        }
        this.animalName = animalName;
        this.animalType = animalType;
        this.animalWeight = animalWeight;
        this.region = region;
    }
    public virtual string TooString()
    {

        StringBuilder sb = new StringBuilder();

        if (this.GetType().Name == "Tiger" && this.foodType == "Vegetable")
        {
            sb.Append("Tigers are not eating that type of food!\n");
        }
        if (this.GetType().Name == "Mouse" && this.foodType == "Meat")
        {
            sb.Append("Mouses are not eating that type of food!\n");
        }
        if (this.GetType().Name == "Zebra" && this.foodType == "Meat")
        {
            sb.Append("Zebras are not eating that type of food!\n");
        }
        sb.Append(this.animalType + "[") //anymal type
            .Append(this.animalName + ", ")
            .Append(this.animalWeight + ", ")
            .Append(this.region + ", ")
            .Append(this.foodEaten + "]");

        return sb.ToString();
    }
    public virtual void MakeSound()
    {

    }
    protected virtual void EatFood()
    {

    }

}



