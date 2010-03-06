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
			
			var theMiddletonDistillary = new Distillary() { Name = "Middleton distillary"};
			var jamesons = new Whiskey () {Name = "Jamesons"};
			
			theMiddletonDistillary.AddWhiskey(jamesons);
			
			var theGeorge = new Pub { Name="The George"};
						
			
			theGeorge.Whiskies.Add(jamesons);
			
			session.Save(theMiddletonDistillary);
			
			session.Save (theGeorge);
			session.Flush ();

			
			
			
			
			
			sessionFactory.Close ();
		}
	}
	
	
}



