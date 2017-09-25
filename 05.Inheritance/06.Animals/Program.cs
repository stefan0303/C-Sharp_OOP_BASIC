using System;
using System.Linq;
using _06.Animals.Animals;

class Program
{
    static void Main(string[] args)
    {
        string typeOfAnymal = Console.ReadLine();
        string[] input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
        while (typeOfAnymal != "Beast!")
        {

            string name = input[0];
            int age = int.Parse(input[1]);
            string gender = input[2];

            try
            {
                Animal animal = null;
                switch (typeOfAnymal)
                {
                    case "Dog":

                        animal = new Dog(name, age, gender);
                        //Console.WriteLine("Dog");
                        //Console.WriteLine(dog.Name + " " + dog.Age + " " + dog.Gender);
                        
                        break;
                    case "Cat":

                        animal  = new Cat(name, age, gender);
                        //Console.WriteLine("Cat");
                        //Console.WriteLine(cat.Name + " " + cat.Age + " " + cat.Gender);
                        //cat.ProduceSound();
                        break;
                    case "Frog":

                        animal = new Frog(name, age, gender);
                        //Console.WriteLine("Frog");
                        //Console.WriteLine(frog.Name + " " + frog.Age + " " + frog.Gender);

                        //frog.ProduceSound();

                        break;
                    case "Kitten":

                        animal = new Kitten(name, age);
                        //Console.WriteLine("Cat");
                        //Console.WriteLine(kitten.Name + " " + kitten.Age + " " + kitten.Gender);

                        //kitten.ProduceSound();
                        break;
                    case "Tomcat":

                        animal= new Tomcat(name, age);
                        //Console.WriteLine("Cat");
                        //Console.WriteLine(tomCat.Name + " " + tomCat.Age + " " + tomCat.Gender);

                        //tomCat.ProduceSound();
                        break;
                    default:
                        throw new ArgumentException("Invalid input!");
                   
                       

                }
                Console.WriteLine(typeOfAnymal);
                Console.WriteLine(animal.ToString());
                animal.ProduceSound();
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }
            typeOfAnymal = Console.ReadLine();
            if (typeOfAnymal == "Beast!")
            {
                break;
            }
            input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
        }
      

    }
}

