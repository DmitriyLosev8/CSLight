using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CSLight
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Задание: Brave new world:

            Console.CursorVisible = false;
            char player = '@';
            char money = '$';
            int coordinateOfPlayerX = 8;
            int coordinateOfPlayerY = 6;
            bool isPlaying = true;
            char wall = '#';
            int bag = 0;

            char[,] map = { {'#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#'},
                            {'#',' ',' ',' ','#',' ',' ',' ',' ',' ','#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
                            {'#','$',' ',' ','#',' ',' ',' ',' ',' ','#',' ',' ','#',' ',' ',' ',' ',' ',' ',' ','$',' ','#'},
                            {'#',' ',' ',' ','#','$',' ',' ','$',' ','#',' ',' ','#',' ','$',' ',' ',' ',' ',' ',' ',' ','#'},
                            {'#',' ',' ',' ','#',' ',' ',' ',' ',' ','#',' ',' ','#',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
                            {'#',' ',' ',' ','#',' ',' ',' ',' ',' ','#',' ',' ','#',' ',' ',' ','#','#','#','#','#','#','#'},
                            {'#',' ',' ',' ','#',' ',' ',' ',' ',' ','#',' ',' ','#',' ',' ',' ','#',' ',' ',' ',' ',' ','#'},
                            {'#',' ','#','#','#',' ','$',' ',' ',' ',' ',' ',' ','#',' ',' ',' ','#',' ',' ',' ',' ',' ','#'},
                            {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ','#',' ',' ','#',' ',' ',' ','#',' ','$',' ',' ',' ','#'},
                            {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ','#',' ',' ','#',' ',' ',' ','#',' ',' ',' ',' ',' ','#'},
                            {'#','$',' ',' ','$',' ',' ',' ',' ',' ','#',' ',' ','#',' ',' ',' ','#',' ',' ',' ',' ',' ','#'},
                            {'#',' ',' ',' ',' ',' ',' ',' ','$',' ','#',' ',' ','#',' ','$',' ','#',' ',' ',' ','$',' ','#'},
                            {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ','#',' ',' ','#',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
                            {'#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#'} };

            while (isPlaying)
            {
                Console.SetCursorPosition(0, 20);
                Console.WriteLine("В вашей сумке " + bag + " денег");

                DrawMap(map);
                MoveOfPlayer(map, player, wall, ref coordinateOfPlayerX, ref coordinateOfPlayerY); 
                CollectMoney(map, money, ref bag, coordinateOfPlayerY, coordinateOfPlayerX);
                Console.Clear();
            }
        }

        static void DrawMap(char[,] map)
        {
            Console.SetCursorPosition(0, 0);

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j]);
                }
                Console.WriteLine();
            }
        }

        static void MoveOfPlayer(char[,] map, char player, char wall, ref int coordinateOfPlayerX, ref int coordinateOfPlayerY)
        {
            Console.SetCursorPosition(coordinateOfPlayerY, coordinateOfPlayerX);
            Console.WriteLine(player);
            ConsoleKeyInfo userInput = Console.ReadKey();

            switch (userInput.Key)
            {
                case ConsoleKey.UpArrow:
                    if (map[coordinateOfPlayerX - 1, coordinateOfPlayerY] != wall)
                    {
                        coordinateOfPlayerX--;
                        Console.SetCursorPosition(coordinateOfPlayerY, coordinateOfPlayerX);
                        Console.Write(player);
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (map[coordinateOfPlayerX + 1, coordinateOfPlayerY] != wall)
                    {
                        coordinateOfPlayerX++;
                        Console.SetCursorPosition(coordinateOfPlayerY, coordinateOfPlayerX);
                        Console.WriteLine(player);
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (map[coordinateOfPlayerX, coordinateOfPlayerY - 1] != wall)
                    {
                        coordinateOfPlayerY--;
                        Console.SetCursorPosition(coordinateOfPlayerY, coordinateOfPlayerX);
                        Console.WriteLine(player);
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (map[coordinateOfPlayerX, coordinateOfPlayerY + 1] != wall)
                    {
                        coordinateOfPlayerY++;
                        Console.SetCursorPosition(coordinateOfPlayerY, coordinateOfPlayerX);
                        Console.WriteLine(player);
                    }
                    break;
            }
        }

        static void CollectMoney(char[,] map, char money, ref int bag, int coordinateOfPlayerY, int coordinateOfPlayerX)
        {
            if (map[coordinateOfPlayerX, coordinateOfPlayerY] == money)
            {
                bag++;
                map[coordinateOfPlayerX, coordinateOfPlayerY] = ' ';
            }
        }
    }
}
