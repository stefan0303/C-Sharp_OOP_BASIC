using System.Collections.Generic;

public abstract class Race
{
    private int length;
    private string route;
    private int prizePool;
    private List<Car> participants;

    public Race(int length, string route, int prizePool)
    {
        this.Length = length;
        this.Route = route;
        this.PrizePool = prizePool;
        this.Participants = new List<Car>();
    }

    public int Length
    {
        get { return length; }
        set { length = value; }
    }

    public string Route
    {
        get { return route; }
        set { route = value; }
    }

    public int PrizePool
    {
        get { return prizePool; }
        set { prizePool = value; }
    }
    public List<Car> Participants
    {
        get { return participants; }
        set
        {

            this.participants = value;
        }
    }
    public void AddPartivipants(Car car)
    {

        this.participants.Add(car);
    }

    public virtual bool SearchCarsInRace(Car car)
    {
        foreach (var c in participants)
        {
            if (c == car)
            {
                return true;
            }
        }
        return false;
    }
}

