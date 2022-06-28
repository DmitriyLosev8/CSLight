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

            string[] fullNames = new string[0];
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
                        AddDossier(ref fullNames, ref posts); 
                        break;
                    case "2":
                        ShowDossier(ref fullNames, ref posts);
                        break;
                    case "3":
                        DeleteDossier(ref fullNames, ref posts);
                        break;
                    case "4":
                        SearchOfFio(fullNames);
                        break;
                    case "5":
                        isWorking = false;
                        break;
                }
                Console.ReadKey();
                Console.Clear();
            }
        }

        static void AddDossier(ref string[] fullNames, ref string[] posts)
        {
            string userInformation;
            Console.WriteLine("Введите Ваши ФИО:");
            userInformation = Console.ReadLine();
            fullNames = AddPartOfDossier(fullNames, userInformation);
            Console.WriteLine("Введите Вашу должность:");
            userInformation = Console.ReadLine();
            posts = AddPartOfDossier(posts, userInformation);
        }

        static string[] AddPartOfDossier(string[] partOfDossier, string userInformation)
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

        static void ShowDossier(ref string[] fullNames, ref string[] posts)
        {
            int numberToCorrectInput = 1;
            Console.WriteLine("Вот список досье:\n");

            for (int i = 0; i < fullNames.Length; i++)
            {
                for (int j = 0; j < posts.Length; j++)
                {
                    if (i == j)
                    {
                        Console.Write((i + numberToCorrectInput) + ") " + fullNames[i] + " - " + posts[j] + ", ");
                    }
                }
            }
        }

        static void DeleteDossier(ref string[] fullNames, ref string[] posts)
        {
            int numberOfDossierToDelete;
            
            Console.WriteLine("Какое по счёту досье вы хотите удалить?");
            numberOfDossierToDelete = Convert.ToInt32(Console.ReadLine());

            if (numberOfDossierToDelete > fullNames.Length || numberOfDossierToDelete > posts.Length)
            {
                Console.WriteLine("Такого досье нет, введите корректный номер досье");
            }
            else
            {
                fullNames = DeletePartOfDossier(fullNames, numberOfDossierToDelete);
                posts = DeletePartOfDossier(posts, numberOfDossierToDelete);
            }
        }

        static string[] DeletePartOfDossier(string[] partOfDossier, int numberOfDossierToDelete)
        {
            int numberToCorrectInput = 1;
            string[] tempParOfDossier = new string[partOfDossier.Length - 1];

            for (int i = 0; i < numberOfDossierToDelete - numberToCorrectInput; i++)
            {
                tempParOfDossier[i] = partOfDossier[i];
            }

            for (int i = numberOfDossierToDelete; i < partOfDossier.Length; i++)
            {
                tempParOfDossier[i - 1] = partOfDossier[i];
            }
            partOfDossier = tempParOfDossier;
            return partOfDossier;
        }

        static void SearchOfFio(string[] fullNames)
        {
            string inputedLastname;
            string lastname;
            int numberOfDossier;
            int numberToCorrectInput = 1;

            Console.WriteLine("Введите фамилию:");
            inputedLastname = Console.ReadLine();

            for (int i = 0; i < fullNames.Length; i++)
            {
                lastname = fullNames[i];
                string[] separateFullName = lastname.Split(' ');

                for (int j = 0; j < separateFullName.Length; j++)
                {
                    if (separateFullName[j] == inputedLastname)
                    {
                        numberOfDossier = i;
                        
                        Console.WriteLine("Вот номер досье и полное имя этого человека:\n");
                        Console.Write((i + numberToCorrectInput) + ") " + fullNames[i]);  
                    }
                }
            }
        }
    }
}


