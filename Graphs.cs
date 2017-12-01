using System.Collections.Generic;

namespace DataStructuresAndAlgorithms
{
    public interface INode
    {
        IEnumerable<INode> ChildNodes { get; }
    }

    public static class Graphs
    {
        public static bool AreAllConnected(this IEnumerable<INode> graph)
        {
            int count = 0;
            var visited = new HashSet<INode>();

            foreach (var node in graph)
            {
                count++;
                visited.BFS(node);

                // or DFS(node, visited);
            }

            return count == visited.Count;
        }

        public static void DFS(this ISet<INode> visited, INode pivotNode)
        {
            var stack = new Stack<INode>();
            stack.Push(pivotNode);

            while (stack.Count != 0)
            {
                var nodes = stack.Pop().ChildNodes;
                foreach (var node in nodes)
                {
                    if (visited.Add(node))
                    {
                        stack.Push(node);
                    }
                }
            }
        }

        public static void BFS(this ISet<INode> visited, INode pivotNode)
        {
            var queue = new Queue<INode>();
            queue.Enqueue(pivotNode);

            while (queue.Count != 0)
            {
                var nodes = queue.Dequeue().ChildNodes;
                foreach (var node in nodes)
                {
                    if (visited.Add(node))
                    {
                        queue.Enqueue(node);
                    }
                }
            }
        }

    }
}