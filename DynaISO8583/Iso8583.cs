using DynaISO8583.Attributes;
using DynaISO8583.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DynaISO8583
{
	public class Iso8583 : IIso8583
	{
		const int fieldCount = 128;
		public string Build<TMessage>(TMessage message, StringBuilder serializedMessage = null) where TMessage : new()
		{
			Dictionary<PropertyInfo, IIsoField> fieldInfos = GetFieldInfo(message);
			//int currentPosition = 0;
			serializedMessage = serializedMessage ?? new StringBuilder();
			string secondaryBitmap = null;
			string bitmap = string.Empty;

			foreach (var field in fieldInfos.OrderBy(field => field.Value.Position))
			{
				switch (field.Value.IsoFieldTypes)
				{
					case IsoFieldTypes.BITMAP:
						(bitmap, secondaryBitmap) = BuildBitmap(fieldInfos.Values);
						field.Key.SetValue(message, bitmap);
						//shoud set secondary bitmap also
						serializedMessage.Append(bitmap);
						//currentPosition += bitmap.Length;
						break;
					case IsoFieldTypes.FIELD:
						switch (field.Value.LengthType)
						{
							case LengthTypes.FIXED:
								if (field.Value.ContentType == ContentTypes.B || field.Value.ContentType == ContentTypes.H || field.Value.ContentType == ContentTypes.N)
								{
									serializedMessage.Append(field.Value.Value.ToString().PadLeft(field.Value.MaxLen, '0'));
								}
								else
								{
									serializedMessage.Append(field.Value.Value.ToString().PadRight(field.Value.MaxLen, ' '));
								}
								break;
							case LengthTypes.LVAR:
								serializedMessage.Append(field.Value.Value.ToString().Length.ToString().Substring(0, (int)LengthTypes.LVAR));
								serializedMessage.Append(field.Value.Value);
								break;
							case LengthTypes.LLVAR:
								serializedMessage.Append(field.Value.Value.ToString().Length.ToString().Substring(0, (int)LengthTypes.LLVAR));
								serializedMessage.Append(field.Value.Value);
								break;
							case LengthTypes.LLLVAR:
								serializedMessage.Append(field.Value.Value.ToString().Length.ToString().Substring(0, (int)LengthTypes.LLLVAR));
								serializedMessage.Append(field.Value.Value);
								break;
							default:
								break;
						}
						break;
					case IsoFieldTypes.SECONDARYBITMAP:
						serializedMessage.Append(secondaryBitmap);
						break;
					case IsoFieldTypes.SUBFIELD:
						Build(field.Value.Value, serializedMessage);
						break;
				}
			}

			return serializedMessage.ToString();
		}

		private static (string, string) BuildBitmap(IEnumerable<IIsoField> fieldInfos)
		{
			//bitmap mitone binary, hex bashe bayad fixed bashe. va bayad yeki bashe va hatman bashe.
			//secondarybitmap mitone binary, hex bashe bayad fixed bashe. va bayad yeki ya hichi bashe.
			//har do az samte chap ba 0 gostaresh miaband.

			StringBuilder binaryBitmap = new StringBuilder(new string('0', fieldCount));
			string hexBitmap = string.Empty;
			string hexSecondaryBitmap = string.Empty;
			string binarySecondaryBitmap = string.Empty;
			IIsoField bitmap = fieldInfos.Single(field => field.IsoFieldTypes == IsoFieldTypes.BITMAP);
			IIsoField secondaryBitmap = fieldInfos.SingleOrDefault(field => field.IsoFieldTypes == IsoFieldTypes.SECONDARYBITMAP);

			foreach (IIsoField item in fieldInfos.Where(field => field.Position > bitmap.Position).OrderBy(field => field.Position))
			{
				if (item.Value != null)
				{
					binaryBitmap[item.Position] = '1';
				}
			}

			if (bitmap.ContentType == ContentTypes.B)
			{
				if (binaryBitmap.Length > bitmap.MaxLen && secondaryBitmap != null)
				{
					binarySecondaryBitmap = binaryBitmap.ToString().Substring(bitmap.MaxLen - 1, secondaryBitmap.MaxLen);
					binaryBitmap = new StringBuilder(binaryBitmap.ToString().Substring(0, bitmap.MaxLen));
				}

				return (binaryBitmap.ToString().PadLeft(bitmap.MaxLen, '0'), secondaryBitmap != null ? binarySecondaryBitmap.PadLeft(secondaryBitmap.MaxLen, '0') : null);
			}
			else
			if (bitmap.ContentType == ContentTypes.H)
			{
				hexBitmap = ConvertBinaryToHex(binaryBitmap.ToString());

				if (hexBitmap.Length > bitmap.MaxLen && secondaryBitmap != null)
				{
					hexSecondaryBitmap = hexBitmap.Substring(bitmap.MaxLen - 1, secondaryBitmap.MaxLen);
					hexBitmap = hexBitmap.Substring(0, bitmap.MaxLen);
				}

				return (hexBitmap.PadLeft(bitmap.MaxLen, '0'), secondaryBitmap != null ? hexSecondaryBitmap.PadLeft(secondaryBitmap.MaxLen, '0') : null);
			}
			else
			{
				throw new Exception("Invalid Bitmap ContentType");
			}
		}

		private static Dictionary<PropertyInfo, IIsoField> GetFieldInfo<TMessage>(TMessage messsage) where TMessage : new()
		{
			IEnumerable<PropertyInfo> properties = messsage
														.GetType()
														.GetProperties()
														.Where(prop => prop
																		.GetCustomAttributes()
																		.Any(attr => attr.GetType() == typeof(IsoFieldAttribute)));
			var result = new Dictionary<PropertyInfo, IIsoField>();

			foreach (var prop in properties)
			{
				result.Add(prop, new IsoField
				{
					ContentType = prop.GetCustomAttribute<IsoFieldAttribute>().ContentType,
					DataFormat = prop.GetCustomAttribute<IsoFieldAttribute>().DataFormat,
					Encoding = prop.GetCustomAttribute<IsoFieldAttribute>().Encoding,
					IsoFieldTypes = prop.GetCustomAttribute<IsoFieldAttribute>().IsoFieldTypes,
					LenDataFormat = prop.GetCustomAttribute<IsoFieldAttribute>().LenDataFormat,
					LengthType = prop.GetCustomAttribute<IsoFieldAttribute>().LengthType,
					MaxLen = prop.GetCustomAttribute<IsoFieldAttribute>().MaxLen,
					Position = prop.GetCustomAttribute<IsoFieldAttribute>().Position,
					Value = prop.GetValue(messsage)
				});
			};

			return result;
		}

		private static string ConvertBinaryToHex1(string binary)
		{
			return Convert.ToUInt64(binary, 2).ToString("X");
		}

		public static string ConvertBinaryToHex(string binary)
		{
			int hexLength = binary.Length / 4;
			if (string.IsNullOrEmpty(binary))
			{
				return binary;
			}

			StringBuilder result = new StringBuilder(binary.Length / 8 + 1);

			// TODO: check all 1's or 0's... throw otherwise

			int mod4Len = binary.Length % 8;
			if (mod4Len != 0)
			{
				// pad to length multiple of 8
				binary = binary.PadLeft(((binary.Length / 8) + 1) * 8, '0');
			}

			for (int i = 0; i < binary.Length; i += 8)
			{
				string eightBits = binary.Substring(i, 8);
				result.AppendFormat("{0:X2}", Convert.ToByte(eightBits, 2));
			}

			return result.ToString().PadLeft(hexLength, '0');
		}
	}
}
