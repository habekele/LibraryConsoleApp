using System.Data;
using Dapper;
using LibraryConsoleApp.Data;
using LibraryConsoleApp.Models;
using Microsoft.Data.SqlClient;

class Program{
    static void Main(string[] args)
    {


        Book [] books =
         {
            new Book("Harry Potter","J.K Rowling",19.99m,new DateTime(2005,04,23),GenreClass.Mystery), 
            new Book("Hunger Games","Suzanne Collins",29.99m,new DateTime(2012,02,11),GenreClass.Action), 
            new Book("Dune","Frank Hubert",9.99m,new DateTime(1965,07,25),GenreClass.SciFi), 
        };

        DataContextEF entityframework = new DataContextEF();
        foreach( Book book in books){
        entityframework.Add(book);
        }
        entityframework.SaveChanges();

    }
}