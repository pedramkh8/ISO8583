using DynaISO8583.Enums;

namespace DynaISO8583.Attributes
{
	public interface IIsoFieldAttribute
	{

		IsoFieldType IsoFieldTypes { get; set; }

		int Position { get; set; }

		int MaxLen { get; set; }

		LengthType LengthType { get; set; }

		ContentTypes ContentType { get; set; }

		DataFormats DataFormat { get; set; }

		DataFormats LenDataFormat { get; set; }

		EncodingTypes Encoding { get; set; }

	}
}
