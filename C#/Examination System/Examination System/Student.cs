using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal class Student : Character
    {
        public Student(string name, int id) : base(name, id) { }

        public static void ViewOptions()
        {
            Console.Write("Press 1 For Viewing A Specific Exam | ");
            int choice;

            while (!int.TryParse(Console.ReadLine(), out choice) || choice != 1 )
            {
                Console.WriteLine("Invalid Choice !!");
                Console.Write("Press 1 For Viewing A Specific Exam | ");

            }


            Console.Write("Enter The Subject Name | ");
            string subName = Console.ReadLine();

            while (string.IsNullOrEmpty(subName))
            {
                Console.WriteLine("Don't Let This Field Empty !!");
                Console.Write("Enter The Subject Name | ");
                subName = Console.ReadLine();
            }

            bool exist = false;

            for (int i = 0; i < ExaminationSystem.Subjects.Count; i++)
            {
                if (ExaminationSystem.Subjects[i].Name == subName)
                {
                    exist = true;
                    ExaminationSystem.Subjects[i].ShowExam();
                    break;
                }
                
                
            }


            if (!exist)
            {
                Console.WriteLine("===========================");
                Console.WriteLine($"{subName} Subject Wasn't Exist In The System  ");
                Console.WriteLine("===========================");
            }
         

        }


    }
}
