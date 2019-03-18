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
            PriorityQueueDemo();

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
    }
}
