using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    internal class Library
    {
        private static List<Book> Books = new();
        private static List<BorrowedBook> BorrowedBooks = new();

        static public int[] UserCardNumber = Enumerable.Range(1, 100).ToArray();

        static public Dictionary<int,string> Librarians = new();

        static Library()
        {
            Librarians.Add(101, "samar");
            Librarians.Add(202, "mohammed");
            Librarians.Add(303, "ziad");
            Librarians.Add(404, "yahia");
            Librarians.Add(505, "mona");
        }

        public static void LoadBooks(string path)
        {
            if (File.Exists(path))
            {
                string[] lines = File.ReadAllLines(path);
                foreach (var line in lines)
                {
                    string[] parts = line.Split('|');
                    if (parts.Length == 4)
                    {
                        Book book = new Book(parts[0], parts[1], int.Parse(parts[2]), bool.Parse(parts[3]));
                        Books.Add(book);
                    }
                }
            }
        }

        public static void LoadBorrowedBooks(string path)
        {
            if (File.Exists(path))
            {
                string[] lines = File.ReadAllLines(path);

                for (int i = 0; i < lines.Length; i++)
                {
                    string[] parts = lines[i].Split('|');
                    if (parts.Length == 3)
                    {
                        BorrowedBook borrowed = new BorrowedBook() { Name = parts[0], BorrowedBy = parts[1], BorrowTime = int.Parse(parts[2]) };
                        BorrowedBooks.Add(borrowed);
                    }
                    
                }
            }
        }

        public static void displayAll()
        {
            Console.Clear();
            if (Books.Count == 0)
            {
                Console.WriteLine("No Available books !");
            }
            else
            {
                Console.WriteLine($" Name | Author |Amount | Available  ");
                for (int i = 0; i < Books.Count; i++)
                {
                    Console.WriteLine(@$" {Books[i].Name} | {Books[i].Author} | {Books[i].Amount} | {Books[i].Available} ");
                }
            }

        }

        public static void displayBorrowed()
        {
            if (BorrowedBooks.Count == 0)
            {
                Console.WriteLine("No Available books !");
            }
            else
            {
                Console.WriteLine($" Name | BorrowedBy | BorrowTime ");
                for (int i = 0; i < BorrowedBooks.Count; i++)
                {
                    Console.WriteLine(@$" {BorrowedBooks[i].Name} | {BorrowedBooks[i].BorrowedBy} | {BorrowedBooks[i].BorrowTime}");
                }
            }

        }

        public static void AddBook(Book book)
        {
            Books.Add(book);
            Console.WriteLine("book added successfully");

        }
       
        public static void Remove(string name , int BookAmountToRemove)
        {
            for (int i = 0; i < Books.Count; i++)
            {
                if (Books[i].Name.ToLower() == name.ToLower())
                {
                  if (Books[i].Amount <= BookAmountToRemove)
                    {
                        Books[i].Amount = 0;
                        Books[i].Available = false;
                        return;

                    }
                    else
                    {
                        Books[i].Amount -= BookAmountToRemove;
                        return;

                    }

                }
                
            }
            Console.WriteLine("book not exist !");
        }


        public static void Borrow(BorrowedBook borrowed)
        {
            BorrowedBooks.Add(borrowed);
            for (int i = 0; i < Books.Count; i++)
            {
                if (Books[i].Name == borrowed.Name)
                {
                    if (Books[i].Amount <= 1)
                    {
                        Books[i].Amount -= 1;
                        Books[i].Available = false;
                    }
                    else
                    {
                        Books[i].Amount -= 1;
                    }
                        
                }
            }
        }




    }
}
