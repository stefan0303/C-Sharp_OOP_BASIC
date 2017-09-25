using System;
using System.Reflection;

public class Person
{
    public string name;
    public int age;

    public Person(string name, int age)
    {
        this.name=name;
        this.age = age;
    }
}
    class Program
    {
    static void Main()
    {
        Type personType = typeof(Person);
        FieldInfo[] fields = personType.GetFields(BindingFlags.Public | BindingFlags.Instance);//Reflection
        Console.WriteLine(fields.Length);
    }

}

