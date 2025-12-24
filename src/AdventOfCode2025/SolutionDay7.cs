using System.Collections.Immutable;

namespace AdventOfCode2025.Day7;

public static class SolutionDay7
{
	public static uint RunPart1(ImmutableArray<string> data)
	{
		var splitCount = 0u;

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional
		var diagram = new char[data[0].Length, data.Length];

		for (var y = 0; y < data.Length; y++)
		{
			for (var x = 0; x < data[0].Length; x++)
			{
				diagram[x, y] = data[y][x];
			}
		}

		for (var y = 1; y < data.Length; y++)
		{
			for (var x = 0; x < data[0].Length; x++)
			{
				var currentNode = diagram[x, y];

				if (currentNode == '.')
				{
					var aboveNode = diagram[x, y - 1];

					if (aboveNode == '|' || aboveNode == 'S')
					{
						diagram[x, y] = '|';
					}
				}
				else if (currentNode == '^')
				{
					var aboveNode = diagram[x, y - 1];

					if (aboveNode == '|')
					{
						splitCount++;
						diagram[x - 1, y] = '|';
						diagram[x + 1, y] = '|';
					}
				}
			}
		}

		return splitCount;
	}
}