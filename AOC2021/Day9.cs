class Day9 : AocDay
{
    private string[] input;
    private int[,] htGrid;
    private int gridWidth;
    private int gridHeight;

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

    public override void SolveDay()
    {
        Console.WriteLine("Getting the solution to Day 9");
        int lowPointsSum = 0;
        int altLowPointSum = 0;
        for (int r = 0; r < gridHeight; r++)
        {
            Console.ForegroundColor = ConsoleColor.White;
            for (int c = 0; c < gridWidth; c++)
            {
                if (isLowPt(r, c)) { altLowPointSum += htGrid[r, c] + 1; }
                bool isLow = false;
                if (r == 0)
                {
                    if (c == 0)
                    {
                        if ((htGrid[r, c] < htGrid[r, c + 1]) && (htGrid[r, c] < htGrid[r + 1, c]))
                        {
                            lowPointsSum += (htGrid[r, c] + 1);
                            isLow = true;
                        }
                    }
                    else if (c == this.gridWidth - 1)
                    {
                        if ((htGrid[r, c] < htGrid[r, c - 1]) && (htGrid[r, c] < htGrid[r + 1, c]))
                        {
                            lowPointsSum += (htGrid[r, c] + 1);
                            isLow = true;
                        }
                    }
                    else
                    {
                        if ((htGrid[r, c] < htGrid[r, c - 1]) && (htGrid[r, c] < htGrid[r, c + 1]) && (htGrid[r, c] < htGrid[r + 1, c]))
                        {
                            lowPointsSum += (htGrid[r, c] + 1);
                            isLow = true;
                        }

                    }
                }
                else if (r == this.gridHeight - 1)
                {
                    if (c == 0)
                    {
                        if ((htGrid[r, c] < htGrid[r, c + 1]) && (htGrid[r, c] < htGrid[r - 1, c]))
                        {
                            lowPointsSum += (htGrid[r, c] + 1);
                            isLow = true;
                        }
                    }
                    else if (c == this.gridWidth - 1)
                    {
                        if ((htGrid[r, c] < htGrid[r, c - 1]) && (htGrid[r, c] < htGrid[r - 1, c]))
                        {
                            lowPointsSum += (htGrid[r, c] + 1);
                            isLow = true;
                        }
                    }
                    else
                    {
                        if ((htGrid[r, c] < htGrid[r, c - 1]) && (htGrid[r, c] < htGrid[r, c + 1]) && (htGrid[r, c] < htGrid[r - 1, c]))
                        {
                            lowPointsSum += (htGrid[r, c] + 1);
                            isLow = true;
                        }
                    }

                }
                else
                {
                    if (c == 0)
                    {
                        if ((htGrid[r, c] < htGrid[r, c + 1]) && (htGrid[r, c] < htGrid[r - 1, c]) && (htGrid[r, c] < htGrid[r + 1, c]))
                        {
                            lowPointsSum += (htGrid[r, c] + 1);
                            isLow = true;
                        }
                    }
                    else if (c == this.gridWidth - 1)
                    {
                        if ((htGrid[r, c] < htGrid[r, c - 1]) && (htGrid[r, c] < htGrid[r + 1, c]) && (htGrid[r, c] < htGrid[r - 1, c]))
                        {
                            lowPointsSum += (htGrid[r, c] + 1);
                            isLow = true;
                        }
                    }
                    else
                    {
                        if ((htGrid[r, c] < htGrid[r, c - 1]) && (htGrid[r, c] < htGrid[r, c + 1]) &&
                            (htGrid[r, c] < htGrid[r - 1, c]) && (htGrid[r, c] < htGrid[r + 1, c]))
                        {
                            lowPointsSum += (htGrid[r, c] + 1);
                            isLow = true;
                        }
                    }
                }
                if (isLow) { Console.ForegroundColor = ConsoleColor.Red; }
                else { Console.ForegroundColor = ConsoleColor.White; }
                Console.Write(htGrid[r, c]);
            }
            Console.Write("\n");
        }
        Console.ResetColor();
        Console.WriteLine("Sum of low point risk: " + lowPointsSum);
        Console.WriteLine("Alt sum of low point risk: " + altLowPointSum);
    }

}

class Day9Factory : AocDayFactory
{
    public override AocDay GetAocDay()
    {
        return new Day9();
    }
}
