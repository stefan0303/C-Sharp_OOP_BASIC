using System;

class Kitten:Cat //female
{
    public Kitten(string name, int age) : base(name, age,"Female")
    {
       
    }
    public override void ProduceSound()
    {
        Console.WriteLine("Miau");
    }
}

