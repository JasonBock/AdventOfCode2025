using System.Collections.Immutable;
using System.Globalization;

namespace AdventOfCode2025.Day1;

public static class SolutionDay1
{
	public static int RunPart1(ImmutableArray<string> rotations)
	{
		var location = 50;
		var zeroLocationCounts = 0;

		foreach (var rotation in rotations)
		{
			var direction = rotation[0];
			var distance = int.Parse(rotation.AsSpan(1), CultureInfo.CurrentCulture);

			if (direction == 'L')
			{
				location -= distance;

				while (location < 0)
				{
					location += 100;
				}
			}
			else
			{
				location += distance;

				while (location > 99)
				{
					location -= 100;
				}
			}

			if (location == 0)
			{
				zeroLocationCounts++;
			}
		}

		return zeroLocationCounts;
	}

	public static int RunPart2(ImmutableArray<string> rotations)
	{
		var location = 50;
		var zeroLocationCounts = 0;

		foreach (var rotation in rotations)
		{
			var direction = rotation[0];
			var distance = int.Parse(rotation.AsSpan(1), CultureInfo.CurrentCulture);
			var startingLocation = location;

			if (direction == 'L')
			{
				for (var i = 0; i < distance; i++)
				{
					location--;

					if (location % 100 == 0)
					{
						zeroLocationCounts++;
					}
				}

				while (location < 0)
				{
					location += 100;
				}
			}
			else
			{
				for (var i = 0; i < distance; i++)
				{
					location++;

					if (location % 100 == 0)
					{
						zeroLocationCounts++;
					}
				}

				while (location > 99)
				{
					location -= 100;
				}
			}
		}

		return zeroLocationCounts;
	}
}