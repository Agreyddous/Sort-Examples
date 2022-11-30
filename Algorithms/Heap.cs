using System;
using Sort.Extensions;

namespace Sort.Algorithms
{
	public partial class Sorter
	{
		public void Heap(int[] vector) => _heap(vector, 0, vector.Length);

		private void _heap(int[] vector, int start, int end)
		{
			_createHeap(vector, start, end--);

			while (end > start)
			{
				vector.Swap(end--, start);

				_orderHeap(vector, start, end);
			}
		}

		private void _createHeap(int[] vector, int start, int end)
		{
			int size = end - start;
			int heaptStart = (int)Math.Floor((decimal)(size - 2) / 2);

			while (heaptStart >= 0)
				_orderHeap(vector, heaptStart--, size - 1);
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