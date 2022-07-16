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
        {      // Задание: База данных игроков:      Лист - доработать проверку на уникальный номер

            bool isWorking = true;
            int userInput;
            Database database = new Database();

            while (isWorking)
            {
                Console.SetCursorPosition(35, 0);
                Console.WriteLine("Перед вами консоль управления базой данных игроков:");
                Console.SetCursorPosition(0, 2);
                Console.WriteLine("Чтобы добавить игрока, нажмите 1\nЧтобы удалить угрока по уникальному номеру нажмите 2\nЧтобы забанить игрока по уникальному номеру,нажмите 3\n" +
                    "Чтобы разбанить игрока по уникальному номеру, нажмите 4\nЧтобы посмотреть забанненых игроков, нажмите 5\nЧтобы посмотреть" +
                    "не забаненных игроков, нажмите 6\nЧтобы выйти, нажмите 7");

                userInput = Convert.ToInt32(Console.ReadLine());

                switch (userInput)
                {
                    case 1:
                        database.AddPlayer();
                        break;
                    case 2:
                       database.DeletePlayer();
                        break;
                    case 3:
                        database.BanPlayer();
                        break;
                    case 4:
                        database.UnBanPlayer();
                        break;
                    case 5:
                        database.ShowBannedPlayers();
                        break;
                    case 6:
                        database.ShowNotBannedPlayers();
                        break;
                    case 7:
                        isWorking = false;
                        break;
                }
                Console.ReadKey();
                Console.Clear();
            }
        }

        class Database
        {
            public List<Player> Players { get; private set; } = new List<Player>();

            public void AddPlayer()
            {
                string userNickName;
                int userNumber;
                int userLevel;
                bool isNotUnique = true;
                bool isBanned = false;

                Console.WriteLine("Введите ник игрока");
                userNickName = Console.ReadLine();
                Console.WriteLine("Введите уровень игрока");
                userLevel = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите уникальный номер игрока");
                userNumber = Convert.ToInt32(Console.ReadLine());
                Players.Add(new Player(userNickName, userLevel, isBanned, userNumber));


                //Попытка проверить на уникальный номер, но новый элемент не добавляется
                //while (isNotUnique)
                //{
                //    Console.WriteLine("Введите ник игрока");
                //    userNickName = Console.ReadLine();
                //    Console.WriteLine("Введите уровень игрока");
                //    userLevel = Convert.ToInt32(Console.ReadLine());
                //    Console.WriteLine("Введите уникальный номер игрока");
                //    userNumber = Convert.ToInt32(Console.ReadLine());
                //    Players.Add(new Player(userNickName, userLevel, isBanned, userNumber));

                //    for (int i = 0; i < Players.Count; i++)
                //    {
                //        if (Players[i].Id == userNumber)
                //        {
                //            Console.WriteLine("Запись с таким номером уже есть, введите данные заново.");

                //        }
                //        else
                //        {
                //            Players.Add(new Player(userNickName, userLevel, isBanned, userNumber));
                //            isNotUnique = false;
                //        }
                //    }
                //}
            }

            public void DeletePlayer()
            {
                Console.WriteLine("Введите уникальный номер игрока, которого хотите удалить:");
                int userNumber = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < Players.Count; i++)
                {
                    if (Players[i].Id == userNumber)
                    {
                        Players.RemoveAt(i);
                    }
                    else
                    {
                        Console.WriteLine("Игрока под таким номером нет.");
                    }
                }
            }

            public void BanPlayer()
            {
                bool isBanned = true;
                Console.WriteLine("Введите уникальный номер игрока, которого хотите забанить:");
                int userNumber = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < Players.Count; i++)
                {
                    if (Players[i].Id == userNumber)
                    {
                        Players[i].Ban(isBanned);
                    }
                    else
                    {
                        Console.WriteLine("Игрока под таким номером нет.");
                    }
                }
            }

            public void UnBanPlayer()
            {
                bool isBanned = false;
                Console.WriteLine("Введите уникальный номер игрока, которого хотите разбанить:");
                int userNumber = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < Players.Count; i++)
                {
                    if (Players[i].Id == userNumber)
                    {
                        Players[i].Ban(isBanned);
                    }
                    else
                    {
                        Console.WriteLine("Игрока под таким номером нет.");
                    }
                }
            }

            public void ShowNotBannedPlayers()
            {
                Console.WriteLine("Вот список не забанненых игроков:\n");
                for (int i = 0; i < Players.Count; i++)
                {
                    if (Players[i].IsBanned == false)
                    {
                        Console.WriteLine($"Уникальный номер игрока - {Players[i].Id}, его ник - {Players[i].NickName}, а его уровень - {Players[i].Level}");
                    }  
                }
            }

            public void ShowBannedPlayers()
            {
                Console.WriteLine($"Вот список забанненых игроков:\n");
                for (int i = 0; i < Players.Count; i++)
                {
                    if (Players[i].IsBanned == true)
                    {
                        Console.WriteLine($"Уникальный номер игрока - {Players[i].Id}, его ник - {Players[i].NickName}, а его уровень - {Players[i].Level}");
                    }
                }
            }
        }
       
        class Player
        {
            public string NickName { get; private set; }
            public int Id { get; private set; }
            public int Level { get; private set; }
            public bool IsBanned { get; private set; }

            public Player(string nickName, int level, bool IsBanned, int id) 
            {
                NickName = nickName;
                IsBanned = false;
                Level = level;
                Id = id;
            }

            public void Ban(bool isBanned)
            {
                IsBanned = isBanned;
            }
        }
    }
}












