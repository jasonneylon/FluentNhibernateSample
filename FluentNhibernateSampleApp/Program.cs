using System;
using FluentNhibernateSampleApp.Domain;

namespace FluentNhibernateSampleApp
{
	class Program
	{
		static void Main (string[] args)
		{
			var sessionFactory = NHibernateSessionProvider.CreateSessionFactory();
			var session = sessionFactory.OpenSession ();
			Console.Out.WriteLine ("Saving some whiskey");

            var theMiddletonDistillary = new Distillary("Middleton distillary") { Address = { Town = "Cork" } };
			var jamesons = new Whiskey () {Name = "Jamesons", Price = 17};
			var rare = new Whiskey () {Name = "Middleton rare", Price = 110};
			
			theMiddletonDistillary.AddWhiskey(jamesons);
			theMiddletonDistillary.AddWhiskey(rare);


            var taliskerDistallary = new Distillary("Talisker Distillery") { Address = { Town = "Carbost", Country = "Scotland" } };

            taliskerDistallary.AddWhiskey(new ScotchWhiskey() { Region = Region.Islay});
			
			var theGeorge = new Pub { Name="The George"};
			theGeorge.Whiskies.Add(jamesons);
			theGeorge.Whiskies.Add(rare);
			
			var theVictoria = new Pub { Name="The Victoria"};
			theVictoria.Whiskies.Add(jamesons);
			
			session.Save(theMiddletonDistillary);
		    session.Save(taliskerDistallary);
			
			session.Save (theGeorge);
			session.Flush ();

			var newSession = sessionFactory.OpenSession();			
			var loadedDistillary = newSession.Get<Distillary>(theMiddletonDistillary.Id) as Distillary;

    		sessionFactory.Close ();
		}
	}
	
	
}



