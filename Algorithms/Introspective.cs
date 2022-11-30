using System;

namespace Sort.Algorithms
{
	public partial class Sorter
	{
		public void Introspective(int[] vector) => _instrospectiveRecursive(vector, 0, vector.Length - 1, (int)(Math.Log2(vector.Length) * 2));

		private void _instrospectiveRecursive(int[] vector, int start, int end, int maxDepth)
		{
			if (start < end)
			{
				if (maxDepth > 0)
					_instrospectiveQuick(vector, start, end, maxDepth);

				else
					_heap(vector, start, end + 1);
			}
		}

		private void _instrospectiveQuick(int[] vector, int start, int end, int maxDepth)
		{
			int middle = _quickBreak(vector, start, end);

			_instrospectiveRecursive(vector, start, middle - 1, maxDepth - 1);
			_instrospectiveRecursive(vector, middle + 1, end, maxDepth - 1);
		}
	}
}