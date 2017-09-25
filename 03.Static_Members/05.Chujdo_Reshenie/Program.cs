using System;
using System.Collections.Generic;


public class AnimalClinic
{
    public static int patientId = 0;
    public static int healedAnimalsCount = 0;
    public static int rehabilitedAnimalsCount = 0;
}
public class Animal
{
    public string name;
    public string breed;

    public Animal(string name, string breed)
    {
        this.name = name;
        this.breed = breed;
    }
}
class Program
{
    static void Main(string[] args)
    {
        List<Animal> healedAnimals = new List<Animal>();
        List<Animal> rehabilitedAnimals = new List<Animal>();

        string command = Console.ReadLine();

        while (command != "End")
        {
            string[] tokens = command.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);

            string name = tokens[0];
            string breed = tokens[1];
            string procedure = tokens[2];

            Animal animal = new Animal(name, breed);
            switch (procedure)
            {
                case "heal":
                    healedAnimals.Add(animal);
                    AnimalClinic.healedAnimalsCount++;
                    Console.WriteLine("Patient {0}: [{1} ({2})] has been healed!", ++AnimalClinic.patientId, animal.name, animal.breed);
                    break;
                case "rehabilitate":
                    rehabilitedAnimals.Add(animal);
                    AnimalClinic.rehabilitedAnimalsCount++;
                    Console.WriteLine("Patient {0}: [{1} ({2})] has been rehabilitated!", ++AnimalClinic.patientId, animal.name, animal.breed);
                    break;
            }
            command = Console.ReadLine();
        }

        Console.WriteLine("Total healed animals: {0}", AnimalClinic.healedAnimalsCount);
        Console.WriteLine("Total rehabilitated animals: {0}", AnimalClinic.rehabilitedAnimalsCount);

        command = Console.ReadLine();
        switch (command)
        {
            case "heal":
                foreach (Animal animal in healedAnimals)
                {
                    Console.WriteLine("{0} {1}", animal.name, animal.breed);
                }
                break;
            case "rehabilitate":
                foreach (Animal animal in rehabilitedAnimals)
                {
                    Console.WriteLine("{0} {1}", animal.name, animal.breed);
                }
                break;
        }
    }

}