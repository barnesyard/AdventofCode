class Day4 : AocDay
{
    public override void RunPartA()
    {
        Console.WriteLine("Running Day 4 part A");
    }
    public override void RunPartB()
    {
        Console.WriteLine("Running Day 4 part B");
    }
}

class Day4Factory : AocDayFactory
{
    public override AocDay GetAocDay()
    {
        return new Day4();
    }
}