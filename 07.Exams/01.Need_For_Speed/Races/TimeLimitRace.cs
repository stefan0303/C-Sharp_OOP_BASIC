
class TimeLimitRace : Race
{
    private int goldTime;

    public TimeLimitRace(int length, string route, int prizePool, int goldTime)
    : base(length, route, prizePool)
    {
        this.GoldTime = goldTime;

    }

    public int GoldTime
    {
        get { return this.goldTime; }
        set { this.goldTime = value; }
    }

    public int GetGoldTime()
    {
        return this.GoldTime;
    }
}

