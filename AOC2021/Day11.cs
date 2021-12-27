class Day11 : AocDay
{
    private string[] input;
    private int[,] octogrid = new int[10, 10];

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
        // do this 100 times
        for (int i = 0; i < 100; i++)
        {
            // First increase all the energy levels by 1
            for (int r = 0; r < 10; r++)
            {
                for (int c = 0; c < 10; c++)
                {
                    octogrid[r, c]++;
                    //renderGrid();
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
                    //renderGrid();
                }
            }
            // Let's see if that actually did what it was supposed to do
            Console.WriteLine("The count of flashes: " + flashes);
        }
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
        Thread.Sleep(1);
    }


}

class Day11Factory : AocDayFactory
{
    public override AocDay GetAocDay()
    {
        return new Day11();
    }
}
