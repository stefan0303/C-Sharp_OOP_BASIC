using System.Collections.Generic;
using System.Linq;

public class Fibonacci
{
    public List<long> numbers;

    public Fibonacci()
    {
        this.numbers = new List<long>();
    }

    public List<long> GetNumbersInRange(int startPosition, int endPosition)
    {
        return this.numbers.Skip(startPosition).Take(endPosition - startPosition).ToList();
    }
}
