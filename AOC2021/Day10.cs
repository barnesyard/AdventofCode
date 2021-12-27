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
        List<ulong> compScores = new List<ulong> { };

        foreach (string line in this.input)
        {
            Stack<char> trackChunks = new Stack<char> { };
            bool isCorrupt = false;

            foreach (char c in line)
            {
                if (!isClosing(c))
                {
                    trackChunks.Push(c);
                }
                else
                {
                    if (closesOpener(trackChunks.Peek(), c))
                    { trackChunks.Pop(); }
                    else
                    {
                        // ): 3 points
                        // ]: 57 points
                        // }: 1197 points
                        // >: 25137 points
                        if (c == ')')
                        {
                            syntaxErrorScore += 3;
                            isCorrupt = true;
                            break;
                        }
                        if (c == ']')
                        {
                            syntaxErrorScore += 57;
                            isCorrupt = true;
                            break;
                        }
                        if (c == '}')
                        {
                            syntaxErrorScore += 1197;
                            isCorrupt = true;
                            break;
                        }
                        if (c == '>')
                        {
                            syntaxErrorScore += 25137;
                            isCorrupt = true;
                            break;
                        }
                    }
                }
            }
            Console.WriteLine("Current syntax score: " + syntaxErrorScore);
            if (!isCorrupt)
            {
                ulong score = 0;

                while (trackChunks.Count > 0)
                {
                    int value = 0;
                    // ): 1 point.
                    // ]: 2 points.
                    // }: 3 points.
                    // >: 4 points.
                    switch (trackChunks.Peek())
                    {
                        case '(':
                            value = 1;
                            break;
                        case '[':
                            value = 2;
                            break;
                        case '{':
                            value = 3;
                            break;
                        case '<':
                            value = 4;
                            break;
                    }
                    score = (score * 5) + (ulong)value;
                    trackChunks.Pop();
                }
                compScores.Add(score);
            }
        }
        // Output the final value for the syntax error score
        Console.WriteLine("Final Score: " + syntaxErrorScore);
        compScores.Sort();
        Console.WriteLine("The middle completion score: " + compScores[((compScores.Count - 1) / 2)]);
    }

    private bool isClosing(char c)
    {
        if (c == '}') { return true; }
        if (c == ']') { return true; }
        if (c == '>') { return true; }
        if (c == ')') { return true; }
        return false;
    }

    private bool closesOpener(char inList, char c)
    {
        switch (inList)
        {
            case '(':
                if (c == ')') { return true; }
                break;
            case '<':
                if (c == '>') { return true; }
                break;
            case '{':
                if (c == '}') { return true; }
                break;
            case '[':
                if (c == ']') { return true; }
                break;
            default:
                return false;
        }
        return false;
    }


}

class Day10Factory : AocDayFactory
{
    public override AocDay GetAocDay()
    {
        return new Day10();
    }
}
