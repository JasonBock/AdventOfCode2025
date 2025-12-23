using NUnit.Framework;

namespace AdventOfCode2025.Day5.Tests;

public static class SolutionDay5Tests
{
	[Test]
	public static void Part1()
	{
		var input =
			"""
			3-5
			10-14
			16-20
			12-18

			1
			5
			8
			11
			17
			32
			""";

		Assert.That(SolutionDay5.RunPart1([.. input.Split(Environment.NewLine)]), Is.EqualTo(3));
	}
}