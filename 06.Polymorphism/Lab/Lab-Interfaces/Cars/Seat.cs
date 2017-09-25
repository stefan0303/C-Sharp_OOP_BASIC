using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


  
        public class Seat : ICar
        {
            public string Model { get; }
            public string Color { get; }

            public Seat(string model, string color)
            {
                this.Model = model;
                this.Color = color;
            }

            public string Stop()
            {
                return "Breaaak!";
            }

            public string Start()
            {
                return "Engine start";
            }

            public override string ToString()
            {
                return $"{this.Color} Seat {this.Model}";
            }

   
}


