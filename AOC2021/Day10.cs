class Day10 : AocDay
{
    private string[] input;

    public Day10()
    {
        //Load the input
        this.input = System.IO.File.ReadAllLines(@".\input\Day10_Input.txt");
    }

    public override void SolveDay()
    {
        Console.WriteLine("Getting the solution to Day10");

        int syntaxErrorScore = 0;

        foreach (string line in this.input)
        {
            Dictionary<char, int> chunkTracking = new Dictionary<char, int> { };
            chunkTracking.Add('(', 0);
            chunkTracking.Add(')', 0);
            chunkTracking.Add('[', 0);
            chunkTracking.Add(']', 0);
            chunkTracking.Add('<', 0);
            chunkTracking.Add('>', 0);
            chunkTracking.Add('{', 0);
            chunkTracking.Add('}', 0);

            // ): 3 points
            // ]: 57 points
            // }: 1197 points
            // >: 25137 points
            foreach (char c in line)
            {
                chunkTracking[c]++;
                if (chunkTracking[')'] > chunkTracking[')'])
                {
                    syntaxErrorScore += 3;
                    break;
                }
                if (chunkTracking[']'] > chunkTracking['['])
                {
                    syntaxErrorScore += 57;
                    break;
                }
                if (chunkTracking['}'] > chunkTracking['{'])
                {
                    syntaxErrorScore += 1197;
                    break;
                }
                if (chunkTracking['>'] > chunkTracking['<'])
                {
                    syntaxErrorScore += 25137;
                    break;
                }
            }
            Console.WriteLine("Current syntax score: " + syntaxErrorScore);
        }
        // Output the final value for the syntax error score
        Console.WriteLine("Final Score: " + syntaxErrorScore);
    }

}

class Day10Factory : AocDayFactory
{
    public override AocDay GetAocDay()
    {
        return new Day10();
    }
}