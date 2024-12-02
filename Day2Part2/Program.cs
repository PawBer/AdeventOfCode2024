namespace Day2Part2;

static class Report
{
    public static bool IsMonotonic(List<int> measurements)
    {
        if (measurements.Count < 2)
        {
            return true;
        }

        var monotonic = true;
        if (measurements[0] < measurements[1])
        {
            for (var i = 1; i < measurements.Count - 1; i++)
            {
                if (measurements[i] > measurements[i + 1])
                {
                    monotonic = false;
                    break;
                }
            }
        }
        else
        {
            for (var i = 1; i < measurements.Count - 1; i++)
            {
                if (measurements[i] < measurements[i + 1])
                {
                    monotonic = false;
                    break;
                }
            }
        }

        return monotonic;
    }

    public static bool IsChangingSafely(List<int> measurements)
    {
        if (measurements.Count < 2)
        {
            return true;
        }

        var safe = true;
        for (var i = 0; i < measurements.Count - 1; i++)
        {
            if (measurements[i] == measurements[i + 1] || Math.Abs(measurements[i] - measurements[i + 1]) > 3)
            {
                safe = false;
                break;
            }
        }

        return safe;
    }


    public static bool IsSafe(List<int> measurements) => IsMonotonic(measurements) && IsChangingSafely(measurements);

    public static bool CheckWithTolerance(List<int> measurements)
    {
        if (IsSafe(measurements))
        {
            return true;
        }

        for (var i = 0; i < measurements.Count; i++)
        {
            var measurementsCopy = measurements.ToList();
            measurementsCopy.RemoveAt(i);
            if (IsSafe(measurementsCopy))
            {
                return true;
            }
        }
        
        return false;
    }
}

class Program
{
    static void Main(string[] args)
    {
        var reports = File
            .ReadAllLines("input.txt")
            .Select(line => line
                .Split(' ')
                .Select(int.Parse)
                .ToList()
            )
            .ToList();

        var safeReports = reports.Count(Report.CheckWithTolerance);
        Console.WriteLine(safeReports);
        //reports.Select(Report.CheckWithTolerance).ToList().ForEach(Console.WriteLine);
    }
}