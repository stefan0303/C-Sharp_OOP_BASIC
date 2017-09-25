using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CarManager
{
    private static Dictionary<int, Car> id_Car = new Dictionary<int, Car>();
    private static Dictionary<int, Race> id_Race = new Dictionary<int, Race>();
    private static Garage garage = new Garage();

    public void Register(int id, string type, string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability)
    { 
        if (type == "Performance")
        {

            Car performanceCar = new PerformanceCar(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability);
            if (!id_Car.ContainsKey(id))
            {
                id_Car.Add(id, performanceCar);
            }


        }
        else//Show
        {
            Car showCar = new ShowCar(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability, 0);
            if (!id_Car.ContainsKey(id))
            {
                id_Car.Add(id, showCar);
            }
        }
    }

    public  string Check(int id)
    {//OK
        var car = id_Car.FirstOrDefault(c => c.Key == id).Value;


        return car.ToString();
    }

    public  void Open(int id, string type, int length, string route, int prizePool)
    {
        if (!id_Race.ContainsKey(id))
        {
            switch (type)
            {
                case "Casual":
                    Race casualRace = new CasualRace(length, route, prizePool);
                    id_Race.Add(id, casualRace);
                    break;
                case "Drag":
                    Race dragRace = new DragRace(length, route, prizePool);
                    id_Race.Add(id, dragRace);
                    break;
                case "Drift":
                    Race driftRace = new DriftRace(length, route, prizePool);
                    id_Race.Add(id, driftRace);
                    break;
              
            }
        }


    }

    public  void Participate(int carId, int raceId)
    {
        //Find the car
        Car car = id_Car.FirstOrDefault(c => c.Key == carId).Value;
        var race = id_Race.FirstOrDefault(r => r.Key == raceId);//Find the race
        
        //Bonus Task
        if (race.Value.GetType().ToString() == "TimeLimitRace"|| race.Value.GetType().ToString()== "CircuitRace")
        {
            if (race.Value.Participants.Count==0&& garage.CheckIsThereSuchCarInGarage(carId, car))
            {
                race.Value.AddPartivipants(car);
            }
        }
        if (garage.CheckIsThereSuchCarInGarage(carId, car)) //Check there is such car in garage
        {
            race.Value.AddPartivipants(car);
        }

    }

    public  string Start(int id)
    {
        var race = id_Race.FirstOrDefault(r => r.Key == id).Value;
        if (race.Participants.Count==0)//there are no participants in the race
        {
            return "Cannot start the race with zero participants.";

        }
        StringBuilder sb = new StringBuilder();
        sb.Append(race.Route + " - " + race.Length);
        switch (race.GetType().Name)
        {
            case "TimeLimitRace":
                var timeLimitRace = (TimeLimitRace) race;
                int timeLimitPoints = race.Length * (race.Participants.First().Horsepower/100)* race.Participants.First().Acceleration;
                string title = "";
                int money = 0;
                if (timeLimitPoints<= timeLimitRace.GetGoldTime())
                {
                    title = "Gold";
                    money = timeLimitRace.PrizePool;
                }
                if (timeLimitPoints<= timeLimitRace.GetGoldTime()+15)
                {
                    title = "Silver";
                    money = timeLimitRace.PrizePool / 2;
                }
                if (timeLimitPoints > timeLimitRace.GetGoldTime() + 15)
                {
                    title = "Bronze";
                    money = timeLimitRace.PrizePool * 30/100;
                }
                var participant = race.Participants.First();
                sb.Append(Environment.NewLine + participant.Brand + " " + participant.Model + " - " + timeLimitPoints +
                          " s.")
                    .Append(Environment.NewLine + title + " Time, $" + money);
                break;
            case "Circuit":

                break;
            case "CasualRace":
                int num = 1;
                int firstPlace = 50;
                int secindPlace = 30;
                int thirdPlace = 20;
            
                foreach (var car in race.Participants.OrderByDescending(c => c.Horsepower / c.Acceleration + c.Suspension + c.Durability).Take(3))
                {
                    int points = car.Horsepower / car.Acceleration + car.Suspension + car.Durability;
                    sb.Append(Environment.NewLine+ num + ". " + car.Brand + " " + car.Model + " " + points + "PP - $" +
                              race.PrizePool * firstPlace / 100);
                    num++;
                    firstPlace = secindPlace;
                    secindPlace = thirdPlace;
                }
                id_Race.Remove(id);
              
                break;
            case "DragRace":
                int n = 1;
                int first = 50;
                int second = 30;
                int third = 20;
                foreach (var car in race.Participants.OrderByDescending(c=>c.Horsepower/c.Acceleration).Take(3))
                {
                    int p = car.Horsepower / car.Acceleration;
                    sb.Append("\r\n"+ n + ". " + car.Brand + " " + car.Model + " " + p + "PP - $" +
                              race.PrizePool * first / 100);
                    n++;
                    first = second;
                    second = third;
                    
                    
                }
                id_Race.Remove(id);
                break;
            case "DriftRace":
                int pos = 1;
                int firstDrft = 50;
                int secondDrift = 30;
                int thirdDrift = 20;
                foreach (var car in race.Participants.OrderByDescending(c => c.Suspension+c.Durability).Take(3))
                {
                    int p = car.Suspension + car.Durability;
                    sb.Append("\r\n" + pos + ". " + car.Brand + " " + car.Model + " " + p + "PP - $" +
                              race.PrizePool * firstDrft / 100);
                    pos++;
                    firstDrft = secondDrift;
                    secondDrift = thirdDrift;


                }
                id_Race.Remove(id);
                break;
        }
         return sb.ToString();

    }

    public  void Park(int id)
    {
      
        var car = id_Car.FirstOrDefault(i => i.Key == id).Value;
        bool haveCarInRace = false;//Check is there such car in any open Race
        foreach (var r in id_Race)
        {
            if (r.Value.Participants.Contains(car))
            {
                haveCarInRace = true;
            }
        }
        if (haveCarInRace==false)
        {
            garage.AddToGarage(id, car);//Add to garage if the car is not in Race
        }
       
    }

    public  void Unpark(int id)
    {
        var car = id_Car.FirstOrDefault(c => c.Key == id).Value;
        if (car!=null)//check is there such car in garage
        {
            garage.RemoveFromGarage(id);
        }
        
    }

    public  void Tune(int tuneIndex, string addOn)
    {
        if (garage.ParkedCars.Count!=0)
        {
            garage.TuneCars(tuneIndex, addOn);
        }
        
    }
}

