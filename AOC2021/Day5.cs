class Day5 : AocDay
{
    private string[] input;
    private List<Line> lines = new List<Line> { };
    private int[,] grid1, grid2;

    private class Line
    {
        private int[] linePoints = new int[4];
        public Line(int x1, int y1, int x2, int y2)
        {
            this.linePoints[0] = x1;
            this.linePoints[1] = y1;
            this.linePoints[2] = x2;
            this.linePoints[3] = y2;
        }

        public int X1 { get { return this.linePoints[0]; } }
        public int Y1 { get { return this.linePoints[1]; } }
        public int X2 { get { return this.linePoints[2]; } }
        public int Y2 { get { return this.linePoints[3]; } }
        public int MaxPoint { get { return this.linePoints.Max(); } }
    }

    public Day5()
    {
        //Load the input
        this.input = System.IO.File.ReadAllLines(@".\input\Day5_Input.txt");
        //Store input a lines 
        foreach (string line in this.input)
        {
            int x1, x2, y1, y2;

            x1 = int.Parse(line.Replace(" -> ", ",").Split(",", 4)[0]);
            y1 = int.Parse(line.Replace(" -> ", ",").Split(",", 4)[1]);
            x2 = int.Parse(line.Replace(" -> ", ",").Split(",", 4)[2]);
            y2 = int.Parse(line.Replace(" -> ", ",").Split(",", 4)[3]);

            this.lines.Add(new Line(x1, y1, x2, y2));
        }
        Console.WriteLine("Stored " + this.lines.Count + " lines");

        //search through all the lines and find the largest value for x or y point and use that to set size of grid array
        int gridSize = 0;
        foreach (Line oneLine in this.lines)
        {
            gridSize = oneLine.MaxPoint > gridSize ? oneLine.MaxPoint : gridSize;
        }

        grid1 = new int[gridSize + 1, gridSize + 1];
        grid2 = new int[gridSize + 1, gridSize + 1];

    }

    public override void RunPartA()
    {
        Console.WriteLine("Running Day 5 part A");

        //loop over each line
        foreach (Line line in this.lines)
        {
            int xit = 0;
            int yit = 0;
            if (line.X1 < line.X2) { xit = 1; }
            else if (line.X1 > line.X2) { xit = -1; }
            if (line.Y1 < line.Y2) { yit = 1; }
            else if (line.Y1 > line.Y2) { yit = -1; }

            int x = line.X1, y = line.Y1;
            if (line.X1 == line.X2 || line.Y1 == line.Y2)
            {
                this.grid1[x, y]++;
            }
            this.grid2[x, y]++;
            do
            {
                x = x + xit;
                y = y + yit;
                this.grid2[x, y]++;
                if (line.X1 == line.X2 || line.Y1 == line.Y2)
                {
                    this.grid1[x, y]++;
                }
            } while (x != line.X2 || y != line.Y2);
        }

        int overlapCount1 = 0;
        int overlapCount2 = 0;
        for (int i = 0; i < this.grid1.GetLength(0); i++)
        {
            for (int j = 0; j < this.grid1.GetLength(1); j++)
            {
                if (this.grid1[i, j] > 1) { overlapCount1++; }
                if (this.grid2[i, j] > 1) { overlapCount2++; }
            }
        }
        Console.WriteLine("The number of overlapping grid points part 1: " + overlapCount1);
        Console.WriteLine("The number of overlapping grid points part 2: " + overlapCount2);
    }
    public override void RunPartB()
    {
        Console.WriteLine("Running Day 5 part B");
    }
}

class Day5Factory : AocDayFactory
{
    public override AocDay GetAocDay()
    {
        return new Day5();
    }
}
