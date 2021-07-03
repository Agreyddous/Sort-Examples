using System;
using System.Collections.Generic;
using System.Linq;

namespace Sort.Extensions
{
	public static class VectorExtensions
	{
		private static Random _random = new Random();

		public static int[] Initialize(this int[] vector, int minimum, int maximum) => Enumerable.Range(minimum, maximum - minimum)
																									 .Select(item => new KeyValuePair<int, int>(_random.Next(), item))
																									 .OrderBy(pair => pair.Key)
																									 .Select(pair => pair.Value)
																									 .Take(vector.Length)
																									 .ToArray();

		public static int[] Copy(this int[] vector)
		{
			int[] copyVector = new int[vector.Length];
			Array.Copy(vector, copyVector, vector.Length);

			return copyVector;
		}
	}
}