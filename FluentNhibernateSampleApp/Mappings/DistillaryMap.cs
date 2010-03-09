using FluentNHibernate.Mapping;
using FluentNhibernateSampleApp.Domain;

namespace FluentNhibernateSampleApp
{
    public class DistillaryMap : ClassMap<Distillary>
	{

		public DistillaryMap ()
		{
			Id(x=> x.Id).GeneratedBy.GuidComb();
			Map(x=> x.Name).Column("NICKNAME").Access.CamelCaseField(Prefix.Underscore);
			HasMany(x=> x.Whiskies).AsSet().Cascade.All();
			Component(x=> x.Address, m => {
				m.Map(x=> x.Town);
				m.Map(x=> x.Country);
			});
		}
	}
}
