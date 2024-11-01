namespace Quiz_Game
{
    internal class Program
    {
        // object initializer of array must take the full size
         static int score = 0;
        static void Main(string[] args)
        {
            string[] Questions = new string[3]
            {
                "1. what is the capital og italy",
                "2.",""
            };

            string[] Answers = new string[3]
{
                "1. what is the capital og italy",
                "2.",""
            };

            Console.WriteLine("answer");
            try
            {
                for (int i = 0; i < Questions.Length; i++)
                {
                    Console.WriteLine(Questions[i]);
                    string input = Console.ReadLine() ?? "";
                    Console.WriteLine(Compare(input, Answers[i]));
                    Console.WriteLine($"correct answer : {Answers[i]}");

                }
            }
            catch(Exception ex) {
                Console.WriteLine(ex.Message);
            }
           
            Console.WriteLine("Quiz completed");

        }
        private static bool Compare (string input , string answer) {
            // exception handling
            if (string.IsNullOrEmpty(input)) 
                throw new Exception("answercan't be empty");
            return input.ToLower() == answer.ToLower();
        }
    }
}
