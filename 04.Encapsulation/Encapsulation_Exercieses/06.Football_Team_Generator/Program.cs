using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        string command = Console.ReadLine();
        List<Team> teams = new List<Team>();
        while (command != "END")
        {
            string[] tokens = command.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            switch (tokens[0])
            {
                case "Team": teams.Add(new Team(tokens[1])); break;
                case "Add":
                    string teamName = tokens[1];
                    string playerName = tokens[2];
                    int endurance = int.Parse(tokens[3]);
                    int sprint = int.Parse(tokens[4]);
                    int dribble = int.Parse(tokens[5]);
                    int passing = int.Parse(tokens[6]);
                    int shooting = int.Parse(tokens[7]);

                    bool teamExists = teams.Any(t => t.Name == teamName);
                    Team team;
                    if (!teamExists)
                    {
                        Console.WriteLine("Team {0} does not exist.", teamName);
                    }
                    else
                    {
                        try
                        {
                            team = teams.Where(t => t.Name == teamName).First();
                            Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);
                            team.AddPlayer(player);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    break;
                case "Remove":
                    teamName = tokens[1];
                    team = teams.Where(t => t.Name == teamName).First();
                    playerName = tokens[2];
                    try
                    {
                        team.RemovePlayer(playerName);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                case "Rating":
                    teamName = tokens[1];
                    teamExists = teams.Any(t => t.Name == teamName);
                    if (!teamExists)
                    {
                        Console.WriteLine("Team {0} does not exist.", teamName);
                    }
                    else
                    {
                        team = teams.Where(t => t.Name == teamName).First();
                        Console.WriteLine("{0} - {1}", team.Name, team.Rating());
                    }
                    break;
            }

            command = Console.ReadLine();
        }
    }
}

public class Team
{
    private string name;
    private List<Player> players;

    public Team(string name)
    {
        this.Name = name;
        this.players = new List<Player>();
    }

    public string Name
    {
        get { return this.name; }

        set
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("A name should not be empty.");
            }
            this.name = value;
        }
    }

    public int Rating()
    {
        if (this.players.Count == 0)
        {
            return 0;
        }
        return (int)Math.Round(this.players.Select(p => p.Skill()).Sum() / (double)this.players.Count);
    }

    public void AddPlayer(Player player)
    {
        this.players.Add(player);
    }

    public void RemovePlayer(string playerName)
    {
        bool containsPlayer = this.players.Any(p => p.Name == playerName);
        if (!containsPlayer)
        {
            throw new ArgumentException(string.Format("Player {0} is not in {1} team.", playerName, this.Name));
        }
        Player player = this.players.Where(p => p.Name == playerName).First();
        this.players.Remove(player);
    }
}

public class Player
{
    private string name;
    private int endurance;
    private int sprint;
    private int dribble;
    private int passing;
    private int shooting;

    public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
    {
        this.Name = name;
        this.Endurance = endurance;
        this.Sprint = sprint;
        this.Dribble = dribble;
        this.Passing = passing;
        this.Shooting = shooting;
    }

    public string Name
    {
        get { return this.name; }

        set
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("A name should not be empty.");
            }
            this.name = value;
        }
    }

    public int Endurance
    {
        get { return this.endurance; }

        private set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException("Endurance should be between 0 and 100.");
            }
            this.endurance = value;
        }
    }

    public int Sprint
    {
        get { return this.sprint; }

        private set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException("Sprint should be between 0 and 100.");
            }
            this.sprint = value;
        }
    }

    public int Dribble
    {
        get { return this.dribble; }

        private set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException("Dribble should be between 0 and 100.");
            }
            this.dribble = value;
        }
    }

    public int Passing
    {
        get { return this.passing; }

        private set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException("Passing should be between 0 and 100.");
            }
            this.passing = value;
        }
    }

    public int Shooting
    {
        get { return this.shooting; }

        private set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException("Shooting should be between 0 and 100.");
            }
            this.shooting = value;
        }
    }

    public int Skill()
    {
        return
            (int)Math.Round((this.passing + this.shooting + this.sprint + this.dribble + this.endurance) / 5.0);
    }
}


