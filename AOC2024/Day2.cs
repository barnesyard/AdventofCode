using System.Security.Cryptography;
using System.Text.RegularExpressions;

class Day2 : AocDay
{
    private List<List<int>> reports = [];
    public Day2(int day) : base(day)
    {
        FormatData();
    }

    public override void FormatData()
    {
        // Split the raw string from text file to get an array of strings
        string[] allLines = this.input.Split("\n", StringSplitOptions.RemoveEmptyEntries);

        // each line of the text is an array of integers separated by a space, convert that to List<int>
        // once each line is converted to List<int> then add that to a List<>
        this.reports = allLines
            .Select(line => line.Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(num => int.Parse(num)).ToList())
            .ToList();
    }

    public override void SolveDay()
    {
        Console.WriteLine($"Getting the solution to Day {this.day} ");
        Console.WriteLine("-----------------------------------------");
        Console.WriteLine($"Running Day {this.day} part A");

        // Need to check each "report" in the "reports" list to see if it is safe
        // need a count of all the reports that are safe
        // it is safe it all numbers are in ascending or decscending order and each level differs by at least one and at most 3

        bool ValidLevelsInReport(List<int> report)
        {
            return report.Zip(report.Skip(1)).All(v => 1 <= v.Second - v.First && v.Second - v.First <= 3) || //checking the ascending scenario
                report.Zip(report.Skip(1)).All(v => 1 <= v.First - v.Second && v.First - v.Second <= 3); // checking the descending scenario
        }

        // int safeReports = this.reports.Count(report =>
        //     report.Zip(report.Skip(1)).All(v => 1 <= v.Second - v.First && v.Second - v.First <= 3) || //checking the ascending scenario
        //     report.Zip(report.Skip(1)).All(v => 1 <= v.First - v.Second && v.First - v.Second <= 3) // checking the descending scenario
        //     );

        int safeReports = this.reports.Count(report => ValidLevelsInReport(report));

        // List<List<int>> unsafeReportsList = this.reports.Where(report =>
        //     !(report.Zip(report.Skip(1)).All(v => 1 <= v.Second - v.First && v.Second - v.First <= 3) ||
        //     report.Zip(report.Skip(1)).All(v => 1 <= v.First - v.Second && v.First - v.Second <= 3))
        // ).ToList();

        List<List<int>> unsafeReportsList = this.reports.Where(report => !ValidLevelsInReport(report)).ToList();
        
        int calcSafeReports = this.reports.Count - unsafeReportsList.Count;

        Console.WriteLine($"Day {this.day} Part A solution: {safeReports}");
        Console.WriteLine($"Day {this.day} Part A solution (alt): {calcSafeReports}");
        Console.WriteLine("-----------------------------------------");
        Console.WriteLine($"Running Day {this.day} part B");
        // int fixedReports = unsafeReportsList.Count(report =>
        //     report.Select((num, index) => report.Where((_, i) => i != index).ToList()) // Remove one value at a time
        //           .Any(remaining => remaining.Zip(remaining.Skip(1)).All(v => 1 <= v.Second - v.First && v.Second - v.First <= 3) ||
        //                            remaining.Zip(remaining.Skip(1)).All(v => 1 <= v.First - v.Second && v.First - v.Second <= 3))
        // );

        int fixedReports = unsafeReportsList.Count(report =>
            report.Select((num, index) => report.Where((_, i) => i != index).ToList()) // Remove one value at a time
                  .Any(remaining => ValidLevelsInReport(remaining))
        );


        int calcNewSafeReports = calcSafeReports + fixedReports;
        Console.WriteLine($"Day {this.day} Part B solution is: {calcNewSafeReports}");
    }
}

class Day2Factory : AocDayFactory
{
    public override AocDay GetAocDay(int day)
    {
        return new Day2(day);
    }
}
