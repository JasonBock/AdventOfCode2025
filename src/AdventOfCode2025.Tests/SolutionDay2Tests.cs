using AdventOfCode2025.Day2;
using NUnit.Framework;
using System.Globalization;

namespace AdventOfCode2025.Day1.Tests;

public static class SolutionDay2Tests
{
	[Test]
	public static void Simple()
	{
		var input = "11-13";

		Assert.That(SolutionDay2.RunPart1(input), Is.EqualTo(Int128.Parse("11", CultureInfo.CurrentCulture)));
	}

	[Test]
	public static void Part1()
	{
		var input = "11-22,95-115,998-1012,1188511880-1188511890,222220-222224,1698522-1698528,446443-446449,38593856-38593862,565653-565659,824824821-824824827,2121212118-2121212124";

		Assert.That(SolutionDay2.RunPart1(input), Is.EqualTo(Int128.Parse("1227775554", CultureInfo.CurrentCulture)));
	}

	[Test]
	public static void Part2()
	{
		var input = "11-22,95-115,998-1012,1188511880-1188511890,222220-222224,1698522-1698528,446443-446449,38593856-38593862,565653-565659,824824821-824824827,2121212118-2121212124";

		Assert.That(SolutionDay2.RunPart2(input), Is.EqualTo(Int128.Parse("4174379265", CultureInfo.CurrentCulture)));
	}
}