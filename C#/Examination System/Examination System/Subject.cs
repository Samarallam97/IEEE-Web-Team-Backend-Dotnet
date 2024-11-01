using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal class Subject
    {
        public string Name { get; set; }
        public int Id { get; set; }

        public Exam SubjectExam;

        public Subject(string name)
        {
            Name = name;
        }


        public void CreateExam()
        {
            Console.Write("Please Enter The Type Of Exam You Want To Create ( 1 For Practical and 2 For Final ) | ");
            int input;

            while (!int.TryParse(Console.ReadLine() , out input) || (input != 1 && input!=2))
            {
                Console.WriteLine("Invalid Choice !!");
                Console.Write("Please Enter The Type Of Exam You Want To Create ( 1 For Practical and 2 For Final ) | ");

            }

            switch (input)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("====================================");
                    Console.WriteLine($"Creating a Prctical Exam For {Name}");
                    Console.WriteLine("====================================\n");
                    int examTime;
                    int NumOfQ;
                    Exam.getExamDetatils(out examTime , out NumOfQ );
                    SubjectExam = new PracticalExam(examTime , NumOfQ); 
                    SubjectExam.CreateQuestions();


                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("===============================");
                    Console.WriteLine($"Creating a Final Exam For {Name}");
                    Console.WriteLine("===============================\n");
                    Exam.getExamDetatils(out examTime, out NumOfQ);
                    SubjectExam = new FinalExam(examTime, NumOfQ);
                    SubjectExam.CreateQuestions();
                    break;
               
            }
        }

        public void ShowExam() {

                if(SubjectExam is not null)
                {
                Console.WriteLine("========================");
                Console.WriteLine($"Showing The Last Added Exam For {Name} ");
                Console.WriteLine("========================\n");

                Console.Write("Press Enter When You Are Ready To Start The Exam | ");
                    var inputKey = Console.ReadKey();
                    if (inputKey.Key == ConsoleKey.Enter)
                    {
                        Stopwatch sw = new Stopwatch();
                        sw.Start();
                        Console.WriteLine();
                        Console.WriteLine("============================");
                        SubjectExam.ShowQuestions();
                        Console.WriteLine($"You've Taken {sw.Elapsed} To Finih The Exam");

                    }
                    else
                    {
                    Console.WriteLine();
                    return;
                    }

                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("No Exams Added Yet For This Subject !!");
                    Console.WriteLine();

                }




        }
    }

}
