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
            int directionX = 0; 
            int directionY = 0;
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
                DrawPlayer(coordinateOfPlayerX, coordinateOfPlayerY, player);
                ChangeDirection(map, ref directionX, ref directionY);
                MoveOfPlayer(map, wall, ref coordinateOfPlayerX, ref coordinateOfPlayerY, directionX, directionY);
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

        static void DrawPlayer(int coordinateOfPlayerX, int coordinateOfPlayerY, char player)
        {
            Console.SetCursorPosition(coordinateOfPlayerY, coordinateOfPlayerX);
            Console.WriteLine(player);
        }

        static void MoveOfPlayer(char[,] map, char wall, ref int coordinateOfPlayerX, ref int coordinateOfPlayerY, int directionX, int directionY)
        {

            if (map[coordinateOfPlayerX + directionX, coordinateOfPlayerY + directionY] != wall)
            {
                coordinateOfPlayerX += directionX;
                coordinateOfPlayerY += directionY;
            }
        }

        static void ChangeDirection(char[,] map, ref int directionX, ref int directionY)
        {
            ConsoleKeyInfo userInput = Console.ReadKey();

            switch (userInput.Key)
            {
                case ConsoleKey.UpArrow:
                    directionX = -1;
                    directionY = 0;
                    break;
                case ConsoleKey.DownArrow:
                    directionX = 1;
                    directionY = 0;
                    break;
                case ConsoleKey.LeftArrow:
                    directionX = 0;
                    directionY = -1;
                    break;
                case ConsoleKey.RightArrow:
                    directionX = 0;
                    directionY = 1;
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
