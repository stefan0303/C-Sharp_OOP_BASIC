using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<Pizza> pizzas = new List<Pizza>();
        string[] pizzaInfo = Console.ReadLine().Split(' ').ToArray();
        while (pizzaInfo[0] != "END")
        {
            switch (pizzaInfo[0])
            {
                case "Pizza":
                    try
                    {
                        Pizza pizza = new Pizza(pizzaInfo[1], int.Parse(pizzaInfo[2]));
                        pizzas.Add(pizza);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return;

                    }
                    break;
                case "Dough":
                    try
                    {
                        Douth douth = new Douth(pizzaInfo[1], pizzaInfo[2], double.Parse(pizzaInfo[3]));

                        if (pizzas.Count == 0)
                        {
                            Console.WriteLine("{0:f2}", douth.CalculateCalories());

                            pizzaInfo = Console.ReadLine().Split(' ').ToArray();
                            if (pizzaInfo[0] == "END")
                            {
                                return;
                            }
                            continue;
                        }
                        pizzas[0].Douth = douth;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return;
                    }
                    break;
                case "Topping":
                    try
                    {
                        Topping topping = new Topping(pizzaInfo[1], double.Parse(pizzaInfo[2]));
                        if (pizzas.Count == 0)
                        {
                            Console.WriteLine("{0:f2}", topping.CalculateCalories());
                            pizzaInfo = Console.ReadLine().Split(' ').ToArray();
                            if (pizzaInfo[0] == "END")
                            {
                                return;
                            }
                            continue;
                        }

                        pizzas[0].AddToppings(topping);//add topping
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return;
                    }
                    break;
            }
            pizzaInfo = Console.ReadLine().Split(' ').ToArray();
        }
        Console.WriteLine(pizzas[0].Name + " – {0:f2}", pizzas[0].TotalCalloriesSum());

    }
}

class Pizza
{
    private string name;
    private int numberToppings;
    private Douth douth;//testo
    private List<Topping> toppings;
    private double totalCallories;

    public Pizza(string name, int numberToppings)
    {
        this.Name = name;
        this.NumberToppings = numberToppings;
        this.toppings = new List<Topping>();
        this.Douth = douth;

    }

    public Douth Douth
    {
        get { return this.douth; }
        set { this.douth = value; }
    }

    public int NumberToppings
    {
        get { return this.numberToppings; }
        set
        {
            if (value <= 10)
            {
                this.numberToppings = value;
            }
            else
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
        }
    }

    public string Name
    {
        get { return this.name; }
        set
        {
            if (!string.IsNullOrEmpty(value) && value.Length <= 15 && value.Length >= 1)//check is valid Name
            {
                this.name = value;
            }
            else
            {
                throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
            }

        }
    }

    public double TotalCalloriesSum()
    {
        double totalCallories = this.douth.CalculateCalories() + toppings.Select(t => t.CalculateCalories()).Sum();


        return totalCallories;
    }

    public void AddToppings(Topping topping)//method to add toppings to List
    {
        if (toppings.Count <= 10 && toppings.Count >= 1)
        {
            toppings.Add(topping);
        }
        else
        {
            throw new ArgumentException("Number of toppings should be in range [0..10].");
        }

    }

}






