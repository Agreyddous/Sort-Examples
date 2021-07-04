using System;
using System.Collections.Generic;

namespace Sort.Algorithms
{
	public partial class Sorter
	{
		public void BucketSort(int[] vector)
		{
			int largestValue = _countLargestValue(vector);

			List<int>[] bucketLists = new List<int>[10];
			for (int bucketIndex = 0; bucketIndex < 10; bucketIndex++)
				bucketLists[bucketIndex] = new List<int>();

			int index = 0;

			for (index = 0; index < vector.Length; index++)
				bucketLists[_getBucketIndex(vector[index], largestValue)].Add(vector[index]);

			index = 0;
			foreach (List<int> bucketList in bucketLists)
			{
				int[] bucketArray = bucketList.ToArray();
				InsertionSort(bucketArray);

				foreach (int value in bucketArray)
					vector[index++] = value;
			}
		}

		private int _getBucketIndex(int value, int largestValue) => (int)Math.Floor(value / (((decimal)largestValue + 1) / 10));
	}
}