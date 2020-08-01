namespace DynaISO8583.Enums
{
	public enum ContentTypes
	{
		/// <summary>
		/// Alpha, including blanks
		/// </summary>
		A = 1,
		/// <summary>
		/// Numeric values only
		/// </summary>
		N = 2,
		/// <summary>
		/// Special characters only
		/// </summary>
		S = 3,
		/// <summary>
		/// Alphanumeric
		/// </summary>
		AN = 4,
		/// <summary>
		/// Alpha and special characters only
		/// </summary>
		AS = 5,
		/// <summary>
		/// Alphabetic, numeric and special characters
		/// </summary>
		ANS = 6,
		/// <summary>
		/// Binary data
		/// </summary>
		B = 7,
		/// <summary>
		/// Tracks 2 and 3 code set as defined in ISO/IEC 7813 and ISO/IEC 4909 respectively
		/// </summary>
		Z = 6,
		/// <summary>
		/// Persian Data
		/// </summary>
		F = 7,
		/// <summary>
		/// Alphanumeric
		/// </summary>
		AFN = 8,
		/// <summary>
		/// Alpha, Persian and Special characters only
		/// </summary>
		AFS = 9,
		/// <summary>
		/// Alphabetic, Persain. numeric and special characters
		/// </summary>
		AFNS = 10,
		/// <summary>
		/// HexaDecimal characters
		/// </summary>
		H = 11,
	}
}
