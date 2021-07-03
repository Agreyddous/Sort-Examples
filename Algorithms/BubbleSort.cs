namespace Sort.Algorithms
{
	public partial class Sorter
	{
		public void BubbleSort(int[] vector)
		{
			bool sorted;
			int compareLimit = vector.Length - 1;

			do
			{
				sorted = true;
				int nextCompareLimit = compareLimit - 1;

				for (int index = 0; index < compareLimit; index++)
					if (vector[index] > vector[index + 1])
					{
						Swap(vector, index, index + 1);
						sorted = false;
						nextCompareLimit = index;
					}

				compareLimit = nextCompareLimit;
			} while (!sorted);
		}
	}
}