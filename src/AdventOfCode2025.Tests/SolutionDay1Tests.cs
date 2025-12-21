using NUnit.Framework;

namespace AdventOfCode2025.Day1.Tests;

public static class SolutionDay1Tests
{
	[Test]
	public static void Part1()
	{
		var input =
			"""
			L68
			L30
			R48
			L5
			R60
			L55
			L1
			L99
			R14
			L82
			""";

		Assert.That(SolutionDay1.RunPart1([.. input.Split(Environment.NewLine)]), Is.EqualTo(3));
	}

	[Test]
	public static void Part2()
	{
		var input =
			"""
			L68
			L30
			R48
			L5
			R60
			L55
			L1
			L99
			R14
			L82
			""";

		Assert.That(SolutionDay1.RunPart2([.. input.Split(Environment.NewLine)]), Is.EqualTo(6));
	}
}