﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class Cat:Animal
    {
        

        public Cat(string name, string favouriteFood) : base(name, favouriteFood)
        {

        }
    public override string ExplainMyself()
    {
        return $"I am {this.name} and my fovourite food is {this.favouriteFood}\nMEEOW";


    }
}

