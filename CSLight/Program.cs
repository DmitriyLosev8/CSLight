using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;                       //мы вбили это, чтобы мы могли работать с файлами внутри компа

namespace CSLight    //Создание игры Pac-Man 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Random random = new Random();
            bool isPlaing = true;
            int pacmanX, pacmanY;
            bool isAlive = true;  
            int ghostX, ghostY;  
            char pacman = '@';
            char enemyOfPacman = '$';
            int allBerries = 0;
            int collectBerries = 0;
            int pacmanDX = 0, pacmanDY = 1;
            int enemyDX = 0, enemyDY = - 1; 
           
            char[,] map = ReadMap("map1", out pacmanX, out pacmanY, out ghostX, out ghostY, ref allBerries);  
            
            DrawMap(map);

            while (isPlaing)
            {
                Console.SetCursorPosition(0, 20);
                Console.WriteLine($"Собранно {collectBerries}/{allBerries}");

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    ChangeDirection(key, ref pacmanDX, ref pacmanDY);
                }

                if (map[pacmanX + pacmanDX, pacmanY + pacmanDY] != '#')
                {
                    CollectBerries(map, pacmanX, pacmanY, ref collectBerries);
                    Move(map,pacman, ref pacmanX, ref pacmanY, pacmanDX, pacmanDY);
                    
                }

                if (map[ghostX + enemyDX, ghostY + enemyDY] != '#')
                {
                    Move(map,enemyOfPacman, ref ghostX, ref ghostY, enemyDX, enemyDY);
                }
                else
                {
                    ChangeDirection(random,ref enemyDX, ref enemyDY);
                }

                System.Threading.Thread.Sleep(200);

                if (ghostX == pacmanX && ghostY == pacmanY)
                {
                    isAlive = false;
                }
                
                if(collectBerries == allBerries || !isAlive)
                {
                    isPlaing = false;
                }
 
                if (collectBerries == allBerries)
                {
                    Console.SetCursorPosition(40, 15);
                    Console.WriteLine("Вы победили!"); 
                }
                else if (!isAlive)
                {
                    Console.SetCursorPosition(40, 15);
                    Console.WriteLine("Вас съели!");
                }
            }
        }

        static void Move(char[,] map,char symbol,ref int X, ref int Y, int DX, int DY)
        {
            Console.SetCursorPosition(Y, X);
            Console.Write(map[X,Y]);   

            X += DX;
            Y += DY;

            Console.SetCursorPosition(Y, X);
            Console.Write(symbol);
        }

        static void CollectBerries(char[,] map, int pacmanX, int pacmanY, ref int collectBerries)
        {
            if (map[pacmanX, pacmanY] == '.')

            {
                collectBerries++;
                map[pacmanX, pacmanY] = ' ';
            }
        }
        static void ChangeDirection(ConsoleKeyInfo key, ref int DX, ref int DY)
        {
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    DX = -1; DY = 0;
                    break;
                case ConsoleKey.DownArrow:
                    DX = 1; DY = 0;
                    break;
                case ConsoleKey.LeftArrow:
                    DX = 0; DY = -1;
                    break;
                case ConsoleKey.RightArrow:
                    DX = 0; DY = 1;
                    break;
            }
        }

        static void ChangeDirection(Random random, ref int DX, ref int DY)   
        {
            int ghostDirection = random.Next(1, 5);  

            switch (ghostDirection)
            {
                case 1:
                    DX = -1; DY = 0;
                    break;
                case 2:
                    DX = 1; DY = 0;
                    break;
                case 3:
                    DX = 0; DY = -1;
                    break;
                case 4:
                    DX = 0; DY = 1;
                    break;                       
            }
        }
        static void DrawMap(char[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j]);
                }
                Console.WriteLine();
            }
        }
        static char[,] ReadMap(string mapName, out int pacmanX, out int pacmanY, out int ghostX, out int ghostY, ref int allBerries) 
        {
            pacmanX = 0;
            pacmanY = 0;
            ghostX = 0;   
            ghostY = 0;

            string[] newFile = File.ReadAllLines($"Maps/{mapName}.txt");

            char[,] map = new char[newFile.Length, newFile[0].Length];

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    map[i, j] = newFile[i][j];

                    if (map[i, j] == '@')
                    {
                        pacmanX = i;
                        pacmanY = j;
                        map[i, j] = '.';
                    }
                    else if (map[i,j] == '$')   
                    {
                        ghostX = i;       
                        ghostY = j;
                        map[i, j] = '.';
                    }
                    else if (map[i, j] == ' ')
                    {
                        map[i, j] = '.';
                        allBerries++;
                    }
                }
            }
            return map;
        }
    }
}
