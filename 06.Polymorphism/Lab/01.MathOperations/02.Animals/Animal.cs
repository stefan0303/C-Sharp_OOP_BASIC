using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public abstract class Animal
{
    protected string name;
    protected string favouriteFood;

    protected Animal(string name, string favouriteFood)
    {
        this.name = name;
        this.favouriteFood = favouriteFood;
    }
    public virtual string ExplainMyself()
    {
        return "";
    }
}
