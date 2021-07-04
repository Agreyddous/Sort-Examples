using System;

namespace Sort.Algorithms
{
	public partial class Sorter
	{
		public void IntrospectiveSort(int[] vector) => _instrospectiveRecursiveSort(vector, 0, vector.Length - 1, (int)(Math.Log2(vector.Length) * 2));

		private void _instrospectiveRecursiveSort(int[] vector, int start, int end, int maxDepth)
		{
			if (start < end)
			{
				if (maxDepth > 0)
					_instrospectiveQuickSort(vector, start, end, maxDepth);

				else
					_heapSort(vector, start, end + 1);
			}
		}

		private void _instrospectiveQuickSort(int[] vector, int start, int end, int maxDepth)
		{
			int middle = _quickBreak(vector, start, end);

			_instrospectiveRecursiveSort(vector, start, middle - 1, maxDepth - 1);
			_instrospectiveRecursiveSort(vector, middle + 1, end, maxDepth - 1);
		}
	}
}