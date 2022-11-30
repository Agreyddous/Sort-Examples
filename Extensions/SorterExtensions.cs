using System.Reflection;
using Sort.Algorithms;

namespace Sort.Extensions
{
	public static class SorterExtensions
	{
		public static MethodInfo[] GetAvailableMethods() => typeof(Sorter).GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance);
	}
}