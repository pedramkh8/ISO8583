using DynaISO8583.Attributes;
using DynaISO8583.Enums;

namespace DynaISO8583.Messages
{
	public class TopupPaymentAnnouncementRequest0220 
	{
		[IsoField(position: -1, isoFieldType: Enums.IsoFieldType.Mti, maxLen: 4, lengthType: LengthType.Fixed, contentType: ContentTypes.N)]
		public int MTI { get; set; }

		[IsoField(position: 0, isoFieldType: Enums.IsoFieldType.BitMap, maxLen: 16, lengthType: LengthType.Fixed, contentType: ContentTypes.H)]
		public string MainBitmap { get; set; }

		[IsoField(position: 1, isoFieldType: Enums.IsoFieldType.SecondaryBitMap, maxLen: 16, lengthType: LengthType.Fixed, contentType: ContentTypes.H)]
		public string SecondaryBitMapP1 { get; set; }

		[IsoField(position: 2, isoFieldType: Enums.IsoFieldType.Field, maxLen: 19, lengthType: LengthType.LlVAR, contentType: ContentTypes.N)]
		public string MainAccountNumberP2 { get; set; }

		[IsoField(position: 3, isoFieldType: Enums.IsoFieldType.Field, maxLen: 6, lengthType: LengthType.Fixed, contentType: ContentTypes.N)]
		public string ProcessTransactionCodeP3 { get; set; }

		[IsoField(position: 4, isoFieldType: Enums.IsoFieldType.Field, maxLen: 12, lengthType: LengthType.Fixed, contentType: ContentTypes.N)]
		public string TransactionAmountP4 { get; set; }

		[IsoField(position: 11, isoFieldType: Enums.IsoFieldType.Field, maxLen: 6, lengthType: LengthType.Fixed, contentType: ContentTypes.N)]
		public string TraceTransactionCodeP11 { get; set; }

		[IsoField(position: 12, isoFieldType: Enums.IsoFieldType.Field, maxLen: 6, lengthType: LengthType.Fixed, contentType: ContentTypes.N)]
		public string TransactionTimeP12 { get; set; }

		[IsoField(position: 13, isoFieldType: Enums.IsoFieldType.Field, maxLen: 4, lengthType: LengthType.Fixed, contentType: ContentTypes.N)]
		public string TransactionDateP13 { get; set; }

		[IsoField(position: 17, isoFieldType: Enums.IsoFieldType.Field, maxLen: 4, lengthType: LengthType.Fixed, contentType: ContentTypes.N)]
		public string TransactionRecievedDateP17 { get; set; }

		[IsoField(position: 25, isoFieldType: Enums.IsoFieldType.Field, maxLen: 2, lengthType: LengthType.Fixed, contentType: ContentTypes.N)]
		public string TerminalStatusP25 { get; set; }

		[IsoField(position: 32, isoFieldType: Enums.IsoFieldType.Field, maxLen: 11, lengthType: LengthType.LlVAR, contentType: ContentTypes.N)]
		public string SenderCodeP32 { get; set; }

		[IsoField(position: 33, isoFieldType: Enums.IsoFieldType.Field, maxLen: 11, lengthType: LengthType.LlVAR, contentType: ContentTypes.N)]
		public string SenderCode2P33 { get; set; }

		[IsoField(position: 37, isoFieldType: Enums.IsoFieldType.Field, maxLen: 12, lengthType: LengthType.Fixed, contentType: ContentTypes.AN)]
		public string TransactionRetrieverReferenceCodeP37 { get; set; }

		[IsoField(position: 41, isoFieldType: Enums.IsoFieldType.Field, maxLen: 8, lengthType: LengthType.Fixed, contentType: ContentTypes.ANS)]
		public string TerminalCodeP41 { get; set; }

		[IsoField(position: 48, isoFieldType: Enums.IsoFieldType.SubField, maxLen: 999, lengthType: LengthType.LllVAR, contentType: ContentTypes.ANS)]
		public DedicatedExtendedData48For0220 DedicatedExtendedDataP48 { get; set; }

		[IsoField(position: 100, isoFieldType: Enums.IsoFieldType.Field, maxLen: 11, lengthType: LengthType.LlVAR, contentType: ContentTypes.N)]
		public string ReceiverCodeP100 { get; set; }

		[IsoField(position: 121, isoFieldType: Enums.IsoFieldType.SubField, maxLen: 999, lengthType: LengthType.LllVAR, contentType: ContentTypes.ANS)]
		public DedicatedExtendedData121 DedicatedExtendedDataP121 { get; set; }

	}

}
