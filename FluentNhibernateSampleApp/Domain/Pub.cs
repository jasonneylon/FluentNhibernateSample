
using System;
using System.Collections.Generic;

namespace FluentNhibernateSampleApp.Domain
{
	public class Pub
	{
		public Pub ()
		{
			Whiskies = new List<Whiskey>();
            Address = new Address();
        }
		
		public virtual Guid Id {get;set;}
		public virtual string Name {get;set;}
		public virtual IList<Whiskey> Whiskies {get;set;}
        public virtual Address Address { get; set; }

	}
}
