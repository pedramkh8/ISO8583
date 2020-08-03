using DynaISO8583.Enums;
using System.Reflection;

namespace DynaISO8583.Attributes
{
	public sealed class IsoField : IIsoField
	{
		public object Value { get; set; }

		public IsoFieldType IsoFieldTypes { get; set; }

		public int Position { get; set; }

		public int MaxLen { get; set; }

		public LengthType LengthType { get; set; }

		public ContentTypes ContentType { get; set; }

		public DataFormats DataFormat { get; set; }

		public DataFormats LenDataFormat { get; set; }

		public EncodingTypes Encoding { get; set; }

		public PropertyInfo PropertyInfo { get; set; }
	}
}
