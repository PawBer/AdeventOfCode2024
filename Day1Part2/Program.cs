namespace Day1Part2;

class Program
{
    static void Main(string[] args)
    {
        List<int> firstList = [], secondList = [];
        
        foreach (var line in File.ReadLines("input.txt"))
        {
            var numbers = line.Split("   ");
            firstList.Add(int.Parse(numbers[0]));
            secondList.Add(int.Parse(numbers[1]));
        }
        
        var numberCounts = new Dictionary<int, int>();
        foreach (var number in secondList)
        {
            numberCounts.TryAdd(number, 0);
            numberCounts[number]++;
        }

        var similarity = 0;
        foreach (var number in firstList)
        {
            if (numberCounts.TryGetValue(number, out var count))
            {
                similarity += count * number;
            }
        }
        
        Console.WriteLine(similarity);
    }
}