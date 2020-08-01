using DynaISO8583;

namespace Test
{
	class Program
	{
		static void Main(string[] args)
		{
			var t = new Message
			{
				MTI = "0100",
				P1 = "dsfd",
				P2 = 3453
			};

			new Iso8583().Build(t);
		}
	}
}
