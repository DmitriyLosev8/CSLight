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
            //домашнее задание: последовательность. У нас есть неделя обучения и полный курс обучения по дням. 
            //Использовал цикл for, потому что есть чёткие парраметры цикла и чёткий шаг.
            
            int weekOfStudy = 7;
            int fullCourseOfStudy = 100;
            
            for (int i = 5; i <= fullCourseOfStudy; i+= weekOfStudy)
            {
                Console.WriteLine(i);
            }
        }
    }
}
