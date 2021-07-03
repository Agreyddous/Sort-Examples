namespace Sort.Algorithms
{
	public partial class Sorter
	{
		private void Swap(int[] vector, int firstIndex, int secondIndex)
		{
			int firstIndexCurrentValue = vector[firstIndex];

			vector[firstIndex] = vector[secondIndex];
			vector[secondIndex] = firstIndexCurrentValue;
		}
	}
}