using System.Collections.Generic;

namespace Sort.Algorithms
{
	public partial class Sorter
	{
		public void ShellSort(int[] vector)
		{
			foreach (int gap in _shellSortGaps(vector.Length))
			{
				for (int gapIndex = gap; gapIndex < vector.Length; gapIndex++)
				{
					int currentGapValue = vector[gapIndex];
					int index = gapIndex;

					for (; index >= gap && vector[index - gap] > currentGapValue; index -= gap)
						vector[index] = vector[index - gap];

					vector[index] = currentGapValue;
				}
			}
		}

		private IEnumerable<int> _shellSortGaps(int size)
		{
			if (size != 1)
			{
				size /= 2;

				yield return size;

				foreach (int result in _shellSortGaps(size))
					yield return result;
			}
		}
	}
}