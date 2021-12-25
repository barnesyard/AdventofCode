class Day10 : AocDay
{
    private string[] input;

    public Day10()
    {
        //Load the input
        this.input = System.IO.File.ReadAllLines(@".\input\Day10_Input.txt");
    }

    public override void SolveDay()
    {
        Console.WriteLine("Getting the solution to Day10");

    }

}

class Day10Factory : AocDayFactory
{
    public override AocDay GetAocDay()
    {
        return new Day10();
    }
}
