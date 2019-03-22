using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Heaps
{
    public class Node
    {
        public string Val { get; set; }
        public double Priority { get; set; }

        public Node(double priority, string val)
        {
            Priority = priority;
            Val = val;
        }
    }

    // implemented using a Binary Heap
    public class PriorityQueue
    {
        private readonly List<Node> nodes = new List<Node>();

        public bool IsEmpty { get { return !nodes.Any(); } }

        public void PrintItems()
        {
            StringBuilder sb = new StringBuilder();

            foreach (Node item in nodes)
            {
                sb.Append($"{item.Priority}: {item.Val}, ");
            }

            string printString = sb.Length > 1 ? sb.ToString(0, sb.Length - 2) : sb.ToString();

            Console.WriteLine(printString);
        }

        public void Enqueue(string val, double priority)
        {
            Node n = new Node(priority, val);

            // Step 1: add the value to the end        
            nodes.Add(n);

            BubbleUp(n);
        }

        public Node Dequeue()
        {
            if (nodes.Count == 0) return null;

            Node max = nodes[0];
            Node lastItem = nodes[nodes.Count - 1];

            nodes[0] = lastItem;
            nodes.RemoveAt(nodes.Count - 1);

            if (nodes.Count > 0)
            {
                BubbleDown();
            }

            return max;
        }

        private void BubbleUp(Node item)
        {
            int idx = nodes.Count - 1;

            while (idx > 0)
            {
                int parentIdx = (idx - 1) / 2;

                Node parent = nodes[parentIdx];

                if (item.Priority >= parent.Priority) break;

                // swap parent <-> child
                nodes[parentIdx] = item;
                nodes[idx] = parent;

                idx = parentIdx;
            }
        }

        private void BubbleDown()
        {
            int idx = 0;

            while (true)
            {
                Node item = nodes[idx];

                int length = nodes.Count;

                int leftChildIdx = (idx * 2) + 1;
                int rightChildIdx = (idx * 2) + 2;
                int? swapIdx = null;

                if (leftChildIdx < length)
                {
                    if (nodes[leftChildIdx].Priority < item.Priority)
                    {
                        swapIdx = leftChildIdx;
                    }
                }

                if (rightChildIdx < length)
                {
                    if ((!swapIdx.HasValue && nodes[rightChildIdx].Priority < item.Priority)
                            || (swapIdx.HasValue && nodes[rightChildIdx].Priority < nodes[leftChildIdx].Priority))
                    {
                        swapIdx = rightChildIdx;
                    }
                }

                if (!swapIdx.HasValue) break;

                // swap parent item with child that is larger
                Node childItem = nodes[swapIdx.Value]; // item value to swap

                nodes[swapIdx.Value] = item;
                nodes[idx] = childItem;

                idx = swapIdx.Value; // this is now the new parent for next iteration
            }
        }
    }
}
