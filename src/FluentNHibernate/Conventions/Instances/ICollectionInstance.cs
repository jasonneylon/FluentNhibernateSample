using System;
using System.Diagnostics;
using System.Reflection;
using FluentNHibernate.Conventions.Inspections;
using NHibernate.Persister.Entity;

namespace FluentNHibernate.Conventions.Instances
{
    public interface ICollectionInstance : ICollectionInspector
    {
        new IKeyInstance Key { get; }
        new IRelationshipInstance Relationship { get; }
        void Table(string tableName);
        new void Name(string name);
        new void Schema(string schema);
        new void LazyLoad();
        new void BatchSize(int batchSize);
        void ReadOnly();

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        ICollectionInstance Not { get; }
        new IAccessInstance Access { get; }
        new ICacheInstance Cache { get; }
        new ICollectionCascadeInstance Cascade { get; }
        new IFetchInstance Fetch { get; }
        new IOptimisticLockInstance OptimisticLock { get; }
        new void Check(string constraint);
        new void CollectionType<T>();
        new void CollectionType(string type);
        new void CollectionType(Type type);
        new void Generic();
        new void Inverse();
        new void Persister<T>() where T : IEntityPersister;
        new void Where(string whereClause);
        new void OrderBy(string orderBy);
        void Subselect(string subselect);
    }
}