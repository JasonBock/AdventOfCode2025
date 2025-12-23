using AdventOfCode2025.Day1;
using AdventOfCode2025.Day2;
using AdventOfCode2025.Day3;

//await RunDay1Async();
//await RunDay2Async();
await RunDay3Async();

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