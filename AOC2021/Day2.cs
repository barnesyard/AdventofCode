class Day2 : AocDay
{
    public override void RunPartA()
    {
        Console.WriteLine("Running Day 2 part A");
        string[] input = System.IO.File.ReadAllLines(@"E:\OneDrive\Code Projects\AdventOfCode\AOC2021\input\Day2_Input.txt");
     
        int horizPos = 0;
        int depth = 0;
            foreach(string line in input)
            {
                Console.Write(line);
                if (line.Contains("forward")) 
                {
                    horizPos += int.Parse(line.Substring(line.Length-1));
                    Console.Write("  horiz: " + horizPos + "  depth: " + depth + "\n");
                }
                if (line.Contains("down"))
                {
                    depth += int.Parse(line.Substring(line.Length-1));
                    Console.Write("  horiz: " + horizPos + "  depth: " + depth + "\n");
                }
                if (line.Contains("up"))
                {
                    depth -= int.Parse(line.Substring(line.Length-1));
                    Console.Write("  horiz: " + horizPos + "  depth: " + depth + "\n");
                }
            }

            Console.WriteLine("The final answer is horizPos X depth: ");
            Console.WriteLine(horizPos*depth);
    }
    public override void RunPartB()
    {
        Console.WriteLine("Running Day 2 part B");
        Console.WriteLine("Running Day 2 part A");
        string[] input = System.IO.File.ReadAllLines(@"E:\OneDrive\Code Projects\AdventOfCode\AOC2021\input\Day2_Input.txt");
     
        int horizPos = 0;
        int depth = 0;
        int aim =0;
        foreach(string line in input)
        {
            Console.Write(line);
            if (line.Contains("forward")) 
            {
                horizPos += int.Parse(line.Substring(line.Length-1));
                depth += int.Parse(line.Substring(line.Length-1)) * aim;
                Console.Write("  aim: " + aim + "  horiz: " + horizPos + "  depth: " + depth + "\n");
            }
            if (line.Contains("down"))
            {
                aim += int.Parse(line.Substring(line.Length-1));
                Console.Write("  aim: " + aim + "  horiz: " + horizPos + "  depth: " + depth + "\n");
            }
            if (line.Contains("up"))
            {
                aim -= int.Parse(line.Substring(line.Length-1));
                Console.Write("  aim: " + aim + "  horiz: " + horizPos + "  depth: " + depth + "\n");
            }
        }

        Console.WriteLine("The final answer is horizPos X depth: ");
        Console.WriteLine(horizPos*depth);
    }
}

class Day2Factory : AocDayFactory
{
    public override AocDay GetAocDay()
    {
        return new Day2();
    }
}
