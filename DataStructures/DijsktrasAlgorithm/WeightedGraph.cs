using DataStructures.Heaps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.DijsktrasAlgorithm
{
    public class WeightedGraph
    {
        private Dictionary<string, List<Edge>> AdjacencyList { get; set; }

        public WeightedGraph()
        {
            this.AdjacencyList = new Dictionary<string, List<Edge>>();
        }

        public void AddVertex(string v)
        {
            AdjacencyList[v] = new List<Edge>();
        }

        public void AddEdge(string v1, string v2, int weight)
        {
            AdjacencyList[v1].Add(new Edge { Vertex = v2, Weight = weight });
            AdjacencyList[v2].Add(new Edge { Vertex = v1, Weight = weight });
        }

        public List<string> DijkstraShortestPath(string startVertex, string endVertex)
        {
            PriorityQueue nodes = new PriorityQueue();
            Dictionary<string, double> distances = new Dictionary<string, double>();
            Dictionary<string, string> previous = new Dictionary<string, string>();

            List<string> returnPath = new List<string>();

            // build up initial state
            foreach (string vertex in AdjacencyList.Keys)
            {
                if (vertex == startVertex)
                {
                    distances[vertex] = 0;
                    nodes.Enqueue(vertex, 0);
                }
                else
                {
                    distances[vertex] = double.PositiveInfinity;
                    nodes.Enqueue(vertex, double.PositiveInfinity);
                }

                previous[vertex] = null;
            }

            while(!nodes.IsEmpty)
            {
                string smallestWeightedNode = nodes.Dequeue().Val;

                if (smallestWeightedNode == endVertex)
                {
                    // we got to the target node - no need to look for further neighbours
                    // build up the path from start node to this from the 'previous' 

                    while (previous[smallestWeightedNode] != null)
                    {
                        returnPath.Add(smallestWeightedNode);

                        smallestWeightedNode = previous[smallestWeightedNode];
                    }

                    // start won't be added in previous loop as we are checking for previous[node] != null
                    // which would be null for the start node
                    returnPath.Add(startVertex);

                    returnPath.Reverse(); // reverse to start -> end

                    break; // stop looping the priority queue
                }
                
                if (distances[smallestWeightedNode] != double.PositiveInfinity)
                {
                    foreach (Edge neighbour in AdjacencyList[smallestWeightedNode])
                    {
                        // calculate new distance to neighbour
                        double newDistanceToNeighbour = distances[smallestWeightedNode] + neighbour.Weight;

                        if (newDistanceToNeighbour < distances[neighbour.Vertex])
                        {
                            // update the new smallest distance to the neighbour
                            distances[neighbour.Vertex] = newDistanceToNeighbour;

                            // update previous i.e how we got to nieghbour
                            previous[neighbour.Vertex] = smallestWeightedNode;

                            // enqueue in priority queue with new priority
                            nodes.Enqueue(neighbour.Vertex, newDistanceToNeighbour);
                        }
                    }
                }
            }

            return returnPath;
        }
    }

    class Edge
    {
        public string Vertex { get; set; }
        public double Weight { get; set; }
    }
}
