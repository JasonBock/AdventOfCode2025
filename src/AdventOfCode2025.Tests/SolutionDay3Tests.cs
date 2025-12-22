using NUnit.Framework;

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
}