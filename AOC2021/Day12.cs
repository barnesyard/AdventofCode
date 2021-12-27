class Day12 : AocDay
{
    private string[] input;
    
    public Day12()
    {
        //Load the input
        this.input = System.IO.File.ReadAllLines(@".\input\Day12_Input.txt");
    }

    public override void SolveDay()
    {
        Console.WriteLine("Getting the solution to Day12");
    }
}

class Day12Factory : AocDayFactory
{
    public override AocDay GetAocDay()
    {
        return new Day12();
    }
}
