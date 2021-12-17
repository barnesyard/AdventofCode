class Day7 : AocDay
{
    private string[] input;
    private List<int> crabPositions = new List<int> { };

    public Day7()
    {
        //Load the input
        this.input = System.IO.File.ReadAllLines(@".\input\Day7_Input.txt");
        crabPositions = this.input[0].Split(',').Select(int.Parse).ToList();
    }

    public override void SolveDay()
    {
        Console.WriteLine("Getting the solution to Day 7");
    }
}

class Day7Factory : AocDayFactory
{
    public override AocDay GetAocDay()
    {
        return new Day7();
    }
}
