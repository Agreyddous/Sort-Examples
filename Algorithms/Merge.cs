namespace Sort.Algorithms
{
	public partial class Sorter
	{
		public void Merge(int[] vector) => _mergeBreak(vector, 0, vector.Length - 1);

		private void _mergeBreak(int[] vector, int start, int end)
		{
			if (start < end)
			{
				int middle = (start + end) / 2;

				_mergeBreak(vector, start, middle);
				_mergeBreak(vector, middle + 1, end);

				_merge(vector, start, middle, end);
			}
		}

		private void _merge(int[] vector, int start, int middle, int end)
		{
			int[] mergeVector = new int[end - start + 1];

			int firstHalfIndex;
			int secondHalfIndex;

			for (firstHalfIndex = start; firstHalfIndex <= middle; firstHalfIndex++)
				mergeVector[firstHalfIndex - start] = vector[firstHalfIndex];

			for (secondHalfIndex = middle + 1; secondHalfIndex <= end; secondHalfIndex++)
				mergeVector[end + middle + 1 - secondHalfIndex - start] = vector[secondHalfIndex];

			firstHalfIndex = 0;
			secondHalfIndex = end - start;

			for (int index = start; index <= end; index++)
			{
				if (mergeVector[firstHalfIndex] <= mergeVector[secondHalfIndex])
					vector[index] = mergeVector[firstHalfIndex++];

				else
					vector[index] = mergeVector[secondHalfIndex--];
			}
		}
	}
}