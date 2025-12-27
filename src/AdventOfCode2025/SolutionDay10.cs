#pragma warning disable CA2249 // Consider using 'string.Contains' instead of 'string.IndexOf'

using System.Collections.Immutable;
using System.Globalization;

namespace AdventOfCode2025.Day10;

public static class SolutionDay10
{
	public static long RunPart1(ImmutableArray<string> data)
	{
		var manual = new List<MachineConfiguration>();

		foreach (var machine in data)
		{
			var rightBracketIndex = machine.IndexOf(']', StringComparison.OrdinalIgnoreCase);
			var desiredState = machine.AsSpan()[1..rightBracketIndex];

			var buttonWiringSchematics = new List<ImmutableArray<int>>();
			var leftParenthesisIndex = machine.IndexOf('(', StringComparison.OrdinalIgnoreCase);

			do
			{
				if (leftParenthesisIndex >= 0)
				{
					var rightParenthesisIndex = machine.IndexOf(')', leftParenthesisIndex);
					var buttons = machine.Substring(leftParenthesisIndex + 1, rightParenthesisIndex - leftParenthesisIndex - 1);

					var buttonParts = buttons.Split(',')
						.Select(value => int.Parse(value, CultureInfo.CurrentCulture)).ToImmutableArray();
					buttonWiringSchematics.Add(buttonParts);

					leftParenthesisIndex = machine.IndexOf('(', rightParenthesisIndex + 1);
				}
			} while (leftParenthesisIndex >= 0);

			manual.Add(new(new(desiredState), [.. buttonWiringSchematics]));
		}

		return 0L;
	}
}

public record struct MachineConfiguration(string DesiredState, ImmutableArray<ImmutableArray<int>> ButtonWiringSchematics);