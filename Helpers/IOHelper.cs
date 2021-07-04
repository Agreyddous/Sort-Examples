using System;
using System.Linq;

namespace Sort.Helpers
{
	public class IOHelper
	{
		public void Say(string message) => Console.WriteLine(message);

		public void Clear() => Console.Clear();

		public void Pause()
		{
			Say("\nPress any key to continue...");
			Console.ReadKey();
			Console.WriteLine();
		}

		public void InvalidValue() => Say("\nInvalid value provided");

		public string Ask(string question, params object[] parameters)
		{
			Console.Write($"{question}\n-> ", parameters);
			string response = Console.ReadLine();

			Console.WriteLine();

			return response;
		}

		public int AskForSomething(string question, int[] possibleAnswers)
		{
			bool validResponse;
			int response = -1;

			do
			{
				validResponse = true;

				if (!int.TryParse(Ask(question), out response) || !possibleAnswers.Contains(response))
				{
					validResponse = false;

					InvalidValue();
					Pause();
				}
			} while (!validResponse);

			return response;
		}
	}
}