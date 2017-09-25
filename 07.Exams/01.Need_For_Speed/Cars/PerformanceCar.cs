using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



class PerformanceCar : Car
{
    private const int HorsepowerIncrease = 50;
    private const int SuspensionDecrease = 25;
    private List<string> addOns;
    public PerformanceCar(string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability)
        : base(brand, model, yearOfProduction, horsepower + (horsepower * HorsepowerIncrease) / 100, acceleration, suspension - (suspension * SuspensionDecrease) / 100, durability)
    {
        this.AddOns = new List<string>();
    }
    public List<string> AddOns
    {
        get { return addOns; }
        set { addOns = value; }
    }
    public void AddtoAddons(string addon)
    {
        addOns.Add(addon);
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(this.Brand + " " + this.Model + " " + this.YearOfProduction + "\r\n")
            .Append(this.Horsepower + " HP, 100 m/h in " + this.Acceleration+" s" + "\r\n")
            .Append(this.Suspension + " Suspension force, " + this.Durability + " Durability"+ "\r\n");
        if (addOns.Count==0)
        {
            sb.Append("Add-ons: None");
        }
        else
        {
            sb.Append("Add-ons: ");
            sb.Append(string.Join(", ", addOns));
           
        }
       
        return sb.ToString();
    }


}

