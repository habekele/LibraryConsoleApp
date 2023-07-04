using System.Data;
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

        Order [] orders ={
            new Order(customers[1],books[0],2),
            new Order(customers[0],books[2],3)
        };




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

        


        IEnumerable<Book> ? bookEF = entityframework.Book?.ToList<Book>(); //create list of books items found on entityframework 
        if(bookEF != null){
            foreach(Book book in bookEF)
            {
            Console.WriteLine("Title: {0}",book.Title);
            Console.WriteLine("Author: {0}",book.Author);
            Console.WriteLine("Price: {0}\n",book.Price);


            }
        }

        

        // foreach(Customer customer in customers)
        // {
        //     customer.printCustomer();
        // }

        // foreach(Order order in orders)
        // {
        //     order.PrintOrder();
        // }



    }
}