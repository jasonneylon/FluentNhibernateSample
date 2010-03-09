using NUnit.Framework;
using FluentNHibernate.Testing;
using FluentNhibernateSampleApp.Domain;

namespace FluentNhibernateSampleApp
{
	[TestFixture]
	public class WhiskeyMappingTest
	{
        [Test]
		public void CanMapWhiskey()
		{
			var sessionFactory = NHibernateSessionProvider.CreateSessionFactory();
			new PersistenceSpecification<Whiskey>(sessionFactory.OpenSession())
                .CheckProperty(x=> x.Age, 15)
                .CheckProperty(x => x.Name, "Ardbeg")
                    .VerifyTheMappings();
		}
	}
}
