using Sort.Extensions;

namespace Sort.Algorithms
{
	public partial class Sorter
	{
		public void Selection(int[] vector)
		{
			for (int iteratorIndex = 0; iteratorIndex < vector.Length - 1; iteratorIndex++)
			{
				int minimumValueFoundIndex = iteratorIndex;

				for (int index = iteratorIndex + 1; index < vector.Length; index++)
					if (vector[index] < vector[minimumValueFoundIndex])
						minimumValueFoundIndex = index;

				vector.Swap(iteratorIndex, minimumValueFoundIndex);
			}
		}
	}
}