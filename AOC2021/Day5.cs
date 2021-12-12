class Day1 : AocDay
{
    public override void RunPartA()
    {
        Console.WriteLine("Running Day 1 part A");
        string[] input = System.IO.File.ReadAllLines(@"E:\OneDrive\Code Projects\AdventOfCode\AOC2021\input\Day1A_Input.txt");

        int index = 0;
        int prevValue = 0;

        //part A
        foreach (string value in input)
        {
            if (0 == prevValue)
            {
                prevValue = int.Parse(value);
                continue;
            }
            if (int.Parse(value) > prevValue)
            {
                index++;
            }
            string tempStr = "Part A Number of increases in depth measurements-----> " + value + " <----- (This is the index: " + index + ")";
            Console.WriteLine(tempStr);
            prevValue = int.Parse(value);
        }
    }
    public override void RunPartB()
    {
        Console.WriteLine("Running Day 1 part B");
        string[] input = System.IO.File.ReadAllLines(@"E:\OneDrive\Code Projects\AdventOfCode\AOC2021\input\Day1A_Input.txt");

        int prev1 = int.Parse(input[0]);
        int prev2 = int.Parse(input[1]);
        int prev3 = int.Parse(input[2]);
        int sum1 = prev1 + prev2 + prev3;
        int sum2 = 0;
        int day2increase = 0;
        Console.WriteLine(input.Length);
        for (int a = 3; a < input.Length; a++)
        {
            sum2 = int.Parse(input[a]) + int.Parse(input[a - 1]) + int.Parse(input[a - 2]);
            if (sum2 > sum1)
            {
                day2increase++;
            }
            Console.WriteLine("Index: " + a + "  Win1 " + input[a - 3] + " " + input[a - 2] + " " + input[a - 1] + "  Win2 " + input[a - 2] + " " + input[a - 1] + " " + input[a] + "  Count of increases: " + day2increase);
            sum1 = sum2;
        }
    }
}

class Day1Factory : AocDayFactory
{
    public override AocDay GetAocDay()
    {
        return new Day1();
    }
}
