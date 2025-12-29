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

	public static ulong RunPart2(ImmutableArray<string> data)
	{
		static int ExamineOutputs(string input, (bool dacVisited, bool fftVisited) visitations,
			Dictionary<string, List<string>> connections, Dictionary<string, int> nodeBranchCounts, ref ulong pathCount)
		{
			if (nodeBranchCounts.TryGetValue(input, out var branchCounts))
			{
				return branchCounts;
			}
			else
			{
				visitations.dacVisited |= input == "dac";
				visitations.fftVisited |= input == "fft";

				var outputs = connections[input];

				var nodeBranchCount = 0;

				if (outputs.Count == 1 && outputs[0] == "out")
				{
					if (visitations.dacVisited && visitations.fftVisited)
					{
						pathCount++;
					}

					nodeBranchCounts[input] = 0;
					return 0;
				}

				foreach (var output in outputs)
				{
					nodeBranchCount += ExamineOutputs(output, visitations, connections, nodeBranchCounts, ref pathCount);
				}

				nodeBranchCounts[input] = nodeBranchCount + (outputs.Count > 1 ? outputs.Count : 0);
				return nodeBranchCount;
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

		var nodeBranchCounts = new Dictionary<string, int>();

		_ = ExamineOutputs("svr", (false, false), connections, nodeBranchCounts, ref pathCount);

		return pathCount;
	}
}