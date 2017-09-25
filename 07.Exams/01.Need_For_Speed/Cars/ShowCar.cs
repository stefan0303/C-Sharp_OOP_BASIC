using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class ShowCar : Car
{
    private int stars;
    public ShowCar(string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability, int stars=0)
        : base(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability)
    {
        this.Stars = 0;
    }
    public int Stars
    {
        get { return this.stars; }
        set { this.stars = value; }
    }
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(this.Brand + " " + this.Model + " " + this.YearOfProduction + "\r\n")
            .Append(this.Horsepower + " HP, 100 m/h in " + this.Acceleration + " s\r\n")
            .Append(this.Suspension + " Suspension force, " + this.Durability + " Durability\r\n")
            .Append(this.Stars + " *");
        return sb.ToString();
    }
  

    public void ChangeStars()
    {
        this.stars += 1;
    }
}
