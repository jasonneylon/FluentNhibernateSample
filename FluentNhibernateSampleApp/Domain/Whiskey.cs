using System;
using System.Collections.Generic;

namespace FluentNhibernateSampleApp.Domain
{
    public class Whiskey
    {
        public Whiskey()
        {
            Ingredients = new List<Whiskey>();
        }

        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
        public virtual int Age { get; set; }
        public virtual decimal Price { get; set; }
        public virtual string Country { get; set; }
		public virtual string UnMappedProperty {get; set; }
		
        public virtual List<Whiskey> Ingredients { get; set; }
    }
}