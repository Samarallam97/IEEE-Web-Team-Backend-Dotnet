using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal class Manager : Character, ICharacter
    {
        public Manager(string name, int id) : base(name, id) { }

        public static void ViewOptions()
        {
            Console.WriteLine("Choose From The Following :\n1 For Adding a New Student In The System\n2 For Removing a Student From The System\n3 For Adding a New Teacher In The System\n4 For Removing a Teacher From The System ");
            Console.Write("| ");
            int choice;

            while (!int.TryParse(Console.ReadLine(), out choice) || (choice != 1 && choice != 2 && choice != 3 && choice != 4))
            {
                Console.WriteLine("Invalid Choice !!");
                Console.WriteLine("Choose From The Following :\n1 For Adding a New Student In The System\n2 For Removing a Student From The System\n3 For Adding a New Teacher In The System\n4 For Removing a Teacher From The System ");
                Console.Write("| ");
            }

            switch (choice) 
            { 

            case 1:
                int id;
                if (StudentExist(out id))
                    {
                        Console.WriteLine($"Student {ExaminationSystem.Students[id]} With Id {id} Is Already In The System !!");
                    }
                else
                    {
                        Console.Write("Please Enter The Student Name | ");
                        string studentName;
                        studentName = Console.ReadLine();

                        while (string.IsNullOrEmpty(studentName))
                        {
                            Console.WriteLine("Don't Let This Field Empty !!");
                            Console.WriteLine("Please Enter The Student Name | ");
                            studentName = Console.ReadLine();
                        }

                        ExaminationSystem.Students.Add(id, studentName);
                        Console.WriteLine("============================================================");
                        Console.WriteLine($"Student {studentName} With Id {id} Is Added Successfully !!");
                        Console.WriteLine("============================================================");

                    }
            break;

            case 2:
                    if (!StudentExist(out id))
                    {
                        Console.WriteLine($"Student With Id {id} Is Not Exist In The System !!");
                    }
                    else
                    {

                        ExaminationSystem.Students.Remove(id);
                        Console.WriteLine("============================================================");
                        Console.WriteLine($"Student {ExaminationSystem.Students[id]} With Id {id} Is Removed Successfully !!");
                        Console.WriteLine("============================================================");

                    }
            break;

            case 3:
                    if (TeacherExist(out id))
                    {
                        Console.WriteLine($"Teacher {ExaminationSystem.Teachers[id]} With Id {id} Is Already In The System !!");
                    }
                    else
                    {
                        Console.Write("Please Enter The Teacher Name | ");
                        string teacherName;
                        teacherName = Console.ReadLine();

                        while (string.IsNullOrEmpty(teacherName))
                        {
                            Console.WriteLine("Don't Let This Field Empty !!");
                            Console.WriteLine("Please Enter The Teacher Name | ");
                            teacherName = Console.ReadLine();
                        }

                        ExaminationSystem.Teachers.Add(id, teacherName);
                        Console.WriteLine("============================================================");
                        Console.WriteLine($"Student {teacherName} With Id {id} Is Added Successfully !!");
                        Console.WriteLine("============================================================");

                    }
            break;
            case 4:
                    if (!TeacherExist(out id))
                    {
                        Console.WriteLine($"Teacher With Id {id} Is Not Exist In The System !!");
                    }
                    else
                    {

                        ExaminationSystem.Teachers.Remove(id);
                        Console.WriteLine("============================================================");
                        Console.WriteLine($"Teacher {ExaminationSystem.Teachers[id]} With Id {id} Is Removed Successfully !!");
                        Console.WriteLine("============================================================");

                    }
                    break;

            }

        }

        private static bool StudentExist(out int studentId )
        {
            Console.Write("Please Enter The Student Id | ");

            while (!int.TryParse(Console.ReadLine(), out studentId) || studentId <= 0)
            {
                Console.WriteLine("Invalid Input !!");
                Console.Write("Please Enter A Correct Student Id | ");

            }


            if (!ExaminationSystem.Students.Keys.Contains(studentId))
            {
                return false;
            }
            else
            {
                return true;
            }


        }

        private static bool TeacherExist(out int teacherId)
        {
            Console.Write("Please Enter The Teacher Id | ");

            while (!int.TryParse(Console.ReadLine(), out teacherId) || teacherId <= 0)
            {
                Console.WriteLine("Invalid Input !!");
                Console.Write("Please Enter A Correct Teacher Id | ");

            }

            if (!ExaminationSystem.Teachers.Keys.Contains(teacherId))
            {
                return false;
            }
            else
            {
                return true;
            }


        }
    }

}