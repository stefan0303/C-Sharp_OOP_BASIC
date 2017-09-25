using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

class Program
{
    static void Main()
    {

        MethodInfo[] methods = typeof(Pizza).GetMethods();
        bool containsMethod = methods.Any(m => m.ReturnType.Name.Contains("SortedDictionary"));
        if (!containsMethod)
        {
            throw new Exception();
        }

        SortedDictionary<int, List<string>> dictionary = Pizza.Pizzas(Console.ReadLine().Split(new char[0], StringSplitOptions.RemoveEmptyEntries));

        foreach (var pair in dictionary)
        {
            Console.WriteLine("{0} - {1}", pair.Key, string.Join(", ", pair.Value));
        }
    }
}
