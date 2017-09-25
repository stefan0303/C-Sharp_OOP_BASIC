using System;
using System.Reflection;

class Person
{
    public string name;
    public string SayHello;
    public Person(string name)
    {
        this.name = name;

        this.SayHello = name + " says \"Hello\"!";
    }
}

class Program
{
    static void Main()
    {
        Type personType = typeof(Person);
        FieldInfo[] fields = personType.GetFields(BindingFlags.Public | BindingFlags.Instance);
        MethodInfo[] methods = personType.GetMethods(BindingFlags.Public | BindingFlags.Instance);

        if (fields.Length != 1 || methods.Length != 5)
        {
            throw new Exception();
        }

        string personName = Console.ReadLine();
        Person person = new Person(personName);

        Console.WriteLine(person.SayHello);
    }
}


