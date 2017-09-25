using System.Collections.Generic;

 public  class Garage
   {
       private Dictionary<int,Car> parkedCars;

    public Garage()
    {
        this.ParkedCars = new Dictionary<int, Car>() ;

    }
    public Dictionary<int, Car> ParkedCars
    {
        get { return parkedCars; }
        set { parkedCars = value; }
    }
    public bool CheckIsThereSuchCarInGarage(int carId,Car car)
    {
        if (parkedCars.ContainsKey(carId))
        {
            return false;
        }
        return true;
    }

    public void AddToGarage(int idCar,Car car)
    {
       parkedCars.Add(idCar,car);
    }
    public void RemoveFromGarage(int idCar)
    {
        this.parkedCars.Remove(idCar);
    }

    public void TuneCars(int tuneIndex, string addOn)
    {

        foreach (var car in parkedCars)
        {
            car.Value.Horsepower += tuneIndex;
            car.Value.Suspension += tuneIndex / 2;
            
            if (car.Value.GetType().ToString()== "PerformanceCar")
            {
                PerformanceCar perf = (PerformanceCar)car.Value;//cast
                perf.AddOns.Add(addOn);
               
            }
            else//Show Car
            {
                ShowCar showCar = (ShowCar)car.Value;
                showCar.Stars += tuneIndex;
            }
           
        }
    
    }
}

