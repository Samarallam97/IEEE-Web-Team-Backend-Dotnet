using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal class Character
    {
        public string Name { get; set; }
        public int Id { get; set; }

        public Character(string name, int id)
        {
            Name = name;
            Id = id;
        }

        //public virtual static void ViewOptions() { } 

    }


}
