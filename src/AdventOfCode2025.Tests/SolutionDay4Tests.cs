using NUnit.Framework;

namespace AdventOfCode2025.Day4.Tests;

public static class SolutionDay4Tests
{
	[Test]
	public static void Part1()
	{
		var input =
			"""
			..@@.@@@@.
			@@@.@.@.@@
			@@@@@.@.@@
			@.@@@@..@.
			@@.@@@@.@@
			.@@@@@@@.@
			.@.@.@.@@@
			@.@@@.@@@@
			.@@@@@@@@.
			@.@.@@@.@.
			""";

		Assert.That(SolutionDay4.RunPart1([.. input.Split(Environment.NewLine)]), Is.EqualTo(13));
	}
}