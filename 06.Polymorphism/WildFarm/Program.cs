using System;
using System.Linq;

class Program
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
        while (input[0] != "End")
        {
            string typeOfEnimal = input[0];//Cat,Zebra.....
            string animalName = input[1];
            double weight = Convert.ToDouble(input[2]);
            string livingRegion = input[3];

            string[] inputLineTwo = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            string typeOfFood = inputLineTwo[0];
            int quantityFood = int.Parse(inputLineTwo[1]);
            dynamic food = null;
            switch (typeOfFood)
            {
                case "Vegetable":
                    food = new Vegetable(quantityFood, typeOfFood);
                    break;
                case "Meat":
                    food = new Meat(quantityFood, typeOfFood);
                    break;
            }

            switch (typeOfEnimal)
            {
                case "Cat":
                    string animalBreed = input[4];
                    Animal cat = new Cat(animalName, typeOfEnimal, weight, food, livingRegion, animalBreed);
                    cat.MakeSound();
                    Console.WriteLine(cat.ToString());
                    break;
                case "Tiger":

                    Animal tiger = new Tiger(animalName, typeOfEnimal, weight, food, livingRegion);
                    tiger.MakeSound();
                    Console.WriteLine(tiger.TooString());
                    break;
                case "Zebra":

                    Mammal zebra = new Zebra(animalName, typeOfEnimal, weight, food, livingRegion);
                    zebra.MakeSound();
                    Console.WriteLine(zebra.TooString());


                    break;
                case "Mouse":
                    Mammal mouse = new Mouse(animalName, typeOfEnimal, weight, food, livingRegion);
                    mouse.MakeSound();
                    Console.WriteLine(mouse.TooString());
                    break;
            }
            input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
        }
    }
}

