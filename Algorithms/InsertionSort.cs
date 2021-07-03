using Sort.Extensions;

namespace Sort.Algorithms
{
	public partial class Sorter
	{
		public void InsertionSort(int[] vector)
		{
			bool sorted;

			do
			{
				sorted = true;

				for (int index = 1; index < vector.Length; index++)
				{
					int currentIndex = index;

					while (currentIndex != 0 && vector[currentIndex - 1] > vector[currentIndex])
					{
						vector.Swap(currentIndex - 1, currentIndex);
						currentIndex--;
					}
				}
			} while (!sorted);
		}
	}
}