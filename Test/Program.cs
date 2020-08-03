using DynaISO8583;
using DynaISO8583.Messages;

namespace Test
{
	class Program
	{
		static void Main(string[] args)
		{
			TopupResponse0100 topupResponse0100 = new TopupResponse0100
			{
				MTI = 100,
				MainAccountNumberP2 = "6037691000010561",
				ProcessTransactionCodeP3 = "192000",
				TransactionAmountP4 = "000000054500",
				TraceTransactionCodeP11 = "069982",
				TransactionTimeP12 = "154415",
				TransactionDateP13 = "0727",
				TransactionRecievedDateP17 = "0727",
				TerminalStatusP25 = "02",
				SenderCodeP32 = "603769",
				SenderCode2P33 = "603769",
				TransactionRetrieverReferenceCodeP37 = "069920856655",
				TerminalCodeP41 = "00060699",
				ReceiverCodeP100 = "950500",
				DedicatedExtendedDataP48 = new DedicatedExtendedData48
				{
					ReservedForFutureP1 = "      ",
					LanguageCodeP2 = "01",//English
					OrganizationCodeP4 = "0935",
					ExtraDataP6 = "2007",
					BankCodeP8 = "019",
					BillNumberP10 = "0100009359351985082208",
					ReservedForFutureP11 = "     ATM                                   1",
					ReservedForFutureP5 = "01",
					ReservedForFutureP7 = "  2",
					ReservedForPaymentCenterP3 = "      04UD02",
					ReservedForFutureP9 = "      "
				},
				DedicatedExtendedDataP121 = new DedicatedExtendedData121
				{
					EnglishReceiptP3 = "",
					ReceiverOrganizationNumberP8 = "9399290935",
					ReservedForBillPaymentCenters11P14 = "0",
					ReservedForBillPaymentCenters12P15 = "0",
					ReservedForBillPaymentCenters7P10 = "74AE7DE4A7DEE4C8",
					ReservedForBillPaymentCentersP1 = "Topup Irancell"
				},
			};

			new Iso8583().Build(topupResponse0100);


			TopupResponse0110 topupResponse0110 = new TopupResponse0110
			{
				MTI = 0110,
				MainAccountNumberP2 = "6037691000010561",
				ProcessTransactionCodeP3 = "192000",
				ReceiverCodeP100 = "950500",
				SenderCodeP32 = "603769",
				TerminalCodeP41 = "00060699",
				TraceTransactionCodeP11 = "069982",
				TransactionAmountP4 = "000000054500",
				TransactionDateP13 = "0727",
				TransactionResponseCodeP39 = "00",
				TransactionTimeP12 = "154415",
				DedicatedExtendedDataP48 = new DedicatedExtendedData48
				{
					ReservedForFutureP1 = "      ",
					LanguageCodeP2 = "01",
					ReservedForPaymentCenterP3 = "      04UD02",
					OrganizationCodeP4 = "0935",
					ReservedForFutureP5 = "01",
					ExtraDataP6 = "2007",
					ReservedForFutureP7 = "  2",
					BankCodeP8 = "019",
					ReservedForFutureP9 = "      ",
					BillNumberP10 = "0100009359351985082208",
					ReservedForFutureP11 = "     ATM                                   1",

				},
				DedicatedExtendedDataP121 = new DedicatedExtendedData121
				{
					ReservedForBillPaymentCentersP1 = "Topup Irancell",
					EnglishReceiptP3 = "^06Result~037Your requested completed successfully",
					ReceiverOrganizationNumberP8 = "9399290935",
					ReservedForBillPaymentCenters11P14 = "0",
					ReservedForBillPaymentCenters12P15 = "0",
					ReservedForBillPaymentCenters7P10 = "74AE7DE4A7DEE4C8",
				},
			};

			var y = new Iso8583().Build(topupResponse0110);


			TopupPaymentAnnouncementRequest0220 topupPaymentAnnouncementRequest0220 = new TopupPaymentAnnouncementRequest0220
			{
				MTI = 220,
				MainAccountNumberP2 = "6037691000010561",
				ProcessTransactionCodeP3 = "172000",
				TransactionAmountP4 = "000000054500",
				TraceTransactionCodeP11 = "069982",
				TransactionTimeP12 = "154415",
				TransactionDateP13 = "0727",
				TransactionRecievedDateP17 = "0727",
				TerminalStatusP25 = "02",
				SenderCodeP32 = "603769",
				SenderCode2P33 = "603769",
				TransactionRetrieverReferenceCodeP37 = "069920856655",
				TerminalCodeP41 = "00060699",
				DedicatedExtendedDataP48 = new DedicatedExtendedData48For0220
				{
					BankCode8 = "019",
					BillNumber10 = "0100009359351985082208",
					ExtraData6 = "2007",
					LanguageCode2 = "01",
					OrganizationCode4 = "0935",
					ReservedForFuture1 = "      ",
					ReservedForFuture11 = "     ATM",
					ReservedForFuture12 = "                   1",
					ReservedForFuture5 = "01",
					ReservedForFuture7 = "  2",
					ReservedForFuture9 = "      ",
					ReservedForPaymentCenter2 = "      04UD02",
					TransmitDataReceiverToOperator = "0011243155      "
				},
				ReceiverCodeP100 = "950500",
				DedicatedExtendedDataP121 = new DedicatedExtendedData121
				{
					ReservedForBillPaymentCentersP1 = "Topup Irancell",
					EnglishReceiptP3 = "",
					ReceiverOrganizationNumberP8 = "9399290935",
					ReservedForBillPaymentCenters7P10 = "74AE7DE4A7DEE4C8",
					ReservedForBillPaymentCenters11P14 = "0",
					ReservedForBillPaymentCenters12P15 = "0",
				},
			};

			var dd = new Iso8583().Build(topupPaymentAnnouncementRequest0220);


			TopupPaymentAnnouncementResponse0230 topupPaymentAnnouncementResponse0230 = new TopupPaymentAnnouncementResponse0230
			{
				MTI=230,
				MainAccountNumberP2 = "6037691000010561",
				ProcessTransactionCodeP3 = "172000",
				TransactionAmountP4 = "000000054500",
				TraceTransactionCodeP11 = "069982",
				TransactionTimeP12 = "154415",
				TransactionDateP13 = "0727",
				SenderCodeP32 = "603769",
				TransactionResponseCodeP39 = "00",
				TerminalCodeP41 = "00060699",
				ReceiverCodeP100 = "950500",
				DedicatedExtendedDataP121 = new DedicatedExtendedData121
				{
					ReservedForBillPaymentCentersP1 = "Topup Irancell",
					EnglishReceiptP3 = "^06Result~037Your requested completed successfully",
					ReceiverOrganizationNumberP8 = "9399290935",
					ReservedForBillPaymentCenters7P10 = "74AE7DE4A7DEE4C8",
					ReservedForBillPaymentCenters11P14 = "0",
					ReservedForBillPaymentCenters12P15 = "0",
				},
			};

			var tt = new Iso8583().Build(topupPaymentAnnouncementResponse0230);


			string message100 = "0100F03880818881000000000000100000801660376910000105611920000000000545000699821544150727072702066037690660376906992085665500060699108      01      04UD020935012007  2019      0100009359351985082208     ATM                                   106950500058A14614Topup Irancell001093992909351674AE7DE4A7DEE4C8010010";
			string message110 = "0110F03800010281000000000000100000801660376910000105611920000000000545000699821544150727066037690000060699108      01      04UD020935012007  2019      0100009359351985082208     ATM                                   106950500108A14614Topup Irancell50^06Result~037Your requested completed successfully1093992909351674AE7DE4A7DEE4C8010010";
			string message220 = "0220F03880818881000000000000100000801660376910000105611720000000000545000699821544150727072702066037690660376906992085665500060699108      01      04UD020935012007  2019      0100009359351985082208     ATM0011243155                         106950500058A14614Topup Irancell001093992909351674AE7DE4A7DEE4C8010010";
			string message230 = "0230F0380001028000000000000010000080166037691000010561172000000000054500069982154415072706603769000006069906950500108A14614Topup Irancell50^06Result~037Your requested completed successfully1093992909351674AE7DE4A7DEE4C8010010";

			var uu = new Iso8583().Parse<TopupResponse0100>(message100);
			var qq = new Iso8583().Parse<TopupResponse0110>(message110);
			var ww = new Iso8583().Parse<TopupPaymentAnnouncementRequest0220>(message220);
			var ee = new Iso8583().Parse<TopupPaymentAnnouncementResponse0230>(message230);
		}
	}
}
