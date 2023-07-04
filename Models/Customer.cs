using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryConsoleApp.Models
{
    public class Customer
    {   
        [Key]
        public string FullName {get; set;} = "";

        public string PhoneNumber {get; set;} = "";

        public string Email {get;set;} = "";

        public Customer()
        {

        }

        public Customer(string fname, string pnumber, string email){

            this.FullName = fname;
            this.Email = email;
            this.PhoneNumber = pnumber;
        }

        public void printCustomer()
        {
            Console.WriteLine("Full Name: {0}",FullName);
            Console.WriteLine("Phone Number: {0}",PhoneNumber);
            Console.WriteLine("Email: {0}\n",Email);

        }



        
    }

}