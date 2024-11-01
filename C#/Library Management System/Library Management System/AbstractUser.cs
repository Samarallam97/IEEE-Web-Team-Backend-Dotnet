using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    abstract class AbstractUser
    {
        public string Name { get; set; }

         public static void Display()
        {
            Library.displayAll();
        }

    }
}
