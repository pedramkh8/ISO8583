using DynaISO8583.Enums;

namespace DynaISO8583.Attributes
{
	public sealed class IsoField : IIsoField
	{
		public object Value { get; set; }

		public IsoFieldTypes IsoFieldTypes { get; set; }

		public int Position { get; set; }

		public int MaxLen { get; set; }

		public LengthTypes LengthType { get; set; }

		public ContentTypes ContentType { get; set; }

		public DataFormats DataFormat { get; set; }

		public DataFormats LenDataFormat { get; set; }

		public EncodingTypes Encoding { get; set; }
	}
}
