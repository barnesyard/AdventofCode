class Day3 : AocDay
{
    private string[] input;
    private List<string> mostCom = new List<string> { };
    private List<string> leastCom = new List<string> { };

    public Day3()
    {
        this.input = System.IO.File.ReadAllLines(@"E:\OneDrive\Code Projects\AdventOfCode\AOC2021\input\Day3_Input.txt");
    }

    public override void RunPartA()
    {
        Console.WriteLine("Running Day 3 part A");

        // count the number of 1s in each column
        int[] binaryCount = new int[input[0].Length];
        int index = 1;
        foreach (string line in this.input)
        {
            Console.Write(index + " of " + this.input.Length + "  Current value: " + line + "  Running count: ");
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == '1')
                {
                    binaryCount[i] += 1;
                }
                else
                {
                    binaryCount[i] += 0;
                }

                Console.Write(binaryCount[i] + " ");
            }
            Console.Write("\r");
            Thread.Sleep(10);
            index++;
        }
        Console.Write("\n");

        // for each column subtract from length and use difference to decide if col is more 1 or 0
        string gammaBinary = String.Empty;
        string epsilonBinary = String.Empty;
        for (int i = 0; i < binaryCount.Length; i++)
        {
            //Console.WriteLine("The length: " + input.Length + "  The current count: " + binaryCount[i]);
            if (binaryCount[i] > (this.input.Length - binaryCount[i]))
            {
                gammaBinary = gammaBinary + '1';
                epsilonBinary = epsilonBinary + '0';
            }
            else
            {
                gammaBinary = gammaBinary + '0';
                epsilonBinary = epsilonBinary + '1';
            }
        }
        Int64 gamma = Convert.ToInt64(gammaBinary, 2);
        Int64 epsilon = Convert.ToInt64(epsilonBinary, 2);
        Console.WriteLine("The gamma binary string: " + gammaBinary + " Converted to decimal: " + gamma);
        Console.WriteLine("The epsilon binary string: " + epsilonBinary + " Converted to decimal: " + epsilon);
        Console.WriteLine("Final power consumption: " + (gamma * epsilon));
    }
    public override void RunPartB()
    {
        Console.WriteLine("Running Day 4 part B");

        this.mostCom = new List<string>(this.input);
        int col = 0;
        while (this.mostCom.Count > 1)
        {
            Console.WriteLine("Number of items in Oxygen (most common) list: " + this.mostCom.Count);
            createMostAndLeastCommonLists(this.mostCom, col);
            col++;
        }
        Int64 oxygenRating = Convert.ToInt64(this.mostCom[0], 2);
        Console.WriteLine("The oxygen binary string: " + this.mostCom[0] + " Converted to decimal: " + oxygenRating);

        this.leastCom = new List<string>(this.input);
        col = 0;
        while (this.leastCom.Count > 1)
        {
            Console.WriteLine("Number of items in CO2 (least common) list: " + this.leastCom.Count);
            createMostAndLeastCommonLists(this.leastCom, col);
            col++;
        }
        Int64 co2Rating = Convert.ToInt64(this.leastCom[0], 2);
        Console.WriteLine("The oxygen binary string: " + this.leastCom[0] + " Converted to decimal: " + co2Rating);

        Console.WriteLine("The life support rating (O x CO2) is: " + (oxygenRating * co2Rating));
    }

    private void createMostAndLeastCommonLists(List<string> inputList, int col)
    {
        List<string> the0s = new List<string> { };
        List<string> the1s = new List<string> { };
        foreach (string line in inputList)
        {
            if (line[col] == '1')
            {
                the1s.Add(line);
            }
            else
            {
                the0s.Add(line);
            }
        }

        // If 1s are more common use it for oxygen
        if (the1s.Count >= the0s.Count)
        {
            this.mostCom = new List<string>(the1s);
            this.leastCom = new List<string>(the0s);
        }
        else // If 0s are more common use it for oxygen
        {
            this.mostCom = new List<string>(the0s);
            this.leastCom = new List<string>(the1s);
        }
    }
}


class Day3Factory : AocDayFactory
{
    public override AocDay GetAocDay()
    {
        return new Day3();
    }
}
