namespace Day4Part1;

class Program
{
    private static bool checkNorth(string[] lines, int i, int j)
    {
        return i >= 3 &&
               lines[i][j] == 'X' && lines[i - 1][j] == 'M' && lines[i - 2][j] == 'A' &&
               lines[i - 3][j] == 'S';
    }

    private static bool checkSouth(string[] lines, int i, int j)
    {
        return i + 3 < lines.Length &&
               lines[i][j] == 'X' && lines[i + 1][j] == 'M' && lines[i + 2][j] == 'A' &&
               lines[i + 3][j] == 'S';
    }

    private static bool checkWest(string[] lines, int i, int j)
    {
        return j >= 3 &&
               lines[i][j] == 'X' && lines[i][j - 1] == 'M' && lines[i][j - 2] == 'A' &&
               lines[i][j - 3] == 'S';
    }

    private static bool checkEast(string[] lines, int i, int j)
    {
        return j + 3 < lines[i].Length &&
               lines[i][j] == 'X' && lines[i][j + 1] == 'M' && lines[i][j + 2] == 'A' &&
               lines[i][j + 3] == 'S';
    }

    private static bool checkNortheast(string[] lines, int i, int j)
    {
        return i >= 3 && j + 3 < lines[i].Length &&
               lines[i][j] == 'X' && lines[i - 1][j + 1] == 'M' && lines[i - 2][j + 2] == 'A' &&
               lines[i - 3][j + 3] == 'S';
    }

    private static bool checkNorthwest(string[] lines, int i, int j)
    {
        return i >= 3 && j >= 3 &&
               lines[i][j] == 'X' && lines[i - 1][j - 1] == 'M' && lines[i - 2][j - 2] == 'A' &&
               lines[i - 3][j - 3] == 'S';
    }

    private static bool checkSoutheast(string[] lines, int i, int j)
    {
        return i + 3 < lines.Length &&
               j + 3 < lines[i].Length &
               lines[i][j] == 'X' && lines[i + 1][j + 1] == 'M' && lines[i + 2][j + 2] == 'A' &&
               lines[i + 3][j + 3] == 'S';
    }

    private static bool checkSouthwest(string[] lines, int i, int j)
    {
        return i + 3 < lines.Length && j >= 3 &&
               lines[i][j] == 'X' && lines[i + 1][j - 1] == 'M' && lines[i + 2][j - 2] == 'A' &&
               lines[i + 3][j - 3] == 'S';
    }

    static void Main(string[] args)
    {
        var lines = System.IO.File.ReadAllLines("input.txt");

        var count = 0;

        for (int i = 0; i < lines.Length; i++)
        {
            for (int j = 0; j < lines[i].Length; j++)
            {
                if (checkNorth(lines, i, j)) count++;
                if (checkSouth(lines, i, j)) count++;
                if (checkEast(lines, i, j)) count++;
                if (checkWest(lines, i, j)) count++;
                if (checkNortheast(lines, i, j)) count++;
                if (checkNorthwest(lines, i, j)) count++;
                if (checkSoutheast(lines, i, j)) count++;
                if (checkSouthwest(lines, i, j)) count++;
            }
        }

        Console.WriteLine(count);
    }
}