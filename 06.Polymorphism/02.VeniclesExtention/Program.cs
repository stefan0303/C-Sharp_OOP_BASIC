using System;
using System.Linq;

public abstract class Vehicles
{
    private double fuelQuantity;
    private double litersPerKm;
    private int tankCapacity;
    protected Vehicles(double fuelQuantity, double litersPerKm, int tankCapacity)
    {
        this.FuelQuantity = fuelQuantity;
        this.LitersPerKm = litersPerKm;
        this.TankCapacity = tankCapacity;
    }

    public int TankCapacity
    {
        get { return this.tankCapacity; }
        protected set
        {
            if (value < 0)
            {
                Console.WriteLine("Fuel must be a positive number");
                //  throw new ArgumentException("Fuel must be a positive number");
                //To do
            }
            this.tankCapacity = value;
        }
    }


    public double FuelQuantity
    {
        get { return this.fuelQuantity; }
        protected set { this.fuelQuantity = value; }
    }

    public double LitersPerKm
    {
        get { return this.litersPerKm; }
        protected set { this.litersPerKm = value; }
    }

    public abstract void DriveDistance(double distance);
    public abstract void Refuel(double refuel);

    public void DriveEmptyBus(double distance)//Bus is without people
    {
        double fuelTravelDistance = distance * (LitersPerKm);
        if (fuelTravelDistance > this.FuelQuantity)
        {
            throw new ArgumentException("Bus needs refueling");
        }
        if (this.FuelQuantity - fuelTravelDistance < 0)
        {
            Console.WriteLine("Fuel must be a positive number");
            //Todo
            return;
        }
        this.FuelQuantity -= fuelTravelDistance;
    }
}

class Bus : Vehicles
{
    public Bus(double fuelQuantity, double litersPerKm, int tankCapacity)
        : base(fuelQuantity, litersPerKm, tankCapacity)
    {
        this.LitersPerKm = this.LitersPerKm;
    }

    public override void DriveDistance(double distance)//Bus is with people
    {
        double fuelTravelDistance = distance * (base.LitersPerKm + 1.4);//there is air condition more fulel(1.4 per km)
        if (fuelTravelDistance > this.FuelQuantity)
        {
            throw new ArgumentException("Bus needs refueling");
        }
        //if (this.FuelQuantity - fuelTravelDistance < 0)
        //{
        //    Console.WriteLine("Fuel must be a positive number");
        //    //Todo
        //    return;
        //}
        this.FuelQuantity -= fuelTravelDistance;
    }



    public override void Refuel(double quantity)
    {
        if (this.FuelQuantity + quantity > TankCapacity)//there is no space in Tank do not fuel
        {
            Console.WriteLine("Cannot fit fuel in tank");
            //  throw new ArgumentException("Cannot fit fuel in tank");
            // Todo
            return;
        }
        if (quantity < 0)
        {
            Console.WriteLine("Fuel must be a positive number");
        }
        else
        {
            this.FuelQuantity += quantity;
        }

    }
}

class Car : Vehicles
{
    public Car(double fuelQuantity, double litersPerKm, int tankCapacity)
        : base(fuelQuantity, litersPerKm, tankCapacity)
    {
        this.LitersPerKm = this.LitersPerKm;
    }

    public override void DriveDistance(double distance)
    {
        double fuelTravelDistance = distance * (base.LitersPerKm);
        if (fuelTravelDistance > this.FuelQuantity)
        {
            throw new ArgumentException("Car needs refueling");
        }
        if (this.FuelQuantity - fuelTravelDistance < 0)
        {
            Console.WriteLine("Fuel must be a positive number");
            //Todo
            return;
        }
        this.FuelQuantity -= fuelTravelDistance;
    }

    public override void Refuel(double quantity)
    {
        if (this.FuelQuantity + quantity > TankCapacity)//there is no space in Tank
        {
            Console.WriteLine("Cannot fit fuel in tank");
            //  throw new ArgumentException("Cannot fit fuel in tank");
            // To do
            return;

        }
        //if (quantity<=0) //Moje da zarejdame kolata sus otricatelno gorivo Bezumie!!!!@!
        //{
        //    Console.WriteLine("Fuel must be a positive number");

        //}
        else
        {
            this.FuelQuantity += quantity;
        }

    }
}

