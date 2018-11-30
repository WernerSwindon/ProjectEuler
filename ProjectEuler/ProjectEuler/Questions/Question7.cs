using ProjectEuler.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Questions
{
    class Question7
    {
        public static void Caclulate()
        {
            Console.WriteLine("Question 7");

            // By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13.
            // What is the 10 001st prime number ?

            int Prime = 2;

            for (int x = 2; x <= 10001; x++)
            {
                Prime = Library.NextPrime(Prime);
            }

            Console.WriteLine("Result : " + Prime.ToString());
        }
    }
}
