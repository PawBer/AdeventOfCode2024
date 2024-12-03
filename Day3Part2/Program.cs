using System.Text.RegularExpressions;

namespace Day3Part2;

class Program
{
    static void Main(string[] args)
    {
        var memory = File.ReadAllText("input.txt");
        var controlRegex = @"(don't\(\))(.|\n)*?(do\(\))";
        var mulRegex = @"mul\(([0-9]+),([0-9]+)\)";

        List<List<int>> disabledRanges = [];
        var controlMatches = Regex.Matches(memory, controlRegex);
        foreach (Match match in controlMatches)
        {
            var disabledStart = match.Groups[1].Index;
            var disabledEnd = match.Groups[2].Index;
            
            disabledRanges.Add([disabledStart, disabledEnd]);
        }
        
        var mulMatches = Regex.Matches(memory, mulRegex);
        var sum = 0;

        foreach (Match match in mulMatches)
        {
            if (disabledRanges.Any(r => match.Index > r[0] && match.Index < r[1]))
            {
                continue;
            }
            
            var multiplicand = int.Parse(match.Groups[1].Value);
            var multiplier = int.Parse(match.Groups[2].Value);
            sum += multiplicand * multiplier;
        }
        
        Console.WriteLine(sum);
    }
}