using System.Collections.Immutable;

namespace AdventOfCode2025.Day4;

public static class SolutionDay4
{
	public static int RunPart1(ImmutableArray<string> batteryBanks)
	{
		var minX = 0;
		var minY = 0;
		var maxX = batteryBanks[0].Length;
		var maxY = batteryBanks.Length;

		var accessiblePaperRolls = 0;

		for (var y = 0; y < maxY; y++)
		{
			var line = batteryBanks[y];

			for (var x = 0; x < maxX; x++)
			{
				var adjacentPaperRollCount = 0;

				if (line[x] == '@')
				{
					// Top 3 positions
					if ((y - 1) >= minY)
					{
						if ((x - 1) >= minX)
						{
							if (batteryBanks[y - 1][x - 1] == '@')
							{
								adjacentPaperRollCount++;
							}
						}

						if (batteryBanks[y - 1][x] == '@')
						{
							adjacentPaperRollCount++;
						}

						if ((x + 1) < maxX)
						{
							if (batteryBanks[y - 1][x + 1] == '@')
							{
								adjacentPaperRollCount++;
							}
						}
					}

					// Left and right
					if ((x - 1) >= minX)
					{
						if (batteryBanks[y][x - 1] == '@')
						{
							adjacentPaperRollCount++;
						}
					}

					if ((x + 1) < maxX)
					{
						if (batteryBanks[y][x + 1] == '@')
						{
							adjacentPaperRollCount++;
						}
					}

					// Bottom 3
					if ((y + 1) < maxY)
					{
						if ((x - 1) >= minX)
						{
							if (batteryBanks[y + 1][x - 1] == '@')
							{
								adjacentPaperRollCount++;
							}
						}

						if (batteryBanks[y + 1][x] == '@')
						{
							adjacentPaperRollCount++;
						}

						if ((x + 1) < maxX)
						{
							if (batteryBanks[y + 1][x + 1] == '@')
							{
								adjacentPaperRollCount++;
							}
						}
					}

					if (adjacentPaperRollCount < 4)
					{
						accessiblePaperRolls++;
					}
				}
			}
		}

		return accessiblePaperRolls;
	}
}