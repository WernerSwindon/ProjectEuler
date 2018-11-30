using ProjectEuler.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Questions
{
    class Question10
    {
        public static void Caclulate()
        {
            Console.WriteLine("Question 10");

            // The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.
            // Find the sum of all the primes below two million.

            int Prime = 2;
            long Sum = 2;
            int PrimeLim = 2000000;

            while (Prime < PrimeLim)
            {
                Prime = Library.NextPrime(Prime);

                Console.WriteLine(Prime);

                if (Prime < PrimeLim)
                    Sum += Prime;
            }

            Console.WriteLine("Result : " + Sum.ToString());
        }
    }
}
