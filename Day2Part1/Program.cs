namespace Day2Part1;

struct Report
{
    private List<int> _measurements;

    public Report(string reportString)
    {
        var measurements = reportString.Split(' ').Select(int.Parse).ToList();
        _measurements = measurements;
    }

    public bool IsMonotonic()
    {
        if (_measurements.Count < 2)
        {
            return true;
        }

        var monotonic = true;
        if (_measurements[0] < _measurements[1])
        {
            for (var i = 1; i < _measurements.Count - 1; i++)
            {
                if (_measurements[i] > _measurements[i + 1])
                {
                    monotonic = false;
                }
            }
        }
        else
        {
            for (var i = 1; i < _measurements.Count - 1; i++)
            {
                if (_measurements[i] < _measurements[i + 1])
                {
                    monotonic = false;
                }
            }
        }

        return monotonic;
    }

    public bool IsChangingSafely()
    {
        if (_measurements.Count < 2)
        {
            return true;
        }

        var safe = true;
        for (var i = 0; i < _measurements.Count - 1; i++)
        {
            if (_measurements[i] == _measurements[i + 1] || Math.Abs(_measurements[i] - _measurements[i + 1]) > 3)
            {
                safe = false;
            }
        }

        return safe;
    }
    
    public bool IsSafe() => IsMonotonic() && IsChangingSafely();
}

class Program
{
    static void Main(string[] args)
    {
        var reports = File.ReadAllLines("input.txt").Select((line) => new Report(line)).ToList();
        var sum = reports.Count(r => r.IsSafe());
        Console.WriteLine(sum);
    }
}