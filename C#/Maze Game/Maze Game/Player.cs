using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze_Game
{
    internal class Player : IMazeObject
    {
        public char Icon =>'@';
        public bool IsSolid => false;

        public int X { get; set; }
        public int Y { get; set; }

    }
}
