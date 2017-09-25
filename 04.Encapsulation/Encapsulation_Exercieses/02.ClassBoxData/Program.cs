using System;
using System.Linq;
using System.Reflection;

class Box
{
    private double length;
    private double width;
    private double height;

    public Box(double length, double width, double height)
    {
        this.Length = length;
        this.Width = width;
        this.Height = height;
    }

    public double Length
    {
        get
        {
            return this.length;
        }

        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Length cannot be zero or negative.");
            }
            this.length = value;
        }
    }

    public double Width
    {
        get
        {
            return this.width;
        }

        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Width cannot be zero or negative.");
            }
            this.width = value;
        }
    }

    public double Height
    {
        get
        {
            return this.height;
        }

        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Height cannot be zero or negative.");
            }
            this.height = value;
        }
    }

    public double GetVolume()
    {
        return this.Length * this.Width * this.Height;
    }

    public double GetLateralSurfaceArea()
    {
        return this.Length * this.Height * 2 + this.Width * this.Height * 2;
    }

    public double GetSurfaceArea()
    {
        return 2 * this.Length * this.Width + 2 * this.Length * this.Height + 2 * this.Width * this.Height;
    }
}

class Program
{
    static void Main()
    {
        try
        {
            Type boxType = typeof(Box);
            FieldInfo[] fields = boxType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            Console.WriteLine(fields.Count());

            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            Box box = new Box(length, width, height);

            Console.WriteLine("Surface Area - {0:F2}", box.GetSurfaceArea());
            Console.WriteLine("Lateral Surface Area - {0:F2}", box.GetLateralSurfaceArea());
            Console.WriteLine("Volume - {0:F2}", box.GetVolume());

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
