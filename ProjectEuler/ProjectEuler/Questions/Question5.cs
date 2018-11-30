using ProjectEuler.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Questions
{
    class Question5
    {
        public static void Caclulate()
        {
            Console.WriteLine("Question 5");

            // 2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.
            // What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20 ?

            int Result = 1;
            bool Found = false;

            while (!Found)
            {
                Found = true;

                for (int x = 1; x <= 20; x++)
                {
                    if (Result % x != 0)
                    {
                        Found = false;
                        Result++;
                    }
                }
            }

            Console.WriteLine("Result : " + Result.ToString());
        }
    }
}
