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
            Stack<char> trackChunks = new Stack<char> { };

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
                            break;
                        }
                        if (c == ']')
                        {
                            syntaxErrorScore += 57;
                            break;
                        }
                        if (c == '}')
                        {
                            syntaxErrorScore += 1197;
                            break;
                        }
                        if (c == '>')
                        {
                            syntaxErrorScore += 25137;
                            break;
                        }
                    }
                }
            }
            Console.WriteLine("Current syntax score: " + syntaxErrorScore);
        }
        // Output the final value for the syntax error score
        Console.WriteLine("Final Score: " + syntaxErrorScore);
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
