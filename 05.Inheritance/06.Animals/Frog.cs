﻿using System;

namespace _06.Animals.Animals
{
    class Frog : Animal
    {
        public Frog(string name, int age, string gender) : base(name, age, gender)
        {

        }
        public override void ProduceSound()
        {
            Console.WriteLine("Frogggg");
        }
    }
}
