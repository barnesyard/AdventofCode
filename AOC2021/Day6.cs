class Day6 : AocDay
{
    private string[] input;
    private List<int> fishes = new List<int> { };

    public Day6()
    {
        //Load the input
        this.input = System.IO.File.ReadAllLines(@".\input\Day6_Input.txt");
        fishes = this.input[0].Split(',').Select(int.Parse).ToList();
    }

    public override void SolveDay()
    {
        Console.WriteLine("Getting the solution to Day 6 ");
        // create way to track fish count based on the count of each fish at the same state
        ulong[] fishState = new ulong[9];
        foreach (int fish in this.fishes)
        {
            fishState[fish]++;
        }

        ulong fishCount = 0;

        for (int s = 0; s < 9; s++)
        {
            fishCount += fishState[s];
        }
        Console.WriteLine("Initial fish count: " + fishCount);
        int day = 1;
        do
        {
            // tracking by state
            ulong newFish = fishState[0];
            Array.Copy(fishState, 1, fishState, 0, 8);
            fishState[8] = newFish;
            fishState[6] += newFish;
            fishCount += newFish;

            if (day < 81)
            {
                // this way has a trap
                int todaysFishCount = this.fishes.Count;
                for (int i = 0; i < todaysFishCount; i++)
                {
                    // If the fish is zero add another fish at 8
                    if (this.fishes[i] == 0)
                    {
                        this.fishes.Add(8);
                        this.fishes[i] = 6;
                        continue;
                    }
                    this.fishes[i]--;
                }
            }
            Console.Write("Day: " + day + " count of fish: " + this.fishes.Count + " tracking state: " + fishCount);
            Console.Write("  States 0:" + fishState[0] + " 1:" + fishState[1] + " 2:" + fishState[2] + " 3:" + fishState[3]);
            Console.Write(" 4:" + fishState[4] + " 5:" + fishState[5] + " 6:" + fishState[6] + " 7:" + fishState[7] + "\n");
            if (day == 80 || day == 256)
            {
                Console.WriteLine("Day: " + day + " count of fish: " + this.fishes.Count);
            }
            day++;
        } while (day < 257);
    }


}

class Day6Factory : AocDayFactory
{
    public override AocDay GetAocDay()
    {
        return new Day6();
    }
}
