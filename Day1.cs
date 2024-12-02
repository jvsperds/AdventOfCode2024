using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2024
{
    public class Day1
    {
        public static async Task Execute()
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
    }
}
