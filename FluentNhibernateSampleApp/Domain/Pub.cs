
using System;
using System.Collections.Generic;

namespace FluentNhibernateSampleApp.Domain
{


	public class Pub
	{

		public Pub ()
		{
			Whiskies = new List<Whiskey>();
		}
		
		public virtual Guid Id {get;set;}
		public virtual string Name {get;set;}
		public virtual IList<Whiskey> Whiskies {get;set;}
		
	}
}
