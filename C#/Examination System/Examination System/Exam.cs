using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal class Exam
    {
        public int Time { get; set; }
        public int NumberOfQuestions { get; set; }
        public List<Question> Questions { get; set; }

        public Exam(int time, int NumOfQ )
        {
            Time = time;
            NumberOfQuestions = NumOfQ;
            Questions = new List<Question>();
        }

        public static void getExamDetatils(out int examTime, out int numOfQ)
        {
            Console.Write("Please Enter The Time Of Exam in Minutes | ");

            while (!int.TryParse(Console.ReadLine(), out examTime) || examTime <= 0)
            {
                Console.WriteLine("Invalid Input !!");
                Console.Write("Please Enter The Time Of Exam in Minutes | ");

            }

            Console.Write("Please Enter The Number Of Questions You Want To Create | ");

            while (!int.TryParse(Console.ReadLine(), out numOfQ) || numOfQ <= 0)
            {
                Console.WriteLine("Invalid Input !!");
                Console.Write("Please Enter The Time Of Exam in Minutes | ");

            }


        }
        public virtual void CreateQuestions() { }
        public virtual void ShowQuestions() { }



    }


}

