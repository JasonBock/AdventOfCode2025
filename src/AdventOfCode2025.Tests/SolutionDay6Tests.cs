using NUnit.Framework;
using System.Numerics;

namespace AdventOfCode2025.Day6.Tests;

public static class SolutionDay6Tests
{
	[Test]
	public static void Part1()
	{
		var input =
			"""
			123 328  51 64 
			 45 64  387 23 
			  6 98  215 314
			*   +   *   +  
			""";

		Assert.That(SolutionDay6.RunPart1([.. input.Split(Environment.NewLine)]), Is.EqualTo(new BigInteger(4_277_556)));
	}
}