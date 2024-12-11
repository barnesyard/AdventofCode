using System.Net;
using System.Reflection;
// See https://aka.ms/new-console-template for more information
// Importing file
Console.WriteLine("Advent of Code, 2024 is Upon Us!");

AocDayFactory factory;

//Console.Write("Input AOC Day to run: ");
//var inputDay = Console.ReadLine();
var inputDay = "4";

string inputDayStr = "1";
if (inputDay == null)
{
    throw new Exception("No day detected in the input value.");
}
else
{
    inputDayStr = inputDay;
}

string factoryTypeName = "Day" + inputDayStr + "Factory";
Type factoryType = Type.GetType(factoryTypeName) ?? throw new Exception("Type " + factoryTypeName + " was not found");
var constructorInfo = factoryType.GetConstructor(BindingFlags.Public | BindingFlags.Instance, Type.EmptyTypes);

factory = (AocDayFactory)constructorInfo!.Invoke(null);

AocDay aocDay = factory.GetAocDay(int.Parse(inputDay));
aocDay.SolveDay();

abstract class AocDay
{
    // I am saving my path as an absolute value for the sake of convenience. Could overide this with a cmd line arg
    private readonly string pathToAocData = @"C:\Code\AdventOfCode\AOCData";
    public abstract void SolveDay();
    public abstract void FormatData();
    private readonly int year = 2024;
    public int day;
    public string input;

    public AocDay (int day)
    {
        this.day = day;
        this.input = GetInput(day, year);
    }

    /// <summary>
    /// This is a method that will get the input for the puzzle. It will pull the data
    /// from a file if it exists. If the file doesn't exist it will use http client to
    /// make a call to get the data from AoC site then store it in a file.
    /// </summary>
    /// <param name="day">Day of the AoC event, valid values of 1 - 25</param>
    /// <param name="year">Year of the AoC event</param>
    /// <returns>A string that contains the entire raw input from the AoC site</returns>
    /// <remarks> I want this to be a simple non async method but if the 
    /// methods that are called fail to get data from the site I want the exception to 
    /// bubble up to here.
    /// </remarks>
    public string GetInput(int day, int year)
    {
        string filename = year + "D" + day.ToString("D2") + ".txt";
        string pathToDayData = Path.Combine(this.pathToAocData, filename);
        if (!File.Exists(pathToDayData))
        {
            // Since I need the data to work on the puzzle I am forcing this async method to run synchronously
           SaveDataToFileAsync(year, day, pathToDayData).GetAwaiter().GetResult();
        }
        // Eventually we want to return a string here with the data in the file
        string retVal = File.ReadAllText(pathToDayData);
        return retVal;
    }

    /// <summary>
    /// This method gets a session token that is stored in a file called session.txt
    /// </summary>
    /// <param name="folderPath">The folder where the file is stored on local drive</param>
    /// <returns>string with the session token that can be used in an http request</returns>
    /// <remarks> I want to find a way to get a token from Github site and not store in a local file </remarks>
    private string GetSessionToken(string folderPath)
    {
        return File.ReadAllText(Path.Combine(folderPath, "session.txt"));
    }

    private async Task SaveDataToFileAsync(int year, int day, string filename)
    {
        var uri = new Uri("https://adventofcode.com");
        string cookie = GetSessionToken(this.pathToAocData);
        CookieContainer cookies = new();
        cookies.Add(uri, new System.Net.Cookie("session", cookie));
        using var handler = new HttpClientHandler() { CookieContainer = cookies };
        using var client = new HttpClient(handler) { BaseAddress = uri };
        using var response = await client.GetAsync($"/{year}/day/{day}/input");
        // we can use the response to ensure it worked before we create a file. 
        // if it didn't work we can throw an exception
        response.EnsureSuccessStatusCode();

        using var stream = await response.Content.ReadAsStreamAsync();
        using var file = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None);
        await stream.CopyToAsync(file);
    }
}

abstract class AocDayFactory
{
    public abstract AocDay GetAocDay(int day);
}
