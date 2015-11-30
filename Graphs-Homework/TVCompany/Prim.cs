﻿namespace TVCompany
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Wintellect.PowerCollections;

    public class TVCompany
    {
        public static void Main()
        {
            // Considering the input as sequence of pairs of houses and cost between them
            var input = new string[] 
            {
                "1 2 12",
                "2 3 32",
                "1 4 18",
                "3 7 22",
                "1 5 15",
                "6 7 12",
                "3 4 99",
                "5 3 12",
                "8 1 32",
                "4 7 12",
                "3 8 22"
            };

            long answer = Solve(input);

            Console.WriteLine(answer);
        }

        public static long Solve(string[] input)
        {
            var graph = new Dictionary<int, List<CablePath>>();

            foreach (string connection in input)
            {
                string[] line = connection.Split();
                int from = int.Parse(line[0]);
                int to = int.Parse(line[1]);
                int cost = int.Parse(line[2]);

                if (!graph.ContainsKey(from))
                {
                    graph.Add(from, new List<CablePath>());
                }

                if (!graph.ContainsKey(to))
                {
                    graph.Add(to, new List<CablePath>());
                }

                graph[from].Add(new CablePath { FromHouse = from, ToHouse = to, Cost = cost });
                graph[to].Add(new CablePath { FromHouse = to, ToHouse = from, Cost = cost });
            }

            int startNode = graph.First().Key;

            var bag = new OrderedBag<CablePath>();

            foreach (var neighbour in graph[startNode])
            {
                bag.Add(neighbour);
            }

            var minimumSpanningTreeCables = new List<CablePath>();

            var visitedNodes = new HashSet<int> { startNode };

            while (bag.Count > 0)
            {
                var min = bag.RemoveFirst();

                if (visitedNodes.Contains(min.ToHouse))
                {
                    continue;
                }

                minimumSpanningTreeCables.Add(min);

                visitedNodes.Add(min.ToHouse);

                foreach (var neighbour in graph[min.ToHouse])
                {
                    bag.Add(neighbour);
                }
            }

            return minimumSpanningTreeCables.Sum(c => c.Cost);
        }
    }

    public class CablePath : IComparable<CablePath>
    {
        public int FromHouse { get; set; }

        public int ToHouse { get; set; }

        public int Cost { get; set; }

        public int CompareTo(CablePath other)
        {
            return this.Cost.CompareTo(other.Cost);
        }
    }
}
