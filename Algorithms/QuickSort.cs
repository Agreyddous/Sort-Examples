using Sort.Extensions;

namespace Sort.Algorithms
{
	public partial class Sorter
	{
		public void QuickSort(int[] vector) => _quickRecursiveSort(vector, 0, vector.Length - 1);

		private void _quickRecursiveSort(int[] vector, int start, int end)
		{
			if (start < end)
			{
				int middle = _quickBreak(vector, start, end);

				_quickRecursiveSort(vector, start, middle - 1);
				_quickRecursiveSort(vector, middle + 1, end);
			}
		}

		private int _quickBreak(int[] vector, int start, int end)
		{
			int pivot = vector[start];
			int left = start + 1;
			int right = end;

			while (left <= right)
			{
				while (left <= right && vector[left] < pivot)
					left++;

				while (vector[right] > pivot)
					right--;

				if (left < right)
					vector.Swap(left++, right--);
			}

			vector[start] = vector[right];
			vector[right] = pivot;

			return right;
		}
	}
}