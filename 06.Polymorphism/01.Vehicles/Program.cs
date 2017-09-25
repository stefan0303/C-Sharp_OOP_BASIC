using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

public abstract class Vehicles
{
    private double fuelQuantity;
    private double litersPerKm;

    protected Vehicles(double fuelQuantity , double litersPerKm)
    {
        this.FuelQuantity = fuelQuantity;
       
        this.LitersPerKm = litersPerKm;
    }

    public  double FuelQuantity
    {
        get { return this.fuelQuantity; }
       protected set { this.fuelQuantity = value; }
    }
    
    public  double LitersPerKm
    {
        get { return this.litersPerKm; }
      protected  set { this.litersPerKm = value; }
    }

    public abstract void DriveDistance(double distance);
    public abstract void Refuel(double refuel);
}

class Car:Vehicles
{
    public Car(double fuelQuantity,double litersPerKm)
        : base(fuelQuantity,litersPerKm)
    {
        this.LitersPerKm += 0.9;//harchi sus 0.9 litra poveche kolata
    }

    public override void DriveDistance(double distance )
    {
        double fuelTravelDistance = distance * (base.LitersPerKm);
        if (fuelTravelDistance>this.FuelQuantity)
        {
            throw new ArgumentException("Car needs refueling");
        }
        this.FuelQuantity -= fuelTravelDistance;
    }

    public override void Refuel(double quantity)
    {
        this.FuelQuantity += quantity;
    }
}

class Truck:Vehicles
{
    public Truck(double fuelQuantity, double litersPerKm)
        :base(fuelQuantity,litersPerKm)
    {
        this.LitersPerKm += 1.6;//konsumaciata na gorivo pri kamiona za uvelichava sus 1,6 litra
    }

    public override void DriveDistance(double distance)
    {
        double fuelTravelDistance = distance * (base.LitersPerKm);
        if (fuelTravelDistance > this.FuelQuantity)
        {
            throw  new ArgumentException("Truck needs refueling");
        }
        this.FuelQuantity -= fuelTravelDistance;
    }

    public override void  Refuel(double quantity)
    {
        this.FuelQuantity += quantity * 0.95;
    }
}

class Program
{
    static void Main()
    {
        string[] carInfo = Console.ReadLine().Split().ToArray();
        string[] truckInfo= Console.ReadLine().Split().ToArray();
        int numberCommands = int.Parse(Console.ReadLine());

        double carFuelQuantity = double.Parse(carInfo[1]);//kolichestvo benzi v kolata
        double carLitersPerKm= double.Parse(carInfo[2]);////razhod na gorivo na kolata

        double truckFuelQuantity = double.Parse(truckInfo[1]);//kolichestvo benzi v kamiona
        double truckLitersPerKm = double.Parse(truckInfo[2]);//razhod na gorivo na kamiona

        Vehicles car=new Car(carFuelQuantity,carLitersPerKm);
        Vehicles truck=new Truck(truckFuelQuantity,truckLitersPerKm);
        for (int i = 0; i < numberCommands; i++)
        {
            string[] command = Console.ReadLine().Split().ToArray();
            string action = command[0];
            string typeOfVenicle = command[1];
            if (action=="Drive")
            {               
                double distance = double.Parse(command[2]);
                if (typeOfVenicle=="Car")
                {
                    try
                    {
                        car.DriveDistance(distance);
                        Console.WriteLine("Car travelled {0} km", distance);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);                      
                    }                   
                }
                else//Truck
                {
                    try
                    {
                        truck.DriveDistance(distance);
                        Console.WriteLine("Truck travelled {0} km", distance);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }                 
                }             
            }
            else//Refuel
            {
                double refuelLiters = double.Parse(command[2]);
                if (typeOfVenicle=="Car")
                {
                    car.Refuel(refuelLiters);                  
                }
                else//Truck
                {
                    truck.Refuel(refuelLiters);    
                }
            }
        }
        Console.WriteLine("Car: {0:f2}",car.FuelQuantity);
        Console.WriteLine("Truck: {0:f2}", truck.FuelQuantity);
    }
}

