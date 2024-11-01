using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAnalyser
{
    /// excetension methods
    public static class FileInfoExtensions
    {
        public static bool IsText(this FileInfo fileInfo) // don't forget this
        {
            return fileInfo.Extension == ".txt";
        }

        public static bool IsCsv(this FileInfo fileInfo)
        {
            return fileInfo.Extension == ".csv";
        }

    }
}
