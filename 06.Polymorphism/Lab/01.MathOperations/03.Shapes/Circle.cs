using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Circle : Shape
{
    private double radius;

   
    public Circle(double radius)
    {
        this.Radius = radius;
    }

    public double Radius
    {
        get {return this.radius; }
        set { this.radius = value; }
    }

    public override double CalculatePerimeter()
    {
        return this.Radius * Math.PI * 2;
    }

    public override double CalculateArea()
    {
        return Math.PI * this.Radius * this.Radius;
    }
    public sealed override string Draw()//sealed Modifier prevents other classes from inheriting from it

    {
        return base.Draw() + "Circle";
    }
}

