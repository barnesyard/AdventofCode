class Day8 : AocDay
{
    private string[] input;
    private List<DisplayData> displayData;

    private class DisplayData
    {
        public List<string> SignalPatterns { get; set; }
        public List<string> OutputValues { get; set; }
        private string[] digits = new string[10];
        public int displayValue { get; set; }
        public DisplayData(List<string> inputPatterns, List<string> inputValues)
        {
            this.SignalPatterns = inputPatterns;
            this.OutputValues = inputValues;

            // First set the digits we know based on the fact they have a unique count of segments
            this.digits[1] = this.SignalPatterns.First(sig => sig.Length == 2);
            this.digits[4] = this.SignalPatterns.First(sig => sig.Length == 4);
            this.digits[7] = this.SignalPatterns.First(sig => sig.Length == 3);
            this.digits[8] = this.SignalPatterns.First(sig => sig.Length == 7);

            // Set "digit 6" based on its 6 segments and doesn't have both of 1's segments
            // The segment it doesn't have is the top right segment which will distinguish the 5 from the 2 so save it
            List<string> all6Segs = this.SignalPatterns.Where(sig => sig.Length == 6).ToList<string>();
            string? topRtSeg = "";
            foreach (string sixSeg in all6Segs)
            {
                foreach (char c in this.digits[1])
                {
                    if (!sixSeg.Contains(c))
                    {
                        topRtSeg = c.ToString();
                        this.digits[6] = sixSeg;
                        break;
                    }
                }
            }

            // Go through remaining 6 segment digits to find 0 digit using 4 digit as criteria
            all6Segs.Remove(this.digits[6]);
            foreach (string sixSeg in all6Segs)
            {
                foreach (char c in this.digits[4])
                {
                    if (!sixSeg.Contains(c))
                    {
                        this.digits[0] = sixSeg;
                        break;
                    }
                }
            }

            // Remaining 6 segment digit is the 9 digit
            all6Segs.Remove(this.digits[0]);
            this.digits[9] = all6Segs[0];

            // Set 3 digit based on it is 5 segments and does have both of 1 digit's segments
            List<string> all5SegDigits = this.SignalPatterns.Where(sig => sig.Length == 5).ToList<string>();
            foreach (string of5Segs in all5SegDigits)
            {
                if (of5Segs.Contains(this.digits[1][0]) && of5Segs.Contains(this.digits[1][1]))
                {
                    this.digits[3] = of5Segs;
                    break;
                }
            }

            all5SegDigits.Remove(this.digits[3]);
            // Just 2 and 5 remain to be identified and the 5 will not have the top right segment
            if (all5SegDigits[0].Contains(topRtSeg))
            {
                this.digits[5] = all5SegDigits[1];
                this.digits[2] = all5SegDigits[0];
            }
            else
            {
                this.digits[5] = all5SegDigits[0];
                this.digits[2] = all5SegDigits[1];
            }

            // All the digits are identified, now set the display value
            SetDisplayValue();
        }

        private void SetDisplayValue()
        {
            this.displayValue += (getDigitValue(this.OutputValues[0]) * 1000);
            this.displayValue += (getDigitValue(this.OutputValues[1]) * 100);
            this.displayValue += (getDigitValue(this.OutputValues[2]) * 10);
            this.displayValue += getDigitValue(this.OutputValues[3]);
        }

        private int getDigitValue(string digit)
        {
            for (int i = 0; i < 10; i++)
            {
                // Since the string can be in any order you have to handle that by ordering the strings to have same order
                if (String.Concat(this.digits[i].OrderBy(c => c)) == String.Concat(digit.OrderBy(c => c)))
                {
                    return i;
                }
            }
            // if you didn't find a match something is wrong throw out of here
            throw new Exception("Didn't find a value for this digit");
        }
    }

    public Day8()
    {
        //Load the input
        this.input = System.IO.File.ReadAllLines(@".\input\Day8_Input.txt");
        this.displayData = new List<DisplayData> { };
        foreach (string line in this.input)
        {
            this.displayData.Add(new DisplayData(line.Split("|")[0].Trim().Split(" ").ToList<string>(), line.Split("|")[1].Trim().Split(" ").ToList<string>()));
        }
    }

    public override void SolveDay()
    {
        Console.WriteLine("Getting the solution to Day 8");
        //part 1 count all output digits with number of segments of 2, 3, 4, or 7
        int uniqueDigits = 0;
        int outputSum = 0;
        foreach (DisplayData oneDisplay in this.displayData)
        {
            foreach (string outDigit in oneDisplay.OutputValues)
            {
                if (outDigit.Length == 2 || outDigit.Length == 3 || outDigit.Length == 4 || outDigit.Length == 7)
                {
                    uniqueDigits++;
                }

            }
            outputSum += oneDisplay.displayValue;
        }
        Console.WriteLine("The number of unique number segments: " + uniqueDigits);
        Console.WriteLine("The sum of all the display values: " + outputSum);
    }
}

class Day8Factory : AocDayFactory
{
    public override AocDay GetAocDay()
    {
        return new Day8();
    }
}
