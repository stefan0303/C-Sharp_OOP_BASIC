using System;

class Douth
{
    //dough can be white or wholegrain and in addition it can be crispy, chewy or homemade
    private string flourType;
    private string bakingTehnique;
    private double weight;

    public Douth(string flourType, string bakingTehnique, double weight)
    {
        this.FlourType = flourType;
        this.BakingTehnique = bakingTehnique;
        this.Weight = weight;
    }

    public double CalculateCalories()
    {
        double calories = 0;
        double caloriesFlourType = 0;
        double caloriesBakingTehnique = 0;
        switch (this.FlourType.ToLower())
        {
            case "white":
                caloriesFlourType = 1.5;
                break;
            case "wholegrain":
                caloriesFlourType = 1.0;
                break;
        }
        switch (this.BakingTehnique.ToLower())
        {
            case "crispy":
                caloriesBakingTehnique = 0.9;
                break;
            case "chewy":
                caloriesBakingTehnique = 1.1;
                break;
            case "homemade":
                caloriesBakingTehnique = 1.0;
                break;
        }
        calories = (weight * 2) * caloriesFlourType * caloriesBakingTehnique;
        return calories;
    }

    public double Weight
    {
        get { return this.weight; }
        set
        {
            if (value >= 1 && value <= 200)//is valid
            {
                this.weight = value;
            }
            else
            {
                throw new ArgumentException("Dough weight should be in the range [1..200].");
            }

        }
    }

    public string FlourType
    {
        get { return this.flourType; }
        set
        {
            if (value.ToLower() == "white" || value.ToLower() == "wholegrain")//the name is correct
            {
                this.flourType = value;

            }
            else
            {
                throw new ArgumentException("Invalid type of dough.");
            }

        }
    }
    public string BakingTehnique
    {
        get { return this.bakingTehnique; }
        set
        {
            if (value.ToLower() == "crispy" || value.ToLower() == "chewy" || value.ToLower() == "homemade")
            {
                this.bakingTehnique = value;
            }
            else
            {
                throw new ArgumentException("Invalid type of dough.");
            }

        }
    }
}


