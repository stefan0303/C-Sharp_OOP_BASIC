using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
           // string pattern = "^[a-zA-Z0-9]+$";
           //Regex regex =new Regex(pattern);
           // string input = "aasg214dwfac213";
           
           // if (regex.IsMatch(input))
           // {
           //     Console.WriteLine("Match");
           // }
           // else
           // {
           //     Console.WriteLine("Not Match");
           // }
            int m = 150;
            m = m - m * 75 / 100;
            Console.WriteLine(m);
        }
    }
}
