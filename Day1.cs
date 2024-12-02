using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2024
{
    public class Day1
    {
        public static async Task ExecutePart1()
        {
            int difference = 0;
            Console.WriteLine("--- Day 1: Historian Hysteria ---");
            try
            {
                List<string> inputLines = await InputHelper.FetchInputAsync(1);
                List<int> leftCol = new();
                List<int> rightCol = new();
                foreach (string line in inputLines)
                {
                    leftCol.Add(int.Parse(line.Split("   ")[0].Trim()));
                    rightCol.Add(int.Parse(line.Split("   ")[1].Trim()));
                }
                leftCol.Sort();
                rightCol.Sort();
                for (int i = 0; i < inputLines.Count; i++)
                {
                    difference = Math.Abs(leftCol[i] - rightCol[i]) + difference;
                }
                Console.WriteLine($"--- Difference: {difference} ---");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching input: {ex.Message}");
            }
        }
        public static async Task ExecutePart2()
        {
            int timesPresent = 0;
            int runningValue = 0;
            Console.WriteLine("--- Part Two ---");
            try
            {
                List<string> inputLines = await InputHelper.FetchInputAsync(1);
                List<int> leftCol = new();
                List<int> rightCol = new();
                foreach (string line in inputLines)
                {
                    leftCol.Add(int.Parse(line.Split("   ")[0].Trim()));
                    rightCol.Add(int.Parse(line.Split("   ")[1].Trim()));
                }
                for (int i = 0; i < leftCol.Count; i++)
                {
                    timesPresent = 0;
                    foreach (int col in rightCol)
                    {
                        if (leftCol[i] == col)
                            timesPresent++;
                    }
                    runningValue = (leftCol[i] * timesPresent) + runningValue;


                }
                Console.WriteLine("--- Similarity Score: " + runningValue + " ---");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
