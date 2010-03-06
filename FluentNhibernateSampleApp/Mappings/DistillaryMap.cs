
using System;
using FluentNHibernate.Mapping;
using FluentNhibernateSampleApp.Domain;

namespace FluentNhibernateSampleApp
{


	public class DistillaryMap : ClassMap<Distillary>
	{

		public DistillaryMap ()
		{
			Id(x=> x.Id).GeneratedBy.GuidComb();
			Map(x=> x.Name);
			HasMany(x=> x.Whiskies).AsSet().Cascade.All().Inverse();
		}
	}
}