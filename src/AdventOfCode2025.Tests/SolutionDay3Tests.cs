using NUnit.Framework;
using System.Globalization;

namespace AdventOfCode2025.Day3.Tests;

public static class SolutionDay3Tests
{
	[Test]
	public static void Part1()
	{
		var input =
			"""
			987654321111111
			811111111111119
			234234234234278
			818181911112111
			""";

		Assert.That(SolutionDay3.RunPart1([.. input.Split(Environment.NewLine)]), Is.EqualTo(357));
	}

	[Test]
	public static void Part2()
	{
		var input =
			"""
			987654321111111
			811111111111119
			234234234234278
			818181911112111
			""";

		Assert.That(SolutionDay3.RunPart2([.. input.Split(Environment.NewLine)]), Is.EqualTo(Int128.Parse("3121910778619", CultureInfo.CurrentCulture)));
	}
}