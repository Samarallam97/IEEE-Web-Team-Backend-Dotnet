using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze_Game
{
    internal class Maze
    {
         int Width;
         int Height;
        Player player;

        private IMazeObject[,] MazeObjects;

        public Maze(int width , int height)
        {
            Width = width;
            Height = height;    
            MazeObjects = new IMazeObject[Width, Height]; // 2d arrayy of width & height
            player = new Player() { X =1 , Y =1}; // fixed place
            
        }

        public void MovePlayer()
        {
            // you can use var
            ConsoleKeyInfo input = Console.ReadKey(); // returns :  public readonly struct ConsoleKeyInfo 
                                                      // has prop : ConsoleKey Key 
                                                      // ConsoleKey : public enum ConsoleKey 
            ConsoleKey Key = input.Key;

            switch (Key)
            {
                case ConsoleKey.UpArrow:
                    UpdatePlayer(0, -1);
                    break;
                case ConsoleKey.DownArrow:
                    UpdatePlayer(0, 1);
                    break;
                case ConsoleKey.LeftArrow:
                    UpdatePlayer(-1, 0);
                    break;
                case ConsoleKey.RightArrow:
                    UpdatePlayer(1, 0);
                    break;
                default:
                    break;

            }

        }

        private void UpdatePlayer(int dx , int dy)
        {
            int newX = player.X + dx;
            int newY = player.Y + dy;

            if (newX < Width && newX >=0 && newY < Height && newY >=0 && MazeObjects[newX,newY].IsSolid == false)
            {
                player.X = player.X + dx;
                player.Y = player.Y + dy;
                DrawMaze();
            }
            
        }
        // 2d array
        public void DrawMaze()
        {
            Console.Clear();

            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                { 
                    // exit
                    if ( x ==39 && y ==19 )
                    {
                        MazeObjects[x, y] = new Space(); // casting
                        Console.Write(MazeObjects[x, y].Icon);
                    }
                    // outer walls
                    else if(x == 0 || y == 0 || x == Width -1 || y == Height -1)
                    {
                        //Console.WriteLine(((Wall)MazeObjects[x, y]).Icon);
                        MazeObjects[x, y] = new Wall(); // casting
                        Console.Write(MazeObjects[x, y].Icon);
                    }
                    else if (x == player.X && y == player.Y)
                    {
                        Console.Write(player.Icon);
                    }
                    else if(x %3 ==0 && y %3 ==0)
                    {
                        MazeObjects[x, y] = new Wall(); // casting
                        Console.Write(MazeObjects[x, y].Icon);
                    }
                    else if (x % 5 == 0 && y % 5 == 0)
                    {
                        MazeObjects[x, y] = new Wall(); // casting
                        Console.Write(MazeObjects[x, y].Icon);
                    }
                    // empty spaces
                    else
                    {
                        MazeObjects[x, y] = new Space(); // casting
                        Console.Write(MazeObjects[x, y].Icon);
                    }
                   
                }
                Console.WriteLine();
            }
        }
    }
}
