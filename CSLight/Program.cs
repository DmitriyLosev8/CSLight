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
        {      // Задание: База данных игроков:      

            bool isWorking = true;
            int userInput;
            Database database = new Database();

            while (isWorking)
            {
                bool isSuccessfull;
                Console.SetCursorPosition(35, 0);
                Console.WriteLine("Перед вами консоль управления базой данных игроков:");
                Console.SetCursorPosition(0, 2);
                Console.WriteLine("Чтобы добавить игрока, нажмите 1\nЧтобы удалить угрока по уникальному номеру нажмите 2\nЧтобы забанить игрока по уникальному номеру,нажмите 3\n" +
                    "Чтобы разбанить игрока по уникальному номеру, нажмите 4\nЧтобы посмотреть забанненых игроков, нажмите 5\nЧтобы посмотреть" +
                    " не забаненных игроков, нажмите 6\nЧтобы выйти, нажмите 7");

                isSuccessfull = int.TryParse(Console.ReadLine(), out userInput);

                if (isSuccessfull == false)
                {
                    Console.WriteLine("Вы ввели не число");
                }
                else
                {
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
        }

        class Database
        {
            private List<Player> _players = new List<Player>();

            public void AddPlayer()
            {
                string userNickName;
                int userLevel;
                bool isBanned = false;
                bool isSuccessfull;

                Console.WriteLine("Введите ник игрока");
                userNickName = Console.ReadLine();
                Console.WriteLine("Введите уровень игрока");
                isSuccessfull = int.TryParse(Console.ReadLine(), out userLevel);

                if (isSuccessfull == false)
                {
                    Console.WriteLine("Вы ввели не число");
                }
                else
                {
                    _players.Add(new Player(userNickName, userLevel, isBanned));
                }
            }

            public void DeletePlayer()
            {
                _players.RemoveAt(GetindexOfPlayer());
            }

            public void BanPlayer()
            {
                _players[GetindexOfPlayer()].Ban();
            }

            public void UnBanPlayer()
            {
                _players[GetindexOfPlayer()].UnBan();
            }

            public void ShowNotBannedPlayers()
            {
                Console.WriteLine("Вот список не забанненых игроков:\n");
                for (int i = 0; i < _players.Count; i++)
                {
                    if (_players[i].IsBanned == false)
                    {
                        Console.WriteLine($"Уникальный номер игрока - {_players[i].Id}, его ник - {_players[i].NickName}, а его уровень - {_players[i].Level}");
                    }
                }
            }

            public void ShowBannedPlayers()
            {
                Console.WriteLine("Вот список забанненых игроков:\n");
                for (int i = 0; i < _players.Count; i++)
                {
                    if (_players[i].IsBanned == true)
                    {
                        Console.WriteLine($"Уникальный номер игрока - {_players[i].Id}, его ник - {_players[i].NickName}, а его уровень - {_players[i].Level}");
                    }
                }
            }

            private int GetindexOfPlayer()
            {
                int indexOfPlayer = 0;
                bool isSuccessfull;
                int userNumber;
                Console.WriteLine("Введите уникальный номер игрока:");
                isSuccessfull = int.TryParse(Console.ReadLine(), out userNumber);

                if (isSuccessfull == false)
                {
                    Console.WriteLine("Вы ввели не число");
                }
                else
                {
                    for (int i = 0; i < _players.Count; i++)
                    {
                        if (_players[i].Id == userNumber)
                        {
                            indexOfPlayer = i;
                        }
                    }
                }
                return indexOfPlayer;
            }
        }

        class Player
        {
            private static int _ids;

            public string NickName { get; private set; }
            public int Id { get; private set; }
            public int Level { get; private set; }
            public bool IsBanned { get; private set; }
 
            public Player(string nickName, int level, bool IsBanned)
            {
                NickName = nickName;
                IsBanned = false;
                Level = level;
                Id = ++_ids;
            }

            public void Ban()
            {
                IsBanned = true;
            }

            public void UnBan()
            {
                IsBanned = false;
            }
        }
    }
}












