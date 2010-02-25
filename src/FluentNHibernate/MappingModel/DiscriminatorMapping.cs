﻿using System;
using System.Linq.Expressions;
using System.Reflection;
using FluentNHibernate.Utils;
using FluentNHibernate.Visitors;

namespace FluentNHibernate.MappingModel
{
    public class DiscriminatorMapping : ColumnBasedMappingBase
    {
        public DiscriminatorMapping()
            : this(new AttributeStore())
        {}

        public DiscriminatorMapping(AttributeStore underlyingStore)
            : base(underlyingStore)
        {}

        public override void AcceptVisitor(IMappingModelVisitor visitor)
        {
            visitor.ProcessDiscriminator(this);

            columns.Each(visitor.Visit);
        }

        public bool Force
        {
            get { return attributes.Get<bool>("Force"); }
            set { attributes.Set("Force", value); }
        }

        public bool Insert
        {
            get { return attributes.Get<bool>("Insert"); }
            set { attributes.Set("Insert", value); }
        }

        public string Formula
        {
            get { return attributes.Get("Formula"); }
            set { attributes.Set("Formula", value); }
        }

        public TypeReference Type
        {
            get { return attributes.Get<TypeReference>("Type"); }
            set { attributes.Set("Type", value); }
        }

        public Type ContainingEntityType { get; set; }

        public bool Equals(DiscriminatorMapping other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.ContainingEntityType, ContainingEntityType) &&
                other.columns.ContentEquals(columns) &&
                Equals(other.attributes, attributes);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(DiscriminatorMapping)) return false;
            return Equals((DiscriminatorMapping)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((ContainingEntityType != null ? ContainingEntityType.GetHashCode() : 0) * 397) ^ ((columns != null ? columns.GetHashCode() : 0) * 397) ^ (attributes != null ? attributes.GetHashCode() : 0);
            }
        }
    }
}
