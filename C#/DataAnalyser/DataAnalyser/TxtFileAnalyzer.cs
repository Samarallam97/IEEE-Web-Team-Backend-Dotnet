using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAnalyser
{
    internal class TxtFileAnalyzer : FileAnalyzer, IFileAnalysis
    {
        public void AnalysizeFile(FileInfo fileInfo)
        {
            string fileString = File.ReadAllText(fileInfo.FullName);

            AnalysisResults results = new AnalysisResults();
            var words = fileString.Split(new char[] { ' ', '\n', '\r' });
            results.WordCount = words.Length;

            results.CharCount = fileString.Length;
            var lines = fileString.Split(new char[] {'\n'});
            results.LineCount = lines.Length;

            Results = results;
        }
    }
}
