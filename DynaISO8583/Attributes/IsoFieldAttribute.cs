using DynaISO8583.Enums;
using System;

namespace DynaISO8583.Attributes
{
	[AttributeUsage(validOn: AttributeTargets.Property, Inherited = false)]
	public sealed class IsoFieldAttribute : Attribute, IIsoFieldAttribute
	{
		public IsoFieldAttribute(int position, IsoFieldType isoFieldType, int maxLen, LengthType lengthType,
								ContentTypes contentType, DataFormats dataFormat = DataFormats.ASCII,
								DataFormats lenDataFormat = DataFormats.ASCII, EncodingTypes encoding = EncodingTypes.None)
		{
			Position = position;
			MaxLen = maxLen;
			LengthType = lengthType;
			ContentType = contentType;
			DataFormat = dataFormat;
			LenDataFormat = lenDataFormat;
			Encoding = encoding;
			IsoFieldTypes = isoFieldType;
		}

		public IsoFieldType IsoFieldTypes { get; set; }

		public int Position { get; set; }

		public int MaxLen { get; set; }

		public LengthType LengthType { get; set; }

		public ContentTypes ContentType { get; set; }

		public DataFormats DataFormat { get; set; }

		public DataFormats LenDataFormat { get; set; }

		public EncodingTypes Encoding { get; set; }
	}
}
