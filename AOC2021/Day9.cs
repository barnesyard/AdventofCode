class Day9 : AocDay
{
    private string[] input;
    private int[,] htGrid;
    private int gridWidth;
    private int gridHeight;
    private List<int> basinSizes = new List<int> { };

    public Day9()
    {
        //Load the input
        this.input = System.IO.File.ReadAllLines(@".\input\Day9_Input.txt");
        htGrid = new int[this.input.Length, this.input[0].Length];
        gridHeight = this.input.Length;
        gridWidth = this.input[0].Length;
        for (int r = 0; r < gridHeight; r++)
        {
            for (int c = 0; c < gridWidth; c++)
            {
                htGrid[r, c] = int.Parse(this.input[r][c].ToString());
            }
        }
    }

    private bool isLowPt(int r, int c)
    {
        bool checkLeft = c == 0 ? true : (htGrid[r, c] < htGrid[r, c - 1]);
        bool checkRight = c == gridWidth - 1 ? true : (htGrid[r, c] < htGrid[r, c + 1]);
        bool checkUp = r == 0 ? true : (htGrid[r, c] < htGrid[r - 1, c]);
        bool checkDown = r == gridHeight - 1 ? true : (htGrid[r, c] < htGrid[r + 1, c]);

        if (checkLeft && checkRight && checkUp && checkDown)
        {
            return true;
        }
        return false;

    }

    private int getBasinSize(int r, int c)
    {
        // if the left point is less than 9 it adds 1 to our basin size
        int checkLeft = (c != 0) && (htGrid[r, c - 1] < 9) ? getBasinSize(r, c - 1) + 1 : 0;
        return 1;
    }

    public override void SolveDay()
    {
        Console.WriteLine("Getting the solution to Day 9");

        // Track the sum of the risk level of each low point as you find them
        int lowPointsSum = 0;

        //loop over the entire grid of elevations
        for (int r = 0; r < gridHeight; r++)
        {
            Console.ForegroundColor = ConsoleColor.White;
            for (int c = 0; c < gridWidth; c++)
            {
                // at each point call a method to figure out if it is a low point
                bool isLow = false;
                if (isLowPt(r, c))
                {
                    lowPointsSum += htGrid[r, c] + 1;
                    isLow = true;

                    // find the size of the basin
                    int basinSize = 1 + this.getBasinSize(r, c);
                    this.basinSizes.Add(basinSize);
                }
                if (isLow) { Console.ForegroundColor = ConsoleColor.Red; }
                else { Console.ForegroundColor = ConsoleColor.White; }
                Console.Write(htGrid[r, c]);
            }
            Console.Write("\n");
        }
        Console.ResetColor();
        Console.WriteLine("Sum of low point risk: " + lowPointsSum);
    }

}

class Day9Factory : AocDayFactory
{
    public override AocDay GetAocDay()
    {
        return new Day9();
    }
}
