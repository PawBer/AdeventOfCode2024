namespace Day8Part1;

interface INode;

record struct Empty : INode;

record struct Antenna(char Frequency) : INode;

record struct Antinode : INode;

class Program
{
    static void Main(string[] args)
    {
        var grid = new List<List<INode>>();
        var lines = File.ReadAllLines("input.txt");

        foreach (var line in lines)
        {
            var row = new List<INode>();
            foreach (var node in line)
            {
                switch (node)
                {
                    case '.':
                        row.Add(new Empty());
                        break;
                    default:
                        row.Add(new Antenna(node));
                        break;
                }
            }

            grid.Add(row);
        }

        var antinodeLocations = new HashSet<(int, int)>();

        for (var row = 0; row < grid.Count; row++)
        {
            for (var col = 0; col < grid[row].Count; col++)
            {
                if (grid[row][col] is Empty or Antinode)
                    continue;

                var frequency = ((Antenna)grid[row][col]).Frequency;

                for (var i = 0; i < grid.Count; i++)
                {
                    for (var j = 0; j < grid[i].Count; j++)
                    {
                        if (i == row && j == col)
                            continue;
                        if (grid[i][j] is Empty or Antinode)
                            continue;

                        var secondFrequency = ((Antenna)grid[i][j]).Frequency;
                        if (frequency != secondFrequency)
                            continue;

                        var (dx, dy) = (Math.Abs(j - col), Math.Abs(i - row));

                        double slope;
                        if (j < col)
                            slope = (double)(row - i) / (col - j);
                        else
                            slope = (double)(i - row) / (j - col);

                        var b = i - slope * j;
                        
                        var x = j < col ? j - dx : col - dx;
                        var y = (int)Math.Round(x * slope + b);
                        if (y >= 0 && y < grid.Count && x >= 0 && x < grid[y].Count)
                            antinodeLocations.Add((x, y));

                        x = j < col ? col + dx : j + dx;
                        y = (int)Math.Round(x * slope + b);
                        if (y >= 0 && y < grid.Count && x >= 0 && x < grid[y].Count)
                            antinodeLocations.Add((x, y));
                    }
                }
            }
        }


        Console.WriteLine(antinodeLocations.Count);
    }
}