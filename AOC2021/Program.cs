// See https://aka.ms/new-console-template for more information
// Importing file
Console.WriteLine("Advent of Code is Upon Us!");

AocDayFactory factory = null;

Console.Write("Input AOC Day to run: ");
string inputDay = Console.ReadLine();
switch (inputDay)
{
    case "1":
        factory = new Day3Factory();
        break;
    case "2":
        factory = new Day2Factory();
        break;
    case "3":
        factory = new Day3Factory();
        break;
    case "4":
        factory = new Day4Factory();
        break;
    default:
        break;
}

AocDay aocDay = factory.GetAocDay();
aocDay.RunPartA();

abstract class AocDay
{
    public abstract void RunPartA();
    public abstract void RunPartB();
}

abstract class AocDayFactory
{
    public abstract AocDay GetAocDay();
}




