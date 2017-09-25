using System;
using System.Collections.Generic;
using System.Linq;

public class Person
{
    private string name;
    private int age;

    public Person(string name, int age)
    {
        this.age = age;
        this.name = name;
    }
    public string Name
    {
        get { return this.name; }

    }
    public int Age
    {
        get { return this.age; }
    }
}
class PersonsClass
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var people = new List<Person>();
        for (int i = 1; i <= n; i++)
        {
            string[] personInfo = Console.ReadLine().Split().ToArray();
            Person person = new Person(personInfo[0], int.Parse(personInfo[1]));
            people.Add(person);
        }
        var result = people.Where(p => p.Age > 30).OrderBy(p => p.Name).ToList();
        Console.WriteLine();
        foreach (var item in result)
        {
            Console.WriteLine(item.Name + " - " + item.Age);
        }
    }
}
