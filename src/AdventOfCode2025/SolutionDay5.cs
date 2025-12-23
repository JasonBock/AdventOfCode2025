using Spackle;
using System.Collections.Immutable;
using System.Globalization;

namespace AdventOfCode2025.Day5;

public static class SolutionDay5
{
	public static int RunPart1(ImmutableArray<string> database)
	{
		var idRanges = new List<Range<ulong>>();
		var ingredientIds = new List<ulong>();
		var frestIngredientCount = 0;

		foreach (var item in database)
		{
			if (item.Length > 0)
			{
				if (item.Contains('-', StringComparison.CurrentCultureIgnoreCase))
				{
					// range
					var parts = item.Split('-');
					idRanges.Add(
						new(
							ulong.Parse(parts[0], CultureInfo.InvariantCulture),
							ulong.Parse(parts[1], CultureInfo.InvariantCulture) + 1));
				}
				else
				{
					// id
					ingredientIds.Add(ulong.Parse(item, CultureInfo.CurrentCulture));
				}
			}
		}

		foreach (var ingredientId in ingredientIds)
		{
			if (idRanges.Any(idRange => idRange.Contains(ingredientId)))
			{
				frestIngredientCount++;
			}
		}

		return frestIngredientCount;
	}

	public static ulong RunPart2(ImmutableArray<string> database)
	{
		var idRanges = new List<Range<ulong>>();
		var validIdCount = 0ul;

		foreach (var item in database)
		{
			if (item.Length > 0)
			{
				if (item.Contains('-', StringComparison.CurrentCultureIgnoreCase))
				{
					// range
					var parts = item.Split('-');
					idRanges.Add(
						new(
							ulong.Parse(parts[0], CultureInfo.InvariantCulture),
							ulong.Parse(parts[1], CultureInfo.InvariantCulture) + 1));
				}
			}
		}

		// "Compress" the ranges
		for (var i = 0; i < idRanges.Count; i++)
		{
			var targetIdRange = idRanges[i];

			for (var j = i + 1; j < idRanges.Count; j++)
			{
				var idIntersection = targetIdRange.Union(idRanges[j]);

				if (idIntersection.HasValue)
				{
					idRanges[j] = idIntersection.Value;
					idRanges.RemoveAt(i);
					i--;
					break;
				}
			}
		}

		// Now calculate the counts.
		foreach (var idRange in idRanges)
		{
			validIdCount += idRange.End - idRange.Start;
		}

		return validIdCount;
	}
}