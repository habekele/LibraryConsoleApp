using System.Data;
using Dapper;
using LibraryConsoleApp.Models;
using Microsoft.Data.SqlClient;

class Program{
    static void Main(string[] args)
    {
        
        string connectionString = "Server=localhost;Database=DotNetCourseDatabase;Trusted_Connection=false;TrustServerCertificate=True;User Id=sa;Password=SQLConnect1;";

        IDbConnection dbConnection = new SqlConnection(connectionString);

        string sqlCommand = "SELECT GETTIME();";

        dbConnection.Query<DateTime>(sqlCommand);


        Book [] books = {
            new Book("Harry Potter","J.K Rowling",19.99m,new DateTime(2005,04,23),GenreClass.Mystery), 
            new Book("Hunger Games","Suzanne Collins",29.99m,new DateTime(2012,02,11),GenreClass.Action), 
            new Book("Dune","Frank Hubert",9.99m,new DateTime(1965,07,25),GenreClass.SciFi), 
        };

        foreach (Book book in books){book.PrintBook();}
    }
}