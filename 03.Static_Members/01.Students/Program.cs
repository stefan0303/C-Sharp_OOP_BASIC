using System;

public class Student
{
    static int numberStudents = 0;
    public Student(string name)
    {
        if (name == "End")
        {
            Console.WriteLine(numberStudents);

        }
        numberStudents++;
    }
}
class Program
{
    static void Main()
    {
        string names = Console.ReadLine();
        while (names != "End")
        {

            Student name = new Student(names);
            names = Console.ReadLine();
            if (names == "End")
            {
                Student n = new Student(names);
            }
        }

    }
}


