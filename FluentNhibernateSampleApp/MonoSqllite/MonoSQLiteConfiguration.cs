
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
using Mono.Data.Sqlite;

namespace FluentNhibernateSampleApp
{
public class MonoSQLiteConfiguration : SQLiteConfiguration
    {
        public static new MonoSQLiteConfiguration Standard
        {
            get { return new MonoSQLiteConfiguration(); }
        }


        public MonoSQLiteConfiguration()
        {
            Driver<MonoSqliteDriver>();
        }
    }
}
