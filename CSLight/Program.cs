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
        {      //Задание: объединение в одну коллекцию: 

            string[] chairs = { "1", "2", "3", "7", "10", "45" };
            string[] armchairs = { "4", "3", "5", "10", "18" };
            List<string> seats = new List<string>();
            seats.AddRange(chairs);
            seats.AddRange(armchairs);

            DeleteRepeatingStrings(seats);
            ShowingAllUniqueSeats(seats);
        }

        static void DeleteRepeatingStrings(List<string> seats)
        {
            seats.Sort();

            for (int i = 1; i < seats.Count; i++)
            {
                if (seats[i - 1] == seats[i])
                {
                    seats.Remove(seats[i]);
                }
            }
        }

        static void ShowingAllUniqueSeats(List<string> seats)
        {
            for (int i = 0; i < seats.Count; i++)
            {
                Console.WriteLine(seats[i]);

            }
        }
    }
}
