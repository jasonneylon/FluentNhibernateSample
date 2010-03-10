using System;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.AcceptanceCriteria;
using FluentNHibernate.Conventions.Inspections;
using FluentNHibernate.Conventions.Instances;
using NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System.IO;
using FluentNHibernate.Automapping;
using FluentNhibernateSampleApp.Domain;

namespace FluentNhibernateSampleApp
{
	public class NHibernateSessionProvider
	{
		const string DbFile = "Whiskey.db";

	    public static ISessionFactory CreateSessionFactory ()
		{
			// configure SQL Server						
			// MsSqlConfiguration.MsSql2008.ConnectionString("WhiskeyDB")
            // MsSqlConfiguration.MsSql2008.ConnectionString(c=> c.Database("").Server(""));
			// can also do SQLiteConfiguration.Standard.InMemory();

            //var autoMap = AutoMap.AssemblyOf<Whiskey>()
            //    .Where(x => x.Namespace.EndsWith("Domain"))
            //    .Setup(s => s.IsComponentType = t => t == typeof (Address));
            //    .Conventions.Add(new MoneyUserTypeConvention());
            
	        return null;
		}

		private static void BuildSchema (Configuration config)
		{
			// delete the existing db on each run
			if (File.Exists (DbFile))
				File.Delete (DbFile);
			
			// this NHibernate tool takes a configuration (with mapping info in)
			// and exports a database schema from it
			new SchemaExport (config).Create (false, true);
		}

    }
}
