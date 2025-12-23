using System.Collections.Immutable;
using System.Globalization;

namespace AdventOfCode2025.Day3;

public static class SolutionDay3
{
	public static int RunPart1(ImmutableArray<string> batteryBanks)
	{
		var totalJoltage = 0;

		foreach (var batteryBank in batteryBanks)
		{
			var maximumJoltage = 0;

			for (var firstIndex = 0; firstIndex < batteryBank.Length; firstIndex++)
			{
				var firstNumber = batteryBank[firstIndex];

				for (var secondIndex = firstIndex + 1; secondIndex < batteryBank.Length; secondIndex++)
				{
					var currentJoltage = int.Parse($"{firstNumber}{batteryBank[secondIndex]}", CultureInfo.CurrentCulture);

					if (currentJoltage > maximumJoltage)
					{
						maximumJoltage = currentJoltage;
					}
				}
			}

			totalJoltage += maximumJoltage;
		}

		return totalJoltage;
	}

	public static Int128 RunPart2(ImmutableArray<string> batteryBanks)
	{
		var totalJoltage = Int128.Zero;

		foreach (var batteryBank in batteryBanks)
		{
			var joltageValues = new char[12];
			var n = 12;
			var startingIndex = 0;

			for (var i = 0; i < joltageValues.Length; i++)
			{
				var leftValues = batteryBank.Substring(startingIndex, batteryBank.Length - startingIndex - n + 1);
				var leftLargest = leftValues.Max();
				var leftLargestIndex = batteryBank.IndexOf(leftLargest, startingIndex);
				joltageValues[i] = leftLargest;
				n--;
				startingIndex = leftLargestIndex + 1;
			}

			totalJoltage += Int128.Parse(joltageValues.AsSpan(), CultureInfo.CurrentCulture);
		}

		return totalJoltage;
	}
}