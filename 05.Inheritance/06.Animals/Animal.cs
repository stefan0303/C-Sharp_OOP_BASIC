﻿using System;
using System.Text;

abstract class Animal:Sound
{
    private string name;
    private int age;
    private string gender;

    protected Animal(string name, int age,string gender)
    {
        this.Name = name;
        this.Age = age;
        this.Gender = gender;
    }

    public string Name
    {
        get { return name; }
        set
        {
            if (string.IsNullOrEmpty(value)||string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Invalid input!");
            }
          
            this.name = value;
        }
    }
    

    public int Age {
        get { return this.age; }
        set
        {
            
            if (value<0)
            {
                throw new ArgumentException("Invalid input!");
            }
            this.age = value;
        }
    }
    public string Gender {
        get { return gender; }
        set
        {
            if (value!="Male"&&value!="Female"||string.IsNullOrWhiteSpace(value)||string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Invalid input!");
            }
           
            this.gender = value;
        }
    }

    public abstract void ProduceSound();
    public override string ToString()
    {
       StringBuilder sb =new StringBuilder();
        
            sb.Append(this.Name + " " + this.Age + " " + this.Gender);

        return sb.ToString();
    }
}

