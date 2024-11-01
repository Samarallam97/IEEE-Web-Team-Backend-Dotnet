namespace DataAnalyser
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region User stories 
            // as a user , i want file analyzer to count the toatal number of words in each txt file
            //  as a user , i want file analyzer to count the toatal number of chars in each txt file
            //  as a user , i want file analyzer to count the toatal number of lines in each txt file
            //  as a user , i want file analyzer to count the toata number of fields in each csv file

            // csv file => used to save tables in txt format
            // interface name => express behaviour
            // -------->  : impelementing interface arrow
            // straight & bold  : inheritance arrow
            // - => private
            // + => public

            // lightweight => struct , less memory

            #endregion

            Console.WriteLine("welcome !");
            Console.WriteLine("enter folde path where your files exist");

            string folderPath = Console.ReadLine();

            DirectoryInfo folderInfo = new DirectoryInfo(folderPath);

            if ( !folderInfo.Exists)
            {
                Console.WriteLine("not valid path");
                return; // main
            }
            else
            {
                // excetention methods
                // adding methods to classes that already exist in net
                // its name is the same as the class that you want to extend + Exetenstions

                var files = folderInfo.GetFiles();
                IFileAnalysis fileAnalysis;


                foreach (var file in files)
                {
                   if (file.IsText())
                    {
                        fileAnalysis = new TxtFileAnalyzer();
                        fileAnalysis.AnalysizeFile(file); // goes to interface method
                        var results = ((FileAnalyzer)fileAnalysis).Results; // polymarphism

                        Console.WriteLine($"file name {file.Name}");
                        Console.WriteLine($"word count : {results.WordCount}");
                        Console.WriteLine($"char count : {results.CharCount}");
                        Console.WriteLine($"line count : {results.LineCount}");


                    }
                    else if (file.IsCsv())
                    {
                        fileAnalysis = new CsvFileAnalyzer();
                        fileAnalysis.AnalysizeFile(file); // goes to interface method
                        var results = ((FileAnalyzer)fileAnalysis).Results;// polymarphism

                        Console.WriteLine($"file name {file.Name}");
                        Console.WriteLine($"field count : {results.FieldCount}"); 
                       
                    }
                }


            }



        }
    }
}
