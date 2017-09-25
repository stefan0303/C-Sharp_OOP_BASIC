using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class Program
    {
        static void Main(string[] args)
        {
            Generix<string> name = new Generix<string>();
            name.Add("5");
            Console.WriteLine(name.ToString());
        }
    }

public class Generix<T>
{
    public void Add(T element)
    {
        
    }

    public override string ToString()
    {
        return GetType().FullName;
    }
}

