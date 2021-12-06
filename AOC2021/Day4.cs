class Day4 : AocDay
{
    private string[] input;
    private List<BingoCard> BingoCards = new List<BingoCard> {};
    private int[] calledNumbers;

    private class BingoCard
    {
        private int[,] card = new int[5, 5];

        public BingoCard(int[,] card)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    this.card[i,j] = card[i,j];
                }
            }
        }

    }

    public Day4()
    {
        this.input = System.IO.File.ReadAllLines(@".\input\Day4A_Input.txt");
        calledNumbers = (this.input[0].Split(',').Select(x => int.Parse(x))).ToArray<int>();

        int[,] card = new int[5, 5];
        int cardRow = 0;
        for (int i = 2; i < this.input.Length; i++)
        {
            int j = 0;
            foreach (string s in this.input[i].Split(" "))
            {
                if(String.IsNullOrEmpty(s)) {continue;}
                card[cardRow, j] = int.Parse(s);
                j++;
            }
            if (cardRow >= 4)
            {
                this.BingoCards.Add(new BingoCard(card));
                card = new int[5, 5];
                cardRow = 0;
            } else 
            {
                cardRow++;
            }
        }

    }

    public override void RunPartA()
    {
        Console.WriteLine("Running Day 4 part A");
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