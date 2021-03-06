﻿using DynaISO8583.Enums;
using System.Reflection;

namespace DynaISO8583.Attributes
{
	public interface IIsoField
	{
		object Value { get; set; }

		IsoFieldType IsoFieldTypes { get; set; }

		int Position { get; set; }

		int MaxLen { get; set; }

		LengthType LengthType { get; set; }

		ContentTypes ContentType { get; set; }

		DataFormats DataFormat { get; set; }

		DataFormats LenDataFormat { get; set; }

		EncodingTypes Encoding { get; set; }

		PropertyInfo PropertyInfo { get; set; }
	}
}
