using ProjectEuler.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Questions
{
    class Question50
    {
        public static void Caclulate()
        {
            Console.WriteLine("Question 50");

            Console.WriteLine("Result : " + Calculate().ToString());
        }

        private static String Calculate()
        {
            //The prime 41, can be written as the sum of six consecutive primes:
            //41 = 2 + 3 + 5 + 7 + 11 + 13
            //This is the longest sum of consecutive primes that adds to a prime below one - hundred.
            //The longest sum of consecutive primes below one-thousand that adds to a prime, contains 21 terms, and is equal to 953.
            //Which prime, below one - million, can be written as the sum of the most consecutive primes?

            long n = 42; // 1000000;
            long MaxPrime = 0;
            long SumOfPrimes = 0;
            long Terms = 0;
            long MaxTerms = 0;

            List<long> Primes = File.ReadAllLines(Settings.Default.Path_PrimeFile).Where(l => !string.IsNullOrEmpty(l)).Select(data => Convert.ToInt64(data)).ToList<long>();

            for (int x = 0; x < n; x++)
            {
                long Prime = Primes[x];

                if (SumOfPrimes + Prime > n)
                    return MaxPrime.ToString();

                SumOfPrimes = SumOfPrimes + Prime;

                if (Primes.Exists(p => p == SumOfPrimes))
                {
                    MaxPrime = SumOfPrimes;
                    Console.WriteLine(MaxPrime + " " + SumOfPrimes);
                }
            }

            return SumOfPrimes.ToString();
        }
    }
}
