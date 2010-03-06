using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using FluentNhibernateSampleApp.Domain;
using System.Reflection;
using System.Data;
using Mono.Data.Sqlite;

namespace FluentNhibernateSampleApp
{
	class Program
	{

		static void Main (string[] args)
		{
			var sessionFactory = NHibernateSessionProvider.CreateSessionFactory();
			var session = sessionFactory.OpenSession ();
			Console.Out.WriteLine ("Saving some whiskey");
			
			var theMiddletonDistillary = new Distillary() { Name = "Middleton distillary", Address = {Town = "Cork"}};
			var jamesons = new Whiskey () {Name = "Jamesons"};
			var rare = new Whiskey () {Name = "Middleton rare"};
			
			theMiddletonDistillary.AddWhiskey(jamesons);
			theMiddletonDistillary.AddWhiskey(rare);			
			var theGeorge = new Pub { Name="The George"};
			theGeorge.Whiskies.Add(jamesons);
			theGeorge.Whiskies.Add(rare);
			var theVictoria = new Pub { Name="The Victoria"};
			theVictoria.Whiskies.Add(jamesons);
			
			session.Save(theMiddletonDistillary);
			
			session.Save (theGeorge);
			session.Flush ();

			var newSession = sessionFactory.OpenSession();			
			var loadedDistillary = newSession.Get<Distillary>(theMiddletonDistillary.Id) as Distillary;
			Console.Out.WriteLine(loadedDistillary.Address.Town);
			
			
			sessionFactory.Close ();
		}
	}
	
	
}



