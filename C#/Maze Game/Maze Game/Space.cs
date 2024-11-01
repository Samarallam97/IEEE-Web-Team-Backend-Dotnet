using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze_Game
{
    internal class Space : IMazeObject
    {
        public char Icon => ' ';

        public bool IsSolid => false;
    }
}
