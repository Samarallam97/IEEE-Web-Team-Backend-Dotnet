using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    static class ExaminationSystem
    {


        static public Dictionary<int, string> Teachers;
        static public Dictionary<int, string> Students;
        static public Dictionary<int, string> Managers;

        static public  List<Subject> Subjects = new List<Subject>();

        public static void VerifyRole(Dictionary<int,string> characters , out string name)
        {
            Console.Write("Please Enter Your Id | ");
            int id;


            while (!int.TryParse(Console.ReadLine(), out id) || !ExistInSystem(id, characters, out name))
            {
                Console.WriteLine("Invalid Id");
                Console.Write("Please Enter The Right Id | ");

            }

            Console.Clear();
            Console.WriteLine("===============================================");
            Console.WriteLine($"Welcome {characters[id]} To Our Examination System");
            Console.WriteLine("===============================================");
        }
        public static bool ExistInSystem(int id, Dictionary<int,string> characters, out string name)
        {

            for (int i = 0; i < characters.Count; i++)
            {
                if (characters.Keys.Contains(id))
                {
                    name = characters[id];
                    return true;
                }

            }
            name = "";
            return false;
        }

        public static void SaveQuestions(string filepath) {
            if (File.Exists(filepath))
            {
                for (int i = 0; i < Subjects.Count; i++)
                {
                    File.AppendAllText(filepath, Subjects[i].Name);
                    File.AppendAllText(filepath, "|");
                    File.AppendAllText(filepath, Subjects[i].Id.ToString());
                    File.AppendAllText(filepath, "|");
                    if (Subjects[i].SubjectExam is not null)
                    {
                        if (Subjects[i].SubjectExam is PracticalExam)
                        {
                            File.AppendAllText(filepath, "practical");
                            File.AppendAllText(filepath, "|");


                        }
                        else
                        {
                            File.AppendAllText(filepath, "final");
                            File.AppendAllText(filepath, "|");


                        }
                        File.AppendAllText(filepath, Subjects[i].SubjectExam.Time.ToString());
                        File.AppendAllText(filepath, "|");
                        File.AppendAllText(filepath, Subjects[i].SubjectExam.NumberOfQuestions.ToString());
                        File.AppendAllText(filepath, "|");

                        for (int j = 0; j < Subjects[i].SubjectExam.Questions.Count; j++)
                        {
                            if (Subjects[i].SubjectExam.Questions[j] is TrueorFalseQuestion)
                            {
                                File.AppendAllText(filepath, "TrueorFalseQuestion");
                                File.AppendAllText(filepath, "|");

                            }
                            else
                            {
                                File.AppendAllText(filepath, "McqQuestion");
                                File.AppendAllText(filepath, "|");

                            }
                            File.AppendAllText(filepath, Subjects[i].SubjectExam.Questions[j].Body);
                            File.AppendAllText(filepath, "|");
                            File.AppendAllText(filepath, Subjects[i].SubjectExam.Questions[j].Mark.ToString());

                            for (int k = 0; k < Subjects[i].SubjectExam.Questions[j].AnswersList.Length; k++)
                            {
                                File.AppendAllText(filepath, "|");

                                File.AppendAllText(filepath, Subjects[i].SubjectExam.Questions[j].AnswersList[k].AnswerText);
                            }
                        }
                   
                        
                    }
                   
                    File.AppendAllText(filepath, "\n");


                }

            }

        }
        /// review 
        public static void LoadQuestions(string filepath) {
            if (File.Exists(filepath))
            {
                string[] lines = File.ReadAllLines(filepath);
                string[] words;
                for (int i = 0; i < lines.Length; i++)
                {
                     words = lines[i].Split("|");
                     Subject subject = new Subject(words[0]);
                     subject.Id = int.Parse(words[1]);
                    if (words[2] == "practical")
                    {
                        subject.SubjectExam = new PracticalExam(int.Parse(words[3]), int.Parse(words[4]));
                    }
                    else
                    {
                        subject.SubjectExam = new FinalExam(int.Parse(words[3]), int.Parse(words[4]));

                    }
                    subject.SubjectExam.Questions = new List<Question>(int.Parse(words[4]));
                    ///
                    int k = 6;
                    for (int j = 0; j < subject.SubjectExam.Questions.Capacity; j++)
                    {
                        Question question;
                        if (words[5] == "TrueorFalseQuestion")
                        {
                             question = new TrueorFalseQuestion(words[k], int.Parse(words[k + 1]));

                        }
                        else
                        {
                             question = new McqQuestion(words[k], int.Parse(words[k + 1]));

                        }

                        if (words[2] == "practical")
                        {
                            question.AnswersList = new Answer[4];
                            question.AnswersList[0].AnswerText = words[k + 2];
                            question.AnswersList[1].AnswerText = words[k + 3];
                            question.AnswersList[2].AnswerText = words[k + 4];
                            question.AnswersList[3].AnswerText = words[k + 5];

                        }
                     else
                        {

                            question.AnswersList = new Answer[5];
                            question.AnswersList[0].AnswerText = words[k + 2];
                            question.AnswersList[1].AnswerText = words[k + 3];
                            question.AnswersList[2].AnswerText = words[k + 4];
                            question.AnswersList[3].AnswerText = words[k + 5];
                            question.AnswersList[3].AnswerText = words[k + 6];

                        }

                        k++;
                    subject.SubjectExam.Questions.Add(question);

                    }

                    ExaminationSystem.Subjects.Add(subject);


                }
                

            }

        }


    }
}

#region class version
// problem : can't cast List<Teacher> to List<Character>

//static public List<Teacher> Teachers;
//static public List<Student> Students;
//static public List<Manager> Managers;


//static ExaminationSystem()
//{
//Teachers = new List<Teacher>();
//Students = new List<Student>();
//Managers = new List<Manager>();

//}

//public static bool ExistInSystem(int id, List<Character> characters, out string name)
//{

//    for (int i = 0; i < characters.Count; i++)
//    {
//        if (characters[i].Id == id)
//        {
//            name = characters[i].Name;
//            return true;
//        }

//    }
//    name = "";
//    return false;
//}

#endregion
