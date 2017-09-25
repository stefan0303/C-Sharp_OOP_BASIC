using System;
using System.Linq;

class StartUp
{
    static void Main()
    {
        string command = Console.ReadLine();
        string[] commands = command.Split(' ').ToArray();
        CarManager carManager =new CarManager();
        while (command != "Cops Are Here")
        {
            switch (commands[0])
            {
                case "register":
                    int id = int.Parse(commands[1]);
                    string type = commands[2];
                    string brand = commands[3];
                    string model = commands[4];
                    int yearOfProduction = int.Parse(commands[5]);
                    int horsepower = int.Parse(commands[6]);
                    int acceleration = int.Parse(commands[7]);
                    int suspension = int.Parse(commands[8]);
                    int durability = int.Parse(commands[9]);
                    carManager.Register(id, type, brand, model, yearOfProduction, horsepower, acceleration, suspension,
                        durability);
                    break;
                case "check":

                    Console.WriteLine(carManager.Check(int.Parse(commands[1])));

                    break;
                case "open":
                    carManager.Open(int.Parse(commands[1]), commands[2], int.Parse(commands[3]), commands[4], int.Parse(commands[5]));
                    break;
                case "participate":
                    carManager.Participate(int.Parse(commands[1]), int.Parse(commands[2]));//add car to Participents
                    
                    
                    break;
                case "start":
                    Console.WriteLine(carManager.Start(int.Parse(commands[1])));
                   break;
                case "park"://? 

                    carManager.Park(int.Parse(commands[1]));                                                         
                    break;
                
                case "unpark":
                    carManager.Unpark(int.Parse(commands[1]));
                    break;
                case "tune":

                    carManager.Tune(int.Parse(commands[1]), commands[2]);
                    break;
            }

            command = Console.ReadLine();
            commands = command.Split(' ').ToArray();
        }
    }
}

