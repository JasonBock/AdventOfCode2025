using System.Collections.Immutable;

namespace AdventOfCode2025.Day11;

public static class SolutionDay11
{
	public static ulong RunPart1(ImmutableArray<string> data)
	{
		static void ExamineOutputs(string input, Dictionary<string, List<string>> connections, ref ulong pathCount)
		{
			var outputs = connections[input];

			foreach (var output in outputs)
			{
				if (output == "out")
				{
					pathCount++;
				}
				else
				{
					ExamineOutputs(output, connections, ref pathCount);
				}
			}
		}

		var pathCount = 0ul;
		var connections = new Dictionary<string, List<string>>();

		foreach (var connection in data)
		{
			var parts = connection.Split(':');
			var outputs = parts[1].Trim().Split(' ');
			connections[parts[0]] = [.. outputs];
		}

		ExamineOutputs("you", connections, ref pathCount);

		return pathCount;
	}
}