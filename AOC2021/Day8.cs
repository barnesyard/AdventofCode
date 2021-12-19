class Day8 : AocDay
{
    private string[] input;
    private List<DisplayData> displayData;

    private class DisplayData
    {
        private List<string> signalPatterns { get; set; }
        private List<string> outputValues { get; set; }
        public DisplayData(List<string> inputPatterns, List<string> inputValues)
        {
            this.signalPatterns = inputPatterns;
            this.outputValues = inputValues;
        }
    }

    public Day8()
    {
        //Load the input
        this.input = System.IO.File.ReadAllLines(@".\input\Day8_Input.txt");
        this.displayData = new List<DisplayData> { };
        foreach (string line in this.input)
        {
            this.displayData.Add(new DisplayData(line.Split("|")[0].Trim().Split(" ").ToList<string>(), line.Split("|")[1].Trim().Split(" ").ToList<string>()));
        }
    }

    public override void SolveDay()
    {
        Console.WriteLine("Getting the solution to Day 8");
    }
}

class Day8Factory : AocDayFactory
{
    public override AocDay GetAocDay()
    {
        return new Day8();
    }
}
