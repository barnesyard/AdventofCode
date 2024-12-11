using System.Security.Cryptography;
using System.Text.RegularExpressions;

class Day4 : AocDay
{
    private string[] wordSearchRows = [];
    private int gridWidth;
    private int gridHeight;
    public Day4(int day) : base(day)
    {
        FormatData();
        this.gridHeight = this.wordSearchRows.Length;
        this.gridWidth = this.wordSearchRows[0].Length;
    }

    public override void FormatData()
    {
        this.wordSearchRows = this.input.Split("\n", StringSplitOptions.RemoveEmptyEntries);
    }

    public override void SolveDay()
    {
        Console.WriteLine($"Getting the solution to Day {this.day} ");
        Console.WriteLine("-----------------------------------------");
        Console.WriteLine($"Running Day {this.day} part A");
        int xmasCount = 0;

        // Loop over every char in the word search
        // When an 'X' is found search all 8 dirs for 'XMAS'
        for (int i = 0; i < this.gridWidth; i++)
        {
            for (int j = 0; j < this.gridHeight; j++)
            {
                if ('X' == this.wordSearchRows[i][j]) xmasCount += findXmasAllDirs(i, j);
            }
        }

        bool xmasFound(int row, int col, int dr, int dc)
        {
            // handle the edge of the grid
            if (
                (row < 3 && -1 == dr) ||
                (row >= this.gridHeight - 3 && 1 == dr) ||
                (col < 3 && -1 == dc) ||
                (col >= this.gridWidth - 3 && 1 == dc)
                )
            {
                return false;
            }

            // look for "MAS" since we already found "X" in the grid and return true if found
            if (this.wordSearchRows[row + (dr * 1)][col + (dc * 1)] == 'M' &&
                this.wordSearchRows[row + (dr * 2)][col + (dc * 2)] == 'A' &&
                this.wordSearchRows[row + (dr * 3)][col + (dc * 3)] == 'S')
            {
                return true;
            }

            return false;
        }
        int findXmasAllDirs(int row, int col)
        {
            // create a list of directions to search so we can loop over them
            int[][] dirs = {
                [0,-1], // up
                [-1,-1], // up & left
                [-1,0], // left
                [-1,1], // down & left
                [0, 1], // down
                [1, 1], // down & right
                [1,0], //right
                [1,-1] // up & right
                };

            int numXmasFound = 0;
            foreach (int[] dir in dirs)
            {
                if(xmasFound(row, col, dir[0], dir[1])) numXmasFound++; 
            }

            // // search up
            // if (row >= 3 &&
            // this.wordSearchRows[row - 1][col] == 'M' &&
            // this.wordSearchRows[row - 2][col] == 'A' &&
            // this.wordSearchRows[row - 3][col] == 'S') numXmasFound++;
            // // search up & left
            // if (row >= 3 && col >= 3 &&
            // this.wordSearchRows[row - 1][col - 1] == 'M' &&
            // this.wordSearchRows[row - 2][col - 2] == 'A' &&
            // this.wordSearchRows[row - 3][col - 3] == 'S') numXmasFound++;
            // // search left
            // if (col >= 3 &&
            // this.wordSearchRows[row][col - 1] == 'M' &&
            // this.wordSearchRows[row][col - 2] == 'A' &&
            // this.wordSearchRows[row][col - 3] == 'S') numXmasFound++;
            // // search down & left
            // if (row < this.gridHeight - 3 && col >= 3 &&
            // this.wordSearchRows[row + 1][col - 1] == 'M' &&
            // this.wordSearchRows[row + 2][col - 2] == 'A' &&
            // this.wordSearchRows[row + 3][col - 3] == 'S') numXmasFound++;
            // // search down
            // if (row < this.gridHeight - 3 &&
            // this.wordSearchRows[row + 1][col] == 'M' &&
            // this.wordSearchRows[row + 2][col] == 'A' &&
            // this.wordSearchRows[row + 3][col] == 'S') numXmasFound++;
            // // search down & right
            // if (row < this.gridHeight - 3 && col < this.gridWidth - 3 &&
            // this.wordSearchRows[row + 1][col + 1] == 'M' &&
            // this.wordSearchRows[row + 2][col + 2] == 'A' &&
            // this.wordSearchRows[row + 3][col + 3] == 'S') numXmasFound++;
            // // search right
            // if (col < this.gridWidth - 3 &&
            // this.wordSearchRows[row][col + 1] == 'M' &&
            // this.wordSearchRows[row][col + 2] == 'A' &&
            // this.wordSearchRows[row][col + 3] == 'S') numXmasFound++;
            // // search up & right
            // if (row >= 3 && col < this.gridWidth - 3 &&
            // this.wordSearchRows[row - 1][col + 1] == 'M' &&
            // this.wordSearchRows[row - 2][col + 2] == 'A' &&
            // this.wordSearchRows[row - 3][col + 3] == 'S') numXmasFound++;
            return numXmasFound;
        }

        Console.WriteLine($"Day {this.day} Part A solution: {xmasCount}");
        Console.WriteLine("-----------------------------------------");
        Console.WriteLine($"Running Day {this.day} part B");

        int masXCount = 0;

        // Loop over every char in the word search
        // When an 'A' is found search for 'MAS' in "x" shape
        // skip the outside edge of the grid
        for (int i = 1; i < this.gridWidth-1; i++)
        {
            for (int j = 1; j < this.gridHeight-1; j++)
            {
                if ('A' == this.wordSearchRows[i][j]) masXCount += findMasXAllDirs(i, j);
            }
        }

        int findMasXAllDirs(int row, int col)
        {
            int numMasXFound = 0;
            if (
                //row >= 1 && col >= 1 && row < this.gridHeight - 1 && col < this.gridWidth - 1 &&
            (
                (this.wordSearchRows[row - 1][col - 1] == 'M' &&
                this.wordSearchRows[row + 1][col + 1] == 'S') ||
                (this.wordSearchRows[row - 1][col - 1] == 'S' &&
                this.wordSearchRows[row + 1][col + 1] == 'M')
            ) &&
            (
                (this.wordSearchRows[row - 1][col + 1] == 'M' &&
                this.wordSearchRows[row + 1][col - 1] == 'S') ||
                (this.wordSearchRows[row - 1][col + 1] == 'S' &&
                this.wordSearchRows[row + 1][col - 1] == 'M')
            )
            ) numMasXFound++;
            return numMasXFound;
        }

        Console.WriteLine($"Day {this.day} Part B solution is: {masXCount}");
    }
}

class Day4Factory : AocDayFactory
{
    public override AocDay GetAocDay(int day)
    {
        return new Day4(day);
    }
}
