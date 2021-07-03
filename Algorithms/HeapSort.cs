using System;
using Sort.Extensions;

namespace Sort.Algorithms
{
	public partial class Sorter
	{
		public void HeapSort(int[] vector)
		{
			_createHeap(vector, vector.Length);

			int end = vector.Length - 1;

			while (end > 0)
			{
				vector.Swap(end, 0);
				end--;

				_orderHeap(vector, 0, end);
			}
		}

		private void _createHeap(int[] vector, int size)
		{
			int start = (int)Math.Floor((decimal)(size - 2) / 2);

			while (start >= 0)
				_orderHeap(vector, start--, size - 1);
		}

		private void _orderHeap(int[] vector, int start, int end)
		{
			int root = start;
			bool stop = false;

			while (root * 2 + 1 <= end && !stop)
			{
				int node = root * 2 + 1;
				int swap = root;

				if (vector[swap] < vector[node])
					swap = node;

				if (node + 1 <= end && vector[swap] < vector[node + 1])
					swap = node + 1;

				if (swap != root)
				{
					vector.Swap(root, swap);
					root = swap;
				}

				else
					stop = true;
			}
		}
	}
}