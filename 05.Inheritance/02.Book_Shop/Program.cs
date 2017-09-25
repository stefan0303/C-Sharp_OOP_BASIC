using System;
using System.Linq;
using System.Text;

class Program
{
    static void Main()
    {
        try
        {
            string author = Console.ReadLine();
            string title = Console.ReadLine();
            double price = double.Parse(Console.ReadLine());

            Book book = new Book(author, title, price);
            GoldenEditionBook goldenEditionBook = new GoldenEditionBook(author, title, price);

            Console.WriteLine(book.ToString());
            Console.WriteLine(goldenEditionBook.ToString());
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine(ae.Message);
        }

    }
}

class GoldenEditionBook : Book
{
    public GoldenEditionBook(string author, string title, double price)
        : base(author, title, price)
    {

    }

    public override double Price => base.Price * 1.3;
}
class Book
{
    private string title;
    private string author;
    private double price;

    public Book(string author, string title, double price)
    {
        this.Title = title;
        this.Author = author;
        this.Price = price;
    }
    public virtual string Title
    {
        get { return this.title; }
        set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("Title not valid!");
            }
            this.title = value;
        }
    }

    public virtual string Author
    {
        get { return this.author; }
        set
        {
            string[] firstSecondName = value.Split(new char[0], StringSplitOptions.RemoveEmptyEntries).ToArray();
            char c = firstSecondName[1][0];
            if (char.IsDigit(c))
            {
                throw new ArgumentException("Author not valid!");
            }
            this.author = value;
        }
    }

    public virtual double Price
    {
        get { return this.price; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Price not valid");
            }
            this.price = value;
        }
    }
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("Type: ").Append(this.GetType().Name)
            .Append(Environment.NewLine)
            .Append("Title: ").Append(this.Title)
            .Append(Environment.NewLine)
            .Append("Author: ").Append(this.Author)
            .Append(Environment.NewLine)
            .Append(String.Format("Price: {0:F1}", this.Price))
            .Append(Environment.NewLine);

        return sb.ToString();
    }
}


