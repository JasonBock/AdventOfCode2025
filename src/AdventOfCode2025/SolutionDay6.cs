using System.Collections.Immutable;
using System.Globalization;
using System.Numerics;

namespace AdventOfCode2025.Day6;

public static class SolutionDay6
{
	public static BigInteger RunPart1(ImmutableArray<string> worksheet)
	{
		var answer = BigInteger.Zero;

		var operators = new List<char>();
		var data = new List<List<BigInteger>>();

		// Parse the worksheet content.
		for (var i = 0; i < worksheet.Length; i++)
		{
			var input = worksheet[i];

			if (i == worksheet.Length - 1)
			{
				// These are the operators.
				operators = [.. input.Where(value => value != ' ')];
			}
			else
			{
				// This is data.
				data.Add(SolutionDay6.GetData(input));
			}
		}

		for (var i = 0; i < operators.Count; i++)
		{
			var @operator = operators[i];
			var result = BigInteger.Zero;

			if (@operator == '+')
			{
				foreach (var input in data)
				{
					result += input[i];
				}
			}
			else
			{
				result = BigInteger.One;

				foreach (var input in data)
				{
					result *= input[i];
				}
			}

			answer += result;
		}

		return answer;
	}

	private static List<BigInteger> GetData(string input)
	{
		var data = new List<BigInteger>();
		var currentValue = new List<char>();

		for (var i = 0; i < input.Length; i++)
		{
			var value = input[i];

			if (value != ' ')
			{
				currentValue.Add(value);

				if (i == input.Length - 1)
				{
					data.Add(BigInteger.Parse(currentValue.ToArray(), CultureInfo.CurrentCulture));
					currentValue.Clear();
				}
			}
			else
			{
				if (currentValue.Count > 0)
				{
					data.Add(BigInteger.Parse(currentValue.ToArray(), CultureInfo.CurrentCulture));
					currentValue.Clear();
				}
			}
		}

		return data;
	}

	public static BigInteger RunPart2(ImmutableArray<string> worksheet)
	{
		var answer = BigInteger.Zero;

		var operators = new List<char>([.. worksheet[^1].Where(value => value != ' ')]);
		var data = SolutionDay6.GetCephalopodData(worksheet[..^1]);

		for (var i = 0; i < operators.Count; i++)
		{
			var @operator = operators[i];
			var result = BigInteger.Zero;

			if (@operator == '+')
			{
				foreach (var input in data[i])
				{
					result += input;
				}
			}
			else
			{
				result = BigInteger.One;

				foreach (var input in data[i])
				{
					result *= input;
				}
			}

			answer += result;
		}

		return answer;
	}

	private static List<List<BigInteger>> GetCephalopodData(ImmutableArray<string> input)
	{
		var data = new List<List<BigInteger>>();

		var currentValue = new List<char>();
		var currentValues = new List<BigInteger>();

		for (var i = input[0].Length - 1; i >= 0; i--)
		{
			for (var j = 0; j < input.Length; j++)
			{
				var value = input[j][i];

				if (value != ' ')
				{
					currentValue.Add(value);
				}

				if (j == input.Length - 1)
				{
					if (currentValue.Count > 0)
					{
						currentValues.Add(BigInteger.Parse(currentValue.ToArray(), CultureInfo.CurrentCulture));
						currentValue.Clear();
					}
					else
					{
						data.Add(currentValues);
						currentValues = [];
					}
				}
			}

			if (i == 0)
			{
				data.Add(currentValues);
			}
		}

		data.Reverse();

		return data;
	}
}