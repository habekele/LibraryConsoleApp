using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryConsoleApp.Models
{
    public class Book
    {
        string Title { get; set; } = "";

        string Author { get; set; } = "";

        decimal Price { get; set; }

        DateTime Published { get; set; }

        GenreClass Genre { get; set; }

        public Book(string Title, string Author, decimal Price, DateTime Published, GenreClass Genre)
        {
            this.Title = Title;
            this.Author = Author;
            this.Price = Price;
            this.Published = Published;
            this.Genre = Genre;
        }

        public void PrintBook(){
            Console.WriteLine("Title: {0}\n Author: {1}\n Price: {2}\n Published: {3}\n Genre: {4}", Title, Author, Price, Published, Genre);
            
        }

    }
}