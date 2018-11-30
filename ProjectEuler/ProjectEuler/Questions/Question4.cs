using ProjectEuler.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Questions
{
    class Question4
    {
        public static void Caclulate()
        {
            Console.WriteLine("Question 4");

            // A palindromic number reads the same both ways. The largest palindrome made from the product of two 2 - digit numbers is 9009 = 91 × 99.
            // Find the largest palindrome made from the product of two 3 - digit numbers.

            int Result = 0;

            for (int x = 999; x > 99; x--)
            {
                for (int y = 999; y > 99; y--)
                {
                    int temp = x * y;
                    if (temp.ToString() == Reverse(temp.ToString()) && (temp > Result))
                        Result = temp;
                }
            }

            Console.WriteLine("Result : " + Result.ToString());
        }

        private static string Reverse(string text)
        {
            char[] cArray = text.ToCharArray();
            string reverse = String.Empty;
            for (int i = cArray.Length - 1; i > -1; i--)
            {
                reverse += cArray[i];
            }
            return reverse;
        }
    }
}
