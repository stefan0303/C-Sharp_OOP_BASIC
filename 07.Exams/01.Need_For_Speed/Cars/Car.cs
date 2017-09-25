using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



public abstract class Car
    {
        private string brand;
        private string model;
        private int yearOfProduction;
        private int horsepower;
        private int acceleration;
        private int suspension;
        private int durability;

    public Car(string brand, string model, int yearOfProduction, int horsepower,
            int acceleration, int suspension, int durability)
    {
            this.Brand = brand;
            this.Model = model;
            this.YearOfProduction = yearOfProduction;
            this.Horsepower = horsepower;
            this.Acceleration = acceleration;
            this.Suspension = suspension;
            this.Durability = durability;
        }
        public string Brand
        {
            get { return brand; }
            set { brand = value; }
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public int YearOfProduction
        {
            get { return yearOfProduction; }
            set { yearOfProduction = value; }
        }

        public virtual int Horsepower
        {
            get { return horsepower; }
            set { horsepower = value; }
        }

        public int Acceleration
        {
            get { return acceleration; }
            set { acceleration = value; }
        }

        public virtual int Suspension
        {
            get { return suspension; }
            set { suspension = value; }
        }

        public int Durability
        {
            get { return durability; }
            set { durability = value; }
        }

    internal string GetType(Car car)
        {
            return car.brand;
        }

        //public virtual string TooString()
        //{
        //   StringBuilder sb =new StringBuilder();
        //    sb.Append(this.brand + " " + this.model + " " + this.yearOfProduction + "\n")
        //        .Append(this.horsepower + " HP, 100 m/h in " + this.acceleration + " s\n")
        //        .Append(this.suspension + " Suspension force, " + this.durability + " Durability");


        //    return sb.ToString();
        //}


       
    }

