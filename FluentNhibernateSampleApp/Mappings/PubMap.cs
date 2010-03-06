
using System;
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
			HasMany(x=> x.Whiskies);
		}
	}
}
