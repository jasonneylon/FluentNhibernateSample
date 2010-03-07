
using System;

namespace FluentNhibernateSampleApp.Domain
{


	public class Address
	{

		public Address ()
		{
		}
		
		
		public virtual string Town {get;set;}
		public virtual string Country {get;set;}
	}
}
