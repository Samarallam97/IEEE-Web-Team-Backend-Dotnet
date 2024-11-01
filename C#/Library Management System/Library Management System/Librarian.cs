using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    internal class Librarian : AbstractUser
    {
        public int Id { get; set; }

        public Librarian(string name)
        {
            Name = name;
        }

        public static void AddBook() {
            Console.Clear();

            Console.Write("1. Book Name | ");
            string BookName;

            while (string.IsNullOrEmpty(BookName = Console.ReadLine()))
            {
                Console.WriteLine("don't let this field empty");
                Console.Write("1. Book Name | ");

            }

            Console.Write("2. Book Author | ");

            string BookAuthor;
            while (string.IsNullOrEmpty(BookAuthor = Console.ReadLine()))
            {
                Console.WriteLine("don't let this field empty");
                Console.Write("2. Book Author | ");

            }


            Console.Write("3. Book Amount | ");

            int BookAmount;
            while (!int.TryParse(Console.ReadLine(), out BookAmount) || BookAmount <= 0)
            {
                Console.WriteLine("Enter a valid number!");
                Console.Write("3. Book Amount | ");

            }


            Book newbook = new Book(BookName, BookAuthor, BookAmount);

            Library.AddBook(newbook);
        }

        public static void RemoveBook()
        {
            Console.Clear();

            Console.Write("Enter Book Name to remove | ");
            string BookNameToRemove;
            while (string.IsNullOrEmpty(BookNameToRemove = Console.ReadLine()))
            {
                Console.WriteLine("don't let this field empty");
                Console.Write("Enter Book Name to remove | ");
            }

            Console.Write("enter Book Amount to remove | ");

            int BookAmountToRemove;
            while (!int.TryParse(Console.ReadLine(), out BookAmountToRemove) || BookAmountToRemove <= 0)
            {
                Console.WriteLine("Enter a valid number!");
                Console.Write("enter Book Amount to remove | ");
            }

            Library.Remove(BookNameToRemove , BookAmountToRemove);
        }

        public static void DisplayBorrowed()
        {
            Library.displayBorrowed();

        }

    }
}
