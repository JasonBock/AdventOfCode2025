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
}