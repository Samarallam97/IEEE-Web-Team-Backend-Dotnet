using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal class TrueorFalseQuestion : Question
    {
        public TrueorFalseQuestion(string body, int marks) : base(body, marks)
        {
            AnswersList = new Answer[4]; // op1 , op2 , rightAnswer , input
            AnswersList[0].AnswerText = "True";
            AnswersList[1].AnswerText = "False";
        }

        public override void CreateQuestion(out string body, out int mark)
        {
            Console.Write("Please Enter The Body Of The Question | ");
            body = Console.ReadLine();

            while (string.IsNullOrEmpty(body))
            {
                Console.WriteLine("Don't Let This Field Empty !!");
                Console.Write("Please Enter The Body Of The Question | ");
                body = Console.ReadLine();
            }

            Console.Write("Please Enter The Marks Of The Question | ");

            while (!int.TryParse(Console.ReadLine(), out mark) || mark <= 0)
            {
                Console.WriteLine("Invalid Input !!");
                Console.Write("Please Enter The Marks Of The Question | ");

            }

            Console.Write("Please Enter The Right Answer Of The Question (  True or False ) | ");

            AnswersList[2].AnswerText= Console.ReadLine();

            while (string.IsNullOrEmpty(AnswersList[2].AnswerText)  || (AnswersList[2].AnswerText.ToLower() != "true" && AnswersList[2].AnswerText.ToLower() != "false"))
            {
                Console.WriteLine("Invalid Input !!");
                Console.Write("Please Enter The Right Answer Of The Question (  True or False ) | ");
                AnswersList[2].AnswerText = Console.ReadLine();

            }

        }

        public override void ShowQuestion()
        {

            Console.WriteLine("1. True                    2. False");
            Console.WriteLine("-----------------------------------");

            Console.Write("Enter The Right Choice | ");

            AnswersList[3].AnswerText = Console.ReadLine().ToLower();

            while (string.IsNullOrEmpty(AnswersList[3].AnswerText))
            {
                Console.WriteLine("Don't Let This Field Empty !!");
                Console.Write("Enter The Right Choice Number | ");
                AnswersList[3].AnswerText = Console.ReadLine().ToLower();
            }

        }


    }
}


