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
		ArgumentNullException.ThrowIfNull(ranges);

		var invalidIdSum = Int128.Zero;

		foreach (var range in ranges.Split(','))
		{
			var rangeValues = range.Split('-');
			var lowerRangeValue = Int128.Parse(rangeValues[0], CultureInfo.CurrentCulture);
			var upperRangeValue = Int128.Parse(rangeValues[1], CultureInfo.CurrentCulture);

			for (var value = lowerRangeValue; value <= upperRangeValue; value++)
			{
				var valueContent = value.ToString(CultureInfo.CurrentCulture)!;
				var factors = SolutionDay2.GetFactors(valueContent.Length);
				var isValid = true;

				for (var lengthIndex = 0; lengthIndex < factors.Length; lengthIndex++)
				{
					var length = factors[lengthIndex];
					var rootChunk = valueContent.AsSpan(0, length);

					var isSizeValue = false;

					for (var chunkSize = 1; chunkSize < (valueContent.Length / length); chunkSize++)
					{
						if (!rootChunk.SequenceEqual(
							valueContent.AsSpan((chunkSize) * length, length)))
						{
							isSizeValue = true;
							break;
						}
					}

					if (!isSizeValue)
					{
						isValid = false;
						break;
					}
				}

				if (!isValid)
				{
					invalidIdSum += value;
				}
			}
		}

		return invalidIdSum;
	}

	static int[] GetFactors(int number)
	{
		var factors = new SortedSet<int> { 1 };
		var max = (int)Math.Ceiling(Math.Sqrt((double)number));

		for (var factor = 2; factor <= max; factor++)
		{
			if (number % factor == 0)
			{
				_ = factors.Add(factor);

				if (factor != number / factor)
				{
					_ = factors.Add(number / factor);
				}
			}
		}

		_ = factors.Remove(number);
		return [.. factors];
	}
}