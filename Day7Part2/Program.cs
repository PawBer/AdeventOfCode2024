namespace Day7Part2;

record Equation(long Result, List<int> Numbers);

enum Operation
{
    Add,
    Multiply,
    Concat
}

class Program
{
    static List<List<Operation>> GenerateOperations(int length)
    {
        var operations = new List<List<Operation>>();
        GenerateOperationsRecursive(new List<Operation>(), length, operations);
        return operations;
    }

    static void GenerateOperationsRecursive(List<Operation> current, int length, List<List<Operation>> result)
    {
        if (current.Count == length)
        {
            result.Add(new List<Operation>(current));
            return;
        }

        foreach (Operation operation in Enum.GetValuesAsUnderlyingType(typeof(Operation)))
        {
            current.Add(operation);
            GenerateOperationsRecursive(current, length, result);
            current.RemoveAt(current.Count - 1);
        }
    }
    
    static void Main(string[] args)
    {
        var equationLines = File.ReadAllLines("input.txt");
        var equations = equationLines.Select(equationString =>
        {
            var elements = equationString.Split(": ");
            var numbers = elements[1].Split(' ').Select(int.Parse).ToList();
            return new Equation(long.Parse(elements[0]), numbers);
        }).ToList();

        long sum = 0;
        
        foreach (var equation in equations)
        {
            var found = false;
            var operationPermutations = GenerateOperations(equation.Numbers.Count - 1);
            foreach (var operations in operationPermutations)
            {
                if (found)
                    continue;
                
                long result = equation.Numbers[0];
                for (var i = 0; i < operations.Count; i++)
                {
                    if (operations[i] == Operation.Add)
                    {
                        result += equation.Numbers[i + 1];
                    } else if (operations[i] == Operation.Multiply)
                    {
                        result *= equation.Numbers[i + 1];
                    } else if (operations[i] == Operation.Concat)
                    {
                        result = long.Parse(result.ToString() + equation.Numbers[i + 1].ToString());
                    }
                }

                if (result == equation.Result)
                {
                    sum += result;
                    found = true;
                }
                    
            }
        }
        
        Console.WriteLine(sum);
    }
}