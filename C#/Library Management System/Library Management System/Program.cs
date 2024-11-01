using System.IO;

namespace Library_Management_System
{
    internal class Program
    {
        private static string booksFilePath = "C:\\Users\\faz\\Documents\\Backend\\C# Console Projects\\Library Management System\\books.txt";
        private static string borrowedBooksFilePath = "C:\\Users\\faz\\Documents\\Backend\\C# Console Projects\\Library Management System\\borrowed.txt";

        static void LibrarianMenu()
        {
            Console.WriteLine($"1. press 'A' to add a new Book.\n2. press 'R' to remove a Book.\n3. press 'DB' to display borrowed books.\n4. press 'D' to display all books. ");
        }
        static void UserMenu()
        {
            Console.WriteLine($"1. press 'D' to display books.\n2. press 'B' to borrow a book. ");
        }

        static void Main(string[] args)
        {

            Library.LoadBooks(booksFilePath);
            Library.LoadBorrowedBooks(borrowedBooksFilePath);
            //Library.displayAll();
            //Library.displayBorrowed();

            ////////////////////////////////////////
            
            Console.WriteLine("Welcome to our library ! ");
            bool valid = true;

            while (valid)
            {
                Console.Write("Are U a librarian or regular user (L | U) | ");
                string input = Console.ReadLine().ToUpper();

                switch (input)
                {
                    case "L":

                        Console.Write("Enter Your Id | ");
                        int id;
                        while (!int.TryParse(Console.ReadLine(), out id) || !Library.Librarians.Keys.Contains(id))
                        {
                            Console.WriteLine("invalid id !! ");
                            Console.Write("Enter Your Id | ");
                        }

                        while (valid)
                        {
                            Console.Clear();
                            Console.WriteLine($"Welcome {Library.Librarians[id]}");
                            LibrarianMenu();
                            string choice = Console.ReadLine().ToUpper();

                            switch (choice)
                            {
                                case "A":
                                    Librarian.AddBook();
                                    break;

                                case "R":
                                    Librarian.RemoveBook();
                                    break;
                                case "D":
                                    Librarian.Display();
                                    break;
                                case "DB":
                                    Librarian.DisplayBorrowed();
                                    break;
                                default:
                                    Console.WriteLine("Invalid Choice");
                                    break;
                            }

                            Console.Write("Press any key to continue");
                            Console.ReadKey();

                        }                       
                        break;

                    case "U":
                        Console.Write("Enter Your Card Number | ");
                        int cardNumber;
                        while (!int.TryParse(Console.ReadLine(), out cardNumber) || !Library.UserCardNumber.Contains(cardNumber))
                        {
                            Console.WriteLine("invalid Card Number !! ");
                            Console.Write("Enter Your Card Number | ");
                        }

                        while (valid)
                        {
                            Console.Clear();
                            Console.WriteLine($"Welcome user {cardNumber}");
                            UserMenu();  
                            string choice = Console.ReadLine().ToUpper();

                            switch (choice)
                            {
                                case "D":
                                    User.Display();
                                    break;

                                case "B":
                                    User.Borrow();
                                    break;
                                default:
                                    Console.WriteLine("Invalid Choice");
                                    break;
                            }

                            Console.Write("Press any key to continue");
                            Console.ReadKey();

                        }

                        break;

                    default:
                        Console.WriteLine("Invalid Choice !");
                        break;
                }

                Console.Write("Press any key to continue");
                Console.ReadKey();
                Console.Clear();
            }




        }
    }
}
