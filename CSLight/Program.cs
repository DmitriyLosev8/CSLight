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
            // домашнее задание картинки: у нас есть 52 картинке в альбоме, выводятся по 3 ряда, надо понять сколько полностью заполненных рядов можно будет вывести,
            // и сколько картинок будет сверх меры.

            int fullSeriesOfPictures = 52 / 3;
            int exraPictures = 52 % 7;
            Console.WriteLine(fullSeriesOfPictures);
            Console.WriteLine(exraPictures);
        }
    }
}
