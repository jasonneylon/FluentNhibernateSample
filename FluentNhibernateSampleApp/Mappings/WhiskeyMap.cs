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
		//	Map(x => x.Price).CustomType<MoneyUserType>();
			References(x=> x.Distillary);
			HasManyToMany(x=> x.Pubs);
        }
    }
}