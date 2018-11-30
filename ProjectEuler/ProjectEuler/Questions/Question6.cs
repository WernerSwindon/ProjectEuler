using ProjectEuler.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Questions
{
    class Question6
    {
        public static void Caclulate()
        {
            Console.WriteLine("Question 6");

            // The sum of the squares of the first ten natural numbers is,

            // 12 + 22 + ... + 102 = 385
            // The square of the sum of the first ten natural numbers is,

            // (1 + 2 + ... + 10)2 = 552 = 3025
            // Hence the difference between the sum of the squares of the first ten natural numbers and the square of the sum is 3025 − 385 = 2640.

            // Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.

            int Sum1 = 0;
            int Sum2 = 0;

            for (int x = 1; x <= 100; x++)
            {
                Sum1 += (int)Math.Pow(x, 2);
                Sum2 += x;
            }

            Sum2 = (int)Math.Pow(Sum2, 2);

            Console.WriteLine("Result : " + (Sum2 - Sum1).ToString().ToString());
        }
    }
}
