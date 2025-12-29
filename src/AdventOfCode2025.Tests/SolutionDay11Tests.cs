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

	[Test]
	public static void Part2()
	{
		var input =
			"""
			svr: aaa bbb
			aaa: fft
			fft: ccc
			bbb: tty
			tty: ccc
			ccc: ddd eee
			ddd: hub
			hub: fff
			eee: dac
			dac: fff
			fff: ggg hhh
			ggg: out
			hhh: out
			""";

		Assert.That(SolutionDay11.RunPart2([.. input.Split(Environment.NewLine)]), Is.EqualTo(2));
	}
}