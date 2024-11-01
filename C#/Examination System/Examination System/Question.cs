using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal class Question
    {
        public string Body { get; set; }
        public int Mark { get; set; }
        public  Answer[] AnswersList { get; set; }


        public Question(string body , int mark)
        {
            Body = body;
            Mark = mark;
        }

        public virtual void CreateQuestion(out string body, out int mark) {
            body = "";
            mark = 0;
        }
        public virtual void ShowQuestion() { }

    }

}
