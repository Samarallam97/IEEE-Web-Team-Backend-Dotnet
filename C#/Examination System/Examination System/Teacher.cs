using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal class Teacher : Character , ICharacter
    {
        public Teacher(string name, int id) : base(name, id) { }

        public static void ViewOptions()
        {
            Console.WriteLine("Choose From The Following : \n1 For Adding a new Exam \n2 For Viewing The Last Added Exam  ");
            Console.Write("| ");
            int choice;

            while (!int.TryParse(Console.ReadLine(), out choice) || (choice != 1 && choice != 2))
            {
                Console.WriteLine("Invalid Choice !!");
                Console.WriteLine("Choose From The Following : \n1 For Adding a new Exam \n2 For Viewing The Last Added Exam  ");

            }

            
            Console.Write("Enter The Subject Name | ");
            string subName = Console.ReadLine();

            while (string.IsNullOrEmpty(subName))
            {
                Console.WriteLine("Don't Let This Field Empty !!");
                Console.Write("Enter The Subject Name | ");
                subName = Console.ReadLine();
            }

            bool exist;

            Subject subject = CreateSubject(subName, out exist);

            switch (choice)
            {
                case 1:

                    Console.Clear();
                   
                    if (exist)
                    {
                        Console.WriteLine();
                        Console.WriteLine($"{subName} Subject Is Already In The System, You Can Create An Exam For It Freely :) ");
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine($"{subName} Subject Wasn't Exist In The System , So It's Added And You Can Create An Exam For It Freely :) ");
                        Console.WriteLine();

                    }

                    Console.WriteLine("========================");
                    Console.WriteLine($"Adding a {subName} Exam");
                    Console.WriteLine("========================\n");

                    subject.CreateExam();

                    break;
                case 2:

                    Console.Clear();

                    if (!exist)
                    {
                        Console.WriteLine();
                        Console.WriteLine("This Subject Is Not In The System , No Existing Exam For It");
                        Console.WriteLine();
                        return;
                    }
                    else
                    {
                    subject.ShowExam();

                    }

                    break;
            }


        }

        private static Subject CreateSubject(string subjectName, out bool exist)
        {
            Subject subject;

            for (int i = 0; i < ExaminationSystem.Subjects.Count; i++)
            {
                if (ExaminationSystem.Subjects[i].Name.ToLower() == subjectName.ToLower())
                {
                    subject = ExaminationSystem.Subjects[i];
                    exist= true;
                    return subject;
                }
            }

            subject = new Subject(subjectName);
            ExaminationSystem.Subjects.Add(subject);
            exist = false;
            return subject;
        }
    }

}



