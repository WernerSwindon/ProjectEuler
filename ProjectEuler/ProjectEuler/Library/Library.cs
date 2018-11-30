using ProjectEuler.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    class Library
    {
        public static void WritePrimeNumbersToFile(long n)
        {
            long LastPrimeInFile = 0;
            Boolean FileExists = (File.Exists(Settings.Default.Path_PrimeFile));

            if (FileExists)
            {
                if (!string.IsNullOrEmpty(File.ReadAllText(Settings.Default.Path_PrimeFile)))
                {
                    String Last = File.ReadLines(Settings.Default.Path_PrimeFile).Last();
                    long.TryParse(Last, out LastPrimeInFile);
                }
            }
            else
                File.Create(Settings.Default.Path_PrimeFile);

            for (long x = LastPrimeInFile + 1; x < n; x++)
                if (IsPrime(x))
                {
                    File.AppendAllText(Settings.Default.Path_PrimeFile, x.ToString() + "\r\n");
                    Console.WriteLine(x);
                }
        }

        // https://www.geeksforgeeks.org/primality-test-set-1-introduction-and-school-method/
        public static Boolean IsPrime(long n)
        {
            // Corner cases 
            if (n <= 1) return false;
            if (n <= 3) return true;

            // This is checked so that we  
            // can skip middle five numbers 
            // in below loop 
            if (n % 2 == 0 || n % 3 == 0) return false;

            for (int i = 5; i * i <= n; i = i + 6)
                if (n % i == 0 || n % (i + 2) == 0)
                    return false;

            return true;
        }

        public static int NextPrime(int PrevPrimeNumber)
        {
            int Result = PrevPrimeNumber + 1;
            bool NextPrimeFound = false;

            while (!NextPrimeFound)
            {
                NextPrimeFound = true;

                for (int x = 2; x < Result; x++)
                {
                    if (Result % x == 0)
                    {
                        NextPrimeFound = false;
                        Result++;
                        break;
                    }
                }
            }

            return Result;
        }
    }
}
