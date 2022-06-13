﻿using System;
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

            // Игра бродилка. В ней мы сможем ходить и собирать сокровища. Всё будет визуально отображаться. Все комментарии в коде:

            Console.CursorVisible = false;  // отключаем видимость курсора, чтобы он не мешал игроку, так красивее
            char[,] map =                                                             //для начала нам надо сделать карту, у которой будет рамка из знака #
            {
                {'#','#','#','#','#','#','#','#','#','#','#','#','#','#','#' },
                {'#',' ','#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#' },        //внутри этой карты мы располагаем припятствия (стены) в виде символа #
                {'#',' ','#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#' },
                {'#','X','#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#' },        // также внутри этой карты располагаем сокровища в виде английской большой буквы X
                {'#',' ','#',' ',' ',' ',' ',' ','X',' ',' ',' ','X',' ','#' },
                {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#' },
                {'#',' ','#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#' },
                {'#',' ','#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#' },
                {'#','X','#',' ',' ',' ',' ',' ','X',' ',' ',' ',' ',' ','#' },
                {'#',' ','#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#' },
                {'#',' ','#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#' },
                {'#','#','#','#','#','#','#','#','#','#','#','#','#','#','#' }
            };

            int userX = 6, userY = 6;   // задаём координаты нашего персонажа по оси X и Y
            char[] bag = new char[0];   // создали сумку (массив) для найденного сокровища.
                                        // При чём массив с нулевым размером, который будем расширять как только что-то найдём


            while (true)    // отрисовывать карту будем через цикл while, который всегда true, потому что карта всегда должна быть изображена и по ней будет ходить игрок
            {
                Console.SetCursorPosition(0, 20);   // отрисовываем сумку ниже карты
                Console.Write("Сумка: ");
                for (int i = 0; i < bag.Length; i++)   //сумку отрисовываем также через цикл for
                {
                    Console.Write(bag[i] + " ");
                }

                Console.SetCursorPosition(0,0);   // отрисовываем карту в нулевых позициях
                for (int i = 0; i < map.GetLength(0); i++)   // стандартный цикл for для перебора всего массива и последующего его отображения
                {
                    for (int j = 0; j < map.GetLength(1); j++)
                    {
                        Console.Write(map[i, j]);     // отображаемый наш массив ( карту)
                    }
                    Console.WriteLine();  // делаем перенос по строкам
                }
                Console.SetCursorPosition(userY, userX);  //X - координата по горизонтали, а Y - по вертикали, НО, чтобы нам было проще понимать,
                                                          //чтобы изменять положение игрока по вертикали, мы будем изменять значение X, 
                                                          // а чтобы изменять положение игрока по горизонтали, мы будем изменять значение Y
                Console.WriteLine('@'); // изображаем нашего персонажа как символ @
                ConsoleKeyInfo charKey = Console.ReadKey();                     // это тип, который хранит в себе информацию о нажатой клавише
                                                                                // Здесь мы получаем инфу о клавише, которую нажал пользователь

                switch (charKey.Key)    //через switch мы обрабатываем эту информацию и работаем с ней (как уже делали раньше с разными менюшками)
                {
                    case ConsoleKey.UpArrow:    // case при котором пользователь нажал стрелку вверх (UpArrow)
                        
                        if (map[userX - 1, userY] != '#')   // это проверка того, что на пути игрока не встретится стена в виде символа #
                        {
                            userX --;    // и если это не происходит, то по координате X делаем минус 1, чтобы игрок (символ @) поднялся вверх
                        }
                            break;
                    case ConsoleKey.DownArrow:   // case при котором пользователь нажал стрелку вниз (DownArrow)

                        if (map[userX + 1, userY] != '#')   // это проверка того, что на пути игрока не встретится стена в виде символа #
                        {
                            userX++;    // и если это не происходит, то по координате X делаем плюс 1, чтобы игрок (символ @) упустился вниз
                        }
                        break;
                    case ConsoleKey.LeftArrow:   // case при котором пользователь нажал стрелку влево (LeftArrow)

                        if (map[userX, userY -1] != '#')   // это проверка того, что на пути игрока не встретится стена в виде символа #
                        {
                            userY --;    // и если это не происходит, то по координате Y делаем минус 1, чтобы игрок (символ @) сдвинулся влево
                        }
                        break;
                    case ConsoleKey.RightArrow:   // case при котором пользователь нажал стрелку вправо (RightArrow)
                        
                        if (map[userX, userY + 1] != '#')   // это проверка того, что на пути игрока не встретится стена в виде символа #
                        {
                            userY++;    // и если это не происходит, то по координате Y делаем плюс 1, чтобы игрок (символ @) сдвинулся вправо
                        }
                        break;
                }

                if (map[userX, userY] == 'X')  /// делаем процесс собирания сокровища. То есть. Если позиция игрока равна позиции сокровища, то
                {
                    map[userX, userY] = 'o';    // тогда это будет равно символу o (отображение, что тут было сокровище и его собрали)

                    char[] tempBag = new char[bag.Length + 1];   // чтобы расширить наш массив bag, создаём временный массив tempBag 
                                                                 // и делаем ему размер массива bag + 1
                    for (int i = 0; i < bag.Length; i++)   //  с помощью цикла for  переносим все данные из массива bag во временный массив tempBag
                    {
                        tempBag[i] = bag[i];
                    }
                    tempBag[tempBag.Length - 1] = 'X';   // тут мы говорим, что когда длина (размер) временного массива становится на 1 меньше,
                                                         // то этому элементу присваивается значение символ X
                    bag = tempBag;  // и тут, с помощью ссылочного типа, заносим эти данные в наш массив bag

                }
                Console.Clear();      // это для того, чтобы консоль очищалась каждую итерацию и не захломлялась
            }

        }
    }
}


