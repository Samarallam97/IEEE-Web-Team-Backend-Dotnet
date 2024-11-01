using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAnalyser
{
    internal class FileAnalyzer
    {
        AnalysisResults results;
        public AnalysisResults Results {
            get { return results; }
            set { results = value; } // validation => encapsulation
        }

    }
}
