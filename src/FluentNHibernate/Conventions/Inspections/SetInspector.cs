﻿using System.Reflection;
using FluentNHibernate.Mapping;
using FluentNHibernate.MappingModel.Collections;

namespace FluentNHibernate.Conventions.Inspections
{
    public class SetInspector : CollectionInspector, ISetInspector
    {
        private readonly InspectorModelMapper<ISetInspector, SetMapping> mappedProperties = new InspectorModelMapper<ISetInspector, SetMapping>();
        private readonly SetMapping mapping;

        public SetInspector(SetMapping mapping)
            : base(mapping)
        {
            this.mapping = mapping;
            mappedProperties.Map(x => x.LazyLoad, x => x.Lazy);
        }

        public new bool IsSet(Member property)
        {
            return mapping.IsSpecified(mappedProperties.Get(property));
        }

        public new string OrderBy
        {
            get { return mapping.OrderBy; }
        }
        public string Sort
        {
            get { return mapping.Sort; }
        }
    }
}
