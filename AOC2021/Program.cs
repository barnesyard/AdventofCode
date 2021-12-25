using System.Reflection;
// See https://aka.ms/new-console-template for more information
// Importing file
Console.WriteLine("Advent of Code is Upon Us!");

AocDayFactory factory;

//Console.Write("Input AOC Day to run: ");
//var inputDay = Console.ReadLine();
var inputDay = "10";

string inputDayStr = "1";
if(inputDay == null)
{
    throw new Exception("No day detected in the input vale.");
} else 
{
    inputDayStr = inputDay;
}

string factoryTypeName = "Day" + inputDayStr + "Factory";
Type factoryType = Type.GetType(factoryTypeName) ?? throw new Exception ("Type " + factoryTypeName + " was not found");
var constructorInfo = factoryType.GetConstructor(BindingFlags.Public | BindingFlags.Instance, Type.EmptyTypes);

factory = (AocDayFactory)constructorInfo!.Invoke(null);

AocDay aocDay = factory.GetAocDay();
aocDay.SolveDay();

abstract class AocDay
{
    public abstract void SolveDay();
}

abstract class AocDayFactory
{
    public abstract AocDay GetAocDay();
}




