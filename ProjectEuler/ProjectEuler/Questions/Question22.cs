using ProjectEuler.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Questions
{
    class Question22
    {
        public static void Caclulate()
        {
            Console.WriteLine("Question 22");

            // Using names.txt(right click and 'Save Link/Target As...'), 
            // a 46K text file containing over five-thousand first names, begin by sorting it into alphabetical order. 
            // Then working out the alphabetical value for each name, multiply this value by its alphabetical position in the list to obtain a name score.

            // For example, when the list is sorted into alphabetical order, COLIN, which is worth 3 + 15 + 12 + 9 + 14 = 53, is the 938th name in the list.So, 
            // COLIN would obtain a score of 938 × 53 = 49714.

            // What is the total of all the name scores in the file ?

            int Result = 0;
            int Index = 0;

            using (WebClient client = new WebClient())
            {
                List<string> Names = client.DownloadString(@"https://projecteuler.net/project/resources/p022_names.txt").Replace("\"", "").Split(',').OrderBy(q => q).ToList<string>();
                Result += Names.Sum(name => ++Index * name.Sum(c => (int)c % 32));
                Console.WriteLine("Result : " + Result.ToString());
            };
        }
    }
}
