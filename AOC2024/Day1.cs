using System.Security.Cryptography;
using System.Text.RegularExpressions;

class Day1 : AocDay
{
    private List<int> col1 = [];
    private List<int> col2 = [];

    public Day1(int day) : base(day)
    {
        FormatData();
    }

    public override void FormatData()
    {
        string[] allLines = this.input.Split("\n", StringSplitOptions.RemoveEmptyEntries);
        foreach (string line in allLines)
        {
            // for future me: this split will split on any white space but it has to be done with regex instead of normal split
            string[] lineValues = Regex.Split(line, @"\s+");
            this.col1.Add(int.Parse(lineValues[0]));
            this.col2.Add(int.Parse(lineValues[1]));
        }
    }

    public override void SolveDay()
    {
        Console.WriteLine("Getting the solution to Day 1 ");
        Console.WriteLine("Running Day 1 part A");
        // sort the data in the columns without using built-in functions, using a simple bubble sort
        // i could explore  quick sort and a merge sort algorithms in addition to bubble sort
        int n = this.col1.Count; // the length of both columns are same
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (this.col1[j] > this.col1[j + 1])
                {
                    (this.col1[j + 1], this.col1[j]) = (this.col1[j], this.col1[j + 1]);
                }
                if (this.col2[j] > this.col2[j + 1])
                {
                    (this.col2[j + 1], this.col2[j]) = (this.col2[j], this.col2[j + 1]);
                }
            }
        }
        // now with columns sorted loop again and substract and sum
        int finalValueDay1 = 0;
        for (int i = 0; i < n; i++)
        {
            finalValueDay1 += Math.Abs(col1[i] - col2[i]);
        }

        // Now let's play around with some LINQ
        // since we already sorted columns above we need to redo the data
        IEnumerable<int[]> bothCol = from line in this.input.Split("\n", StringSplitOptions.RemoveEmptyEntries)
                                     let nums = Regex.Split(line, @"\s+").Select(int.Parse).ToArray()
                                     select nums;

        List<int> sortedCol1 = bothCol.Select(nums => nums[0]).OrderBy(x => x).ToList();
        List<int> sortedCol2 = bothCol.Select(nums => nums[1]).OrderBy(x => x).ToList();

        int partAFinalValueDay1 = sortedCol1.Select((value, index) => Math.Abs(value - sortedCol2[index])).Sum();


        Console.WriteLine("Part A solution: " + finalValueDay1);
        Console.WriteLine("Running Day 1 part B");

        var countDict = this.col1.Distinct().ToDictionary(value => value, value => this.col2.Count(x => x == value));
        int weightedSum = this.col1
        .Select(val => val * countDict[val])
        .Sum();
        
        Console.WriteLine("The part B solution is: " + weightedSum);
    }
}

class Day1Factory : AocDayFactory
{
    public override AocDay GetAocDay(int day)
    {
        return new Day1(day);
    }
}
