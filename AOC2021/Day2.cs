class Day2 : AocDay
{
    private string[] input;
    public Day2()
    {
        this.input = System.IO.File.ReadAllLines(@".\input\Day2_Input.txt");
    }

    public override void SolveDay()
    {
        Console.WriteLine("Getting the solution to Day 2 ");
        Console.WriteLine("Running Day 2 part A");

        int horizPos = 0;
        int depth = 0;
        foreach (string line in this.input)
        {
            Console.Write(line);
            if (line.Contains("forward"))
            {
                horizPos += int.Parse(line.Substring(line.Length - 1));
                Console.Write("  horiz: " + horizPos + "  depth: " + depth + "\n");
            }
            if (line.Contains("down"))
            {
                depth += int.Parse(line.Substring(line.Length - 1));
                Console.Write("  horiz: " + horizPos + "  depth: " + depth + "\n");
            }
            if (line.Contains("up"))
            {
                depth -= int.Parse(line.Substring(line.Length - 1));
                Console.Write("  horiz: " + horizPos + "  depth: " + depth + "\n");
            }
        }

        Console.WriteLine("The final answer is horizPos X depth: ");
        Console.WriteLine(horizPos * depth);

        Console.WriteLine("Running Day 2 part B");

        horizPos = 0;
        depth = 0;
        int aim = 0;
        foreach (string line in this.input)
        {
            Console.Write(line);
            if (line.Contains("forward"))
            {
                horizPos += int.Parse(line.Substring(line.Length - 1));
                depth += int.Parse(line.Substring(line.Length - 1)) * aim;
                Console.Write("  aim: " + aim + "  horiz: " + horizPos + "  depth: " + depth + "\n");
            }
            if (line.Contains("down"))
            {
                aim += int.Parse(line.Substring(line.Length - 1));
                Console.Write("  aim: " + aim + "  horiz: " + horizPos + "  depth: " + depth + "\n");
            }
            if (line.Contains("up"))
            {
                aim -= int.Parse(line.Substring(line.Length - 1));
                Console.Write("  aim: " + aim + "  horiz: " + horizPos + "  depth: " + depth + "\n");
            }
        }

        Console.WriteLine("The final answer is horizPos X depth: ");
        Console.WriteLine(horizPos * depth);
    }
}

class Day2Factory : AocDayFactory
{
    public override AocDay GetAocDay()
    {
        return new Day2();
    }
}
