using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Tesla:ICar, IElectricCar
{
    public string Model { get; }
    public string Color { get; }
    public int Battery { get; }

    public Tesla(string model, string color, int batteries)
    {
        this.Model = model;
        this.Color = color;
        this.Battery = batteries;
    }

    public string Stop()
    {
        return "Engine start";
    }

    public string Start()
    {
        return "Breaaak!";
    }

    public override string ToString()
    {
        return $"{this.Color} Tesla {this.Model} with {this.Battery} Batteries";
    }
}

