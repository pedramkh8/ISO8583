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
		const char one = '1';
		const char zero = '0';
		const char space = ' ';

		public string Build<TMessage>(TMessage message) where TMessage : new()
		{
			IEnumerable<IIsoField> fieldInfos = GetFieldInfo(message);
			StringBuilder serializedMessage = new StringBuilder();
			string secondaryBitmap = null;
			string bitmap = string.Empty;

			foreach (var field in fieldInfos
										.Where(field => field.Value != null
												|| field.IsoFieldTypes == IsoFieldType.BitMap
												|| field.IsoFieldTypes == IsoFieldType.SecondaryBitMap)
										.OrderBy(field => field.Position))
			{
				switch (field.IsoFieldTypes)
				{
					case IsoFieldType.BitMap:
						(bitmap, secondaryBitmap) = BuildBitmap(fieldInfos);
						field.PropertyInfo.SetValue(message, bitmap);
						serializedMessage.Append(bitmap);
						break;
					case IsoFieldType.Field:
						switch (field.LengthType)
						{
							case LengthType.Fixed:

								if (field.ContentType == ContentTypes.B || field.ContentType == ContentTypes.H || field.ContentType == ContentTypes.N)
								{
									serializedMessage.Append(field.Value.ToString().PadLeft(field.MaxLen, zero));
								}
								else
								{
									serializedMessage.Append(field.Value.ToString().PadRight(field.MaxLen, space));
								}

								break;
							case LengthType.LVar:
							case LengthType.LlVAR:
							case LengthType.LllVAR:
								serializedMessage.Append(GetLengthToFill(field));
								serializedMessage.Append(field.Value);
								break;
							default:
								break;
						}
						break;
					case IsoFieldType.SecondaryBitMap:
						serializedMessage.Append(secondaryBitmap);
						break;
					case IsoFieldType.SubField:
						var value = Build(field.Value);

						switch (field.LengthType)
						{
							case LengthType.Fixed:

								if (field.ContentType == ContentTypes.B || field.ContentType == ContentTypes.H || field.ContentType == ContentTypes.N)
								{
									serializedMessage.Append(value.ToString().PadLeft(field.MaxLen, zero));
								}
								else
								{
									serializedMessage.Append(value.ToString().PadRight(field.MaxLen, space));
								}

								break;
							case LengthType.LVar:
							case LengthType.LlVAR:
							case LengthType.LllVAR:
								serializedMessage.Append(GetSubFieldLengthToFill(field, value));
								serializedMessage.Append(value);
								break;
							default:
								break;
						}

						break;
				}
			}

			return serializedMessage.ToString();
		}

		private static IEnumerable<char> GetSubFieldLengthToFill(IIsoField field, string value)
		{
			string length = value.Length.ToString();

			if (length.Length > (int)field.LengthType)
			{
				throw new Exception($"length: {length} bits are more than desired bits: {(int)field.LengthType} ({field.LengthType})");
			}

			return length.PadLeft((int)field.LengthType, zero).Take((int)field.LengthType).CharsToString();
		}

		private static IEnumerable<char> GetLengthToFill(IIsoField field)
		{
			string length = field.Value.ToString().Length.ToString();

			if (length.Length > (int)field.LengthType)
			{
				throw new Exception($"length: {length} bits are more than desired bits: {(int)field.LengthType} ({field.LengthType})");
			}

			return length.PadLeft((int)field.LengthType, zero).Take((int)field.LengthType).CharsToString();
		}

		public TMessage Parse<TMessage>(string serializedMessage) where TMessage : new()
		{
			int currentPosition = 0;
			object message = new TMessage();
			(message, currentPosition) = ParseMessage(serializedMessage, currentPosition, typeof(TMessage));
			return (TMessage)message;
		}

		#region private Methods
		private static (object, int) ParseMessage(string serializedMessage, int currentPosition, Type type)
		{
			object message = Activator.CreateInstance(type);
			IEnumerable<IIsoField> fieldInfos = GetFieldInfo(message);
			string value = string.Empty;
			object objectValue;
			bool hasMainBitMap = fieldInfos.Any(field => field.IsoFieldTypes == IsoFieldType.BitMap);
			bool hasSecondaryBitmap = fieldInfos.Any(field => field.IsoFieldTypes == IsoFieldType.SecondaryBitMap);
			StringBuilder binaryBitMap = new StringBuilder();

			foreach (IIsoField field in fieldInfos.OrderBy(field => field.Position))
			{
				switch (field.IsoFieldTypes)
				{
					case IsoFieldType.BitMap:
					case IsoFieldType.SecondaryBitMap:
						value = serializedMessage.Skip(currentPosition).Take(field.MaxLen).CharsToString();
						currentPosition += field.MaxLen;
						objectValue = Convert.ChangeType(value, field.PropertyInfo.PropertyType);
						field.PropertyInfo.SetValue(message, objectValue);

						if (field.ContentType == ContentTypes.H)
						{
							binaryBitMap.Append(ConvertHexBinary(value));
						}

						break;
					case IsoFieldType.Field:
					case IsoFieldType.Mti:

						if (hasMainBitMap && field.IsoFieldTypes != IsoFieldType.Mti && (field.Position >= binaryBitMap.Length || field.Position < 1 || binaryBitMap[field.Position - 1] == '0'))
						{
							continue;
						}

						objectValue = GetValue(serializedMessage, ref currentPosition, field);
						field.PropertyInfo.SetValue(message, objectValue);
						break;
					case IsoFieldType.SubField:
						currentPosition += (int)field.LengthType;
						(objectValue, currentPosition) = ParseMessage(serializedMessage, currentPosition, field.PropertyInfo.PropertyType);
						field.PropertyInfo.SetValue(message, objectValue);
						break;
					default:
						break;
				}
			}

			return (message, currentPosition);
		}

		private static object GetValue(string serializedMessage, ref int currentPosition, IIsoField field)
		{
			string value;

			if (field.LengthType == LengthType.Fixed)
			{
				value = serializedMessage.Skip(currentPosition).Take(field.MaxLen).CharsToString();
				currentPosition += field.MaxLen;
				return Convert.ChangeType(value, field.PropertyInfo.PropertyType);
			}

			int length = int.Parse(serializedMessage.Skip(currentPosition).Take((int)field.LengthType).CharsToString());
			currentPosition += (int)field.LengthType;
			value = serializedMessage.Skip(currentPosition).Take(length).CharsToString();
			currentPosition += length;
			return Convert.ChangeType(value, field.PropertyInfo.PropertyType);
		}

		private static (string, string) BuildBitmap(IEnumerable<IIsoField> fieldInfos)
		{
			//bitmap mitone binary, hex bashe bayad fixed bashe. va bayad yeki bashe va hatman bashe.
			//secondarybitmap mitone binary, hex bashe bayad fixed bashe. va bayad yeki ya hichi bashe.
			//har do az samte chap ba 0 gostaresh miaband.
			//bitmap ha fieldhaie bade khodeshhono tosif mikonan na ghabl
			//type bitmap va secondary bitmap bayad yeki bashe
			//bitmap hatman bayad string bashad

			if (fieldInfos is null)
			{
				throw new Exception("Field Info Is Null");
			}

			string hexMainBitmap = string.Empty;
			string hexBitmap = string.Empty;
			string hexSecondaryBitmap = string.Empty;
			string binarySecondaryBitmap = string.Empty;
			string binaryMainBitmap = string.Empty;
			IIsoField bitmap = fieldInfos.Single(field => field.IsoFieldTypes == IsoFieldType.BitMap);
			IIsoField secondaryBitmap = fieldInfos.SingleOrDefault(field => field.IsoFieldTypes == IsoFieldType.SecondaryBitMap);
			int bitmapBitCount = GetBitmapBitCount(bitmap, secondaryBitmap);
			StringBuilder binaryBitmap = new StringBuilder(new string('0', bitmapBitCount));

			foreach (IIsoField item in fieldInfos
											.Where(field => field.Position > bitmap.Position) //BitMap describe all fields after itself.
											.OrderBy(field => field.Position))
			{
				if (item.Value != null)
				{
					binaryBitmap[item.Position - 1] = one;
				}
			}

			bool hasSecondaryBitmap = NeedSecondaryBitMap(bitmap, secondaryBitmap, binaryBitmap);

			if (bitmap.ContentType == ContentTypes.B)
			{
				if (hasSecondaryBitmap)
				{
					binarySecondaryBitmap = binaryBitmap.ToString().Skip(bitmap.MaxLen).Take(secondaryBitmap.MaxLen).CharsToString();
					binaryBitmap[secondaryBitmap.Position - 1] = one;
				}

				binaryMainBitmap = binaryBitmap.ToString().Take(bitmap.MaxLen).CharsToString();

				return (binaryMainBitmap.PadLeft(bitmap.MaxLen, '0'), hasSecondaryBitmap ? binarySecondaryBitmap.PadLeft(secondaryBitmap.MaxLen, '0') : null);
			}
			else if (bitmap.ContentType == ContentTypes.H)
			{
				if (hasSecondaryBitmap)
				{
					binaryBitmap[secondaryBitmap.Position - 1] = one;
				}

				hexBitmap = ConvertBinaryToHex(binaryBitmap.ToString());

				if (hasSecondaryBitmap)
				{
					hexSecondaryBitmap = hexBitmap.Skip(bitmap.MaxLen).Take(secondaryBitmap.MaxLen).CharsToString();
				}

				hexMainBitmap = hexBitmap.Take(bitmap.MaxLen).CharsToString();

				return (hexMainBitmap.PadLeft(bitmap.MaxLen, '0'), hasSecondaryBitmap ? hexSecondaryBitmap.PadLeft(secondaryBitmap.MaxLen, '0') : null);
			}
			else
			{
				throw new Exception("Invalid Bitmap ContentType");
			}
		}

		private static bool NeedSecondaryBitMap(IIsoField bitmap, IIsoField secondaryBitmap, StringBuilder binaryBitmap)
		{
			int mainBitMapBitCount = bitmap.MaxLen * (bitmap.ContentType == ContentTypes.H ? 4 : 1);
			return binaryBitmap.ToString().Skip(mainBitMapBitCount).Contains('1') && secondaryBitmap != null;
		}

		private static int GetBitmapBitCount(IIsoField bitmap, IIsoField secondaryBitmap)
		{
			return bitmap.MaxLen * (bitmap.ContentType == ContentTypes.H ? 4 : 1) +
											(secondaryBitmap?.MaxLen ?? default(int)) * (secondaryBitmap.ContentType == ContentTypes.H ? 4 : 1);
		}

		private static IEnumerable<IIsoField> GetFieldInfo<TMessage>(TMessage messsage) where TMessage : new()
		{
			IEnumerable<PropertyInfo> properties = messsage
														.GetType()
														.GetProperties()
														.Where(prop => prop
																		.GetCustomAttributes()
																		.Any(attr => attr.GetType() == typeof(IsoFieldAttribute)));

			return properties.Select(prop =>
											new IsoField
											{
												ContentType = prop.GetCustomAttribute<IsoFieldAttribute>().ContentType,
												DataFormat = prop.GetCustomAttribute<IsoFieldAttribute>().DataFormat,
												Encoding = prop.GetCustomAttribute<IsoFieldAttribute>().Encoding,
												IsoFieldTypes = prop.GetCustomAttribute<IsoFieldAttribute>().IsoFieldTypes,
												LenDataFormat = prop.GetCustomAttribute<IsoFieldAttribute>().LenDataFormat,
												LengthType = prop.GetCustomAttribute<IsoFieldAttribute>().LengthType,
												MaxLen = prop.GetCustomAttribute<IsoFieldAttribute>().MaxLen,
												Position = prop.GetCustomAttribute<IsoFieldAttribute>().Position,
												Value = prop.GetValue(messsage),
												PropertyInfo = prop
											}
									);
		}

		private static string ConvertHexBinary(string hex)
		{
			return String.Join(String.Empty, hex.Select(c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')));
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
		#endregion
	}
}
