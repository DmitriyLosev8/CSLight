using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;                       //мы вбили это, чтобы мы могли работать с файлами внутри компа

namespace CSLight
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Создание игры "Pac-Man" - Передвижение

            int pacmanX, pacmanY;
            char[,] map = ReadMap("map1", out pacmanX, out pacmanY);  
            
                //координаты персонажа пакман  Чтобы правильно изначально задать координаты пакмана(карты ведь будут меняться) и он не оказался в стене
                                     // надо указать эти координаты в файле, который считывает функция изначально 
            DrawMap(map);
            Console.SetCursorPosition(pacmanY, pacmanX);  //надо рисовать координаты наоборот.
            Console.WriteLine("@");
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

        static char[,] ReadMap(string mapName, out int pacmanX, out int pacmanY)    // добывили в параметры out переменные, потому что надо проинициализировать и перезаписывать в память  
        {

            pacmanX = 0;    //начальная инициализация, чтобы out мог выполниться. Потому что без этого прогрммма считает, что эти координаты не всегда могут быть полученны
                             // (да, в теории там может быть ещё и  else
            pacmanY = 0;

            string[] newFile = File.ReadAllLines($"Maps/{mapName}.txt");   
                                                                 
            char[,] map = new char[newFile.Length, newFile[0].Length];   

            for(int i = 0; i < map.GetLength(0); i++)   
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    
                    map[i, j] = newFile[i][j];
                    
                    if (map[i, j] == '@')    // мы говорим, что если в массиве по двум координатам будет символ собаки, то  pacmanX = i;, а pacmanY = j;
                    {                         // то есть надо поставить туда игрока (в фауле с картой, надо нарисовать этот символ, где будет игрок
                        pacmanX = i;
                        pacmanY = j;
                    }
                }
            }
            return map;
        }
    }
}


