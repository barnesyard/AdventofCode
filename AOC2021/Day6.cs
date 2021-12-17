class Day6 : AocDay
{
    private string[] input;
    private List<int> fishes = new List<int> { };

    public Day6()
    {
        //Load the input
        this.input = System.IO.File.ReadAllLines(@".\input\Day6_Input.txt");
    }

    public override void SolveDay()
    {
        Console.WriteLine("Getting the solution to Day 6 ");
    }


}

class Day6Factory : AocDayFactory
{
    public override AocDay GetAocDay()
    {
        return new Day6();
    }
}
