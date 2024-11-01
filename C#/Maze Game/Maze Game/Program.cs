namespace Maze_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region User stories
            /// 1. as a --player-- i want to |move| through the --maze-- using arrow keys ,so that i can reach the exit
            /// 2. as a player i want to see the maze |displayed| so that i can understand it
            /// 3. as a palyer i want to see my --character-- represented by a symbol so that i can track my position in the maze
            /// UMLs
            /// interface arrow => dashed & head is empty => goes to UML
            #endregion

 
            Maze maze = new Maze(40, 20);

            while (true)
            {
                maze.DrawMaze();
                maze.MovePlayer();
            }
           



        }
    }
}
