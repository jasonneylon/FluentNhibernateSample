
using System;
using System.Collections.Generic;
using FluentNhibernateSampleApp.Domain;

namespace FluentNhibernateSampleApp.Domain
{


	public class Distillary
	{

		
		public Distillary ()
		{
			Whiskies = new HashSet<Whiskey>();
			Address = new Address();
		}
		
		public virtual void AddWhiskey(Whiskey whiskey)
		{
			whiskey.Distillary = this;
			Whiskies.Add(whiskey);
		}
		
		public virtual Guid Id {get;set;}
		public virtual string Name { get;set;}
		public virtual ICollection<Whiskey> Whiskies {get;set;}
		public virtual Address Address {get;set;}
	}
}
