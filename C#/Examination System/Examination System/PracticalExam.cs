using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal class PracticalExam : Exam
    {
        public PracticalExam(int time, int NumOfQ) : base(time, NumOfQ) { }

        public override void CreateQuestions()
        {
            Console.Clear();
            Console.WriteLine("======================================");
            Console.WriteLine("Practical Exam Has Only Mcq Questions ");
            Console.WriteLine("======================================\n");

            for (int i = 0; i < NumberOfQuestions; i++)
            {
                //Console.Clear();
             
                string body2;
                int mark2;
                

                Console.WriteLine($"Question {i + 1}");
                McqQuestion mcqQuestion = new McqQuestion("", 0);

                mcqQuestion.CreateQuestion(out body2, out mark2);

                mcqQuestion.Body = body2;
                mcqQuestion.Mark = mark2;

                Questions.Add(mcqQuestion);
                Console.WriteLine("McqQuestion Added Successfully ....");
            }
        }

        public override void ShowQuestions()
        {
            Console.WriteLine($"You Have {Time} Minutes To Finish The Exam");

            for (int i = 0; i < NumberOfQuestions; i++)
            {
                if (Questions[i] is McqQuestion)
                {
                    Console.WriteLine($"Question ({i + 1})     {Questions[i].Mark} Marks");
                    Console.WriteLine(Questions[i].Body);
                    Console.WriteLine("-----------------------");
                    Questions[i].ShowQuestion();
                }
                Console.WriteLine("==========================");
            }

            /// displaying true answers only
            
            for (int l = 0; l < NumberOfQuestions; l++)
            {
                if (Questions[l] is McqQuestion)
                {

                    if (Questions[l].AnswersList[3].AnswerText == Questions[l].AnswersList[4].AnswerText)
                    {
                        Console.WriteLine($"Question {l + 1} Your Answer is {Questions[l].AnswersList[4].AnswerText} |  Right Answer is {Questions[l].AnswersList[3].AnswerText} || Right Answer :)");
                    }

                    else
                    {
                        Console.WriteLine($"Question {l + 1} Your Answer is {Questions[l].AnswersList[4].AnswerText} |  Right Answer is {Questions[l].AnswersList[3].AnswerText} || Wrong Answer :(");
                    }
                }
               
            }

        }

    }

}
