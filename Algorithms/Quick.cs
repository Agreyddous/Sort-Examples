using Sort.Extensions;

namespace Sort.Algorithms
{
	public partial class Sorter
	{
		public void Quick(int[] vector) => _quickRecursive(vector, 0, vector.Length - 1);

		private void _quickRecursive(int[] vector, int start, int end)
		{
			if (start < end)
			{
				int middle = _quickBreak(vector, start, end);

				_quickRecursive(vector, start, middle - 1);
				_quickRecursive(vector, middle + 1, end);
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