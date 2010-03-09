using System;
using System.Collections.Generic;

namespace FluentNhibernateSampleApp.Domain
{
    public class Whiskey
    {
        public Whiskey()
        {
        }

        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
        public virtual int Age { get; set; }
        public virtual Money Price { get; set; }
        public virtual string Country { get; set; }
		public virtual string UnMappedProperty {get; set; }
		public virtual Distillary Distillary {get;set;}
		public virtual IList<Pub> Pubs {get;set;}	
    }
}