using System;
using System.Collections.Generic;
using System.Linq;

class Animal
{
    public static int healedAnimals;
    public static int rehabilitatedAnimals;
    public static int overalPatients;
    static int id;
    public static List<string> healed = new List<string>();
    public static List<string> rehabilitared = new List<string>();

    public static int Animals(string name, string breed)
    {
        overalPatients += 1;
        return overalPatients;
    }
    public static int AnimalClinic(string treatment, string name, string breed)
    {
        id += 1;

        if (treatment == "heal")
        {
            Console.WriteLine("Patient {0}: [{1} ({2})] has been {3}ed!", id, name, breed, treatment);
            healed.Add(name + " " + breed);
            healedAnimals += 1;
        }
        else
        {
            Console.WriteLine("Patient {0}: [{1}({2})] has been {3}d!", id, name, breed, treatment);
            rehabilitared.Add(name + " " + breed);
            rehabilitatedAnimals += 1;
        }
        overalPatients += 1;
        return overalPatients;
    }
}
class Program
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split().ToArray();
        while (input[0] != "End")
        {
            Animal.Animals(input[0], input[1]);

            Animal.AnimalClinic(input[2], input[0], input[1]);

            input = Console.ReadLine().Split().ToArray();
        }
        Console.WriteLine("Total healed animals: {0}", Animal.healedAnimals);
        Console.WriteLine("Total rehabilitated animals: {0}", Animal.rehabilitatedAnimals);
        string treatment = Console.ReadLine();
        if (treatment == "heal")
        {
            foreach (var item in Animal.healed)
            {
                Console.WriteLine(item);
            }
        }
        else
        {
            foreach (var item in Animal.rehabilitared)
            {
                Console.WriteLine(item);
            }
        }
    }
}
