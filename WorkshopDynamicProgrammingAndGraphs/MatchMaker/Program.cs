using System;
using System.Collections.Generic;

namespace MatchMaker
{
    using System.Linq;

    public static class Program
    {
        private static readonly Dictionary<string, List<string>> vertices = new Dictionary<string, List<string>>();

        private static readonly HashSet<string> guys = new HashSet<string>();
        private static readonly HashSet<string> gals = new HashSet<string>();

        private static readonly Queue<string> queue = new Queue<string>();
        private static readonly Dictionary<string, int> matches = new Dictionary<string, int>();

        public static void Main()
        {
            ReadInput();
            Solve();
        }

        private static void ReadInput()
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                string gender = Console.ReadLine();
                Console.ReadLine();
                var interests = Console.ReadLine().Split(new [] {' '}, StringSplitOptions.RemoveEmptyEntries).Distinct();

                foreach (var interest in interests)
                {
                    string from;
                    string to;
                    if (gender == "m")
                    {
                        from = name;
                        to = interest;

                        if (!vertices.ContainsKey(to))
                        {
                            vertices.Add(to, new List<string>());
                        }

                        guys.Add(name);

                    }
                    else
                    {
                        from = interest;
                        to = name;

                        gals.Add(name);
                    }

                    if (!vertices.ContainsKey(from))
                    {
                        vertices.Add(from, new List<string>());
                    }

                    vertices[from].Add(to);
                }
            }
        }

        private static void Solve()
        {
            string bestGuy = string.Empty;
            int bestMatch = 0;
            string bestGal = string.Empty;

            foreach (string guy in guys)
            {
                matches.Clear();

                queue.Enqueue(guy);
                while (queue.Count > 0)
                {
                    string current = queue.Dequeue();
                    foreach (string next in vertices[current])
                    {
                        if (gals.Contains(next))
                        {
                            if (!matches.ContainsKey(next))
                            {
                                matches.Add(next, 0);
                            }

                            ++matches[next];
                        }
                        else
                        {
                            queue.Enqueue(next);
                        }
                    }
                }

                int currentMatch = 0;
                string currentGal = string.Empty;
                foreach (var match in matches)
                {
                    if (currentMatch < match.Value)
                    {
                        currentMatch = match.Value;
                        currentGal = match.Key;
                    }
                }

                if (bestMatch < currentMatch || (bestMatch == currentMatch && 0 < string.Compare(bestGuy, guy)))
                {
                    bestMatch = currentMatch;
                    bestGuy = guy;
                    bestGal = currentGal;
                }
            }

            Console.WriteLine("{0} and {1} have {2} common interest{3}!", bestGuy, bestGal, bestMatch, bestMatch == 1 ? "" : "s");
        }
    }
}
