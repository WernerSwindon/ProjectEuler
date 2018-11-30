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
    class Question11
    {
        public static void Caclulate()
        {
            Console.WriteLine("Question 11");

            // In the 20×20 grid below, four numbers along a diagonal line have been marked in red.
            // The product of these numbers is 26 × 63 × 78 × 14 = 1788696.
            // What is the greatest product of four adjacent numbers in the same direction(up, down, left, right, or diagonally) in the 20×20 grid ?

            int Result = 0;
            int[,] Grid = new int[20, 20];
            List<string> Gridlines = File.ReadAllLines(Settings.Default.Path_Question11Grid).ToList<string>();

            for (int x = 0; x < Gridlines.Count; x++)
            {
                string[] lines = Gridlines[x].Split(' ');

                for (int y = 0; y < lines.Length; y++)
                {
                    Grid[x, y] = Convert.ToInt32(lines[y]);
                }
            }

            Result = CalculateMax(Grid);

            Console.WriteLine("Result : " + Result);
        }

        private static int CalculateMax(int[,] Grid)
        {
            int Result = 0;
            int MaxResult = 0;
            string MaxOutput = "";

            for (int x = 0; x < 20; x++)
            {
                for (int y = 0; y < 20; y++)
                {
                    if (y + 3 < 20)
                    {
                        Result = Grid[x, y] * Grid[x, y + 1] * Grid[x, y + 2] * Grid[x, y + 3];
                        if (Result > MaxResult)
                        {
                            MaxResult = Result;
                            MaxOutput = "RIGHT - " + Grid[x, y].ToString() + Grid[x, y + 1].ToString() + Grid[x, y + 2].ToString() + Grid[x, y + 3].ToString();
                        }
                    }

                    if (y - 3 > 0)
                    {
                        Result = Grid[x, y] * Grid[x, y - 1] * Grid[x, y - 2] * Grid[x, y - 3];
                        if (Result > MaxResult)
                        {
                            MaxResult = Result;
                            MaxOutput = "LEFT - " + Grid[x, y].ToString() + Grid[x, y - 1].ToString() + Grid[x, y - 2].ToString() + Grid[x, y - 3].ToString();
                        }
                    }

                    if (x + 3 < 20)
                    {
                        Result = Grid[x, y] * Grid[x + 1, y] * Grid[x + 2, y] * Grid[x + 3, y];
                        if (Result > MaxResult)
                        {
                            MaxResult = Result;
                            MaxOutput = "DOWN - " + Grid[x, y].ToString() + Grid[x + 1, y].ToString() + Grid[x + 2, y].ToString() + Grid[x + 3, y].ToString();
                        }
                    }

                    if (x - 3 > 0)
                    {
                        Result = Grid[x, y] * Grid[x - 1, y] * Grid[x - 2, y] * Grid[x - 3, y];
                        if (Result > MaxResult)
                        {
                            MaxResult = Result;
                            MaxOutput = "UP - " + Grid[x, y].ToString() + Grid[x - 1, y].ToString() + Grid[x - 2, y].ToString() + Grid[x - 3, y].ToString();
                        }
                    }

                    if (x + 3 < 20 && y + 3 < 20)
                    {
                        Result = Grid[x, y] * Grid[x + 1, y + 1] * Grid[x + 2, y + 2] * Grid[x + 3, y + 3];
                        if (Result > MaxResult)
                        {
                            MaxResult = Result;
                            MaxOutput = "DIAG RIGHT - " + Grid[x, y].ToString() + Grid[x + 1, y + 1].ToString() + Grid[x + 2, y + 2].ToString() + Grid[x + 3, y + 3].ToString();
                        }
                    }

                    if (x - 3 > 0 && y - 3 > 0)
                    {
                        Result = Grid[x, y] * Grid[x - 1, y - 1] * Grid[x - 2, y - 2] * Grid[x - 3, y - 3];
                        if (Result > MaxResult)
                        {
                            MaxResult = Result;
                            MaxOutput = "DIAG LEFT - " + Grid[x, y].ToString() + Grid[x - 1, y - 1].ToString() + Grid[x - 2, y - 2].ToString() + Grid[x - 3, y - 3].ToString();
                        }
                    }
                }
            }

            Console.WriteLine(MaxOutput);

            return MaxResult;
        }
    }
}
