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
			session.Save (new Whiskey ());
			session.Flush ();
			sessionFactory.Close ();
		}
	}
	
	
}



