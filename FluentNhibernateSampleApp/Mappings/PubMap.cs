using  FluentNHibernate.Mapping;
using FluentNhibernateSampleApp.Domain;

namespace FluentNhibernateSampleApp
{
	public class PubMap : ClassMap<Pub>
	{

		public PubMap ()
		{
			Id(x=> x.Id).GeneratedBy.GuidComb();
			Map(x=> x.Name);
            Component(x => x.Address, m =>
            {
                m.Map(x => x.Town);
                m.Map(x => x.Country);
            });

			HasManyToMany(x=> x.Whiskies);
		}
	}
}
