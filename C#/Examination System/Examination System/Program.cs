using System.Diagnostics;

namespace Examination_System
{
    internal class Program
    {

        public static string filePath = @"C:\Users\faz\Documents\Backend\C# Console Projects\Examination System\Questions.txt";
        static void Main(string[] args)
        {

            #region System Members ( students | Teachers | Managers |Subjects)

            //// students can view exams
            ExaminationSystem.Students = new Dictionary<int, string>()
            {
                {1,"Mona" },
                {2 , "Salma"},
                {3 ,"Noor" },
                {4 ,"Lili" },
                {5,"Farah" }

            };
            
            //// teachers can add & view exams
            ExaminationSystem.Teachers = new Dictionary<int, string>()
            {
                {101,"Ahmed" },
                {102 , "Mohamed"},
                {103 ,"Mahmoud" },
                {104 ,"Zyad" },
                {105,"Walid" }

            };

            //// managers can add & remove students & teachers from the system
            ExaminationSystem.Managers = new Dictionary<int, string>()
            {
                {201,"Ali" },
            };

            /// subjects

            //ExaminationSystem.Subjects.Add(new Subject("Math"));
            //ExaminationSystem.Subjects.Add(new Subject("English"));
            //ExaminationSystem.Subjects.Add(new Subject("Arabic"));

            //ExaminationSystem.LoadQuestions(filePath);


            #endregion


            Console.WriteLine("=================================");
            Console.WriteLine("Welcome To Our Examination System");
            Console.WriteLine("=================================\n");

            Console.WriteLine("Please Select Your Role In The System :\n1 For a Teacher (Can Add & View Exams) \n2 For a Student (Can View Exams) \n3 For a Manager (Can Add & Remove Teachers & Students From The System) ");

            int role;
            while (!int.TryParse(Console.ReadLine() , out role) || (role != 1 && role != 2 && role !=3))
            {
                Console.WriteLine("Invalid Choice !! ");
                Console.WriteLine("Please Select Your Role In The System :\n1 For a Teacher \n2 For a Student \n3 For a Manager ");

            }


            switch (role)
            {
                case 1:
                    string name;
                    ExaminationSystem.VerifyRole(ExaminationSystem.Teachers , out name);
                    while (true)
                    {
                        Teacher.ViewOptions();

                        Console.Write("Press Any Key To Continue Or Press Escape to Exit ...\n");
                        var inKey = Console.ReadKey();
                        if(inKey.Key == ConsoleKey.Escape)
                        {
                            Environment.Exit(0);
                        }
                        Console.Clear();
                        Console.WriteLine("===============================================");
                        Console.WriteLine($"Welcome {name} To Our Examination System Again");
                        Console.WriteLine("===============================================");
                        
                        
                        ExaminationSystem.SaveQuestions(filePath);
                    }
                    break;
                case 2:
                    ExaminationSystem.VerifyRole(ExaminationSystem.Students, out name);
                    while (true)
                    {
                        Student.ViewOptions();

                        Console.Write("Press Any Key To Continue Or Press Escape to Exit ...");
                        Console.WriteLine();
                        var inKey = Console.ReadKey();
                        if (inKey.Key == ConsoleKey.Escape)
                        {
                            Environment.Exit(0);
                        }

                        Console.Clear();
                        Console.WriteLine("===============================================");
                        Console.WriteLine($"Welcome {name} To Our Examination System Again");
                        Console.WriteLine("===============================================");

                        
                    }
                    break;
                case 3:
                    ExaminationSystem.VerifyRole(ExaminationSystem.Managers, out name);
                    while (true)
                    {
                       
                        Manager.ViewOptions();
                        Console.Write("Press Any Key To Continue Or Press Escape to Exit ...");
                        Console.WriteLine();
                        var inKey = Console.ReadKey();
                        if (inKey.Key == ConsoleKey.Escape)
                        {
                            Environment.Exit(0);
                        }
                        Console.Clear();
                        Console.WriteLine("===============================================");
                        Console.WriteLine($"Welcome {name} To Our Examination System Again");
                        Console.WriteLine("===============================================");

                    }

                    break;

            }


        }

    }
}


#region Members with classes
//ExaminationSystem.Students.Add(new Student("Mona", 1));
//ExaminationSystem.Students.Add(new Student("Salma", 2));
//ExaminationSystem.Students.Add(new Student("Noor", 3));
//ExaminationSystem.Students.Add(new Student("Lili", 4));
//ExaminationSystem.Students.Add(new Student("Farah", 5));


//ExaminationSystem.Teachers.Add(new Teacher("Ahmed", 101));
//ExaminationSystem.Teachers.Add(new Teacher("Mohamed", 102));
//ExaminationSystem.Teachers.Add(new Teacher("Mahmoud", 103));
//ExaminationSystem.Teachers.Add(new Teacher("Zyad", 104));
//ExaminationSystem.Teachers.Add(new Teacher("Walid", 105));


//ExaminationSystem.Managers.Add(new Manager("Ali", 202));


#endregion
