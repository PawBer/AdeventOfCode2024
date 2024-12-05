﻿namespace Day5Part1;

class Program
{
    static void Main(string[] args)
    {
        var input = File.ReadAllText("input.txt").Split("\n\n");
        var orderingsList = input[0]
            .Split("\n")
            .Select(
                o => o
                    .Split("|")
                    .Select(int.Parse)
                    .ToList()
            )
            .ToList();

        var orderings = new Dictionary<int, List<int>>();
        foreach (var ordering in orderingsList)
        {
            if (!orderings.ContainsKey(ordering[0]))
            {
                orderings.Add(ordering[0], [ordering[1]]);
                continue;
            }

            orderings[ordering[0]].Add(ordering[1]);
        }

        var pageNumbersList = input[1]
            .Split("\n")
            .Select(
                line => line
                    .Split(",")
                    .Select(int.Parse)
                    .ToList()
            )
            .ToList();
        
        var correct = pageNumbersList.Where(pn => CheckOrdering(pn, orderings)).ToList();
        var result = correct.Sum(pn =>
        {
            var length = pn.Count;
            return pn[length / 2];
        });
        
        Console.WriteLine(result);
    }

    static bool CheckOrdering(List<int> pageNumbers, Dictionary<int, List<int>> orderings)
    {
        var ordered = true;
        
        for (var i = 0; i < pageNumbers.Count; i++)
        {
            if (!orderings.ContainsKey(pageNumbers[i]))
                continue;
            
            for (var j = 0; j < pageNumbers.Count; j++)
            {
                if (orderings[pageNumbers[i]].Contains(pageNumbers[j]))
                {
                    if (i > j)
                    {
                        ordered = false;
                        break;
                    }
                }
            }
        }

        return ordered;
    }
}