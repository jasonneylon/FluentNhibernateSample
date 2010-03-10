using System;
using FluentNhibernateSampleApp.Domain;

namespace FluentNhibernateSampleApp
{
	class Program
	{
		static void Main (string[] args)
		{
			var sessionFactory = NHibernateSessionProvider.CreateSessionFactory();
			var session = sessionFactory.OpenSession();
            
            Console.Out.WriteLine ("Saving some whiskey");

            session.Flush();
		}
	}
	
	
}



