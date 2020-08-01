using DynaISO8583.Enums;

namespace DynaISO8583.Attributes
{
	public interface IIsoField
	{
		object Value { get; set; }

		IsoFieldTypes IsoFieldTypes { get; set; }

		int Position { get; set; }

		int MaxLen { get; set; }

		LengthTypes LengthType { get; set; }

		ContentTypes ContentType { get; set; }

		DataFormats DataFormat { get; set; }

		DataFormats LenDataFormat { get; set; }

		EncodingTypes Encoding { get; set; }
	}
}
