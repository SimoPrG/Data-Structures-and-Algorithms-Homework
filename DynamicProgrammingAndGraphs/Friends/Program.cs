namespace Friends
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static int n;
        static int m;

        static int start;
        static int end;

        static int mid1;
        static int mid2;

        static Dictionary<int, int>[] graph;

        private static void Main()
        {
            StartUp.ReadInput();
            StartUp.Solve();
        }

        private static void ReadInput()
        {
            int[] graphDimensions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            StartUp.n = graphDimensions[0];
            StartUp.m = graphDimensions[1];

            int[] pathDimensions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            StartUp.start = pathDimensions[0];
            StartUp.end = pathDimensions[1];

            int[] mids = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            StartUp.mid1 = mids[0];
            StartUp.mid2 = mids[1];

            StartUp.graph = new Dictionary<int, int>[StartUp.n + 1];
            for (int i = 1; i <= StartUp.m; i++)
            {
                int[] edges = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                var from = edges[0];
                var to = edges[1];
                var cost = edges[2];

                // no need to store all edges between two nodes, only the edge with lowest cost
                if (StartUp.graph[from] != null && StartUp.graph[from].ContainsKey(to))
                {
                    var currentCost = StartUp.graph[from][to];
                    if (currentCost > cost)
                    {
                        StartUp.graph[from][to] = cost;
                        StartUp.graph[to][from] = cost;
                    }

                    continue;
                }

                if (StartUp.graph[from] == null)
                {
                    StartUp.graph[from] = new Dictionary<int, int>();
                }

                StartUp.graph[from].Add(to, cost);

                if (StartUp.graph[to] == null)
                {
                    StartUp.graph[to] = new Dictionary<int, int>();
                }

                StartUp.graph[to].Add(from, cost);
            }
        }

        private static void Solve()
        {
            int m1Cost = StartUp.Djikstra(StartUp.start, StartUp.mid1, StartUp.mid2, StartUp.end);
            int m2Cost = StartUp.Djikstra(StartUp.start, StartUp.mid2, StartUp.mid1, StartUp.end);

            int m1M2Cost = StartUp.Djikstra(StartUp.mid1, StartUp.mid2);

            int m1EndCost = StartUp.Djikstra(StartUp.mid1, StartUp.end, StartUp.mid2, StartUp.start);
            int m2EndCost = StartUp.Djikstra(StartUp.mid2, StartUp.end, StartUp.mid1, StartUp.start);

            int min = Math.Min(
                m1Cost + m1M2Cost + m2EndCost,
                m2Cost + m1M2Cost + m1EndCost);

            Console.WriteLine(min);
        }

        private static int Djikstra(int start, int end, params int[] excluded)
        {
            var cost = Enumerable.Repeat<int>(int.MaxValue, StartUp.n + 1).ToArray();
            cost[start] = 0;
            var visited = new bool[StartUp.n + 1];

            while (true)
            {
                int minCostNode = 0;
                for (int i = 1; i < visited.Length; i++)
                {
                    if (!visited[i] && cost[i] < cost[minCostNode])
                    {
                        minCostNode = i;
                    }
                }

                if (minCostNode == 0)
                {
                    break;
                }

                visited[minCostNode] = true;

                if (StartUp.graph[minCostNode] == null)
                {
                    continue;
                }

                var neighbors = StartUp.graph[minCostNode];
                foreach (var neighbor in neighbors)
                {
                    if (excluded.Contains(neighbor.Key))
                    {
                        continue;
                    }

                    if (cost[minCostNode] + neighbor.Value < cost[neighbor.Key])
                    {
                        cost[neighbor.Key] = cost[minCostNode] + neighbor.Value;
                    }
                }
            }

            return cost[end];
        }
    }
}