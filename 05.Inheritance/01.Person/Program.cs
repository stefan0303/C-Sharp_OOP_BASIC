using System;
using System.Text;

class Program
{
    static void Main()
    {
        string name = Console.ReadLine();
        int age = int.Parse(Console.ReadLine());

        try
        {
            Child child = new Child(name, age);
            Console.WriteLine(child);
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine(ae.Message);
        }
    }

}

public class Child : Person//Inheritace
{
    public Child(string name, int age)
        : base(name, age)
    {

    }

    public override int Age
    {
        get { return base.Age; }
        set
        {
            if (value > 15)
            {
                throw new ArgumentException("Child's age must be less than 15!");
            }
            base.Age = value;
        }
    }
}

public class Person
{
    private int age; //Fields
    private string name;//Fields

    public Person(string name, int age) //constructor
    {
        this.Name = name;
        this.Age = age;
    }

    public virtual string Name //properties
    {
        get { return this.name; }
        set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("Name's length should not be less than 3 symbols!");
            }
            this.name = value;
        }
    }

    public virtual int Age//properties
    {
        get { return this.age; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Age must be positive!");
            }
            this.age = value;

        }
    }
    public override string ToString()//Method Override to String
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append(String.Format("Name: {0}, Age: {1}",
            this.Name,
            this.Age));

        return stringBuilder.ToString();
    }
}


