using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryConsoleApp.Models
{
    public class Order
    {
        public Customer? CustomerId {set; get;}

        public Book ? BookId {set; get;}

        public int Quantity {set; get;}

        private decimal TotalPrice;
    

    public Order()
    {

    }

    public Order(Customer cust, Book book1, int quant){
        this.CustomerId = cust;
        this.BookId = book1;
        this.Quantity = quant;
        this.TotalPrice = quant * book1.Price;
    }

    public void PrintOrder(){
        if(CustomerId!=null && BookId != null){
        Console.WriteLine("Customer Name: {0}",CustomerId.FullName);
        Console.WriteLine("Book Name: {0}",BookId.Title);
        Console.WriteLine("Quantity: {0}",Quantity);
        Console.WriteLine("Total Price: {0}\n",TotalPrice);
        }
    }

    }
}