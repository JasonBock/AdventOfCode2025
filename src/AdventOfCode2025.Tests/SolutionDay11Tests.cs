using NUnit.Framework;

namespace AdventOfCode2025.Day11.Tests;

public static class SolutionDay11Tests
{
	[Test]
	public static void Part1()
	{
		var input =
			"""
			aaa: you hhh
			you: bbb ccc
			bbb: ddd eee
			ccc: ddd eee fff
			ddd: ggg
			eee: out
			fff: out
			ggg: out
			hhh: ccc fff iii
			iii: out
			""";

		Assert.That(SolutionDay11.RunPart1([.. input.Split(Environment.NewLine)]), Is.EqualTo(5));
	}
}