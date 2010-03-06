
using System;
using NUnit.Framework;
using FluentNHibernate.Testing;
using FluentNhibernateSampleApp.Domain;


namespace FluentNhibernateSampleApp
{


	[TestFixture()]
	public class WhiskeyMappingTest
	{

		[Test()]
		public void CanMapWhiskey()
		{
			var sessionFactory = NHibernateSessionProvider.CreateSessionFactory();
			new PersistenceSpecification<Whiskey>(sessionFactory.OpenSession())
				.CheckProperty(x=> x.Name, "Ardbeg")
				.CheckProperty(x=> x.UnMappedProperty, "whatever")
					.VerifyTheMappings();
		}
	}
}
