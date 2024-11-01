using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal class FinalExam : Exam
    {
        public FinalExam(int time, int NumOfQ) : base(time, NumOfQ) { }

        public override void CreateQuestions()
        {
            for (int i = 0; i < NumberOfQuestions; i++)
            {
                Console.Clear();
                Console.WriteLine("======================================================");
                Console.WriteLine("Final Exam Has True|False Questions and Mcq Questions ");
                Console.WriteLine("======================================================\n");

                Console.Write($"Please Choose The Type Of Qusetion {i + 1} ( 1 For True or False || 2 For Mcq ) | ");

                int choice;
                while (!int.TryParse(Console.ReadLine(), out choice) || (choice != 1 && choice != 2))
                {
                    Console.WriteLine("Invalid Choice !!");
                    Console.Write($"Please Choose The Type Of Qusetion {i + 1} ( 1 For True or False || 2 For Mcq ) | ");
                }

                switch (choice)
                {
                    case 1:

                        Console.WriteLine("=====================");
                        Console.WriteLine("True | False Question ");
                        Console.WriteLine("=====================\n");

                        string body;
                        int mark;
                        TrueorFalseQuestion trueorFalseQuestion = new TrueorFalseQuestion("", 0);

                        trueorFalseQuestion.CreateQuestion(out body, out mark);
                        trueorFalseQuestion.Body = body;
                        trueorFalseQuestion.Mark = mark;

                        Questions.Add(trueorFalseQuestion);
                        //Console.WriteLine("T|F Question Added Successfully ....");

                        break;
                    case 2:
                        Console.WriteLine("=====================");
                        Console.WriteLine("Mcq Question ");
                        Console.WriteLine("=====================\n");

                        string body2;
                        int mark2;

                        Console.WriteLine($"Question {i + 1}");
                        McqQuestion mcqQuestion = new McqQuestion("", 0);

                        mcqQuestion.CreateQuestion(out body2, out mark2);
                        mcqQuestion.Body = body2;
                        mcqQuestion.Mark = mark2;

                        Questions.Add(mcqQuestion);
                        //Console.WriteLine("McqQuestion Added Successfully ....");
                        break;

                }

                Console.WriteLine("=============================");
                Console.WriteLine($" Exam Added Successfully !!");
                Console.WriteLine("=============================");


            }
        }

        public override void ShowQuestions()
        {
            Console.WriteLine($"You Have {Time} Minutes To Finish The Exam");
            for (int i = 0; i < NumberOfQuestions; i++)
            {
                Console.WriteLine($"Question ({i + 1})     {Questions[i].Mark} Marks");
                Console.WriteLine(Questions[i].Body);
                Console.WriteLine("-----------------------");

                Questions[i].ShowQuestion();
                Console.WriteLine("========================");

            }

            /// Displaying the result => questions , answers , grade
            
            int count = 0;
            for (int l = 0; l < NumberOfQuestions; l++)
            {
                if (Questions[l] is McqQuestion)
                {

                    if (Questions[l].AnswersList[3].AnswerText == Questions[l].AnswersList[4].AnswerText)
                    {
                        Console.WriteLine($"Question {l + 1} Your Answer is {Questions[l].AnswersList[4].AnswerText} |  Right Answer is {Questions[l].AnswersList[3].AnswerText} || Right Answer :)");
                        count++;
                    }


                    else
                    {
                        Console.WriteLine($"Question {l + 1} Your Answer is {Questions[l].AnswersList[4].AnswerText} |  Right Answer is {Questions[l].AnswersList[3].AnswerText} || Wrong Answer :(");
                    }
                }
                else
                {
                    if (Questions[l].AnswersList[2].AnswerText == Questions[l].AnswersList[3].AnswerText)
                    {
                        Console.WriteLine($"Question {l + 1} Your Answer is {Questions[l].AnswersList[3].AnswerText} |  Right Answer is {Questions[l].AnswersList[2].AnswerText} || Right Answer :)");
                        count++;
                    }
                    else
                    {
                        Console.WriteLine($"Question {l + 1} Your Answer is {Questions[l].AnswersList[3].AnswerText} |  Right Answer is {Questions[l].AnswersList[2].AnswerText} || Wrong Answer :(");
                    }
                }
            }
            Console.WriteLine("====================================");
            Console.WriteLine($"Your Grade Is {count} From {NumberOfQuestions}");
            Console.WriteLine("====================================");

        }
    }

}
