class Day9 : AocDay
{
    private string[] input;
    private GridPoint[,] htGrid;
    private int gridWidth;
    private int gridHeight;
    private List<int> basinSizes = new List<int> { };

    private class GridPoint
    {
        public int heightValue { get; set; }
        public int basinNumber { get; set; }

        public GridPoint()
        {
            heightValue = 0;
            basinNumber = 0;
        }
    }

    public Day9()
    {
        //Load the input
        this.input = System.IO.File.ReadAllLines(@".\input\Day9_Input.txt");
        // Since I am going to use 1 as my first basin I need to add the 0 basin size to start:
        this.basinSizes.Add(0);
        gridHeight = this.input.Length;
        gridWidth = this.input[0].Length;
        htGrid = new GridPoint[gridHeight, gridWidth];
        for (int r = 0; r < gridHeight; r++)
        {
            for (int c = 0; c < gridWidth; c++)
            {
                htGrid[r, c] = new GridPoint();
                htGrid[r, c].heightValue = int.Parse(this.input[r][c].ToString());
            }
        }
    }

    private bool isLowPt(int r, int c)
    {
        int value = htGrid[r, c].heightValue;
        if (c > 0 && (value >= htGrid[r, c - 1].heightValue)) { return false; }
        if (c < gridWidth - 1 && (value >= htGrid[r, c + 1].heightValue)) { return false; }
        if (r > 0 && (value >= htGrid[r - 1, c].heightValue)) { return false; }
        if (r < gridHeight - 1 && (value >= htGrid[r + 1, c].heightValue)) { return false; }
        return true;
    }

    private void setBasinNumber(int r, int c, int basinNum)
    {
        if (r < 0 || c < 0) { return; }
        if (r >= this.gridHeight || c >= this.gridWidth) { return; }
        if (this.htGrid[r, c].basinNumber != 0)
        {
            // This point was already tagged in a basin
            return;
        }

        if (this.htGrid[r, c].heightValue < 9)
        {
            this.htGrid[r, c].basinNumber = basinNum;
            this.basinSizes[basinNum]++;

            setBasinNumber(r + 1, c, basinNum);
            setBasinNumber(r - 1, c, basinNum);
            setBasinNumber(r, c - 1, basinNum);
            setBasinNumber(r, c + 1, basinNum);
        }

    }

    public override void SolveDay()
    {
        Console.WriteLine("Getting the solution to Day 9");

        // Track the sum of the risk level of each low point as you find them
        int lowPointsSum = 0;

        // Use a counter for numbering each basin
        int currentBasin = 1;

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
                    lowPointsSum += htGrid[r, c].heightValue + 1;
                    isLow = true;

                    // if a low point is found add another basin to our list of basin sizes
                    this.basinSizes.Add(0);
                    // find the size of the basin for this point and the connected points
                    this.setBasinNumber(r, c, currentBasin);

                    //increment the basin number for the next low point
                    currentBasin++;
                }
                if (isLow) { Console.ForegroundColor = ConsoleColor.Red; }
                else { Console.ForegroundColor = ConsoleColor.White; }
                Console.Write(htGrid[r, c].heightValue);
            }
            Console.Write("\n");
        }
        Console.ResetColor();
        Console.WriteLine("Sum of low point risk: " + lowPointsSum);
        int[] sortedBasinSizes = new int[basinSizes.Count];
        this.basinSizes.Sort();
        int size1 = this.basinSizes[this.basinSizes.Count - 1];
        int size2 = this.basinSizes[this.basinSizes.Count - 2];
        int size3 = this.basinSizes[this.basinSizes.Count - 3];
        Console.WriteLine("Top 3 basin sizes: " + size1 + " " + size2 + " " + size3 + " And multiply them to get: " + (size1 * size2 * size3));
    }

}

class Day9Factory : AocDayFactory
{
    public override AocDay GetAocDay()
    {
        return new Day9();
    }
}
