﻿
public class Person
{
    public string name;
    public int age;
    public string occupation;

    public Person(string name, int age, string occupation)
    {
        this.name = name;
        this.age = age;
        this.occupation = occupation;
    }

    public override string ToString()
    {
        return string.Format("{0} - age: {1}, occupation: {2}", this.name, this.age, this.occupation);
    }
}
