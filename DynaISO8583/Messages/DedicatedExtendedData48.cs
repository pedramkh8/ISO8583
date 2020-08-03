using DynaISO8583.Attributes;
using DynaISO8583.Enums;

namespace DynaISO8583.Messages
{
	public class DedicatedExtendedData48
	{
		[IsoField(position: 1, isoFieldType: Enums.IsoFieldType.Field, maxLen: 6, lengthType: LengthType.Fixed, contentType: ContentTypes.ANS)]
		public string ReservedForFutureP1 { get; set; }

		[IsoField(position: 2, isoFieldType: Enums.IsoFieldType.Field, maxLen: 2, lengthType: LengthType.Fixed, contentType: ContentTypes.ANS)]
		public virtual string LanguageCodeP2 { get; set; }

		[IsoField(position: 3, isoFieldType: Enums.IsoFieldType.Field, maxLen: 12, lengthType: LengthType.Fixed, contentType: ContentTypes.ANS)]
		public virtual string ReservedForPaymentCenterP3 { get; set; }

		[IsoField(position: 4, isoFieldType: Enums.IsoFieldType.Field, maxLen: 4, lengthType: LengthType.Fixed, contentType: ContentTypes.ANS)]
		public virtual string OrganizationCodeP4 { get; set; }

		[IsoField(position: 5, isoFieldType: Enums.IsoFieldType.Field, maxLen: 2, lengthType: LengthType.Fixed, contentType: ContentTypes.ANS)]
		public virtual string ReservedForFutureP5 { get; set; }

		[IsoField(position: 6, isoFieldType: Enums.IsoFieldType.Field, maxLen: 4, lengthType: LengthType.Fixed, contentType: ContentTypes.ANS)]
		public virtual string ExtraDataP6 { get; set; }

		[IsoField(position: 7, isoFieldType: Enums.IsoFieldType.Field, maxLen: 3, lengthType: LengthType.Fixed, contentType: ContentTypes.ANS)]
		public virtual string ReservedForFutureP7 { get; set; }

		[IsoField(position: 8, isoFieldType: Enums.IsoFieldType.Field, maxLen: 3, lengthType: LengthType.Fixed, contentType: ContentTypes.ANS)]
		public virtual string BankCodeP8 { get; set; }

		[IsoField(position: 9, isoFieldType: Enums.IsoFieldType.Field, maxLen: 6, lengthType: LengthType.Fixed, contentType: ContentTypes.ANS)]
		public virtual string ReservedForFutureP9 { get; set; }

		[IsoField(position: 10, isoFieldType: Enums.IsoFieldType.Field, maxLen: 22, lengthType: LengthType.Fixed, contentType: ContentTypes.ANS)]
		public virtual string BillNumberP10 { get; set; }

		[IsoField(position: 11, isoFieldType: Enums.IsoFieldType.Field, maxLen: 44, lengthType: LengthType.Fixed, contentType: ContentTypes.ANS)]
		public virtual string ReservedForFutureP11 { get; set; }
	}
}
