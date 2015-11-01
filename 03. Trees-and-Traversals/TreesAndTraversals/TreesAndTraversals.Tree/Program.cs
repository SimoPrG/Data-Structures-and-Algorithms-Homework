// You are given a tree of N nodes represented as a set of N-1 pairs of nodes(parent node, child node),
// each in the range(0..N-1).
// Write a program to read the tree and find:
   
// the root node
// all leaf nodes
// all middle nodes
// the longest path in the tree
// (*) all paths in the tree with given sum `S` of their nodes
// (*) all subtrees with given sum `S` of their nodes

namespace TreesAndTraversals.Tree
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    internal class Program
    {
        public static void Main()
        {
            var reader = new StringReader(
@"7
2 4
3 2
5 0
3 5
5 6
5 1");

            Console.SetIn(reader);

            int n = int.Parse(Console.ReadLine());

            var treeNodes = new TreeNode<int>[n];
            for (int i = 0; i < n; i++)
            {
                treeNodes[i] = new TreeNode<int>(i);
            }

            for (int i = 1; i < n; i++)
            {
                var parentChild = Console.ReadLine().Split(' ');
                var parent = int.Parse(parentChild[0]);
                var child = int.Parse(parentChild[1]);

                treeNodes[parent].Children.Add(treeNodes[child]);
                treeNodes[child].HasParent = true;
            }

            Console.WriteLine($"The root is {FindRoot(treeNodes)}");
            Console.WriteLine($"The leafs are {string.Join(", ", FindAllLeafs(treeNodes))}");
            Console.WriteLine($"The middles are {string.Join(", ", FindAllMiddleNodes(treeNodes))}");
            Console.WriteLine($"The longest path is {FindLongestPath(FindRoot(treeNodes))}");

            const int pathSum = 5;
            Console.WriteLine($"All paths with sum {pathSum}:");
            foreach (var path in FindAllPathsWithSum(FindRoot(treeNodes), pathSum).Where(p => p.Sum(nd => nd.Element) == pathSum))
            {
                Console.WriteLine(string.Join(", ", path));
            }

            const int treeSum = 6;
            Console.WriteLine($"All subtrees with sum {treeSum}:");
            foreach (var tree in FindAllSubTreesWithSum(FindRoot(treeNodes), treeSum))
            {
                Console.WriteLine(string.Join(", ", tree));
            }
        }

        public static TreeNode<int> FindRoot(IEnumerable<TreeNode<int>> treeNodes)
        {
            return treeNodes.FirstOrDefault(n => !n.HasParent);
        }

        public static IEnumerable<TreeNode<int>> FindAllLeafs(IEnumerable<TreeNode<int>> treeNodes)
        {
            return treeNodes.Where(n => !n.Children.Any());
        }

        public static IEnumerable<TreeNode<int>> FindAllMiddleNodes(IEnumerable<TreeNode<int>> treeNodes)
        {
            return treeNodes.Where(n => n.HasParent && n.Children.Any());
        }

        public static int FindLongestPath(TreeNode<int> root)
        {
            if (root.Children.Count == 0)
            {
                return 0;
            }

            int maxPath = 0;
            foreach (var child in root.Children)
            {
                maxPath = Math.Max(maxPath, FindLongestPath(child));
            }

            return maxPath + 1;
        }

        public static IEnumerable<Stack<TreeNode<int>>> FindAllPathsWithSum(TreeNode<int> node, int sum)
        {
            var paths = new List<Stack<TreeNode<int>>>();
            foreach (var child in node.Children)
            {
                paths.AddRange(FindAllPathsWithSum(child, sum));
            }

            for (int i = 0; i < paths.Count; i++)
            {
                var currentPath = paths[i];
                var currentPathSum = currentPath.Sum(n => n.Element);
                if (currentPathSum == sum)
                {
                    continue;
                }

                if (currentPathSum + node.Element <= sum)
                {
                    currentPath.Push(node);
                }
                else
                {
                    paths.Remove(currentPath);
                    --i;
                }
            }

            if (node.Element <= sum)
            {
                var pathStack = new Stack<TreeNode<int>>();
                pathStack.Push(node);
                paths.Add(pathStack);
            }

            return paths;
        }

        public static IEnumerable<IEnumerable<TreeNode<int>>> FindAllSubTreesWithSum(TreeNode<int> node, int sum)
        {
            var trees = new List<IEnumerable<TreeNode<int>>>();
            var tree = GetTree(node);
            if (tree.Sum(n => n.Element) == sum)
            {
                trees.Add(tree);
            }

            foreach (var child in node.Children)
            {
                trees.AddRange(FindAllSubTreesWithSum(child, sum));
            }

            return trees;
        }

        private static IEnumerable<TreeNode<int>> GetTree(TreeNode<int> node)
        {
            var tree = new List<TreeNode<int>> { node };
            var queue = new Queue<TreeNode<int>>();
            queue.Enqueue(node);
            while (queue.Count > 0)
            {
                var currentNode = queue.Dequeue();
                foreach (var child in currentNode.Children)
                {
                    queue.Enqueue(child);
                    tree.Add(child);
                }
            }

            return tree;
        }
    }
}