using System.Security.Cryptography;
using System.Text.RegularExpressions;

class Day5 : AocDay
{
    public Day5(int day) : base(day)
    {
        FormatData();
    }

    public override void FormatData()
    {
        // no formatting needed today
    }

    public override void SolveDay()
    {
        Console.WriteLine($"Getting the solution to Day {this.day} ");
        Console.WriteLine("-----------------------------------------");
        Console.WriteLine($"Running Day {this.day} part A");

        Console.WriteLine($"Day {this.day} Part A solution: ");
        Console.WriteLine("-----------------------------------------");
        Console.WriteLine($"Running Day {this.day} part B");

        Console.WriteLine($"Day {this.day} Part B solution is: ");
    }
}

class Day5Factory : AocDayFactory
{
    public override AocDay GetAocDay(int day)
    {
        return new Day5(day);
    }
}
