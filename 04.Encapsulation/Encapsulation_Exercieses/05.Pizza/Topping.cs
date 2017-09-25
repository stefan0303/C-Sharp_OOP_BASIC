using System;

class Topping
{
    //toppings can be of type of meat, veggies, cheese or sauce
    private string type;

    private double weight;

    public Topping(string type, double weight)
    {
        this.Type = type;
        this.Weight = weight;
    }
    public double Weight
    {
        get { return this.weight; }
        set
        {
            if (value >= 1 && value <= 50)//is valid
            {
                this.weight = value;

            }
            else
            {
                string thisType = this.Type;
                throw new ArgumentException($"{thisType} weight should be in the range [1..50].");
            }
        }
    }

    public string Type
    {
        get { return this.type; }
        set
        {
            if (value.ToLower() == "meat" || value.ToLower() == "veggies" || value.ToLower() == "cheese" || value.ToLower() == "sauce")
            {
                this.type = value;
            }
            else
            {
                throw new ArgumentException($"Cannot place {value} on top of your pizza.");
            }
        }
    }

    public double CalculateCalories()
    {
        double calories = 0;
        switch (this.type.ToLower())
        {
            case "meat":
                calories = this.weight * 1.2 * 2;
                break;
            case "veggies":
                calories = this.weight * 0.8 * 2;
                break;
            case "cheese":
                calories = this.weight * 1.1 * 2;
                break;
            case "sauce":
                calories = this.weight * 0.9 * 2;
                break;
        }

        return calories;
    }
}