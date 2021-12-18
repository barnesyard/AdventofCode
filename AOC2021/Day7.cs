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
        ulong[] expFuelCosts = new ulong[this.maxX +1];

        // The fuel cost = take absolute value of current position subrtact target position
        // if target is 4 and position is 0 then abs(0-4) is fuel cost = 4
        // if targe is 4 and position is 11 then abs(11-4) is fuel cost = 7
        for(int f=0; f<this.maxX+1; f++ )
        {
            Console.WriteLine("Current coordinate: " + f);
            foreach(int curPos in this.crabPositions)
            {
                int cost = Math.Abs(f - curPos);
                fuelCosts[f] += cost;

                ulong sumCost = 0;
                for(int i =0; i<cost+1; i++)
                {
                    sumCost += (ulong)i;
                }
                
                expFuelCosts[f] += sumCost;
            }
        }
        Console.WriteLine("The lowest fuel cost: " + fuelCosts.Min());
        Console.WriteLine("The lowest expensive fuel cost: " + expFuelCosts.Min());
    }
}

class Day7Factory : AocDayFactory
{
    public override AocDay GetAocDay()
    {
        return new Day7();
    }
}
