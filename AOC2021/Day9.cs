class Day9 : AocDay
{
    private string[] input;

    public Day9()
    {
        //Load the input
        this.input = System.IO.File.ReadAllLines(@".\input\Day9_Input.txt");
    }

    public override void SolveDay()
    {
        Console.WriteLine("Getting the solution to Day 9");
    }
}

class Day9Factory : AocDayFactory
{
    public override AocDay GetAocDay()
    {
        return new Day9();
    }
}
