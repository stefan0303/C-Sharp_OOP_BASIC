using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class MathOperations
{
    public int Add(int numOne, int numTwo)
    {
        return numOne + numTwo;
    }
    public double Add(double numOne, double numTwo, double c)
    {
        return numOne + numTwo + c;
    }
    public decimal Add(decimal numOne, decimal numTwo, decimal c)
    {
        return (numOne + numTwo + c);
    }
}


