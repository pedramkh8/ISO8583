using DynaISO8583.Attributes;
using DynaISO8583.Enums;

namespace DynaISO8583.Messages
{
	public class DedicatedExtendedData121
	{
		[IsoField(position: 0, isoFieldType: Enums.IsoFieldType.BitMap, maxLen: 4, lengthType: LengthType.Fixed, contentType: ContentTypes.H, dataFormat: DataFormats.ASCII)]
		public string BitMap { get; set; }

		[IsoField(position: 1, isoFieldType: Enums.IsoFieldType.Field, maxLen: 33, lengthType: LengthType.LlVAR, contentType: ContentTypes.ANS, dataFormat: DataFormats.ASCII)]
		public string ReservedForBillPaymentCentersP1 { get; set; }

		[IsoField(position: 2, isoFieldType: Enums.IsoFieldType.Field, maxLen: 99, lengthType: LengthType.LlVAR, contentType: ContentTypes.ANS, dataFormat: DataFormats.ASCII)]
		public string PersianReceiptP2 { get; set; }

		[IsoField(position: 3, isoFieldType: Enums.IsoFieldType.Field, maxLen: 99, lengthType: LengthType.LlVAR, contentType: ContentTypes.ANS, dataFormat: DataFormats.ASCII)]
		public string EnglishReceiptP3 { get; set; }

		[IsoField(position: 4, isoFieldType: Enums.IsoFieldType.Field, maxLen: 99, lengthType: LengthType.LlVAR, contentType: ContentTypes.ANS, dataFormat: DataFormats.ASCII)]
		public string ReservedForBillPaymentCenters2P4 { get; set; }

		[IsoField(position: 5, isoFieldType: Enums.IsoFieldType.Field, maxLen: 99, lengthType: LengthType.LlVAR, contentType: ContentTypes.ANS, dataFormat: DataFormats.ASCII)]
		public string ReservedForBillPaymentCenters3P5 { get; set; }

		[IsoField(position: 6, isoFieldType: Enums.IsoFieldType.Field, maxLen: 99, lengthType: LengthType.LlVAR, contentType: ContentTypes.ANS, dataFormat: DataFormats.ASCII)]
		public string ReservedForBillPaymentCenters4P6 { get; set; }

		[IsoField(position: 7, isoFieldType: Enums.IsoFieldType.Field, maxLen: 99, lengthType: LengthType.LlVAR, contentType: ContentTypes.ANS, dataFormat: DataFormats.ASCII)]
		public string ReservedForBillPaymentCenters5P7 { get; set; }

		[IsoField(position: 8, isoFieldType: Enums.IsoFieldType.Field, maxLen: 16, lengthType: LengthType.LlVAR, contentType: ContentTypes.ANS, dataFormat: DataFormats.ASCII)]
		public string ReceiverOrganizationNumberP8 { get; set; }

		[IsoField(position: 9, isoFieldType: Enums.IsoFieldType.Field, maxLen: 99, lengthType: LengthType.LlVAR, contentType: ContentTypes.ANS, dataFormat: DataFormats.ASCII)]
		public string ReservedForBillPaymentCenters6P9 { get; set; }

		[IsoField(position: 10, isoFieldType: Enums.IsoFieldType.Field, maxLen: 99, lengthType: LengthType.LlVAR, contentType: ContentTypes.ANS, dataFormat: DataFormats.ASCII)]
		public string ReservedForBillPaymentCenters7P10 { get; set; }

		[IsoField(position: 11, isoFieldType: Enums.IsoFieldType.Field, maxLen: 99, lengthType: LengthType.LlVAR, contentType: ContentTypes.ANS, dataFormat: DataFormats.ASCII)]
		public string ReservedForBillPaymentCenters8P11 { get; set; }

		[IsoField(position: 12, isoFieldType: Enums.IsoFieldType.Field, maxLen: 99, lengthType: LengthType.LlVAR, contentType: ContentTypes.ANS, dataFormat: DataFormats.ASCII)]
		public string ReservedForBillPaymentCenters9P12 { get; set; }

		[IsoField(position: 13, isoFieldType: Enums.IsoFieldType.Field, maxLen: 99, lengthType: LengthType.LlVAR, contentType: ContentTypes.ANS, dataFormat: DataFormats.ASCII)]
		public string ReservedForBillPaymentCenters10P13 { get; set; }

		[IsoField(position: 14, isoFieldType: Enums.IsoFieldType.Field, maxLen: 99, lengthType: LengthType.LlVAR, contentType: ContentTypes.ANS, dataFormat: DataFormats.ASCII)]
		public string ReservedForBillPaymentCenters11P14 { get; set; }

		[IsoField(position: 15, isoFieldType: Enums.IsoFieldType.Field, maxLen: 99, lengthType: LengthType.LlVAR, contentType: ContentTypes.ANS, dataFormat: DataFormats.ASCII)]
		public string ReservedForBillPaymentCenters12P15 { get; set; }

		[IsoField(position: 16, isoFieldType: Enums.IsoFieldType.SecondaryBitMap, maxLen: 4, lengthType: LengthType.Fixed, contentType: ContentTypes.H, dataFormat: DataFormats.ASCII)]
		public string SecondaryBitMapP16 { get; set; }

		[IsoField(position: 17, isoFieldType: Enums.IsoFieldType.Field, maxLen: 387, lengthType: LengthType.LllVAR, contentType: ContentTypes.ANS, dataFormat: DataFormats.ASCII)]
		public string ReservedForBillPaymentCenters13P17 { get; set; }

		[IsoField(position: 18, isoFieldType: Enums.IsoFieldType.Field, maxLen: 280, lengthType: LengthType.LllVAR, contentType: ContentTypes.ANS, dataFormat: DataFormats.ASCII)]
		public string AdditionalAmountP18 { get; set; }

		[IsoField(position: 19, isoFieldType: Enums.IsoFieldType.Field, maxLen: 8, lengthType: LengthType.LlVAR, contentType: ContentTypes.ANS, dataFormat: DataFormats.ASCII)]
		public string ReservedForBillPaymentCenters14P19 { get; set; }

		public string ReservedForFutureP20 { get; set; }

		public string ReservedForFuture1P21 { get; set; }

		public string ReservedForFuture2P22 { get; set; }

		public string ReservedForFuture3P23 { get; set; }

		public string ReservedForFuture4P24 { get; set; }

		public string ReservedForFuture5P25 { get; set; }

		public string ReservedForFuture6P26 { get; set; }

		public string ReservedForFuture7P27 { get; set; }

		public string ReservedForFuture8P28 { get; set; }

		public string ReservedForFuture9P29 { get; set; }

		public string ReservedForFuture10P30 { get; set; }

		public string ReservedForFuture11P31 { get; set; }

		public string ReservedForFuture12P32 { get; set; }
	}
}
