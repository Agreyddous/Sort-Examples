using Sort.Extensions;

namespace Sort.Algorithms
{
	public partial class Sorter
	{
		public void Bubble(int[] vector)
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
						vector.Swap(index, index + 1);
						sorted = false;
						nextCompareLimit = index;
					}

				compareLimit = nextCompareLimit;
			} while (!sorted);
		}
	}
}