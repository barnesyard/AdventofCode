using System.Security.Cryptography;
using System.Text.RegularExpressions;

class Day3 : AocDay
{
    public Day3(int day) : base(day)
    {
        FormatData();
    }

    public override void FormatData()
    {
        // do nothing on day 3

    }

    public override void SolveDay()
    {
        Console.WriteLine($"Getting the solution to Day {this.day} ");
        Console.WriteLine("-----------------------------------------");
        Console.WriteLine($"Running Day {this.day} part A");
        // I have a huge string where I need to find occurences of "mul(n,m)" where n and m
        // are int that are 1 - 3 digits long. The final answer is the sum of all occurences of n*m
        // so we need to match this regular expression: 
        string regEx = @"mul\((\d{1,3}),(\d{1,3})\)";

        var ans = Regex.Matches(this.input, regEx).Sum(match => FindAndMuliplyDigits(match.Value));

        int FindAndMuliplyDigits(string match)
        {
            return Regex.Matches(match, @"\d{1,3}")
            .Cast<Match>()
            .Select(m => int.Parse(m.Value))
            .Aggregate(1, (product, number) => product * number);
        }

        Console.WriteLine($"Day {this.day} Part A solution: {ans}");
        Console.WriteLine("-----------------------------------------");
        Console.WriteLine($"Running Day {this.day} part B");

        string mulRegEx = @"mul\((\d{1,3}),(\d{1,3})\)|don't\(\)|do\(\)";
        MatchCollection matchCollection = Regex.Matches(this.input, mulRegEx);

        bool isEnabled = true;
        long condSum = 0;
        foreach (Match match in matchCollection)
        {
            switch (match.Value)
            {
                case "don't()":
                    isEnabled = false;
                    break;
                case "do()":
                    isEnabled = true;
                    break;
                default:
                    if(isEnabled) { condSum += FindAndMuliplyDigits(match.Value); }
                    break;
            }
        }

        Console.WriteLine($"Day {this.day} Part B solution is: {condSum}");
    }
}

class Day3Factory : AocDayFactory
{
    public override AocDay GetAocDay(int day)
    {
        return new Day3(day);
    }
}
