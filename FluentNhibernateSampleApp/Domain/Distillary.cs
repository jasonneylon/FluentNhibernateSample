
using System;
using System.Collections.Generic;
using FluentNhibernateSampleApp.Domain;

namespace FluentNhibernateSampleApp.Domain
{


	public class Distillary
	{

        public Distillary(string name) : this()
        {
            _name = name;
        }


	    protected Distillary ()
		{
			Whiskies = new List<Whiskey>();
			Address = new Address();
		}
		
		public virtual void AddWhiskey(Whiskey whiskey)
		{
			whiskey.Distillary = this;
			Whiskies.Add(whiskey);
		}
		
		public virtual Guid Id {get;set;}
	    private string _name;
	    public virtual string Name
	    {
	        get { return _name; }
	    }

	    public virtual IList<Whiskey> Whiskies {get;set;}
		public virtual Address Address {get;set;}
	}
}
