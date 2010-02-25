using System.Collections.Generic;

namespace FluentNhibernateSampleApp.Domain
{
    public class Whiskey
    {
        public Whiskey()
        {
            Ingredients = new List<Whiskey>();
        }
		
        public string Name { get; set; }
        public int Age { get; set; }
        public decimal Price { get; set; }
        public string Country { get; set; }
		
        public List<Whiskey> Ingredients {get; set;}
    }
}