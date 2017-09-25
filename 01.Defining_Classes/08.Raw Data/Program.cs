using System;
using System.Collections.Generic;
using System.Linq;


class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());//amount of cars
        List<Car> cars = new List<Car>();
        for (int i = 0; i < n; i++)
        {
            string[] info = Console.ReadLine().Split(' ').ToArray();
            string model = info[0];
            int engineSpeed = int.Parse(info[1]);
            int enginePower = int.Parse(info[2]);
            int cargoWeight = int.Parse(info[3]);
            string cargoType = info[4];
            double tiereOnePre = double.Parse(info[5]);
            int tiereOneAge = int.Parse(info[6]);
            double tiereTwoPre = double.Parse(info[7]);
            int tiereTwoAge = int.Parse(info[8]);
            double tiereThreePre = double.Parse(info[9]);
            int tiereThreeAge = int.Parse(info[10]);
            double tiereFourPre = double.Parse(info[11]);
            int tiereFourAge = int.Parse(info[12]);

            Engine engine = new Engine(engineSpeed, enginePower);
            Cargo cargo = new Cargo(cargoWeight, cargoType);
            Tiere tiereOne = new Tiere(tiereOnePre, tiereOneAge, 1);
            Tiere tiereTwo = new Tiere(tiereTwoPre, tiereTwoAge, 2);
            Tiere tiereThree = new Tiere(tiereThreePre, tiereThreeAge, 3);
            Tiere tiereFour = new Tiere(tiereFourPre, tiereFourAge, 4);
            List<Tiere> tieres = new List<Tiere> { tiereOne, tiereTwo, tiereThree, tiereFour };
            Car car = new Car(model, engine, cargo, tieres);

            cars.Add(car);
        }
        string command = Console.ReadLine();
        if (command == "fragile")
        {
            var carsFragile =
                cars.Where(c => c.Cargo.Type == "fragile").Where(t => t.Tieres.Any(ti => ti.Pressure < 1));
            foreach (var car in carsFragile)
            {
                Console.WriteLine(car.Model);
            }
        }
        else//flamable
        {
            var carsFlamable = cars.Where(c => c.Cargo.Type == "flamable").Where(e => e.Engine.Power > 250);
            foreach (var car in carsFlamable)
            {
                Console.WriteLine(car.Model);
            }
        }
    }
}

class Car
{

    public Car(string model, Engine engine, Cargo cargo, List<Tiere> tieres)
    {
        Model = model;
        Engine = engine;
        Cargo = cargo;
        Tieres = tieres;
    }

    public string Model { get; set; }
    public Engine Engine { get; set; }
    public Cargo Cargo { get; set; }

    public List<Tiere> Tieres { get; set; }

}


class Engine
{
    public Engine(int speed, int power)
    {
        this.Speed = speed;
        this.Power = power;
    }
    public int Speed { get; set; }
    public int Power { get; set; }
}

class Cargo
{
    public Cargo(int weight, string type)
    {
        this.Weight = weight;
        this.Type = type;
    }
    public int Weight { get; set; }
    public string Type { get; set; }
}

class Tiere
{
    public Tiere(double pressure, int age, int numOfTiere)
    {
        this.NumOfTier = numOfTiere;
        this.Age = age;
        this.Pressure = pressure;
    }

    public int NumOfTier { get; set; }
    public int Age { get; set; }
    public double Pressure { get; set; }
}

