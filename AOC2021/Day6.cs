class Day6 : AocDay
{
    private string[] input;
    private List<int> fishes = new List<int> { };

    public Day6()
    {
        //Load the input
        this.input = System.IO.File.ReadAllLines(@".\input\Day6_Input.txt");
    }

    public override void RunPartA()
    {
        Console.WriteLine("Running Day 6 part A");
    }
    public override void RunPartB()
    {
        Console.WriteLine("Running Day 5 part B");
    }
}

class Day6Factory : AocDayFactory
{
    public override AocDay GetAocDay()
    {
        return new Day6();
    }
}
