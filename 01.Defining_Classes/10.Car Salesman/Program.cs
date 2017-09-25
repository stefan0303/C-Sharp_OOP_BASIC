using System;
using System.Collections.Generic;
using System.Linq;

public class Car
{
    public string Model { get; set; }
    public Engine Engine { get; set; }
    public int Weight { get; set; } //optional
    public string Colour { get; set; } //optional

    public Car(string model, Engine engine, int weight, string colour)//all
    {
        this.Model = model;
        this.Engine = engine;
        this.Weight = weight;
        this.Colour = colour;
    }
    public Car(string model, Engine engine, string colour)//without weight
        : this(model, engine, -1, colour)
    {
        this.Model = model;
        this.Engine = engine;
        this.Colour = colour;
    }
    public Car(string model, Engine engine, int weight)//without colour
        : this(model, engine, weight, "n/a")
    {
        this.Model = model;
        this.Engine = engine;
        this.Weight = weight;
    }
    public Car(string model, Engine engine)//without colour and weight
        : this(model, engine, -1, "n/a")
    {
        this.Model = model;
        this.Engine = engine;
    }
}
public class Engine
{
    public string Model { get; set; }
    public string Power { get; set; }
    public int Displacement { get; set; }//optional
    public string Efficiency { get; set; }  //optional

    public Engine(string model, string power, int displacement, string efficiency)
    {
        this.Model = model;
        this.Power = power;
        this.Displacement = displacement;
        this.Efficiency = efficiency;
    }

    public Engine(string model, string power, string efficiency)//without displacement
        : this(model, power, -1, efficiency)
    {
        this.Model = model;
        this.Power = power;
        this.Efficiency = efficiency;
    }
    public Engine(string model, string power, int displacement)//without efficiency
        : this(model, power, displacement, "n/a")
    {
        this.Model = model;
        this.Power = power;
        this.Displacement = displacement;
    }
    public Engine(string model, string power)//without efficiency and colour
        : this(model, power, -1, "n/a")
    {
        this.Model = model;
        this.Power = power;

    }
}

public class Program
{
    public static void Main()

    {

        int n = int.Parse(Console.ReadLine());//number of Engines
        List<Engine> engines = new List<Engine>();

        for (int i = 0; i < n; i++)
        {
            string[] engineInfo = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            string model = engineInfo[0];
            string power = engineInfo[1];
            if (engineInfo.Length == 2)//we have only model and power
            {
                Engine engine = new Engine(model, power);
                engines.Add(engine);
            }
            else if (engineInfo.Length == 3)
            {
                int num;
                bool isNumeric = int.TryParse(engineInfo[2], out num);
                if (isNumeric)//is num Only efficiency
                {
                    int displacement = int.Parse(engineInfo[2]);

                    Engine engine = new Engine(model, power, displacement);
                    engines.Add(engine);
                }
                else//is not num Only displacement
                {
                    string efficiency = engineInfo[2];
                    Engine engine = new Engine(model, power, efficiency);
                    engines.Add(engine);
                }
            }
            else//there are all elements of engine
            {
                int displacement = int.Parse(engineInfo[2]);
                string efficiency = engineInfo[3];

                Engine engine = new Engine(model, power, displacement, efficiency);
                engines.Add(engine);
            }

        }
        List<Car> cars = new List<Car>();
        int m = int.Parse(Console.ReadLine());
        //“<Model> <Engine> <Weight> <Color> [2] can be weight or color
        for (int i = 0; i < m; i++)
        {
            string[] carsInfo = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            string model = carsInfo[0];
            string engine = carsInfo[1];
            Engine findEngine = engines.FirstOrDefault(e => e.Model == engine);//Find the Engine
            if (carsInfo.Length == 2)//only model and engine
            {
                Car car = new Car(model, findEngine);
                cars.Add(car);
            }
            else if (carsInfo.Length == 3)
            {
                int num;
                bool isNumeric = int.TryParse(carsInfo[2], out num);
                if (isNumeric)//is num //car with carWeight
                {
                    int carWeight = int.Parse(carsInfo[2]);

                    Car car = new Car(model, findEngine, carWeight);
                    cars.Add(car);
                }
                else //car with colour
                {
                    string colour = carsInfo[2];
                    Car car = new Car(model, findEngine, colour);
                    cars.Add(car);
                }

            }
            else//there is weight and colour
            {
                int carWeight = int.Parse(carsInfo[2]);
                string colour = carsInfo[3];
                Car car = new Car(model, findEngine, carWeight, colour);
                cars.Add(car);
            }

        }
        foreach (var car in cars)
        {
            Console.WriteLine(car.Model + ":");
            Console.WriteLine("  " + car.Engine.Model + ":");
            Console.WriteLine("    Power: " + car.Engine.Power);
            if (car.Engine.Displacement == -1)
            {
                Console.WriteLine("    Displacement: n/a");
            }
            else
            {
                Console.WriteLine("    Displacement: " + car.Engine.Displacement);
            }

            Console.WriteLine("    Efficiency: " + car.Engine.Efficiency);
            if (car.Weight == -1)
            {
                Console.WriteLine("  Weight: n/a");
            }
            else
            {
                Console.WriteLine("  Weight: " + car.Weight);
            }
            Console.WriteLine("  Color: " + car.Colour);
        }

    }

}

