﻿using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        string command = Console.ReadLine();
        List<Person> persons = new List<Person>();

        while (command != "END")
        {
            string[] tokens = command.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            string name = tokens[0];
            int age = int.Parse(tokens[1]);
            string occupation = tokens[2];
            persons.Add(new Person(name, age, occupation));
            command = Console.ReadLine();
        }

        foreach (Person person in persons.OrderBy(p => p.age))
        {
            Console.WriteLine(person);
        }
    }
}
