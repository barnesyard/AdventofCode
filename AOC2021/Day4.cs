class Day4 : AocDay
{
    private string[] input;
    private List<BingoCard> BingoCards = new List<BingoCard> { };
    private int[] calledNumbers;

    private class BingoCard
    {
        private int[,] card = new int[5, 5];
        private bool[,] called = new bool[5, 5];
        private bool hasBingo = false;
        public bool HasBingo
        { 
            get
            {
                return this.hasBingo;
            }
        }

        public BingoCard(int[,] card)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    this.card[i, j] = card[i, j];
                    this.called[i, j] = false;
                }
            }
        }

        public void numberCalled(int num)
        {
            // Check the bingo card to see if the number was called
            //loop through each row and column looking for a match
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (num == this.card[i, j])
                    {
                        this.called[i, j] = true;
                    }
                }
            }
        }

        public bool weHaveBingo()
        {
            int rowCovered = 0;
            int colCovered = 0;
            int diagLRCovered = 0;
            int diagRLCovered = 0;
            for (int i = 0; i < 5; i++)
            {
                rowCovered = 0;
                colCovered = 0;
                // do we have a diagonal of called numbers?
                if (true == this.called[i, i])
                {
                    diagLRCovered++;
                    if (5 == diagLRCovered) { this.hasBingo = true; return true; }
                }
                if (true == this.called[i, 4 - i])
                {
                    diagRLCovered++;
                    if (5 == diagRLCovered) { this.hasBingo = true; return true; }
                }
                for (int j = 0; j < 5; j++)
                {
                    // do we have a row of called numbers for this bingo card?
                    if (true == this.called[i, j])
                    {
                        rowCovered++;
                        if (5 == rowCovered) { this.hasBingo = true; return true; }
                    }
                    // do we have a column of called numbers?
                    if (true == this.called[j, i])
                    {
                        colCovered++;
                        if (5 == colCovered) { this.hasBingo = true; return true; }
                    }
                }

            }
            return false;
        }

        public int sumCardValues()
        {
            int sum = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (!this.called[i, j]) { sum += this.card[i, j]; }
                }
            }
            return sum;
        }
    }

    public Day4()
    {
        this.input = System.IO.File.ReadAllLines(@".\input\Day4A_Input.txt");
        Console.WriteLine("Storing all the called numbers.");
        calledNumbers = (this.input[0].Split(',').Select(x => int.Parse(x))).ToArray<int>();

        Console.WriteLine("Storing the bingo cards");
        int[,] card = new int[5, 5];
        int cardRow = 0;
        for (int i = 2; i < this.input.Length; i++)
        {
            int j = 0;
            foreach (string s in this.input[i].Split(" "))
            {
                if (String.IsNullOrEmpty(s)) { continue; }
                card[cardRow, j] = int.Parse(s);
                j++;
            }
            if (cardRow >= 4)
            {
                this.BingoCards.Add(new BingoCard(card));
                card = new int[5, 5];
                cardRow = 0;
                i++; //do this to skip blank rows in input data
            }
            else
            {
                cardRow++;
            }
        }
        Console.WriteLine(this.BingoCards.Count + " bingo cards added!");

    }

    public override void RunPartA()
    {
        Console.WriteLine("Running Day 4 part A");
        Console.WriteLine("Let's start calling numbers!");

        int numCalled = 0;
        List<int> winningCards = new List<int> {};
        List<int> winningNumbers = new List<int> {};
        Console.Write("Numbers drawn: ");
        foreach (int called in this.calledNumbers)
        {
            Console.Write(" " + called);

            // check all the bingo cards to see if they contained the called number
            for (int b=0; b<this.BingoCards.Count; b++)
            {
                BingoCard card = this.BingoCards[b];
                // check to see if the number called is on the card and note it if it was called
                card.numberCalled(called);
                //after calling 5 numbers we may have a bingo so we should check for a bingo
                if (numCalled < 5) { continue; }
                if (!card.HasBingo && card.weHaveBingo())
                {
                    Console.WriteLine("\nWe have a bingo! Card #" + b);
                    int cardSum = card.sumCardValues();
                    Console.WriteLine("Sum of all card numbers not called: " + cardSum);
                    Console.WriteLine("Winning board score: " + (cardSum) + " x " + called + " = " + (cardSum * called));
                    //Environment.Exit(0);

                    winningCards.Add(b);
                    winningNumbers.Add(called);
                }
            }
            numCalled++;
        }

    }
    public override void RunPartB()
    {
        Console.WriteLine("Running Day 4 part B");
    }
}

class Day4Factory : AocDayFactory
{
    public override AocDay GetAocDay()
    {
        return new Day4();
    }
}