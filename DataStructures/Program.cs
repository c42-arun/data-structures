﻿using DataStructures.DijsktrasAlgorithm;
using DataStructures.Graphs;
using DataStructures.Heaps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            //MaxBinaryHeapDemo();
            //PriorityQueueDemo();
            //GraphCreateDemo();
            //DijkstrasAlgorithm();
            //RecursivePalindromeCheck();
            RecursivePowerFunction();

            Console.ReadLine();
        }

        private static void MaxBinaryHeapDemo()
        {
            int[] initialHeap = new int[] { 41, 39, 33, 18, 27, 12 };
            int newItem = 45;

            MaxBinaryHeap h = new MaxBinaryHeap(initialHeap);

            Console.WriteLine("Heap before add: ");
            h.PrintHeap();

            // Add
            h.Add(newItem);

            Console.WriteLine($"Heap after adding {newItem}: ");
            h.PrintHeap();

            // Remove
            int? maxValue = null;
            do
            {
                maxValue = h.ExtractMax();

                Console.WriteLine($"Heap after getting max {maxValue}: ");
                h.PrintHeap();

            } while (maxValue.HasValue);

        }

        private static void PriorityQueueDemo()
        {
            PriorityQueue pq = new PriorityQueue();

            pq.Enqueue("Common cold", 5);
            pq.Enqueue("Gunshot wound", 1);
            pq.Enqueue("High fever", 4);
            pq.Enqueue("Broken arm", 2);
            pq.Enqueue("Kid ill", 3);

            Console.WriteLine($"Priority Queue after adding items: ");
            pq.PrintItems();

            // Dequeue
            Node maxValue = null;
            while (true)
            {
                maxValue = pq.Dequeue();

                if (maxValue == null) break;

                Console.WriteLine($"Heap after getting max {maxValue.Priority} - {maxValue.Val}:");
                pq.PrintItems();

            }
        }

        private static void GraphCreateDemo()
        {
            var g = new Graph();
            g.AddVertex("A");
            g.AddVertex("B");
            g.AddVertex("C");
            g.AddVertex("D");
            g.AddVertex("E");
            g.AddVertex("F");

            g.AddEdge("A", "B");
            g.AddEdge("A", "C");
            g.AddEdge("B", "D");
            g.AddEdge("C", "E");
            g.AddEdge("D", "E");
            g.AddEdge("D", "F");
            g.AddEdge("E", "F");

            List<string> allNodes = g.DfsRecursive("A");

            foreach(string n in allNodes)
            {
                Console.WriteLine(n);
            }
        }

        private static void DijkstrasAlgorithm()
        {
            var g = new WeightedGraph();
            g.AddVertex("A");
            g.AddVertex("B");
            g.AddVertex("C");
            g.AddVertex("D");
            g.AddVertex("E");
            g.AddVertex("F");

            g.AddEdge("A", "B", 4);
            g.AddEdge("A", "C", 2);
            g.AddEdge("B", "E", 3);
            g.AddEdge("C", "D", 2);
            g.AddEdge("C", "F", 4);
            g.AddEdge("D", "E", 3);
            g.AddEdge("D", "F", 1);
            g.AddEdge("E", "F", 1);

            List<string> pathfromAtoE = g.DijkstraShortestPath("A", "E");

            foreach (string node in pathfromAtoE)
            {
                Console.WriteLine(node);
            }
        }

        private static void RecursivePalindromeCheck()
        {
            string s = "Rotor";

            Palindrome p = new Palindrome();

            string isOrIsNot = p.IsPalindrome(s) ? "is" : "is not";

            Console.WriteLine($"Rotor {isOrIsNot} a palindrome");
        }

        private static void RecursivePowerFunction()
        {
            PowerFunction p = new PowerFunction();
            int num = 7;
            int exp = -3;
            Console.WriteLine($"{num} ^ {exp} is {p.Power(num, exp)}.");
        }
    }
}
