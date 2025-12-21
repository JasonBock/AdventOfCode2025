using AdventOfCode2025.Extensions;
using System.Globalization;

namespace AdventOfCode2025.Day2;

public static class SolutionDay2
{
	public static Int128 RunPart1(string ranges)
	{
		ArgumentNullException.ThrowIfNull(ranges);

		var invalidIdSum = Int128.Zero;

		foreach (var range in ranges.Split(','))
		{
			var rangeValues = range.Split('-');
			var lowerRangeValue = Int128.Parse(rangeValues[0], CultureInfo.CurrentCulture);
			var upperRangeValue = Int128.Parse(rangeValues[1], CultureInfo.CurrentCulture);

			for (var i = lowerRangeValue; i <= upperRangeValue; i++)
			{
				if (i.IsInvalid())
				{
					invalidIdSum += i;
				}
			}
		}

		return invalidIdSum;
	}

	public static Int128 RunPart2(string ranges)
	{
		var invalidIdSum = Int128.Zero;

		return invalidIdSum;
	}
}