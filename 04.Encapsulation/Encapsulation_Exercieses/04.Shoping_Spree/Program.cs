using System;
using System.Collections.Generic;
using System.Linq;

class Person
{
    private string name;
    private decimal money;
    private List<Product> bagProducts;
    public Person(string name, decimal money)
    {
        this.Name = name;
        this.Money = money;
        this.bagProducts = new List<Product>();
    }
    public string Name
    {
        get
        {
            return this.name;
        }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be empty");
            }
            this.name = value;
        }
    }
    public decimal Money
    {
        get
        {
            return this.money;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }
            this.money = value;
        }

    }
    public void BuyProduct(Product product) //One Person buys One Product!
    {
        if (product.Cost > this.money)
        {
            throw new InvalidOperationException(string.Format("{0} can't afford {1}", this.Name, product.ProductName));
        }
        this.Money -= product.Cost;//Namaliave parite sled pokupka
        this.bagProducts.Add(product);
    }
    public void AddProductToBag(Product product)
    {
        this.bagProducts.Add(product); //advame producti v koshnicata(Lista bagProducts)
    }
    public List<Product> SeeBag() //vijdame koshnicata 
    {
        return this.bagProducts; //vrushtame koshnicata
    }
}
class Product
{
    private string productName;
    private decimal cost;
    public Product(string productName, decimal cost)//Constructor
    {
        this.ProductName = productName;
        this.Cost = cost;

    }
    public string ProductName
    {
        get
        {
            return this.productName;
        }
        private set
        {
            // if (productName.Length < 1)
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be empty");
            }
            this.productName = value;
        }
    }
    public decimal Cost
    {
        get
        {
            return this.cost;
        }
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }
            this.cost = value;
        }
    }
}
class Program
{
    static void Main()
    {
        List<Person> people = new List<Person>();
        string[] peopleAndMoney = Console.ReadLine().Split(new char[] { '=', ';' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

        for (int i = 0; i < peopleAndMoney.Length; i += 2)
        {
            string name = peopleAndMoney[i];
            decimal money = Convert.ToDecimal(peopleAndMoney[i + 1]);
            try  //Ako persona se povtaria i niama pari
            {
                Person person = new Person(name, money);
                people.Add(person);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
                return; //Escape from Program
            }

        }

        string[] productAndPrice = Console.ReadLine().Split(new char[] { '=', ';' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
        List<Product> productPrice = new List<Product>();
        for (int i = 0; i < productAndPrice.Length; i += 2) //Make Product List
        {
            string product = productAndPrice[i];
            decimal cost = Convert.ToDecimal(productAndPrice[i + 1]);
            try
            {
                Product products = new Product(product, cost);
                productPrice.Add(new Product(product, cost));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

        }
        string[] command = Console.ReadLine().Split(new char[0], StringSplitOptions.RemoveEmptyEntries).ToArray();
        while (command[0] != "END") //Commands for buy products by name
        {
            string personsName = command[0];
            string productName = command[1];
            Person person = people.Where(p => p.Name == personsName).First();
            Product product = productPrice.Where(p => p.ProductName == productName).First();

            if (person.Money >= product.Cost)//have money for product
            {
                person.Money -= product.Cost;
                person.AddProductToBag(product);
                Console.WriteLine("{0} bought {1}", person.Name, product.ProductName);
            }
            else // no money for product
            {
                Console.WriteLine("{0} can't afford {1}", person.Name, product.ProductName);
            }
            command = Console.ReadLine().Split().ToArray();
        }


        foreach (Person person in people)
        {
            if (person.SeeBag().Count > 0)
            {
                //Select all products by Name               
                Console.WriteLine("{0} - {1}", person.Name, String.Join(", ", person.SeeBag().Select(p => p.ProductName)));
            }
            else
            {
                Console.WriteLine("{0} - Nothing bought", person.Name);
            }
        }
    }
}

