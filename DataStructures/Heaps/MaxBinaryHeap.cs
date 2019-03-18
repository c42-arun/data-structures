using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Heaps
{
    public class MaxBinaryHeap
    {
        private readonly List<int> _values;

        public MaxBinaryHeap(int[] values)
        {
            _values = new List<int>(values);
        }

        public void PrintHeap()
        {
            StringBuilder sb = new StringBuilder();

            foreach (int item in _values)
            {
                sb.Append($"{item}, ");
            }

            string printString = sb.Length > 1 ? sb.ToString(0, sb.Length - 2) : sb.ToString();

            Console.WriteLine(printString);
        }

        public void Add(int newItem)
        {
            // Step 1: add the value to the end
            _values.Add(newItem);

            BubbleUp(newItem);
        }

        public int? ExtractMax()
        {
            if (_values.Count == 0) return null;

            int max = _values[0];
            int lastItem = _values[_values.Count - 1];

            _values[0] = lastItem;
            _values.RemoveAt(_values.Count - 1);

            if (_values.Count > 0)
            {
                BubbleDown();
            }

            return max;
        }

        private void BubbleUp(int item)
        {
            int idx = _values.Count - 1;

            while (idx > 0)
            {
                int parentIdx = (idx - 1) / 2;

                int parent = _values[parentIdx];
              
                if (item <= parent) break;

                // swap parent <-> child
                _values[parentIdx] = item;
                _values[idx] = parent;

                idx = parentIdx;
            }
        }

        private void BubbleDown()
        {
            int idx = 0;

            while (true)
            {
                int item = _values[idx];

                int length = _values.Count;

                int leftChildIdx = (idx * 2) + 1;
                int rightChildIdx = (idx * 2) + 2;
                int? swapIdx = null;

                if (leftChildIdx < length)
                {
                    if (_values[leftChildIdx] > item)
                    {
                        swapIdx = leftChildIdx;
                    }
                }

                if (rightChildIdx < length)
                {
                    if ((!swapIdx.HasValue && _values[rightChildIdx] > item)
                            || (swapIdx.HasValue && _values[rightChildIdx] > _values[leftChildIdx]))
                    {
                        swapIdx = rightChildIdx;
                    }
                }

                if (!swapIdx.HasValue) break;

                // swap parent item with child that is larger
                int childItem = _values[swapIdx.Value]; // item value to swap

                _values[swapIdx.Value] = item;
                _values[idx] = childItem;

                idx = swapIdx.Value; // this is now the new parent for next iteration
            }
        }
    }
}
