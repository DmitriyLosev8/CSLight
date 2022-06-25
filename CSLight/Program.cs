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
            // Задание: Кадровый учёт:   недоделанное

            string[] fio = new string[0];
            string[] post = new string[0];
           // string noteToFio;
            //string noteToPost = "";
            string userInformation;
            string userInput;
            bool isWorking = true;

            

            while (isWorking)
            {
                Console.SetCursorPosition(45, 0);
                Console.WriteLine("ПЕРЕД ВАМИ ПРОГРАММА КАДРОВОГО УЧЁТА");
                Console.SetCursorPosition(0, 2);
                Console.WriteLine("Нажмите 1, чтобы добавить досье\nНажмите 2, чтобы показать все досье\nНажмите 3, чтобы удалить какое-то досье\n" +
                    "Нажмите 4, для поиска досье по фамилии\nНажмите 5, чтобы выйти\n\n");
                userInput = Console.ReadLine();
                
                switch (userInput)
                {
                    case "1":
                        Console.WriteLine("Введите Ваши ФИО:");
                        userInformation = Console.ReadLine();
                        AddDossier(fio, userInformation);
                        Console.WriteLine("Введите Вашe должность:");
                        userInformation = Console.ReadLine();
                        AddDossier(post, userInformation);

                        Console.WriteLine("Вот список досье:\n");

                        for (int i = 0; i < fio.Length; i++)
                        {
                            for (int j = 0; j < post.Length; j++)
                            {
                                Console.Write(fio[i] + post[j] + "-");   //(i + 1) + ") " + 
                            }
                        }

                        break;
                    case "2":
                        Console.WriteLine("Вот список досье:\n");

                        for (int i = 0; i < fio.Length; i++)
                        {
                            for (int j = 0; j < post.Length; j++)
                            {
                                Console.Write((i + 1) + ") " + fio[i] + post[j] + "-");
                            }
                        }
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    case "5":
                        isWorking = false;
                        break;
                }
                Console.ReadKey();
                //Console.Clear();
                Console.SetCursorPosition(45, 0);
                Console.WriteLine("ПЕРЕД ВАМИ ПРОГРАММА КАДРОВОГО УЧЁТА");
                Console.SetCursorPosition(0, 2);
                Console.WriteLine("Нажмите 1, чтобы добавить досье\nНажмите 2, чтобы показать все досье\nНажмите 3, чтобы удалить какое-то досье\n" +
                    "Нажмите 4, для поиска досье по фамилии\nНажмите 5, чтобы выйти\n\n");
                userInput = Console.ReadLine();

                //Console.ReadKey();
            }
        }

        static string[] AddDossier(string[] partOfDossier, string userInformation)
        {
            string[] tempPartOfDossier = new string[partOfDossier.Length + 1];

            for (int i = 0; i < partOfDossier.Length; i++)
            {
                tempPartOfDossier[i] = partOfDossier[i];
            }
            tempPartOfDossier[tempPartOfDossier.Length - 1] = userInformation;
            partOfDossier = tempPartOfDossier;
            return partOfDossier;
        }

    }
}


