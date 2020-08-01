namespace DynaISO8583.Enums
{
	public enum LengthTypes
	{
		/// <summary>
		/// Fixed length field of six digits
		/// </summary>
		FIXED = 0,
		/// <summary>
		/// LVAR numeric field of up to 6 digits in length
		/// </summary>
		LVAR = 1,
		/// <summary>
		/// LLVAR alpha field of up to 11 characters in length
		/// </summary>
		LLVAR = 2,
		/// <summary>
		/// LLLVAR binary field of up to 999 bits in length
		/// </summary>
		LLLVAR = 3
	}
}
