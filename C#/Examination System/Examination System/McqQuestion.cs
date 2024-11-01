using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal class McqQuestion : Question
    {
        public McqQuestion(string body, int marks) : base(body, marks)
        {
            AnswersList = new Answer[5]; // op1 , op2 , op3 , rightAnswer , input

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

            Console.WriteLine("The Choices Of The Question:");

            for (int j = 0; j < AnswersList.Length -2; j++)
            {
                Console.Write($"Please Enter The Choice Number {j + 1} | ");
                AnswersList[j].AnswerText = Console.ReadLine();
            }

            Console.Write("Please Enter The Right Choice | ");

            AnswersList[3].AnswerText = Console.ReadLine().ToLower();

            while (string.IsNullOrEmpty(AnswersList[3].AnswerText))
            {
                Console.WriteLine("Don't Let This Field Empty !!");
                Console.Write("Please Enter The Right Choice |");
                AnswersList[3].AnswerText = Console.ReadLine();

            }

        }

        public override void ShowQuestion()
        {

            for (int j = 0; j < 3; j++)
            {
                Console.WriteLine($"{j + 1}) {AnswersList[j].AnswerText}");
            }

            Console.WriteLine("-----------------------");

            Console.Write("Enter The Right Choice | ");

            AnswersList[4].AnswerText = Console.ReadLine().ToLower();

            while (string.IsNullOrEmpty(AnswersList[4].AnswerText))
            {
                Console.WriteLine("Don't Let This Field Empty !!");
                Console.Write("Enter The Right Choice Number | ");
                AnswersList[4].AnswerText = Console.ReadLine().ToLower();
            }
        }

    }
}
