
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
namespace FluentNhibernateSampleApp
{

public class MonoSqliteDriver : NHibernate.Driver.ReflectionBasedDriver
{
    public MonoSqliteDriver() : 
        base("Mono.Data.Sqlite",
        "Mono.Data.Sqlite.SqliteConnection",
        "Mono.Data.Sqlite.SqliteCommand")
    {
    }
    public override bool UseNamedPrefixInParameter {
        get {
            return true;
        }
    }
    public override bool UseNamedPrefixInSql {
        get {
            return true;
        }
    }
    public override string NamedPrefix {
        get {
            return "@";
        }
    }
    public override bool SupportsMultipleOpenReaders {
        get {
            return false;
        }
    }
}
}