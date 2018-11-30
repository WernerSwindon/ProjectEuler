using ProjectEuler.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Questions
{
    class Question3
    {
        public static void Caclulate()
        {
            Console.WriteLine("Question 3");

            // The prime factors of 13195 are 5, 7, 13 and 29.
            // What is the largest prime factor of the number 600851475143 ?

            long n = 600851475143;

            List<long> Primes = File.ReadAllLines(Settings.Default.Path_PrimeFile).Where(l => !string.IsNullOrEmpty(l)).Select(data => Convert.ToInt64(data)).ToList<long>();

            String Result = "";

            foreach (long Prime in Primes.Where(x => x < n).OrderByDescending(y => y))
            {
                if (n % Prime == 0)
                {
                    Result = Prime.ToString();
                    break;
                }
            }

            Console.WriteLine("Result : " + Result);
        }
    }
}
