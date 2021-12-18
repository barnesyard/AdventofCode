class Day7 : AocDay
{
    private string[] input;
    private List<int> crabPositions = new List<int> { };
    private int maxX = 0;


    public Day7()
    {
        //Load the input
        this.input = System.IO.File.ReadAllLines(@".\input\Day7_Input.txt");
        crabPositions = this.input[0].Split(',').Select(int.Parse).ToList();
        this.maxX = this.crabPositions.Max();

    }

    public override void SolveDay()
    {
        Console.WriteLine("Getting the solution to Day 7");
        // Approach: calculate fuel cost for all crabs to move to each horizontal position
        // save the fuel cost per position, return the lowest value
        int[] fuelCosts = new int[this.maxX + 1];

        // The fuel cost = take absolute value of current position subrtact target position
        // if target is 4 and position is 0 then abs(0-4) is fuel cost = 4
        // if targe is 4 and position is 11 then abs(11-4) is fuel cost = 7
    }
}

class Day7Factory : AocDayFactory
{
    public override AocDay GetAocDay()
    {
        return new Day7();
    }
}
