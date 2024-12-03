using System.Text.RegularExpressions;

namespace Day3Part1;

class Program
{
    static void Main(string[] args)
    {
        var memory = File.ReadAllText("input.txt");
        var mulRegex = @"mul\(([0-9]+),([0-9]+)\)";
        
        var matches = Regex.Matches(memory, mulRegex);
        var sum = 0;

        foreach (Match match in matches)
        {
            var multiplicand = int.Parse(match.Groups[1].Value);
            var multiplier = int.Parse(match.Groups[2].Value);
            sum += multiplicand * multiplier;
        }
        
        Console.WriteLine(sum);
    }
}