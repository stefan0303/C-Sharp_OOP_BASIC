using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

class Program
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
        List<Person> persons = new List<Person>();
        while (input[0] != "End")
        {
            string personName = input[0];
            if (!persons.Any(p => p.Name == personName))//there is no such person, we make a person
            {
                Person person = new Person();
                person.Name = input[0];
                person.Children = new List<Child>();
                person.Parents = new List<Parent>();
                person.Pokemons = new List<Pokemon>();  

                persons.Add(person);
            }
            switch (input[1])
            {
                case "company":
                    Company company = new Company
                    {
                        Name = input[2],
                        Department = input[3],
                        Salary = double.Parse(input[4])
                    };
                    persons.FirstOrDefault(p => p.Name == personName).Company = company;
                    break;
                case "pokemon":
                    Pokemon pokemon = new Pokemon
                    {
                        Name = input[2],
                        Type = input[3]
                    };
                    persons.FirstOrDefault(p => p.Name == personName).Pokemons.Add(pokemon);
                    break;
                case "parents":
                    Parent parent = new Parent
                    {
                        Name = input[2],
                        ParentBirhDate = DateTime.ParseExact(input[3], "dd/MM/yyyy", CultureInfo.InvariantCulture)
                    };
                    persons.FirstOrDefault(p => p.Name == personName).Parents.Add(parent);
                    break;
                case "children":
                    Child child = new Child
                    {
                        Name = input[2],
                        ChildBirthDate = DateTime.ParseExact(input[3], "dd/MM/yyyy", CultureInfo.InvariantCulture)
                    };
                    persons.FirstOrDefault(p => p.Name == personName).Children.Add(child);
                    break;
                case "car":
                    Car car = new Car
                    {
                        Model = input[2],
                        CarSpeed = int.Parse(input[3])
                    };
                    persons.FirstOrDefault(p => p.Name == personName).Car = car;
                    break;
            }

            input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
        }
        string findPerson = Console.ReadLine().Trim();

        Person per = persons.FirstOrDefault(p => p.Name == findPerson);
        Console.WriteLine(per.Name);
        Console.WriteLine("Company:");
        if (per.Company != null)
        {
            Console.WriteLine(per.Company?.Name + " " + per.Company?.Department +
                              $" {per.Company?.Salary:f2}");
        }

        Console.WriteLine("Car:");
        if (per.Car != null)
        {
            Console.WriteLine(per.Car?.Model + " " + per.Car?.CarSpeed);
        }

        Console.WriteLine("Pokemon:");
        foreach (var pokemon in per.Pokemons)
        {
            Console.WriteLine(pokemon.Name + " " + pokemon.Type);
        }
        Console.WriteLine("Parents:");
        foreach (var pokemon in per.Parents)
        {
            Console.WriteLine(pokemon.Name + " " + pokemon.ParentBirhDate.ToString("dd/MM/yyyy"));
        }
        Console.WriteLine("Children:");
        foreach (var pokemon in per.Children)
        {
            Console.WriteLine(pokemon.Name + " " + pokemon.ChildBirthDate.ToString("dd/MM/yyyy"));
        }
    }

    public static string ToString(List<Person> persons, Person person)
    {
        Person findperson = persons.FirstOrDefault(p => p.Name == person.Name);
        StringBuilder sb = new StringBuilder();
        sb.Append(findperson.Name + "\n")
            .Append("Company:\n")
            .Append(findperson.Company?.Name + " " + findperson.Company?.Department +
             $" {findperson.Company?.Salary:f2}")
            .Append("Car:\n")
            .Append(findperson.Car?.Model + " " + findperson.Car?.CarSpeed + "\n")
            .Append("Pokemon:");
        foreach (var pokemon in findperson.Pokemons)
        {
            sb.Append("\n" + pokemon.Name + " " + pokemon.Type);

        }
        sb.Append("\nParents:");
        foreach (var parent in findperson.Parents)
        {
            sb.Append("\n" + parent.Name + " " + parent.ParentBirhDate.ToString("dd/MM/yyyy"));

        }
        sb.Append("\nChildren:");
        foreach (var child in findperson.Children)
        {
            sb.Append("\n" + child.Name + " " + child.ChildBirthDate.ToString("dd/MM/yyyy"));
        }
        return sb.ToString();
    }
}


