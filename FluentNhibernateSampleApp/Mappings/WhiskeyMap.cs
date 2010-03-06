using FluentNHibernate.Mapping;
using FluentNhibernateSampleApp.Domain;

namespace FluentNhibernateSampleApp.Mappings
{
    public class WhiskeyMap : ClassMap<Whiskey>
    {
        public WhiskeyMap()
        {
            Id(x => x.Id).GeneratedBy.GuidComb();
            Map(x => x.Name);
            Map(x => x.Age);
            Map(x => x.Country);
            Map(x => x.Price);
			
    /*        HasMany(x => x.Ingredients)
                .Cascade.All(); */
        }
    }
}