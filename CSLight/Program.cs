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
        {      // Задание: База данных игроков:      СЛОВАРЬ - ДОРАБОТАТЬ  бан и разбан

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
            public Dictionary<int, Player> Players { get; private set; } = new Dictionary<int, Player>();

            public void AddPlayer()
            {
                string userNickName;
                int userNumber;
                int userLevel;
                bool isNotUnique = true;
                bool isBanned = false;

                while (isNotUnique)
                {
                    Console.WriteLine("Введите ник игрока");
                    userNickName = Console.ReadLine();
                    Console.WriteLine("Введите уникальный номер игрока");
                    userNumber = Convert.ToInt32(Console.ReadLine());

                    if (Players.ContainsKey(userNumber))
                    {
                        Console.WriteLine("Запись с таким номером уже есть, введите данные заново.");
                    }
                    else
                    {
                        Console.WriteLine("Введите уровень игрока");
                        userLevel = Convert.ToInt32(Console.ReadLine());
                        Players.Add(userNumber, new Player(userNickName, userLevel, isBanned));
                        isNotUnique = false;
                    }
                }
            }

            public void DeletePlayer()
            {
                Console.WriteLine("Введите уникальный номер игрока, которого хотите удалить:");
                int userNumber = Convert.ToInt32(Console.ReadLine());

                if (Players.ContainsKey(userNumber))
                {
                    Players.Remove(userNumber);
                }
                else
                {
                    Console.WriteLine("Игрока под таким номером нет.");
                }
            }

            //тут не получается обратиться к значению словаря, зная конкретный ключ, чтобы изменить значение isBanned
            public void BanPlayer()
            {
                bool isBanned = true;
                Console.WriteLine("Введите уникальный номер игрока, которого хотите забанить:");
                int userNumber = Convert.ToInt32(Console.ReadLine());

                foreach (var player in Players)
                {
                    if (Players.ContainsKey(userNumber))
                    {
                        Console.WriteLine(player.Value.NickName);
                    }
                }
            }

            public void UnBanPlayer()
            {
                bool isBanned = false;
                Console.WriteLine("Введите уникальный номер игрока, которого хотите разбанить:");
                int userNumber = Convert.ToInt32(Console.ReadLine());
                int Key;

                foreach (var player in Players)
                {
                    if (Players.ContainsKey(userNumber))
                    {
                        Console.WriteLine(player.Value.NickName);
                    }
                }
            }

            public void ShowNotBannedPlayers()
            {
                Console.WriteLine("Вот список не забанненых игроков:\n");
                foreach (var player in Players)
                {
                    if (player.Value.IsBanned == false)
                    {
                        Console.WriteLine($"Уникальный номер игрока - {player.Key}, его ник - {player.Value.NickName}, а его уровень {player.Value.Level}");
                    }
                }
            }

            public void ShowBannedPlayers()
            {
                Console.WriteLine($"Вот список забанненых игроков:\n");
                foreach (var player in Players)
                {
                    if (player.Value.IsBanned == true)
                    {
                        Console.WriteLine($"Уникальный номер игрока - {player.Key}, его ник - {player.Value.NickName}, а его уровень {player.Value.Level}");
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

            public Player(string nickName, int level, bool IsBanned) //int id
            {
                NickName = nickName;
                IsBanned = false;
                Level = level;
            }

            public void Ban(bool isBanned)
            {
                IsBanned = isBanned;
            }
        }
    }
}












