using System.Collections.Immutable;

namespace AdventOfCode2025.Day4;

public static class SolutionDay4
{
	public static int RunPart1(ImmutableArray<string> paperRollMap)
	{
		var minX = 0;
		var minY = 0;
		var maxX = paperRollMap[0].Length;
		var maxY = paperRollMap.Length;

		var accessiblePaperRolls = 0;

		for (var y = 0; y < maxY; y++)
		{
			var line = paperRollMap[y];

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
							if (paperRollMap[y - 1][x - 1] == '@')
							{
								adjacentPaperRollCount++;
							}
						}

						if (paperRollMap[y - 1][x] == '@')
						{
							adjacentPaperRollCount++;
						}

						if ((x + 1) < maxX)
						{
							if (paperRollMap[y - 1][x + 1] == '@')
							{
								adjacentPaperRollCount++;
							}
						}
					}

					// Left and right
					if ((x - 1) >= minX)
					{
						if (paperRollMap[y][x - 1] == '@')
						{
							adjacentPaperRollCount++;
						}
					}

					if ((x + 1) < maxX)
					{
						if (paperRollMap[y][x + 1] == '@')
						{
							adjacentPaperRollCount++;
						}
					}

					// Bottom 3
					if ((y + 1) < maxY)
					{
						if ((x - 1) >= minX)
						{
							if (paperRollMap[y + 1][x - 1] == '@')
							{
								adjacentPaperRollCount++;
							}
						}

						if (paperRollMap[y + 1][x] == '@')
						{
							adjacentPaperRollCount++;
						}

						if ((x + 1) < maxX)
						{
							if (paperRollMap[y + 1][x + 1] == '@')
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

	public static int RunPart2(ImmutableArray<string> paperRollMap)
	{
		var minX = 0;
		var minY = 0;
		var maxX = paperRollMap[0].Length;
		var maxY = paperRollMap.Length;

		// create a matrix of chars based on battery banks.
#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional
		var paperRollContent = new char[maxX, maxY];

		for (var y = 0; y < maxY; y++)
		{
			for (var x = 0; x < maxX; x++)
			{
				paperRollContent[x, y] = paperRollMap[y][x];
			}
		}

		List<Point> accessiblePaperRolls;
		var totalPaperRollsRemoved = 0;

		do
		{
			accessiblePaperRolls = [];

			// Find all the locations.
			for (var y = 0; y < maxY; y++)
			{
				for (var x = 0; x < maxX; x++)
				{
					var adjacentPaperRollCount = 0;

					if (paperRollContent[x, y] == '@')
					{
						// Top 3 positions
						if ((y - 1) >= minY)
						{
							if ((x - 1) >= minX)
							{
								if (paperRollContent[x - 1, y - 1] == '@')
								{
									adjacentPaperRollCount++;
								}
							}

							if (paperRollContent[x, y - 1] == '@')
							{
								adjacentPaperRollCount++;
							}

							if ((x + 1) < maxX)
							{
								if (paperRollContent[x + 1, y - 1] == '@')
								{
									adjacentPaperRollCount++;
								}
							}
						}

						// Left and right
						if ((x - 1) >= minX)
						{
							if (paperRollContent[x - 1, y] == '@')
							{
								adjacentPaperRollCount++;
							}
						}

						if ((x + 1) < maxX)
						{
							if (paperRollContent[x + 1, y] == '@')
							{
								adjacentPaperRollCount++;
							}
						}

						// Bottom 3
						if ((y + 1) < maxY)
						{
							if ((x - 1) >= minX)
							{
								if (paperRollContent[x - 1, y + 1] == '@')
								{
									adjacentPaperRollCount++;
								}
							}

							if (paperRollContent[x, y + 1] == '@')
							{
								adjacentPaperRollCount++;
							}

							if ((x + 1) < maxX)
							{
								if (paperRollContent[x + 1, y + 1] == '@')
								{
									adjacentPaperRollCount++;
								}
							}
						}

						if (adjacentPaperRollCount < 4)
						{
							accessiblePaperRolls.Add(new(x, y));
						}
					}
				}
			}

			if (accessiblePaperRolls.Count > 0)
			{
				totalPaperRollsRemoved += accessiblePaperRolls.Count;

				// update the content.
				foreach(var accessiblePaperRoll in accessiblePaperRolls)
				{
					paperRollContent[accessiblePaperRoll.X, accessiblePaperRoll.Y] = '.';
				}
			}
		} while (accessiblePaperRolls.Count > 0);

		return totalPaperRollsRemoved;
	}
}

public record struct Point(int X, int Y);