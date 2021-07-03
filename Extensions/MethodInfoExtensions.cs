using System;
using System.Reflection;
using System.Text.RegularExpressions;
using Sort.Algorithms;

namespace Sort.Extensions
{
	public static class MethodInfoExtensions
	{
		private static Regex _algorithmNameRegex = new Regex(@"(?<=[A-Z])(?=[A-Z][a-z])|(?<=[^A-Z])(?=[A-Z])|(?<=[A-Za-z])(?=[^A-Za-z])", RegexOptions.IgnorePatternWhitespace);

		public static string GetAlgorithmName(this MethodInfo method) => _algorithmNameRegex.Replace(method.Name, " ");

		public static TMethodDelegate GetMethod<TMethodDelegate>(this MethodInfo method) where TMethodDelegate : Delegate => method.CreateDelegate<TMethodDelegate>(new Sorter());

		public static string DisplayAvailableMethods(this MethodInfo[] availableMethods)
		{
			string result = string.Empty;

			for (int index = 0; index < availableMethods.Length; index++)
				result += $"{index + 1} - {availableMethods[index].GetAlgorithmName()}\n";

			return result.Trim('\n');
		}
	}
}