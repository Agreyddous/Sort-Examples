﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Sort.Extensions;
using Sort.Helpers;

namespace Sort
{
	class Program
	{
		public static IOHelper IO = new IOHelper();

		static void Main(string[] args)
		{
			while (true)
			{
				IO.Clear();

				if (int.TryParse(IO.Ask("What will be the vector's size?"), out int size) &&
					int.TryParse(IO.Ask("What is the minimum value?"), out int minimum) &&
					int.TryParse(IO.Ask("What is the maximum value?"), out int maximum))
					ResolveActionToDo()(size, minimum, maximum);

				else
					IO.InvalidValue();

				IO.Pause();
			}
		}

		private static int AskForAction() => IO.AskForSomething("What action should be perfomed?\n1 - Normal test\n2 - Benchmark", Enumerable.Range(1, 2).ToArray());

		private static int AskForAlgorithm(MethodInfo[] availableMethods) => IO.AskForSomething($"What sort algorithm should be used?\n{availableMethods.DisplayAvailableMethods()}", Enumerable.Range(1, availableMethods.Count()).ToArray()) - 1;

		private static Action<int, int, int> ResolveActionToDo()
		{
			Action<int, int, int> action = null;

			switch (AskForAction())
			{
				case 1:
					action = ExecuteSingleAlgorithm;

					break;

				case 2:
					action = ExecuteBenchmarkTest;

					break;
			}

			return action;
		}

		private static TimeSpan TimeAlgorithm(Action<int[]> algorithm, int[] vector)
		{
			DateTime start = DateTime.UtcNow;

			algorithm(vector);

			return DateTime.UtcNow.Subtract(start);
		}

		private static void ExecuteSingleAlgorithm(int size, int minimum, int maximum)
		{
			int[] unorderedVector = new int[size].Initialize(minimum, maximum);
			int[] vector = unorderedVector.Copy();

			TimeSpan executionTime = TimeAlgorithm(ResolveAlgorithmToUse(), vector);

			PrintVector(executionTime, unorderedVector, vector);
		}

		private static TimeSpan BenchmarkAlgorithm(Action<int[]> algorithm, int[][] vectors)
		{
			TimeSpan[] executionsResults = new TimeSpan[vectors.Length];

			IO.Say($"Starting benchmark for {algorithm.Method.GetAlgorithmName()}");

			for (int index = 0; index < vectors.Length; index++)
				executionsResults[index] = TimeAlgorithm(algorithm, vectors[index].Copy());

			IO.Say("Done");

			return TimeSpan.FromTicks(executionsResults.Sum(executionResult => executionResult.Ticks) / vectors.Length);
		}

		private static void ExecuteBenchmarkTest(int size, int minimum, int maximum)
		{
			if (!int.TryParse(IO.Ask("How many times should each algorithm be executed? (Default is 100)"), out int executionsCount))
				executionsCount = 100;

			IO.Clear();

			IO.Say($"Initializing {executionsCount} random vector(s) with a size of {size} and values ranging from {minimum} to {maximum}");

			int[][] vectors = new int[executionsCount][];

			Parallel.For(0, executionsCount, index => vectors[index] = new int[size].Initialize(minimum, maximum));

			IO.Say("Done initializing vectors\n");

			Dictionary<string, TimeSpan> executions = new Dictionary<string, TimeSpan>();

			foreach (MethodInfo method in SorterExtensions.GetAvailableMethods())
				executions.Add(method.GetAlgorithmName(), BenchmarkAlgorithm(method.GetMethod<Action<int[]>>(), vectors));

			PrintBenchmark(executions, executionsCount);
		}

		private static Action<int[]> ResolveAlgorithmToUse()
		{
			MethodInfo[] availableMethods = SorterExtensions.GetAvailableMethods();

			return availableMethods[AskForAlgorithm(availableMethods)].GetMethod<Action<int[]>>();
		}

		public static void PrintVector(TimeSpan executionTime, int[] vector, int[] orderedVector)
		{
			IO.Clear();
			IO.Say($"Sort completed in {executionTime}");

			IO.Pause();

			bool invalid = false;

			for (int index = 0; index < vector.Length; index++)
			{
				bool invalidItem = (index != vector.Length - 1 && orderedVector[index] > orderedVector[index + 1]);

				IO.Say($"{index} - {vector[index]} -> {orderedVector[index]}{(invalidItem ? " -- INVALID" : string.Empty)}");
				invalid = invalid || invalidItem;
			}

			if (invalid)
				IO.Say("\nSort was not valid, some errors have been found!");
		}

		public static void PrintBenchmark(Dictionary<string, TimeSpan> executions, int executionsCount)
		{
			IO.Say($"Each algorithm was executed {executionsCount} time(s)\n");

			foreach (KeyValuePair<string, TimeSpan> execution in executions.OrderBy(execution => execution.Value))
				IO.Say($"{execution.Key} - {execution.Value}");
		}
	}
}
