namespace Day6Part2;

enum NodeType
{
    Empty = '.',
    Obstacle = '#'
}

enum GuardDirection
{
    Up,
    Left,
    Right,
    Down
}

class Program
{
    static bool doesTerminate(List<List<NodeType>> nodes, (int, int) guardLocation, GuardDirection direction, (int, int) obstacleLocation)
    {
        var grid = nodes.Select(row => new List<NodeType>(row)).ToList();
        
        if (grid[obstacleLocation.Item2][obstacleLocation.Item1] == NodeType.Obstacle)
        {
            return true;
        }

        if (obstacleLocation.Item1 == guardLocation.Item1 && obstacleLocation.Item2 == guardLocation.Item2)
        {
            return true;
        }
        
        grid[obstacleLocation.Item2][obstacleLocation.Item1] = NodeType.Obstacle;
        
        var loopCounter = 0;
        while (loopCounter < 100000)
        {
            if (direction == GuardDirection.Up)
            {
                if (guardLocation.Item2 - 1 == -1)
                {
                    return true;
                }
                
                if (grid[guardLocation.Item2 - 1][guardLocation.Item1] == NodeType.Obstacle)
                    direction = GuardDirection.Right;
                else
                {
                    guardLocation = (guardLocation.Item1, guardLocation.Item2 - 1);
                    loopCounter++;
                }
            }
            else if (direction == GuardDirection.Left)
            {
                if (guardLocation.Item1 - 1 == -1)
                {
                    return true;
                }
                
                if (grid[guardLocation.Item2][guardLocation.Item1 - 1] == NodeType.Obstacle)
                    direction = GuardDirection.Up;
                else
                {
                    guardLocation = (guardLocation.Item1 - 1, guardLocation.Item2);
                    loopCounter++;
                }
            }
            else if (direction == GuardDirection.Right)
            {
                if (guardLocation.Item1 + 1 == grid[0].Count)
                {
                    return true;
                }
                
                if (grid[guardLocation.Item2][guardLocation.Item1 + 1] == NodeType.Obstacle)
                    direction = GuardDirection.Down;
                else
                {
                    guardLocation = (guardLocation.Item1 + 1, guardLocation.Item2);
                    loopCounter++;
                }
            }
            else if (direction == GuardDirection.Down)
            {
                if (guardLocation.Item2 + 1 == grid.Count)
                {
                    return true;
                }
                
                if (grid[guardLocation.Item2 + 1][guardLocation.Item1] == NodeType.Obstacle)
                    direction = GuardDirection.Left;
                else
                {
                    guardLocation = (guardLocation.Item1, guardLocation.Item2 + 1);
                    loopCounter++;
                }
            }

            loopCounter++;
        }

        return false;
    }
    
    static void Main(string[] args)
    {
        var grid = new List<List<NodeType>>();
        var input = File.ReadAllLines("input.txt");
        var direction = GuardDirection.Up;
        var guardLocation = (0, 0);
        
        
        for (var i = 0; i < input.Length; i++)
        {
            var row = new List<NodeType>();
            for (var j = 0; j < input[i].Length; j++)
            {
                switch (input[i][j])
                {
                    case '#':
                        row.Add(NodeType.Obstacle);
                        break;
                    case '.':
                        row.Add(NodeType.Empty);
                        break;
                    case '^':
                        row.Add(NodeType.Empty);
                        direction = GuardDirection.Up;
                        guardLocation = (j, i);
                        break;
                    case '>':
                        row.Add(NodeType.Empty);
                        direction = GuardDirection.Right;
                        guardLocation = (j, i);
                        break;
                    case '<':
                        row.Add(NodeType.Empty);
                        direction = GuardDirection.Left;
                        guardLocation = (j, i);
                        break;
                    case 'v':
                        row.Add(NodeType.Empty);
                        direction = GuardDirection.Down;
                        guardLocation = (j, i);
                        break;
                }
            }
            grid.Add(row);
        }

        var counter = 0;
        
        for (var i = 0; i < input.Length; i++)
        {
            for (var j = 0; j < input[i].Length; j++)
            {
                var terminates = doesTerminate(grid, guardLocation, direction, (j, i));
                if (!terminates)
                {
                    counter++;
                }
            }
        }
        
        Console.WriteLine(counter);
    }
}