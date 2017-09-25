using System;
using System.Collections.Generic;
using System.Linq;

public class Department
{
    public Department(string name)
    {
        this.employees = new List<Employee>();
        this.Name = name;
    }
    public List<Employee> employees = new List<Employee>();
    public string Name { get; set; }
}

public class Employee
{
    public string Name;
    public decimal Salary;
    public string Position;
    public string Department;
    public string Email;  //optional //here you can make Email="n/a"
    public int Age;    //optional    //here you can make Age ="-1" and  
    //with email and age
    public Employee(string name, decimal salary, string position, string department, string email, int age)

    {
        this.Name = name;
        this.Salary = salary;
        this.Position = position;
        this.Department = department;
        this.Email = email;
        this.Age = age;
    }
    //without age and email //Chaining Optional
    public Employee(string name, decimal salary, string position, string department)
        : this(name, salary, position, department, "n/a", -1)
    {
        this.Name = name;
        this.Salary = salary;
        this.Position = position;
        this.Department = department;
    }

    //with only email /Chaining!!!
    public Employee(string name, decimal salary, string position, string department, string email)
        : this(name, salary, position, department, email, -1)
    {
        this.Name = name;
        this.Salary = salary;
        this.Position = position;
        this.Department = department;
        this.Email = email;

    }
    //with only age //Chaining
    public Employee(string name, decimal salary, string position, string department, int age)
        : this(name, salary, position, department, "n/a", age)
    {
        this.Name = name;
        this.Salary = salary;
        this.Position = position;
        this.Department = department;
        this.Age = age;
    }
}
public class Program
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        var employees = new List<Employee>();
        List<Department> departments = new List<Department>();
        for (int i = 0; i < n; i++)
        {
            string[] employeesInfo = Console.ReadLine().Split(' ').ToArray();

            if (!departments.Exists(d => d.Name == employeesInfo[3]))
            {
                Department department = new Department(employeesInfo[3]);
                department.employees = new List<Employee>();
                departments.Add(department);
            }
            if (employeesInfo.Length == 4)
            {
                var employee = new Employee(employeesInfo[0],
                    decimal.Parse(employeesInfo[1]),
                    employeesInfo[2],
                    employeesInfo[3]);
                employees.Add(employee);
            }

            else if (employeesInfo.Length == 5)
            {
                int m;
                bool isNumeric = int.TryParse(employeesInfo[4], out m);
                if (employeesInfo[4].Contains("@") && isNumeric == false)//have only email
                {
                    var employee = new Employee(employeesInfo[0],
                        decimal.Parse(employeesInfo[1]),
                        employeesInfo[2],
                        employeesInfo[3],
                        employeesInfo[4]);
                    employees.Add(employee);
                }
                else //have only age
                {
                    var employee = new Employee(employeesInfo[0],
                        decimal.Parse(employeesInfo[1]),
                        employeesInfo[2],
                        employeesInfo[3], int.Parse(employeesInfo[4]));
                    employees.Add(employee);
                }
            }
            else if (employeesInfo.Length == 6)
            {
                var employee = new Employee(employeesInfo[0],
                    decimal.Parse(employeesInfo[1]),
                    employeesInfo[2],
                    employeesInfo[3],
                    employeesInfo[4], int.Parse(employeesInfo[5]));
                employees.Add(employee);
            }

        }


        var result = employees.GroupBy(e => e.Department)
            .Select(e => new
            {
                Department = e.Key,
                AverageSalary = e.Average(emp => emp.Salary),//anonymous object
                employees = e.OrderByDescending(emp => emp.Salary),
                Employee = e.OrderByDescending(emp => emp.Salary)
            })
            .OrderByDescending(dep => dep.AverageSalary).FirstOrDefault();


        Console.WriteLine("Highest Average Salary: " + result.Department);
        foreach (var e in result.employees)
        {
            Console.WriteLine("{0} {1:f2} {2} {3}", e.Name, e.Salary, e.Email, e.Age);
        }
    }
}


