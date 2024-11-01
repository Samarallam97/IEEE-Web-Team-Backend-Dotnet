using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal struct Answer
    {
        public int AnswerId { get; set; }
        public string AnswerText{ get; set; }

        public Answer(string answer)
        {
            AnswerText = answer;    
        }


    }
}
