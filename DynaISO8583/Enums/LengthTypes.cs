namespace DynaISO8583.Enums
{
	public enum LengthType
	{
		/// <summary>
		/// Fixed length field of six digits
		/// </summary>
		Fixed = 0,
		/// <summary>
		/// LVAR numeric field of up to 6 digits in length
		/// </summary>
		LVar = 1,
		/// <summary>
		/// LLVAR alpha field of up to 11 characters in length
		/// </summary>
		LlVAR = 2,
		/// <summary>
		/// LLLVAR binary field of up to 999 bits in length
		/// </summary>
		LllVAR = 3
	}
}
