
public abstract class Food
{

    private double quantity;
    private string type;

    protected Food(double quantity, string type)
    {
        this.SetQuantity(quantity);
        this.SetType(type);
    }

    public double GetQuantity()
    {
        return this.quantity;
    }

    private void SetQuantity(double quantity)
    {
        this.quantity = quantity;
    }

    public string GetType()
    {
        return this.type;
    }

    private void SetType(string type)
    {
        this.type = type;
    }
}

