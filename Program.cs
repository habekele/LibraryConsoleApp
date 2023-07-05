using System.Data;
using System.Linq;
using LibraryConsoleApp.Data;
using LibraryConsoleApp.Models;
using Microsoft.Data.SqlClient;

class Program
{
    static void Main(string[] args)
    {


        Book [] books = {
            new Book("Harry Potter","J.K. Rowling",19.99m,new DateTime(2005,04,23),GenreClass.Mystery), 
            new Book("Hunger Games","Suzanne Collins",29.99m,new DateTime(2012,02,11),GenreClass.Action), 
            new Book("Dune","Frank Hubert",9.99m,new DateTime(1965,07,25),GenreClass.SciFi),
        };



        Customer [] customers ={
            new Customer("Henok Bekele", "605-941-0157", "henokbekele1997@gmail.com"),
            new Customer("Trualem Johnson", "605-777-0123", "trujohnson@hotmail.com")
        };

        // Order [] orders ={
        //     new Order(customers[1],books[0],2),
        //     new Order(customers[0],books[2],3)
        // };




        DataContextEF entityframework = new DataContextEF();

        foreach( Book book in books)//add each book in books array to database using entity framework
        {
            entityframework.Add(book);
        }
        entityframework.SaveChanges();//save to database

        foreach( Customer customer1 in customers)//add each book in books array to database using entity framework
        {
            entityframework.Add(customer1);
        }
        entityframework.SaveChanges();//save to database

        Console.WriteLine("Welcome to My Library!");

        Order order = TakeOrder();

        Console.WriteLine("\n---------- RECEIPT -----------\n");
        order.PrintOrder();

        
        

   

    }

    public static void PrintBooks()
    {
        DataContextEF entityframework = new DataContextEF();
        IEnumerable<Book> ? bookEF = entityframework.Book?.ToList<Book>(); //create list of books items found on entityframework 

        Console.WriteLine("--------------BOOKS-------------");
        if(bookEF != null){
            foreach(Book book in bookEF)
            {   
                Console.WriteLine("Book ID: {0}",book.BookId);
                Console.WriteLine("Title: {0}",book.Title);
                Console.WriteLine("Author: {0}",book.Author);
                Console.WriteLine("Price: {0}\n",book.Price);
            }
        }


    }

    public static void PrintCustomers()
    {
        DataContextEF entityframework = new DataContextEF();
        IEnumerable<Customer> ? customerEF = entityframework.Customer?.ToList<Customer>();

        Console.WriteLine("--------------CUSTOMERS--------------");

        if(customerEF!=null)
        {
            foreach(Customer customer in customerEF)
            {
                Console.WriteLine("Customer Id: {0}",customer.CustomerId);
                Console.WriteLine("Full Name: {0}",customer.FullName);
                Console.WriteLine("Phone Number: {0}",customer.PhoneNumber);
                Console.WriteLine("Email: {0}\n",customer.Email);
            }
        }


    }

    public static Order TakeOrder()
    {
        DataContextEF entityframework = new DataContextEF();

        PrintCustomers();

        Console.WriteLine("------------------------------");

        Console.Write("\n\nEnter Your Customer Id: ");

        string? str = Console.ReadLine();
        int custId = Convert.ToInt32(str);

        IEnumerable<Customer> ?customerEF = entityframework.Customer?.ToList<Customer>();
        Customer ?customer = customerEF?.FirstOrDefault(o => o.CustomerId == custId);
        

        PrintBooks();

        Console.WriteLine("------------------------------");

        Console.Write("\n\nSelect a Book Id: ");

        str = Console.ReadLine();
        int bookId = Convert.ToInt32(str);
        
        IEnumerable<Book> ? bookEF = entityframework.Book?.ToList<Book>(); //create list of books items found on entityframework 
        Book ?book = bookEF?.FirstOrDefault(o => o.BookId == bookId);

        Console.WriteLine("------------------------------");

        Console.Write("\n\nEnter Quantity: ");

        str = Console.ReadLine();
        int Quantity = Convert.ToInt32(str);

        Order ord2 = new Order();
        if(customer != null && book != null)
        {
            Order ord1 = new Order(customer,book,Quantity);
            return ord1;
        }

        return ord2;
    }
}