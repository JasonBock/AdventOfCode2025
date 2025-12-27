using NUnit.Framework;

namespace AdventOfCode2025.Day9.Tests;

public static class SolutionDay9Tests
{
	[Test]
	public static void Part1()
	{
		var input =
			"""
			7,1
			11,1
			11,7
			9,7
			9,5
			2,5
			2,3
			7,3
			""";

		Assert.That(SolutionDay9.RunPart1([.. input.Split(Environment.NewLine)]), Is.EqualTo(50));
	}
}