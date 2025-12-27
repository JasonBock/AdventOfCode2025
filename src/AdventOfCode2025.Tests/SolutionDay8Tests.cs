using NUnit.Framework;

namespace AdventOfCode2025.Day8.Tests;

public static class SolutionDay8Tests
{
	[Test]
	public static void Part1()
	{
		var input =
			"""
			162,817,812
			57,618,57
			906,360,560
			592,479,940
			352,342,300
			466,668,158
			542,29,236
			431,825,988
			739,650,466
			52,470,668
			216,146,977
			819,987,18
			117,168,530
			805,96,715
			346,949,466
			970,615,88
			941,993,340
			862,61,35
			984,92,344
			425,690,689
			""";

		Assert.That(SolutionDay8.RunPart1([.. input.Split(Environment.NewLine)], 10), Is.EqualTo(40));
	}

	[Test]
	public static void Part2()
	{
		var input =
			"""
			162,817,812
			57,618,57
			906,360,560
			592,479,940
			352,342,300
			466,668,158
			542,29,236
			431,825,988
			739,650,466
			52,470,668
			216,146,977
			819,987,18
			117,168,530
			805,96,715
			346,949,466
			970,615,88
			941,993,340
			862,61,35
			984,92,344
			425,690,689
			""";

		Assert.That(SolutionDay8.RunPart2([.. input.Split(Environment.NewLine)]), Is.EqualTo(25_272));
	}
}