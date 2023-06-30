using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryConsoleApp.Models
{
    public class Book
    {
        [Key]
        public string Title { get; set; } = "";

        public string Author { get; set; } = "";

        public decimal Price { get; set; }

        public DateTime PublishedDate { get; set; }

        public string? Genre { get; set; }


        public Book()
        {
            
        }
        public Book(string Title, string Author, decimal Price, DateTime PublishedDate, GenreClass Genre)
        {
            this.Title = Title;
            this.Author = Author;
            this.Price = Price;
            this.PublishedDate = PublishedDate;
            this.Genre = Genre.ToString();
        }

        public void PrintBook(){
            Console.WriteLine("Title: {0}\n Author: {1}\n Price: {2}\n Published: {3}\n Genre: {4}", Title, Author, Price, PublishedDate, Genre);
            
        }

    }
}