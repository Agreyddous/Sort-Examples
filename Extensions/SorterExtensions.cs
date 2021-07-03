using System.Linq;
using System.Reflection;
using Sort.Algorithms;

namespace Sort.Extensions
{
	public static class SorterExtensions
	{
		public static MethodInfo[] GetAvailableMethods() => typeof(Sorter).GetMethods().Where(method => method.Name.ToLower().Contains("sort")).ToArray();
	}
}