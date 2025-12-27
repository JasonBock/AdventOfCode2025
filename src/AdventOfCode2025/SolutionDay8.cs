using System.Collections.Immutable;
using System.Globalization;

namespace AdventOfCode2025.Day8;

public static class SolutionDay8
{
	public static uint RunPart1(ImmutableArray<string> data, int shortestCircuitsCount)
	{
		var positions = new List<Point>();

		foreach (var entry in data)
		{
			var parts = entry.Split(',');
			positions.Add(new(
				long.Parse(parts[0], CultureInfo.CurrentCulture),
				long.Parse(parts[1], CultureInfo.CurrentCulture),
				long.Parse(parts[2], CultureInfo.CurrentCulture)));
		}

		var distancePairs = new Dictionary<PointPair, double>();

		for (var i = 0; i < positions.Count; i++)
		{
			var iPosition = positions[i];

			for (var j = i + 1; j < positions.Count; j++)
			{
				var jPosition = positions[j];
				var distance = Math.Sqrt(
					Math.Pow(iPosition.X - jPosition.X, 2) +
					Math.Pow(iPosition.Y - jPosition.Y, 2) +
					Math.Pow(iPosition.Z - jPosition.Z, 2));

				distancePairs[new(iPosition, jPosition)] = distance;
			}
		}

		var networks = new List<List<Point>>();

		for (var i = 0; i < shortestCircuitsCount; i++)
		{
			var smallestPair = distancePairs.MinBy(pair => pair.Value);

			var p0ExistingNetwork = networks.SingleOrDefault(
				network => network.Contains(smallestPair.Key.p0));
			var p1ExistingNetwork = networks.SingleOrDefault(
				network => network.Contains(smallestPair.Key.p1));

			if (p0ExistingNetwork is null && p1ExistingNetwork is null)
			{
				networks.Add(new([smallestPair.Key.p0, smallestPair.Key.p1]));
			}
			else if (p0ExistingNetwork is null)
			{
				p1ExistingNetwork!.Add(smallestPair.Key.p0);
			}
			else if (p1ExistingNetwork is null)
			{
				p0ExistingNetwork!.Add(smallestPair.Key.p1);
			}
			else if (p0ExistingNetwork != p1ExistingNetwork)
			{
				p0ExistingNetwork.AddRange(p1ExistingNetwork);
				_ = networks.Remove(p1ExistingNetwork);
			}
			else
			{
				// They're equal, do nothing.
			}

			_ = distancePairs.Remove(smallestPair.Key);
		}

		var result = 1u;

		foreach (var network in networks.OrderByDescending(network => network.Count).Take(3))
		{
			result *= (uint)network.Count;
		}

		return result;
	}

	public static long RunPart2(ImmutableArray<string> data)
	{
		var positions = new List<Point>();

		foreach (var entry in data)
		{
			var parts = entry.Split(',');
			positions.Add(new(
				long.Parse(parts[0], CultureInfo.CurrentCulture),
				long.Parse(parts[1], CultureInfo.CurrentCulture),
				long.Parse(parts[2], CultureInfo.CurrentCulture)));
		}

		var distancePairs = new Dictionary<PointPair, double>();

		for (var i = 0; i < positions.Count; i++)
		{
			var iPosition = positions[i];

			for (var j = i + 1; j < positions.Count; j++)
			{
				var jPosition = positions[j];
				var distance = Math.Sqrt(
					Math.Pow(iPosition.X - jPosition.X, 2) +
					Math.Pow(iPosition.Y - jPosition.Y, 2) +
					Math.Pow(iPosition.Z - jPosition.Z, 2));

				distancePairs[new(iPosition, jPosition)] = distance;
			}
		}

		var networks = new List<List<Point>>();
		PointPair lastPair = default;

		while (!networks.Any(network => network.Count >= positions.Count))
		{
			var smallestPair = distancePairs.MinBy(pair => pair.Value);
			lastPair = smallestPair.Key;

			var p0ExistingNetwork = networks.SingleOrDefault(
				network => network.Contains(smallestPair.Key.p0));
			var p1ExistingNetwork = networks.SingleOrDefault(
				network => network.Contains(smallestPair.Key.p1));

			if (p0ExistingNetwork is null && p1ExistingNetwork is null)
			{
				networks.Add(new([smallestPair.Key.p0, smallestPair.Key.p1]));
			}
			else if (p0ExistingNetwork is null)
			{
				p1ExistingNetwork!.Add(smallestPair.Key.p0);
			}
			else if (p1ExistingNetwork is null)
			{
				p0ExistingNetwork!.Add(smallestPair.Key.p1);
			}
			else if (p0ExistingNetwork != p1ExistingNetwork)
			{
				p0ExistingNetwork.AddRange(p1ExistingNetwork);
				_ = networks.Remove(p1ExistingNetwork);
			}
			else
			{
				// They're equal, do nothing.
			}

			_ = distancePairs.Remove(smallestPair.Key);
		}

		return lastPair.p0.X * lastPair.p1.X;
	}
}

public record struct Point(long X, long Y, long Z);
public record struct PointPair(Point p0, Point p1);