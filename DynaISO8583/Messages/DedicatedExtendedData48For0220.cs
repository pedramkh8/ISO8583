using DynaISO8583.Attributes;
using DynaISO8583.Enums;

namespace DynaISO8583.Messages
{
	public class DedicatedExtendedData48For0220 
	{
		[IsoField(position: 1, isoFieldType: Enums.IsoFieldType.Field, maxLen: 6, lengthType: LengthType.Fixed, contentType: ContentTypes.ANS)]
		public string ReservedForFuture1 { get; set; }

		[IsoField(position: 2, isoFieldType: Enums.IsoFieldType.Field, maxLen: 2, lengthType: LengthType.Fixed, contentType: ContentTypes.ANS)]
		public  string LanguageCode2 { get; set; }

		[IsoField(position: 3, isoFieldType: Enums.IsoFieldType.Field, maxLen: 12, lengthType: LengthType.Fixed, contentType: ContentTypes.ANS)]
		public  string ReservedForPaymentCenter2 { get; set; }

		[IsoField(position: 4, isoFieldType: Enums.IsoFieldType.Field, maxLen: 4, lengthType: LengthType.Fixed, contentType: ContentTypes.ANS)]
		public  string OrganizationCode4 { get; set; }

		[IsoField(position: 5, isoFieldType: Enums.IsoFieldType.Field, maxLen: 2, lengthType: LengthType.Fixed, contentType: ContentTypes.ANS)]
		public  string ReservedForFuture5 { get; set; }

		[IsoField(position: 6, isoFieldType: Enums.IsoFieldType.Field, maxLen: 4, lengthType: LengthType.Fixed, contentType: ContentTypes.ANS)]
		public  string ExtraData6 { get; set; }

		[IsoField(position: 7, isoFieldType: Enums.IsoFieldType.Field, maxLen: 3, lengthType: LengthType.Fixed, contentType: ContentTypes.ANS)]
		public  string ReservedForFuture7 { get; set; }

		[IsoField(position: 8, isoFieldType: Enums.IsoFieldType.Field, maxLen: 3, lengthType: LengthType.Fixed, contentType: ContentTypes.ANS)]
		public  string BankCode8 { get; set; }

		[IsoField(position: 9, isoFieldType: Enums.IsoFieldType.Field, maxLen: 6, lengthType: LengthType.Fixed, contentType: ContentTypes.ANS)]
		public  string ReservedForFuture9 { get; set; }

		[IsoField(position: 10, isoFieldType: Enums.IsoFieldType.Field, maxLen: 22, lengthType: LengthType.Fixed, contentType: ContentTypes.ANS)]
		public  string BillNumber10 { get; set; }

		[IsoField(position: 11, isoFieldType: Enums.IsoFieldType.Field, maxLen: 8, lengthType: LengthType.Fixed, contentType: ContentTypes.ANS)]
		public  string ReservedForFuture11 { get; set; }

		[IsoField(position: 12, isoFieldType: Enums.IsoFieldType.Field, maxLen: 16, lengthType: LengthType.Fixed, contentType: ContentTypes.ANS)]
		public  string TransmitDataReceiverToOperator { get; set; }

		[IsoField(position: 13, isoFieldType: Enums.IsoFieldType.Field, maxLen: 20, lengthType: LengthType.Fixed, contentType: ContentTypes.ANS)]
		public  string ReservedForFuture12 { get; set; }
	}
}
