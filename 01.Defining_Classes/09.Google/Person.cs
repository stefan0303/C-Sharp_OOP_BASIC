using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;



class Person
{
    private string name;
    private Company company;
    private Car car;
    private List<Parent> parents;
    private List<Child> children;
    private List<Pokemon> pokemons;

  
    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    public Company Company { get; set; }
    public Car Car { get; set; }
    public List<Parent> Parents { get; set; }
    public List<Child> Children { get; set; }
    public List<Pokemon> Pokemons { get; set; }
}

