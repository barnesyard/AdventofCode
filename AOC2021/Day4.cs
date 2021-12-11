class Day4 : AocDay
{
    private string[] input;
    private List<BingoCard> BingoCards = new List<BingoCard> { };
    private int[] calledNumbers;

    private class BingoCard
    {
        private int[,] card = new int[5, 5];
        private bool[,] called = new bool[5, 5];

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

        public int weHaveBingo()
        {
            int[] rowCovered = { 0, 0 };
            int[] colCovered = { 0, 0 };
            int[] diagLRCovered = { 0, 0 };
            int[] diagRLCovered = { 0, 0 };
            for (int i = 0; i < 5; i++)
            {
                Array.Clear(rowCovered);
                Array.Clear(colCovered);
                // do we have a diagonal of called numbers?
                if (true == this.called[i, i])
                {
                    diagLRCovered[0]++;
                    diagLRCovered[1] += this.card[i, i];
                    if (5 == diagLRCovered[0]) { return diagLRCovered[1]; }
                }
                if (true == this.called[i, 4 - i])
                {
                    diagRLCovered[0]++;
                    diagRLCovered[1] += this.card[i, 4 - i];
                    if (5 == diagRLCovered[0]) { return diagRLCovered[1]; }
                }
                for (int j = 0; j < 5; j++)
                {
                    // do we have a row of called numbers for this bingo card?
                    if (true == this.called[i, j])
                    {
                        rowCovered[0]++;
                        rowCovered[1] += this.card[i, j];
                        if (5 == rowCovered[0]) { return rowCovered[1]; }
                    }
                    // do we have a column of called numbers?
                    if (true == this.called[j, i])
                    {
                        colCovered[0]++;
                        colCovered[1] += this.card[j, i];
                        if (5 == colCovered[0]) { return colCovered[1]; }
                    }
                }

            }
            return 0;
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
        Console.Write("Numbers drawn: ");
        foreach (int called in this.calledNumbers)
        {
            Console.Write(called + ", ");

            // check all the bingo cards to see if they contained the called number
            foreach (BingoCard card in this.BingoCards)
            {
                // check to see if the number called is on the card and note it if it was called
                card.numberCalled(called);
                //after calling 5 numbers we may have a bingo so we should check for a bingo
                if (numCalled < 5) { continue; }
                int bingoSum = card.weHaveBingo();
                if (bingoSum > 0)
                {
                    Console.WriteLine("We have a bingo! Sum of bingo values!");
                    int cardSum = card.sumCardValues();
                    Console.WriteLine("Sum of all card numbers not called: " + cardSum);
                    Console.WriteLine("Winning board score: " + (cardSum) + " x " + called + " = " + (cardSum * called));
                    Environment.Exit(0);
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