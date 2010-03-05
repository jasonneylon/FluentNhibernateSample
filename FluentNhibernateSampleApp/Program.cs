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

namespace FluentNhibernateSampleApp
{
    class Program
    {
        const string DbFile = "Whiskey.db";

        static void Main(string[] args)
        {
            var sessionFactory = CreateSessionFactory();
			var session = sessionFactory.OpenSession();
            session.Save(new Whiskey());
			sessionFactory.Close();
        }

        private static ISessionFactory CreateSessionFactory()
        {
			// configure SQL Server						
			//MsSqlConfiguration.MsSql2008.ConnectionString("WhiskeyDB")
//			MsSqlConfiguration.MsSql2008.ConnectionString(c=> c.Database("").Server(""));
			// can also do SQLiteConfiguration.Standard.InMemory();
            return Fluently.Configure()
                .Database(SQLiteConfiguration.Standard.UsingFile(DbFile).ShowSql())
				.Mappings(m =>
                    m.FluentMappings.AddFromAssemblyOf<Program>())
                .ExposeConfiguration(BuildSchema)
                .BuildSessionFactory();
        }

        private static void BuildSchema(Configuration config)
        {
            // delete the existing db on each run
            if (File.Exists(DbFile))
                File.Delete(DbFile);

            // this NHibernate tool takes a configuration (with mapping info in)
            // and exports a database schema from it
            new SchemaExport(config)
                .Create(false, true);
        }

    }
}
