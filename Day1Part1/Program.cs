namespace Day1;

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
        
        firstList.Sort();
        secondList.Sort();
        
        var distances = firstList.Zip(secondList, (a, b) => Math.Abs(a-b));
        Console.WriteLine(distances.Sum());
    }
}