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
    static class Question59
    {
        public static void Caclulate()
        {
            Console.WriteLine("Question 59");

            // https://en.wikipedia.org/wiki/XOR_cipher

            /*
                Each character on a computer is assigned a unique code and the preferred standard is ASCII (American Standard Code for Information Interchange).
                For example, uppercase A = 65, asterisk (*) = 42, and lowercase k = 107.
            
                A modern encryption method is to take a text file, convert the bytes to ASCII, then XOR each byte with a given value, taken from a secret key.
                The advantage with the XOR function is that using the same encryption key on the cipher text, restores the plain text; for example, 65 XOR 42 = 107, then 107 XOR 42 = 65.
            
                For unbreakable encryption, the key is the same length as the plain text message, and the key is made up of random bytes.The user would keep the encrypted message and the encryption key in different locations, 
                and without both "halves", it is impossible to decrypt the message.
                Unfortunately, this method is impractical for most users, so the modified method is to use a password as a key.If the password is shorter than the message, which is likely, the key is repeated cyclically throughout the message.
                The balance for this method is using a sufficiently long password key for security, but short enough to be memorable.
            
                Your task has been made easy, as the encryption key consists of three lower case characters.
                Using cipher.txt(right click and 'Save Link/Target As...'), a file containing the encrypted ASCII codes, 
                and the knowledge that the plain text must contain common English words, decrypt the message and find the sum of the ASCII values in the original text.
            */

            // a=97
            // z=122

            List<int[]> combinations = new List<int[]>();
            List<byte> nums = new List<byte>();

            for (byte x = 97; x <= 122; x++)
                for (byte y = 97; y <= 122; y++)
                    for (byte z = 97; z <= 122; z++)
                    {
                        if (x != y && y != z && x != z)
                            combinations.Add(new int[] { x, y, z });
                    }

            using (WebClient client = new WebClient())
            {
                nums = client.DownloadString(@"https://projecteuler.net/project/resources/p059_cipher.txt").Split(',').Select(x => Convert.ToByte(x)).ToList<byte>();
            };

            if (File.Exists(Settings.Default.Path_OutputFile))
                File.Delete(Settings.Default.Path_OutputFile);

            int Counter = 0;

            Console.WriteLine("Caclulate all the possible output combinations : ");

            foreach (int[] comb in combinations)
            {
                StringBuilder Decrypted = new StringBuilder();

                for (int x = 0; x < nums.Count(); x++)
                {
                    char c = (char)(nums[x] ^ comb[x % 3]);
                    Decrypted.Append(c); 
                }

                File.AppendAllText(Settings.Default.Path_OutputFile, Decrypted.ToString() + "\r\n");

                Counter++;
                if (Counter % 1000 == 0)
                    Console.WriteLine("Counter : " + Counter.ToString());
            }

            List<String> CommonEnglishWords = File.ReadAllLines(Settings.Default.Path_CommonEnglishWords).ToList();
            List<String> DecrypedMessages = File.ReadAllLines(Settings.Default.Path_OutputFile).ToList();

            if (File.Exists(Settings.Default.Path_OutputFile))
                File.Delete(Settings.Default.Path_OutputFile);

            Counter = 0;

            Console.WriteLine("\r\nCaclulate all the possible output combinations which contains common English Words : ");

            foreach (String DecrypedMessage in DecrypedMessages)
            {
                foreach (String MessagePart in DecrypedMessage.Split(' ').Where(x => !string.IsNullOrEmpty(x)).ToList())
                {
                    if (CommonEnglishWords.Contains(MessagePart))
                    {
                        File.AppendAllText(Settings.Default.Path_OutputFile, DecrypedMessage + "\r\n");
                        break;
                    }
                }

                Counter++;
                if (Counter % 1000 == 0)
                    Console.WriteLine("Counter : " + Counter.ToString());
            }

            Console.WriteLine("\r\nView output file : " + Settings.Default.Path_OutputFile);

            CalculateSumOfResult();
        }

        private static void CalculateSumOfResult()
        {
            // Scanning the Output file and found the following decrypted message.
            String Message = @"(The Gospel of John, chapter 1) 1 In the beginning the Word already existed. He was with God, and he was God. 2 He was in the beginning with God. 3 He created everything there is. Nothing exists that he didn't make. 4 Life itself was in him, and this life gives light to everyone. 5 The light shines through the darkness, and the darkness can never extinguish it. 6 God sent John the Baptist 7 to tell everyone about the light so that everyone might believe because of his testimony. 8 John himself was not the light; he was only a witness to the light. 9 The one who is the true light, who gives light to everyone, was going to come into the world. 10 But although the world was made through him, the world didn't recognize him when he came. 11 Even in his own land and among his own people, he was not accepted. 12 But to all who believed him and accepted him, he gave the right to become children of God. 13 They are reborn! This is not a physical birth resulting from human passion or plan, this rebirth comes from God.14 So the Word became human and lived here on earth among us. He was full of unfailing love and faithfulness. And we have seen his glory, the glory of the only Son of the Father.";
            int sum = 0;

            foreach (char c in Message)
                sum += (int)c;

            String Result = sum.ToString();
            Console.WriteLine("\r\nAnswer : ");
            Console.WriteLine(Result);
        }
    }
}
