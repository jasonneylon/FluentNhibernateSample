using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using FluentNHibernate.Automapping;
using FluentNHibernate.MappingModel.ClassBased;
using FluentNHibernate.MappingModel.Collections;
using FluentNHibernate.Utils.Reflection;
using Iesi.Collections.Generic;
using NUnit.Framework;

namespace FluentNHibernate.Testing.Automapping
{
    [TestFixture]
    public class AutoMapOneToManyTester
    {
        private AutoMapOneToMany mapper;

        [SetUp]
        public void CreateMapper()
        {
            mapper = new AutoMapOneToMany(new AutoMappingExpressions());
        }

        [Test]
        public void ShouldMapSets()
        {
            ShouldMap(x => x.Set);
        }

        [Test]
        public void ShouldMapLists()
        {
            ShouldMap(x => x.List);
        }

        [Test]
        public void ShouldntMapValueTypes()
        {
            ShouldntMap(x => x.Int);
            ShouldntMap(x => x.String);
            ShouldntMap(x => x.DateTime);
        }

        [Test]
        public void ShouldntMapEntities()
        {
            ShouldntMap(x => x.Entity);
        }

        [Test]
        public void ShouldMapListAsBag()
        {
            var classMapping = new ClassMapping()
            {
                Type = typeof(PropertyTarget)
            };

            mapper.Map(classMapping, typeof(PropertyTarget).GetProperty("List").ToMember());

            classMapping.Collections
                .First().ShouldBeOfType(typeof(BagMapping));
        }

        [Test]
        public void ShouldMapSetAsSet()
        {
            var classMapping = new ClassMapping()
            {
                Type = typeof(PropertyTarget)
            };

            mapper.Map(classMapping, typeof(PropertyTarget).GetProperty("Set").ToMember());

            classMapping.Collections
                .First().ShouldBeOfType(typeof(SetMapping));
        }

        [Test]
        public void ShouldMapHashSetAsSet()
        {
            var classMapping = new ClassMapping()
            {
                Type = typeof(PropertyTarget)
            };

            mapper.Map(classMapping, typeof(PropertyTarget).GetProperty("HashSet").ToMember());

            classMapping.Collections
                .First().ShouldBeOfType(typeof(SetMapping));
        }

        protected void ShouldMap(Expression<System.Func<PropertyTarget, object>> property)
        {
            mapper.MapsProperty(ReflectionHelper.GetMember(property)).ShouldBeTrue();
        }

        protected void ShouldntMap(Expression<System.Func<PropertyTarget, object>> property)
        {
            mapper.MapsProperty(ReflectionHelper.GetMember(property)).ShouldBeFalse();
        }

        protected class PropertyTarget
        {
            public ISet<PropertyTarget> Set { get; set; }
            public HashSet<PropertyTarget> HashSet { get; set; }
            public IList<PropertyTarget> List { get; set; }
            public int Int { get; set; }
            public string String { get; set; }
            public System.DateTime DateTime { get; set; }
            public PropertyTarget Entity { get; set; }
        }
    }
}