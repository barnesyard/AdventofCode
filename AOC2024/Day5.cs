using System.ComponentModel;
using System.Globalization;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

class Day5 : AocDay
{
    Dictionary<int, List<int>> testRules = new Dictionary<int, List<int>>
    {
        [47] = [53, 13, 61, 29],
        [97] = [13, 61, 47, 29, 53, 75],
        [75] = [29, 53, 47, 61, 13],
        [61] = [13, 53, 29],
        [29] = [13],
        [53] = [29, 13]
    };

    List<List<int>> testUpdates =
    [
        [75,47,61,53,29], // correctly ordered
        [97,61,53,29,13], // correctly ordered
        [75,29,13], // correctly ordered
        [75,97,47,61,53], // NOT ordered correctly, 97 must be before 75
        [61,13,29], // NOT ordered correctly, 29 must be before 13
        [97,13,75,29,47] // NOT ordered correctly
    ];

    Dictionary<int, List<int>> orderingRules = [];
    List<List<int>> updates = [];
    public Day5(int day) : base(day)
    {
        FormatData();
    }

    public override void FormatData()
    {
        string[] splitResult = this.input.Split("\n\n", StringSplitOptions.RemoveEmptyEntries);
        // storing the ordering rules as a dictionary to be used in solving
        this.orderingRules = splitResult[0]
            .Split('\n')
            .Select(line => line.Split('|')) // Each line in the page ordering rules, like 23|65 shows 23 must be printed before 65
            .GroupBy(pages => int.Parse(pages[0]), pages => int.Parse(pages[1])) // group by the first value
            .ToDictionary(
                group => group.Key, // this is the int that was pages[0] used in the grouping
                group => group.ToList()); // this is a list of int grouped to the key

        var temp = splitResult[1].Split('\n').Select(t => t.Split(',').Select(int.Parse)).ToList().ToList();

        // storing the updates in a list to be used in solving
        this.updates = splitResult[1]
            .Split('\n', StringSplitOptions.RemoveEmptyEntries)
            .Select(up => up.Split(',')
                .Select(int.Parse).ToList()) // create the List<int> on a single line
            .ToList(); // create the List<List<int>
    }

    public override void SolveDay()
    {
        Console.WriteLine($"Getting the solution to Day {this.day} ");
        Console.WriteLine("-----------------------------------------");
        Console.WriteLine($"Running Day {this.day} part A");

        // Loop over each update, test to see if it is in correct order
        // if it is correct save to another list, incorrect are saved to a different list
        List<List<int>> correctUpdates = [];
        List<List<int>> incorrectUpdates = [];
        foreach (List<int> update in this.updates)
        {
            if (isCorrectlyOrdered(update)) { correctUpdates.Add(update); }
            else { incorrectUpdates.Add(update); }
        }

        bool isCorrectlyOrdered(List<int> update)
        {
            for (int i = update.Count - 1; i > 0; i--)
            {
                int current = update[i];
                if (!this.orderingRules.ContainsKey(current)) continue; // if we don't have a rule we can ignore it
                List<int> remainingItems = update.SkipLast(update.Count - i).ToList(); // Get remaining items after the current index
                if (remainingItems.Any(item => this.orderingRules[current].Contains(item))) // Check if any of remaining items exist in testRules[current]
                {
                    return false; // If any item is not found, return false
                }
            }
            return true; // If all checks pass, return true
        }

        int sumOfMiddles = 0;
        foreach (List<int> update in correctUpdates)
        {
            int middle = update.Count / 2; // division using int shoudl cause 5/2 to be 2 which is the middle index 0,1,2,3,4
            sumOfMiddles += update[middle];
        }

        Console.WriteLine($"Day {this.day} Part A solution: {sumOfMiddles}");
        Console.WriteLine("-----------------------------------------");
        Console.WriteLine($"Running Day {this.day} part B");

        int sumOfCorrectedMiddles = 0;
        foreach (List<int> update in incorrectUpdates)
        {
            List<int> correctedUpdate = correctTheUpdate(update);
            int middle = correctedUpdate.Count / 2; // division using int shoudl cause 5/2 to be 2 which is the middle index 0,1,2,3,4
            sumOfCorrectedMiddles += correctedUpdate[middle];
        }

        List<int> correctTheUpdate(List<int> wrongUpdate)
        {
            List<int> correctList = new List<int>(wrongUpdate);
            bool swapped;
            do
            {
                swapped = false;
                for (int i = correctList.Count - 1; i > 0; i--)
                {
                    int current = correctList[i];
                    if (!this.orderingRules.ContainsKey(current)) continue; // if we don't have a rule we can ignore it

                    List<int> remainingItems = correctList.Take(i).ToList(); // Get items before the current index to check
                    if (!remainingItems.Any(item => this.orderingRules[current].Contains(item))) continue; // Save some time by not looping if it is not needed
                    for (int j = remainingItems.Count - 1; j >= 0; j--)
                    {
                        if (this.orderingRules[current].Contains(remainingItems[j]))
                        {
                            (correctList[i], correctList[j]) = (correctList[j], correctList[i]); // swap the location of the item found in the ordering rules
                            swapped = true;
                            break;
                        }
                    }

                }
            } while (swapped);
            return correctList;
        }
        Console.WriteLine($"Day {this.day} Part B solution is: {sumOfCorrectedMiddles}");
    }
}

class Day5Factory : AocDayFactory
{
    public override AocDay GetAocDay(int day)
    {
        return new Day5(day);
    }
}