class Truck : Vehicles
{
    public Truck(double fuelQuantity, double litersPerKm, int tankCapacity)
        : base(fuelQuantity, litersPerKm, tankCapacity)
    {
        this.LitersPerKm = this.LitersPerKm;//konsumaciata na gorivo pri kamiona za uvelichava sus 1,6 litra
    }

    public override void DriveDistance(double distance)
    {
        double fuelTravelDistance = distance * (base.LitersPerKm);
        if (fuelTravelDistance > this.FuelQuantity)
        {
            throw new ArgumentException("Truck needs refueling");
        }
        if (this.FuelQuantity - fuelTravelDistance <= 0)
        {
            Console.WriteLine("Fuel must be a positive number");
            //Todo
            return;
        }
        this.FuelQuantity -= fuelTravelDistance;
    }

    public override void Refuel(double quantity)
    {
        if (quantity <= 0)
        {
            Console.WriteLine("Fuel must be a positive number");
        }
        else
        {
            this.FuelQuantity += quantity * 0.95;
        }



    }
}

class Program
{
    static void Main()
    {
        string[] carInfo = Console.ReadLine().Split().ToArray();
        string[] truckInfo = Console.ReadLine().Split().ToArray();
        string[] busInfo = Console.ReadLine().Split().ToArray();
        int numberCommands = int.Parse(Console.ReadLine());

        double carFuelQuantity = double.Parse(carInfo[1]);//kolichestvo benzi v kolata
        double carLitersPerKm = double.Parse(carInfo[2]);////razhod na gorivo na kolata
        int carTankCapacity = int.Parse(carInfo[3]);// kapaciten na Tank

        double truckFuelQuantity = double.Parse(truckInfo[1]);//kolichestvo benzi v kamiona
        double truckLitersPerKm = double.Parse(truckInfo[2]);//razhod na gorivo na kamiona
        int truckTankCapacity = int.Parse(truckInfo[3]);// kapaciten na Tank

        double busFuelQuantity = double.Parse(busInfo[1]);//kolichestvo benzi v avtobusa
        double busLitersPerKm = double.Parse(busInfo[2]);//razhod na gorivo na avtobusa
        int busTankCapacity = int.Parse(busInfo[3]);// kapaciten na Tank

        Vehicles car = new Car(carFuelQuantity, carLitersPerKm, carTankCapacity);
        Vehicles truck = new Truck(truckFuelQuantity, truckLitersPerKm, truckTankCapacity);
        Vehicles bus = new Bus(busFuelQuantity, busLitersPerKm, busTankCapacity);
        for (int i = 0; i < numberCommands; i++)
        {
            string[] command = Console.ReadLine().Split().ToArray();
            string action = command[0];
            string typeOfVenicle = command[1];
            if (action == "Drive")
            {
                double distance = double.Parse(command[2]);
                if (typeOfVenicle == "Car")
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
                if (typeOfVenicle == "Bus")//bus with people
                {
                    try
                    {
                        bus.DriveDistance(distance);
                        Console.WriteLine("Bus travelled {0} km", distance);
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
            if (action == "DriveEmpty")//bus WithOut people
            {
                double distance = double.Parse(command[2]);
                try
                {
                    bus.DriveEmptyBus(distance);
                    truck.DriveDistance(distance);
                    Console.WriteLine("Truck travelled {0} km", distance);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            if (action == "Refuel")//Refuel
            {
                double refuelLiters = double.Parse(command[2]);
                if (refuelLiters <= 0)
                {
                    Console.WriteLine("Fuel must be a positive number");
                    continue;
                }
                if (typeOfVenicle == "Car")
                {
                    car.Refuel(refuelLiters);
                }
                if (typeOfVenicle == "Bus")
                {
                    bus.Refuel(refuelLiters);
                }
                if (typeOfVenicle == "Truck")
                {
                    truck.Refuel(refuelLiters);
                }
            }
        }
        Console.WriteLine("Car: {0:f2}", car.FuelQuantity);
        Console.WriteLine("Truck: {0:f2}", truck.FuelQuantity);
        Console.WriteLine("Bus: {0:f2}", bus.FuelQuantity);
    }
}

