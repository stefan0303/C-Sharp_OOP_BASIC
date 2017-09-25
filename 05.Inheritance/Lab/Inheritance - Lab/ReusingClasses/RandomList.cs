using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class RandomList: ArrayList
{

  
    private Random rnd; //TODO: Add ctor

    public RandomList()
    {
       this.rnd=new Random();
    }
    public object RandomString(List<string> data)
    {
        int element = rnd.Next(0, data.Count - 1);
        string str = data[element];
        data.Remove(str);
        return str;
    }
}




