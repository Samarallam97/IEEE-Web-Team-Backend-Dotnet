using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAnalyser
{
    internal class CsvFileAnalyzer : FileAnalyzer, IFileAnalysis
    {
        public void AnalysizeFile(FileInfo fileInfo)
        {
            string[] fileString = File.ReadAllLines(fileInfo.FullName); // string array , each element is a  line

            AnalysisResults results = new AnalysisResults();

            results.FieldCount = fileString[0].Split(",").Length;

            Results = results;

        }
    }
}
