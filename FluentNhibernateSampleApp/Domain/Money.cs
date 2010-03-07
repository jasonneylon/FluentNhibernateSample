
using System;

namespace FluentNhibernateSampleApp
{


	public class Money
	{

		public Money ()
		{
		}
		
public Money (decimal value)
		{
			Value = value;
		}

		public decimal? Value {get;set;}
	}
}
