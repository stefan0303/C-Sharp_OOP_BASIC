using System;
using System.Collections.Generic;

public class Student
{
    public static HashSet<string> uniqueNames;
    public string name;

    public Student(string name)
    {
        this.name = name;
    }
    static Student()
    {
        uniqueNames = new HashSet<string>();
    }
}

class Program
{
    static void Main()
    {
        string names = Console.ReadLine();

        while (names != "End")
        {

            Student name = new Student(names);
            Student.uniqueNames.Add(names);
            names = Console.ReadLine();
            if (names == "End")
            {
                Console.WriteLine(Student.uniqueNames.Count);
                Student n = new Student(names);
            }
        }
    }
}

