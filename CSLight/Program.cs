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
            // Задание: Кадровый учёт: 
           
            string[] fios = new string[0];
            string[] posts = new string[0];
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
                        AddDossier(ref fios,ref posts);
                        break;
                    case "2":
                        ShowDossier(ref fios, ref posts);
                        break;
                    case "3":
                        DeleteDossier(ref fios, ref posts);
                        break;
                    case "4":
                        SearchOfFio(ref fios, ref posts);
                        break;
                    case "5":
                        isWorking = false;
                        break;
                }
                Console.ReadKey();
                Console.Clear();
            }
        }

        static void AddDossier(ref string[] fios,ref string[] posts)
        {
            string fio;
            string post;

            Console.WriteLine("Введите Ваши ФИО:");
            fio = Console.ReadLine();
            Console.WriteLine("Введите Вашу должность:");
            post = Console.ReadLine();

            string[] tempFios = new string[fios.Length + 1];

            for (int i = 0; i < fios.Length; i++)
            {
                tempFios[i] = fios[i];
            }
            tempFios[tempFios.Length - 1] = fio;
            fios = tempFios;

            string[] tempPosts = new string[posts.Length + 1];

            for (int i = 0; i < posts.Length; i++)
            {
                tempPosts[i] = posts[i];
            }
            tempPosts[tempPosts.Length - 1] = post;
            posts = tempPosts;
        }

        static void ShowDossier(ref string[] fios, ref string[] posts)
        {
            int numberToCorrectInputOrUotput = 1;
            Console.WriteLine("Вот список досье:\n");

            for (int i = 0; i < fios.Length; i++)
            {
                for (int j = 0; j < posts.Length; j++)
                {
                    if (i == j)
                    {
                        Console.Write((i + numberToCorrectInputOrUotput) + ") " + fios[i] + " - " + posts[j] + ", ");
                    }
                }
            }
        }

        static void DeleteDossier(ref string[] fios, ref string[] posts)
        {
            int DossierToDelete;
            int numberToCorrectInputOrUotput = 1;

            Console.WriteLine("Какое по счёту досье вы хотите удалить?");
            DossierToDelete = Convert.ToInt32(Console.ReadLine());

            if (DossierToDelete > fios.Length || DossierToDelete > posts.Length)
            {
                Console.WriteLine("Такого досье нет, введите корректный номер досье");
            }
            else
            {
                string[] tempFios = new string[fios.Length - 1];

                for (int i = 0; i < DossierToDelete - numberToCorrectInputOrUotput; i++)
                {
                    tempFios[i] = fios[i];
                }

                for (int i = DossierToDelete; i < fios.Length; i++)
                {
                    tempFios[i - 1] = fios[i];
                }
                fios = tempFios;

                string[] tempPosts = new string[posts.Length - 1];

                for (int i = 0; i < DossierToDelete - numberToCorrectInputOrUotput; i++)
                {
                    tempPosts[i] = posts[i];
                }

                for (int i = DossierToDelete; i < posts.Length; i++)
                {
                    tempPosts[i - 1] = posts[i];
                }
                posts = tempPosts;
            } 
        }

        static void SearchOfFio(ref string[] fios, ref string[] posts)
        {
            string inputedFamilia;
            string familia;
            int numberOfDossier;
            int numberToCorrectInputOrUotput = 1;

            Console.WriteLine("Введите фамилию и мы покажем вам это досье:");
            inputedFamilia = Console.ReadLine();

            for (int i = 0; i < fios.Length; i++)
            {
                familia = fios[i];
                string[] separateFio = familia.Split(' ');

                for (int j = 0; j < separateFio.Length; j++)
                {
                    if (separateFio[j] == inputedFamilia)
                    {
                        numberOfDossier = i;

                        Console.WriteLine("Вот это досье:\n");

                        for (int y = 0; y < fios.Length; y++)    
                        {
                            for (int u = 0; u < posts.Length; u++)
                            {
                                if (y == numberOfDossier && y == u)
                                {
                                    Console.Write((y + numberToCorrectInputOrUotput) + ") " + fios[y] + " - " + posts[u] + ", ");
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}


