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

            foreach(string neighbour in AdjacencyList[vertex])
            {
                if (!visitedNodes.ContainsKey(neighbour))
                {
                    RecursiveDfs(neighbour, graphNodes, visitedNodes);
                }
            }
        }
    }
}
