using DynaISO8583.Attributes;

namespace DynaISO8583
{
	public class Message
	{
		[IsoField(1, Enums.IsoFieldTypes.FIELD, 4, Enums.LengthTypes.FIXED, Enums.ContentTypes.N)]
		public string MTI { get; set; }

		[IsoField(2, Enums.IsoFieldTypes.BITMAP, 4, Enums.LengthTypes.FIXED, Enums.ContentTypes.H)]
		public string BitMap { get; set; }

		[IsoField(3, Enums.IsoFieldTypes.FIELD, 4, Enums.LengthTypes.FIXED, Enums.ContentTypes.A)]
		public string P1 { get; set; }

		[IsoField(4, Enums.IsoFieldTypes.FIELD, 4, Enums.LengthTypes.FIXED, Enums.ContentTypes.N)]
		public int P2 { get; set; }

	}
}
