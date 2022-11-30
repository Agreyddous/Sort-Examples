namespace Sort.Algorithms
{
	public partial class Sorter
	{
		public void Count(int[] vector)
		{
			int largestValue = _countLargestValue(vector);

			int[] countVector = new int[largestValue + 1];

			for (int index = 0; index < vector.Length; index++)
				countVector[vector[index]]++;

			int vectorIndex = 0;
			int countVectorIndex = 0;

			while (countVectorIndex < countVector.Length)
			{
				if (countVector[countVectorIndex] > 0)
				{
					vector[vectorIndex++] = countVectorIndex;
					countVector[countVectorIndex]--;
				}

				else
					countVectorIndex++;
			}
		}

		private int _countLargestValue(int[] vector)
		{
			int largestValue = -1;

			for (int index = 0; index < vector.Length; index++)
				largestValue = vector[index] > largestValue ? vector[index] : largestValue;

			return largestValue;
		}
	}
}