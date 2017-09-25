using System;
using System.Collections.Generic;
using System.Linq;

 class Program
{
    static void Main()
    {
        List<Trainer> trainers = new List<Trainer>();
        string[] input = Console.ReadLine().Split(' ').ToArray();
        while (input[0] != "Tournament")
        {
            string trainerName = input[0];
            string pockemonName = input[1];
            string pockemonElementh = input[2];
            int pockemonHealth = int.Parse(input[3]);

            var tra = trainers.Any(t => t.name == trainerName);
            if (!tra)//there is no trainer with that name we make new trainer
            {
                Trainer trainer = new Trainer
                {
                    Name = trainerName,
                    Badges = 0,
                    ListOfPokemons = new List<Pokemon>()
                };
                Pokemon pokemon = new Pokemon
                {
                    Name = pockemonName,
                    Element = pockemonElementh,
                    Health = pockemonHealth
                };
                   
                trainer.pokemons.Add(pokemon);
                trainers.Add(trainer);
            }
            else//there is trainer in list of trainers
            {
                Pokemon pokemon = new Pokemon
                {
                    Name = pockemonName,
                    Element = pockemonElementh,
                    Health = pockemonHealth
                };
                trainers.FirstOrDefault(t => t.name == trainerName).pokemons.Add(pokemon);
            }
            input = Console.ReadLine().Split(' ').ToArray();
        }
        string command = Console.ReadLine();
        while (command != "End")
        {
            if (command=="Fire"||command== "Electricity"||command=="Water")
            {
                foreach (var tra in trainers)
                {
                    if (tra.pokemons.Any(p => p.Element == command))
                    {
                        tra.badges += 1;
                    }
                    else
                    {
                        foreach (var pokemon in tra.pokemons)
                        {
                            pokemon.Health -= 10;
                            if (pokemon.Health <= 0)
                            {
                                tra.pokemons.Remove(pokemon);
                                break;
                            }
                        }
                    }
                }
            }
            command = Console.ReadLine();
        }
        var output = trainers.OrderByDescending(t => t.badges);
        foreach (var tra in output)
        {
            Console.WriteLine(tra.name +" "+tra.badges+" "+tra.pokemons.Count);
        }
    }
}

class Trainer
{
    public string name;
    public int badges;//start with 0
    public List<Pokemon> pokemons;

    public string Name { get { return this.name; } set { this.name = value; } }
    public int Badges { get { return this.badges; } set { this.badges = value; } }
    public List<Pokemon> ListOfPokemons { get { return this.pokemons; } set { this.pokemons = value; } }

}

public class Pokemon
{
    private string name;
    private int health;

    public string Name
    {
        get
        {
            return this.name;
        }
        set
        {
            this.name = value;
        }
    }

    public string Element { get; set; }

    public int Health { get { return this.health; } set { this.health = value; } }
}