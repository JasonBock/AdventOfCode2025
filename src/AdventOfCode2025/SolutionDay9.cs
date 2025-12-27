using System.Collections.Immutable;
using System.Globalization;

namespace AdventOfCode2025.Day9;

public static class SolutionDay9
{
	public static long RunPart1(ImmutableArray<string> data)
	{
		var positions = new List<Point>();

		foreach (var entry in data)
		{
			var parts = entry.Split(',');
			positions.Add(new(
				long.Parse(parts[0], CultureInfo.CurrentCulture),
				long.Parse(parts[1], CultureInfo.CurrentCulture)));
		}

		var maximumArea = 0L;

		for (var i = 0; i < positions.Count; i++)
		{
			var iPosition = positions[i];

			for (var j = i + 1; j < positions.Count; j++)
			{
				var jPosition = positions[j];

				var area = long.Abs(iPosition.X - jPosition.X + 1) *
					long.Abs(iPosition.Y - jPosition.Y + 1);

				if (area > maximumArea)
				{
					maximumArea = area;
				}
			}
		}

		return maximumArea;
	}
}

public record struct Point(long X, long Y);