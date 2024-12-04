namespace Day4Part2;

class Program
{
    private static bool checkLeftDiagonal(string[] lines, int i, int j)
    {
        if (lines[i - 1][j - 1] == 'M' && lines[i][j] == 'A' && lines[i + 1][j + 1] == 'S')
            return true;
        else if (lines[i - 1][j - 1] == 'S' && lines[i][j] == 'A' && lines[i + 1][j + 1] == 'M')
            return true;
        else
            return false;
    }
    
    private static bool checkRightDiagonal(string[] lines, int i, int j)
    {
        if (lines[i - 1][j + 1] == 'M' && lines[i][j] == 'A' && lines[i + 1][j - 1] == 'S')
            return true;
        else if (lines[i - 1][j + 1] == 'S' && lines[i][j] == 'A' && lines[i + 1][j - 1] == 'M')
            return true;
        else
            return false;
    }

    static void Main(string[] args)
    {
        var lines = System.IO.File.ReadAllLines("input.txt");

        var count = 0;

        for (int i = 1; i < lines.Length - 1; i++)
        {
            for (int j = 1; j < lines[i].Length - 1; j++)
            {
                if (checkLeftDiagonal(lines, i, j) && checkRightDiagonal(lines, i, j))
                {
                    count++;
                }
            }
        }

        Console.WriteLine(count);
    }
}