class Day5 : AocDay
{
    private string[] input;
    private List<Line> lines = new List<Line> { };

    private class Line
    {
        private int x1;
        private int x2;
        private int y1;
        private int y2;
        public Line(int x1, int y1, int x2, int y2)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
        }

        public int X1 { get { return this.x1; } }
        public int Y1 { get { return this.y1; } }
        public int X2 { get { return this.x2; } }
        public int Y2 { get { return this.y2; } }
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
    }

    public override void RunPartA()
    {
        Console.WriteLine("Running Day 5 part A");

        //loop over each line
        //how many lines are horiz or vert?
        int hOrVLines = 0;
        foreach (Line line in this.lines)
        {
            //if the line is not vert or horiz skip it
            if (line.X1 != line.X2 && line.Y1 != line.Y2)
            {
                continue;
            }
            Console.Write("Number of hor or ver lines: " + (hOrVLines++) + " in the list \r");
            Thread.Sleep(5);
        }
        Console.WriteLine();
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
