using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Graphs
{
    public class Graph
    {
        private Dictionary<string, List<string>> AdjacencyList { get; set; }

        public Graph()
        {
            AdjacencyList = new Dictionary<string, List<string>>();
        }

        public void AddVertex(string vertex)
        {
            AdjacencyList[vertex] = new List<string>();
        }

        public void AddEdge(string v1, string v2)
        {
            AdjacencyList[v1].Add(v2);
            AdjacencyList[v2].Add(v1);
        }

        public void RemoveEdge(string v1, string v2)
        {
            AdjacencyList[v1].Remove(v2);
            AdjacencyList[v2].Remove(v1);
        }

        public void RemoveVertex(string v)
        {
            foreach(string neighbour in AdjacencyList[v])
            {
                RemoveEdge(v, neighbour);
            }

            AdjacencyList.Remove(v);
        }

        public List<string> DfsRecursive(string vertex)
        {
            List<string> graphNodes = new List<string>();
            Dictionary<string, bool> visitedNodes = new Dictionary<string, bool>();

            RecursiveDfs(vertex, graphNodes, visitedNodes);

            return graphNodes;
        }

        private void RecursiveDfs(string vertex, List<string> graphNodes, Dictionary<string, bool> visitedNodes)
        {
            graphNodes.Add(vertex);
            visitedNodes[vertex] = true;

            // recursively vist each neighbour if not already visited
            foreach(string neighbour in AdjacencyList[vertex])
            {
                if (!visitedNodes.ContainsKey(neighbour))
                {
                    RecursiveDfs(neighbour, graphNodes, visitedNodes);
                }
            }
        }

        public List<string> DfsIterative(string vertex)
        {
            List<string> result = new List<string>();
            Dictionary<string, bool> visitedNodes = new Dictionary<string, bool>();

            // we use a stack ourselves instead of call stack in recursive solution
            Stack<string> stack = new Stack<string>();
            stack.Push(vertex);
            visitedNodes[vertex] = true;

            while(stack.Any())
            {
                string v = stack.Pop();

                result.Add(v);

                foreach(string neighbour in AdjacencyList[v])
                {
                    if (!visitedNodes.ContainsKey(neighbour))
                    {
                        visitedNodes[neighbour] = true; // immediately add to visited so it doesn't get pushed more than once
                        stack.Push(neighbour);
                    }
                }
            }

            return result;
        }

        public List<string> BfsTraversal(string vertex)
        {
            List<string> result = new List<string>();
            Dictionary<string, bool> visitedNodes = new Dictionary<string, bool>();

            // we use a queue instead of a stack for a BF traversal
            Queue<string> queue = new Queue<string>();
            queue.Enqueue(vertex);
            visitedNodes[vertex] = true;

            while(queue.Any())
            {
                string v = queue.Dequeue();

                result.Add(v);

                foreach(string neighbour in AdjacencyList[v])
                {
                    if (!visitedNodes.ContainsKey(neighbour))
                    {
                        visitedNodes[neighbour] = true;
                        queue.Enqueue(neighbour);
                    }
                }
            }

            return result;
        }
    }
}
