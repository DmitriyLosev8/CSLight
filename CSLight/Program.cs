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
        {      //Задание: кадровый учёт продвинутый:

            Dictionary<string, string> dossiers = new Dictionary<string, string>();
            bool isWorking = true;
            string userInput;

            while (isWorking)
            {
                Console.SetCursorPosition(45, 0);
                Console.WriteLine("ПЕРЕД ВАМИ ПРОГРАММА КАДРОВОГО УЧЁТА");
                Console.SetCursorPosition(0, 2);
                Console.WriteLine("Нажмите 1, чтобы добавить досье\nНажмите 2, чтобы показать все досье\nНажмите 3, чтобы удалить какое-то досье\n" +
                    "Нажмите 4, чтобы выйти\n\n");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        AddDossier(dossiers);
                        break;
                    case "2":
                        ShowDossier(dossiers);
                        break;
                    case "3":
                        DeleteDossier(dossiers);
                        break;
                    case "4":
                        isWorking = false;
                        break;
                }
                Console.ReadKey();
                Console.Clear();
            }
        }

        static void AddDossier(Dictionary<string, string> dossiers)
        {
            string fullName;
            string post;
            Console.WriteLine("Введите ФИО:");
            fullName = Console.ReadLine();
            Console.WriteLine("Введите должность:");
            post = Console.ReadLine();

            if (dossiers.ContainsKey(fullName))
            {
                Console.WriteLine("Такая запись уже есть, попробуйте снова.");
            }
            else
            {
                dossiers.Add(fullName, post);
            }
        }

        static void ShowDossier(Dictionary<string, string> dossiers)
        {
            Console.WriteLine("Вот все досье:");
            foreach (var dossier in dossiers)
            {
                Console.Write($"{dossier.Key} - {dossier.Value}, ");
            }
        }

        static void DeleteDossier(Dictionary<string, string> dossiers)
        {
            string dosierToDelete;
            Console.WriteLine("Введите ФИО человека, досье которого хотите удалить:");
            dosierToDelete = Console.ReadLine();

            if (dossiers.ContainsKey(dosierToDelete))
            {
                dossiers.Remove(dosierToDelete);
            }
            else
            {
                Console.WriteLine("Вы ввели неверные данные, попробуйте снова.");
            }
        }
    }
}
