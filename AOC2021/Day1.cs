class Day1 : AocDay
{
    private string[] input;

    public Day1()
    {
        this.input = System.IO.File.ReadAllLines(@".\input\Day1_Input.txt");
    }
    public override void SolveDay()
    {
        Console.WriteLine("Getting the solution to Day 1 ");
        Console.WriteLine("Running Day 1 part A");

        int index = 0;
        int prevValue = 0;

        //part A
        foreach (string value in this.input)
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

        Console.WriteLine("Running Day 1 part B");

        int prev1 = int.Parse(input[0]);
        int prev2 = int.Parse(input[1]);
        int prev3 = int.Parse(input[2]);
        int sum1 = prev1 + prev2 + prev3;
        int sum2 = 0;
        int day2increase = 0;
        Console.WriteLine(this.input.Length);
        for (int a = 3; a < this.input.Length; a++)
        {
            sum2 = int.Parse(this.input[a]) + int.Parse(this.input[a - 1]) + int.Parse(this.input[a - 2]);
            if (sum2 > sum1)
            {
                day2increase++;
            }
            Console.WriteLine("Index: " + a + "  Win1 " + this.input[a - 3] + " " + this.input[a - 2] + " " + this.input[a - 1] + "  Win2 " + this.input[a - 2] + " " + this.input[a - 1] + " " + this.input[a] + "  Count of increases: " + day2increase);
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
