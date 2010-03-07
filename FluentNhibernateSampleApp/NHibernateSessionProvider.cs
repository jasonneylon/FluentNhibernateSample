
using System;
using NHibernate;
using FluentNHibernate;
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

		public NHibernateSessionProvider ()
		{
		}
		
		public static ISessionFactory CreateSessionFactory ()
		{
			// configure SQL Server						
			//MsSqlConfiguration.MsSql2008.ConnectionString("WhiskeyDB")
//			MsSqlConfiguration.MsSql2008.ConnectionString(c=> c.Database("").Server(""));
			// can also do SQLiteConfiguration.Standard.InMemory();
			
			var databaseConfig = SQLiteConfiguration.Standard.UsingFile (DbFile).ShowSql ();
			
			Type monoRuntimeType = Type.GetType ("Mono.Runtime");
			if (monoRuntimeType != null) {
				databaseConfig = MonoSQLiteConfiguration.Standard.UsingFile (DbFile).ShowSql();
				Console.WriteLine ("You are running with the Mono VM");
			} 
			
			var autoMap = AutoMap.AssemblyOf<Whiskey>()
				.Where(c => c.Namespace.EndsWith("Domain"))
				.Setup(s => s.IsComponentType = t => t == typeof(Address))
					.Override<Distillary>(m => m.HasMany(x=> x.Whiskies).AsSet().Inverse().Cascade.All());
			
			return Fluently.Configure ()
				.Database (databaseConfig)
					//.Mappings(m => m.AutoMappings.Add(autoMap))
					//.Mappings(m=> m.AutoMappings.ExportTo(Directory.GetCurrentDirectory ()))
					.Mappings (m => m.FluentMappings.AddFromAssemblyOf<Program> ())
					.Mappings (m => m.FluentMappings.ExportTo (Directory.GetCurrentDirectory ()))
					.ExposeConfiguration (BuildSchema)
					.BuildSessionFactory ();
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
