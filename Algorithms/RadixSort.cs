namespace Sort.Algorithms
{
	public partial class Sorter
	{
		public void RadixSort(int[] vector)
		{
			int largestValue = _countLargestValue(vector);

			for (int digitExponent = 1; largestValue / digitExponent > 0; digitExponent *= 10)
			{
				int[] countVector = new int[10];

				for (int index = 0; index < vector.Length; index++)
					countVector[_radixCounterIndex(vector[index], digitExponent)]++;

				for (int countIndex = 1; countIndex < 10; countIndex++)
					countVector[countIndex] += countVector[countIndex - 1];

				int[] sortingVector = new int[vector.Length];

				for (int index = vector.Length - 1; index >= 0; index--)
					sortingVector[countVector[_radixCounterIndex(vector[index], digitExponent)]-- - 1] = vector[index];


				for (int index = 0; index < vector.Length; index++)
					vector[index] = sortingVector[index];
			}
		}

		private int _radixCounterIndex(int value, int digitExponent) => (value / digitExponent) % 10;
	}
}