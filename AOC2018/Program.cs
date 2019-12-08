using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2018
{
    class Program
    {
        static void Main(string[] args)
        {
            //RunDayOne();
            //RunDayTwo();
            RunDayThree();
        }

        static List<string> getFileContents(string filePath)
        {
            List<string> fileLines = new List<string>();
            System.IO.StreamReader file = new System.IO.StreamReader(filePath);
            string line;
            while ((line = file.ReadLine()) != null)
            {
                fileLines.Add(line);
            }
            file.Close();
            return fileLines;
        }

        static void RunDayOne()
        {
            int frequency = 0;
            int loopCounter = 0;
            List<int> allFreqs = new List<int>();
            List<int> allFreqChanges = new List<int>();
            bool foundDup = false;

            foreach (string line in getFileContents(@"D:\AdventofCode\AOC2018\Day1Input.txt"))
            //foreach (string line in getFileContents(@"C:\Users\tbarnes\code\AOC\2018\AOC2018\Day1Input.txt"))
            {
                    allFreqChanges.Add(Int32.Parse(line));
            }

            //let's see how long this takes, write the time to the console:
            DateTime time = DateTime.Now;
            string startTime = "Starting time: " + time.ToString("h:mm:ss tt");

            do
            {
                foreach (int change in allFreqChanges)
                {
                    frequency += change;
                    if (allFreqs.Contains(frequency))
                    {
                        foundDup = true;
                        break;
                    }
                    allFreqs.Add(frequency);
                }
                loopCounter++;
                System.Console.WriteLine("Loop: " + loopCounter);
                if (loopCounter == 1)
                {
                    System.Console.WriteLine("The total value is {0}", frequency);
                }

            } while (!foundDup);

            Console.WriteLine("Found the dupe frequency: " + frequency);
            Console.WriteLine(startTime);
            Console.WriteLine("Ending time: " + DateTime.Now.ToString("h:mm:ss tt"));
        }

        static void RunDayTwo()
        {
            List<string> boxIds = getFileContents(@"D:\AdventofCode\AOC2018\Day2Input.txt");
            int twiceLetters = 0;
            int thriceLetters = 0;
            foreach (string id in boxIds)
            {
                if (id.GroupBy(c => c).Any(c => c.Count() == 2))
                {
                    twiceLetters++;
                }
                if (id.GroupBy(c => c).Any(c => c.Count() == 3))
                {
                    thriceLetters++;
                }
                //var result = id.GroupBy(c => c) // Group all the characters together, keyed by character (all the A's in one group, all the B's in another, etc.)
                //    .Where(c => c.Count() > 1) // This ".Where" (dot) method is part of Linq functionality. Here we are filtering out groups that have fewer that 2 occurences
                //    .Select(c => new { charName = c.Key, charCount = c.Count() }); // Return the charName and the count of instances
            }
            Console.WriteLine("The checksum for Day 2 puzzle 1: " + (twiceLetters * thriceLetters));

            for(int i = 0; i<boxIds.Count(); i++)
            {
                for (int j = i+1; j < boxIds.Count(); j++)
                {
                    Console.WriteLine("Comparing strings " + i + ": " + boxIds[i] + "   " + i + ": " + boxIds[j]);

                    if (DifferByOne(boxIds[i], boxIds[j]))
                    {
                        Console.WriteLine("The 2 Box ID that differ by 1 are: " + boxIds[i] + " and " + boxIds[j]);
                        return;
                    }
                }               
            }
        }

        static bool DifferByOne(string str1, string str2)
        {
            bool differByOne = false;
            int diffCount = 0;
            for (int i = 0;  i < str1.Length; i++)
            {
                if (str1[i]!=str2[i])
                {
                    diffCount++;
                }
                if (diffCount > 1) { break; }
            }
            if (diffCount == 1)
            {
                differByOne = true;
            }
            return differByOne;
        }
        static void RunDayThree()
        {
            List<string> rects = getFileContents(@"D:\AdventofCode\AOC2018\Day3Input.txt");
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            //Console.Write((char)903);
            for (int i = 0; i < 1000; i++)
            {
                Console.Write((char)i);
            }
        }
    }
}