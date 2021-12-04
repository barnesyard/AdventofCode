class Day3 : AocDay
{
    public override void RunPartA()
    {
        Console.WriteLine("Running Day 3 part A");
        string[] input = System.IO.File.ReadAllLines(@"E:\OneDrive\Code Projects\AdventOfCode\AOC2021\input\Day3A_Input.txt");

        foreach (string line in input)
        {
            Console.Write(line + "\n");
        }
    }
    public override void RunPartB()
    {
        Console.WriteLine("Running Day 4 part B");
    }

}
class Day3Factory : AocDayFactory
{
    public override AocDay GetAocDay()
    {
        return new Day3();
    }
}
