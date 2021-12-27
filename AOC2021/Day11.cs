class Day11 : AocDay
{
    private string[] input;
    private int[,] octogrid = new int[10, 10];
    private int[] stats = new int[10];

    public Day11()
    {
        //Load the input
        this.input = System.IO.File.ReadAllLines(@".\input\Day11_Input.txt");
        for (int r = 0; r < 10; r++)
        {
            for (int c = 0; c < 10; c++)
            {
                int gridPtValue = int.Parse(this.input[r].ToCharArray()[c].ToString());
                octogrid[r, c] = gridPtValue;
            }
        }
    }

    public override void SolveDay()
    {
        Console.WriteLine("Getting the solution to Day11");
        int flashes = 0;
        bool foundSyncFlash = false;
        int loop = 0;
        // do this 100 times
        do
        {
            // Each loop check to see if we have a synced flash
            int[] stateCounts = new int[10];

            // First increase all the energy levels by 1
            for (int r = 0; r < 10; r++)
            {
                for (int c = 0; c < 10; c++)
                {
                    // Before taking this step collect stats on previous step's results
                    // while all values are in range 0-9 to avoid "out of range" error
                    // increment the count and evaluate if it is a sync value
                    // the sync value will not be > 99 until the energy value is incremented so looking for 98
                    if (stateCounts[octogrid[r, c]]++ > 98)
                    {
                        foundSyncFlash = true;
                        Console.WriteLine("On step " + loop + " the flash synced across all dumbos!");
                        Environment.Exit(0);
                    }

                    // Now increment the energy value
                    octogrid[r, c]++;
                }
            }

            // after increasing energy levels anything greater than 9 flashes
            // flash will increas energy level of orthoganol and diaganol neighbors
            // once flash happens has energy set to 0
            // First increase all the energy levels by 1
            for (int r = 0; r < 10; r++)
            {
                for (int c = 0; c < 10; c++)
                {
                    if (octogrid[r, c] > 9)
                    {
                        // this dumbo flashes
                        flashes++;

                        // set energy to 0 so flash doesn't happen again
                        octogrid[r, c] = 0;
                        // give energy and track flashes that occur
                        flashes += spreadFlashEnergy(r - 1, c - 1);
                        flashes += spreadFlashEnergy(r - 1, c);
                        flashes += spreadFlashEnergy(r - 1, c + 1);
                        flashes += spreadFlashEnergy(r, c - 1);
                        flashes += spreadFlashEnergy(r, c + 1);
                        flashes += spreadFlashEnergy(r + 1, c - 1);
                        flashes += spreadFlashEnergy(r + 1, c);
                        flashes += spreadFlashEnergy(r + 1, c + 1);
                    }
                }
            }

            // Part 1 wants count of flashes on day 100
            if (loop < 100)
            {
                Console.WriteLine("At step " + loop + " the count of flashes: " + flashes);
            }

            loop++;
        }
        while (!foundSyncFlash);
    }

    private int spreadFlashEnergy(int r, int c)
    {
        // handle the index out of range
        if (r < 0 || c < 0 || r > 9 || c > 9) { return 0; }

        // if energy level is 0 this dumbo already popped so just return nothing
        if (this.octogrid[r, c] == 0) { return 0; }

        // Add energy to this dumbo that was flashed by a neighbor
        this.octogrid[r, c]++;

        int flashCount = 0;
        if (this.octogrid[r, c] > 9)
        {
            // this dumbo flashed, add 1 to the flash count
            flashCount++;
            // set this dumbo to 0 energy to avoid another flash
            this.octogrid[r, c] = 0;

            // give energy to neighbors and if they flash track it
            flashCount += spreadFlashEnergy(r - 1, c - 1);
            flashCount += spreadFlashEnergy(r - 1, c);
            flashCount += spreadFlashEnergy(r - 1, c + 1);
            flashCount += spreadFlashEnergy(r, c - 1);
            flashCount += spreadFlashEnergy(r, c + 1);
            flashCount += spreadFlashEnergy(r + 1, c - 1);
            flashCount += spreadFlashEnergy(r + 1, c);
            flashCount += spreadFlashEnergy(r + 1, c + 1);
        }
        return flashCount;
    }

    private void renderGrid()
    {
        Console.Clear();
        for (int r = 0; r < 10; r++)
        {
            for (int c = 0; c < 10; c++)
            {
                Console.Write(octogrid[r, c] + " ");
            }
            Console.Write("\n");
        }
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine("Energy level: " + i + " and count for value: " + this.stats[i]);
        }

        Thread.Sleep(2);
    }


}

class Day11Factory : AocDayFactory
{
    public override AocDay GetAocDay()
    {
        return new Day11();
    }
}
