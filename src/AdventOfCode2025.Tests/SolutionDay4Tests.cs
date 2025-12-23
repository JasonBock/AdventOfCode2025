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

	[Test]
	public static void Part2()
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

		Assert.That(SolutionDay4.RunPart2([.. input.Split(Environment.NewLine)]), Is.EqualTo(43));
	}
}