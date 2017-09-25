using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {

        List<Rectangle> listOfRectangle = new List<Rectangle>();
        List<string[]> listOfpairs = new List<string[]>();

        int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        int numberOfRectangles = input[0];
        int numberOfIntersectionChecks = input[1];

        for (int i = 0; i < numberOfRectangles; i++)
        {
            string[] args = Console.ReadLine().Split(' ');

            string id = args[0];
            double width = double.Parse(args[1]);
            double height = double.Parse(args[2]);
            double topLeftCornerX = double.Parse(args[3]);
            double topLeftCornerY = double.Parse(args[4]);

            Rectangle current = new Rectangle()
            {
                ID = id,
                Width = width,
                Height = height,
                TopLeftCornerX = topLeftCornerX,
                TopLeftCornerY = topLeftCornerY
            };

            listOfRectangle.Add(current);
        }

        for (int j = 0; j < numberOfIntersectionChecks; j++)
        {
            string[] pair = Console.ReadLine().Split(' ');
            listOfpairs.Add(pair);
        }

        Rectangle rc = new Rectangle();

        foreach (var pair in listOfpairs)
        {
            rc.IsIntersect(pair[0], pair[1], listOfRectangle);
        }
    }
}

public class Rectangle
{
    private string id;
    private double width;
    private double height;
    private double topLeftCornerX;
    private double topLeftCornerY;

    public string ID
    {
        get { return this.id; }
        set { this.id = value; }
    }

    public double Width
    {
        get { return this.width; }
        set { this.width = value; }
    }

    public double Height
    {
        get { return this.height; }
        set { this.height = value; }
    }

    public double TopLeftCornerX
    {
        get { return this.topLeftCornerX; }
        set { this.topLeftCornerX = value; }
    }

    public double TopLeftCornerY
    {
        get { return this.topLeftCornerY; }
        set { this.topLeftCornerY = value; }
    }

    public void IsIntersect(string rectangleName1, string rectangleName2, List<Rectangle> listOfRectangle)
    {
        Rectangle rectangle1 = listOfRectangle.Where(x => x.ID == rectangleName1).First();
        Rectangle rectangle2 = listOfRectangle.Where(x => x.ID == rectangleName2).First();

        double x1 = rectangle1.TopLeftCornerX;
        double x2 = rectangle2.TopLeftCornerX;
        double y1 = rectangle1.TopLeftCornerY;
        double y2 = rectangle2.TopLeftCornerY;
        double w1 = rectangle1.Width;
        double w2 = rectangle2.Width;
        double h1 = rectangle1.Height;
        double h2 = rectangle2.Height;

        if ((x1 + w1) < x2 || (x2 + w2) < x1 || (y1 + h1) < y2 || (y2 + h2) < y1)
        {
            Console.WriteLine("false");
        }
        else
        {
            Console.WriteLine("true");
        }
    }

}