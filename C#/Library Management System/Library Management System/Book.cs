using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    internal class Book
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public int Amount{ get; set; }
        public bool Available { get; set; } = true;

        public Book() { }
        public Book(string name , string author , int amount , bool available)
        {
            Name = name;
            Author = author;
            Amount = amount;
            Available = available;
        }

        public Book(string name, string author, int amount) : this(name,author,amount,true)
        {
        }
        public override string ToString()
        {
            return $"Name : {Name} :: Author : {Author} Amount : {Amount} Available : {Available} ";
        }


    }

    internal class BorrowedBook : Book
    {
        public string BorrowedBy { get; set; }
        public int BorrowTime { get; set; }


    }
}
