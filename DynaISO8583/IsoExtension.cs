using System.Collections.Generic;
using System.Linq;

namespace DynaISO8583
{
	public static class IsoExtension
	{
		public static string CharsToString(this IEnumerable<char> source)
		{
			return new string(source.ToArray());
		}
	}
}
