using AdventOfCode2025.Day1;
using AdventOfCode2025.Day2;
using AdventOfCode2025.Day3;
using AdventOfCode2025.Day4;
using AdventOfCode2025.Day5;
using AdventOfCode2025.Day6;
using AdventOfCode2025.Day7;
using AdventOfCode2025.Day8;
using AdventOfCode2025.Day9;

//await RunDay1Async();
//await RunDay2Async();
//await RunDay3Async();
//await RunDay4Async();
//await RunDay5Async();
//await RunDay6Async();
//await RunDay7Async();
//await RunDay8Async();
await RunDay9Async();

static async Task RunDay1Async()
{
	Console.WriteLine(nameof(RunDay1Async));
	Console.WriteLine($"Part 1 = {SolutionDay1.RunPart1([.. await File.ReadAllLinesAsync("Day1Input.txt")])}");
	Console.WriteLine($"Part 2 = {SolutionDay1.RunPart2([.. await File.ReadAllLinesAsync("Day1Input.txt")])}");
}

static async Task RunDay2Async()
{
	Console.WriteLine(nameof(RunDay2Async));
	Console.WriteLine($"Part 1 = {SolutionDay2.RunPart1(await File.ReadAllTextAsync("Day2Input.txt"))}");
	Console.WriteLine($"Part 2 = {SolutionDay2.RunPart2(await File.ReadAllTextAsync("Day2Input.txt"))}");
}

static async Task RunDay3Async()
{
	Console.WriteLine(nameof(RunDay3Async));
	Console.WriteLine($"Part 1 = {SolutionDay3.RunPart1([.. await File.ReadAllLinesAsync("Day3Input.txt")])}");
	Console.WriteLine($"Part 2 = {SolutionDay3.RunPart2([.. await File.ReadAllLinesAsync("Day3Input.txt")])}");
}

static async Task RunDay4Async()
{
	Console.WriteLine(nameof(RunDay4Async));
	Console.WriteLine($"Part 1 = {SolutionDay4.RunPart1([.. await File.ReadAllLinesAsync("Day4Input.txt")])}");
	Console.WriteLine($"Part 2 = {SolutionDay4.RunPart2([.. await File.ReadAllLinesAsync("Day4Input.txt")])}");
}

static async Task RunDay5Async()
{
	Console.WriteLine(nameof(RunDay5Async));
	Console.WriteLine($"Part 1 = {SolutionDay5.RunPart1([.. await File.ReadAllLinesAsync("Day5Input.txt")])}");
	Console.WriteLine($"Part 2 = {SolutionDay5.RunPart2([.. await File.ReadAllLinesAsync("Day5Input.txt")])}");
}

static async Task RunDay6Async()
{
	Console.WriteLine(nameof(RunDay6Async));
	Console.WriteLine($"Part 1 = {SolutionDay6.RunPart1([.. await File.ReadAllLinesAsync("Day6Input.txt")])}");
	Console.WriteLine($"Part 2 = {SolutionDay6.RunPart2([.. await File.ReadAllLinesAsync("Day6Input.txt")])}");
}

static async Task RunDay7Async()
{
	Console.WriteLine(nameof(RunDay7Async));
	Console.WriteLine($"Part 1 = {SolutionDay7.RunPart1([.. await File.ReadAllLinesAsync("Day7Input.txt")])}");
}

static async Task RunDay8Async()
{
	Console.WriteLine(nameof(RunDay8Async));
	Console.WriteLine($"Part 1 = {SolutionDay8.RunPart1([.. await File.ReadAllLinesAsync("Day8Input.txt")], 1_000)}");
	Console.WriteLine($"Part 2 = {SolutionDay8.RunPart2([.. await File.ReadAllLinesAsync("Day8Input.txt")])}");
}

static async Task RunDay9Async()
{
	Console.WriteLine(nameof(RunDay9Async));
	Console.WriteLine($"Part 1 = {SolutionDay9.RunPart1([.. await File.ReadAllLinesAsync("Day9Input.txt")])}");
}