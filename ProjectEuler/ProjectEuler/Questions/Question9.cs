using ProjectEuler.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Questions
{
    class Question9
    {
        public static void Caclulate()
        {
            Console.WriteLine("Question 9");

            // A Pythagorean triplet is a set of three natural numbers, a < b < c, for which,

            // a2 + b2 = c2
            // For example, 32 + 42 = 9 + 16 = 25 = 52.

            // There exists exactly one Pythagorean triplet for which a +b + c = 1000.
            // Find the product abc.

            long Result = 0;
            double C = 0;

            for (int A = 1; A < 1000; A++)
            {
                for (int B = 1; B < 1000; B++)
                {
                    C = Math.Sqrt((A * A) + (B * B));
                    long temp;

                    if (
                        long.TryParse(C.ToString(), out temp) &&
                        (A + B + (long)C) == 1000 &&
                        A < B &&
                        B < (long)C)
                    {
                        Result = A * B * (long)C;
                    }
                }
            }

            Console.WriteLine("Result : " + Result.ToString());
        }
    }
}
