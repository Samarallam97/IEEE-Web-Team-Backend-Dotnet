using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    internal class User : AbstractUser
    { 
        // Composition => owns a 
        LibraryCard Card = new();

        public static void Borrow() {
            Console.Clear();

            Console.Write("1. Book Name | ");
            string BookName;

            while (string.IsNullOrEmpty(BookName = Console.ReadLine()))
            {
                Console.WriteLine("don't let this field empty");
                Console.Write("1. Book Name | ");

            }

            Console.Write("2. Your Name | ");

            string Borrower;
            while (string.IsNullOrEmpty(Borrower = Console.ReadLine()))
            {
                Console.WriteLine("don't let this field empty");
                Console.Write("2. Your Name | ");

            }


            Console.Write("3. Borrowing days | ");

            int BorrowingDays;
            while (!int.TryParse(Console.ReadLine(), out BorrowingDays) || BorrowingDays <= 0)
            {
                Console.WriteLine("Enter a valid number!");
                Console.Write("3. Borrowing days | ");

            }


            BorrowedBook newbook = new BorrowedBook() { Name = BookName , BorrowedBy = Borrower , BorrowTime = BorrowingDays};

            Library.Borrow(newbook );
        }

    }
}
