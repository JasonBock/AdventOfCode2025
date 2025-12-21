using System.Numerics;

namespace AdventOfCode2025.Extensions;

internal static class IBinaryNumberExtensions
{
	extension<T>(T self) 
		where T : IBinaryNumber<T>
	{
		internal bool IsInvalid()
		{
			var valueContent = self.ToString()!;

			return (valueContent.Length % 2 == 0 &&
				(valueContent.AsSpan(0, valueContent.Length / 2).SequenceEqual(
					valueContent.AsSpan(valueContent.Length / 2))));
		}
	}
}