using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using FluentNHibernate.Mapping.Providers;
using FluentNHibernate.Utils;

namespace FluentNHibernate.Mapping
{
    public abstract class ClasslikeMapBase<T>
    {
        protected readonly IList<IPropertyMappingProvider> properties = new List<IPropertyMappingProvider>();
        protected readonly IList<IComponentMappingProvider> components = new List<IComponentMappingProvider>();
        protected readonly IList<IOneToOneMappingProvider> oneToOnes = new List<IOneToOneMappingProvider>();
        protected readonly Dictionary<Type, ISubclassMappingProvider> subclasses = new Dictionary<Type, ISubclassMappingProvider>();
        protected readonly IList<ICollectionMappingProvider> collections = new List<ICollectionMappingProvider>();
        protected readonly IList<IManyToOneMappingProvider> references = new List<IManyToOneMappingProvider>();
        protected readonly IList<IAnyMappingProvider> anys = new List<IAnyMappingProvider>();
        protected readonly IList<IFilterMappingProvider> filters = new List<IFilterMappingProvider>();
        protected readonly IList<IStoredProcedureMappingProvider> storedProcedures = new List<IStoredProcedureMappingProvider>();

        public PropertyPart Map(Expression<Func<T, object>> expression)
        {
            return Map(expression, null);
        }

        public PropertyPart Map(Expression<Func<T, object>> expression, string columnName)
        {
            return Map(expression.ToMember(), columnName);
        }

        protected virtual PropertyPart Map(Member property, string columnName)
        {
            var propertyMap = new PropertyPart(property, typeof(T));

            if (!string.IsNullOrEmpty(columnName))
                propertyMap.Column(columnName);

            properties.Add(propertyMap);

            return propertyMap;
        }

        public ManyToOnePart<TOther> References<TOther>(Expression<Func<T, TOther>> expression)
        {
            return References(expression, null);
        }

        public ManyToOnePart<TOther> References<TOther>(Expression<Func<T, TOther>> expression, string columnName)
        {
            return References<TOther>(expression.ToMember(), columnName);
        }

        public ManyToOnePart<TOther> References<TOther>(Expression<Func<T, object>> expression)
        {
            return References<TOther>(expression, null);
        }

        public ManyToOnePart<TOther> References<TOther>(Expression<Func<T, object>> expression, string columnName)
        {
            return References<TOther>(expression.ToMember(), columnName);
        }

        protected virtual ManyToOnePart<TOther> References<TOther>(Member property, string columnName)
        {
            var part = new ManyToOnePart<TOther>(EntityType, property);

            if (columnName != null)
                part.Column(columnName);

            references.Add(part);

            return part;
        }

        public AnyPart<TOther> ReferencesAny<TOther>(Expression<Func<T, TOther>> expression)
        {
            return ReferencesAny<TOther>(expression.ToMember());
        }

        protected virtual AnyPart<TOther> ReferencesAny<TOther>(Member property)
        {
            var part = new AnyPart<TOther>(typeof(T), property);

            anys.Add(part);

            return part;
        }

        public OneToOnePart<TOther> HasOne<TOther>(Expression<Func<T, Object>> expression)
        {
            return HasOne<TOther>(expression.ToMember());
        }

        public OneToOnePart<TOther> HasOne<TOther>(Expression<Func<T, TOther>> expression)
        {
            return HasOne<TOther>(expression.ToMember());
        }

        protected virtual OneToOnePart<TOther> HasOne<TOther>(Member property)
        {
            var part = new OneToOnePart<TOther>(EntityType, property);

            oneToOnes.Add(part);

            return part;
        }

        public DynamicComponentPart<IDictionary> DynamicComponent(Expression<Func<T, IDictionary>> expression, Action<DynamicComponentPart<IDictionary>> action)
        {
            return DynamicComponent(expression.ToMember(), action);
        }

        protected DynamicComponentPart<IDictionary> DynamicComponent(Member property, Action<DynamicComponentPart<IDictionary>> action)
        {
            var part = new DynamicComponentPart<IDictionary>(typeof(T), property);
            
            action(part);

            components.Add(part);

            return part;
        }

        /// <summary>
        /// Creates a component reference. This is a place-holder for a component that is defined externally with a
        /// <see cref="ComponentMap{T}"/>; the mapping defined in said <see cref="ComponentMap{T}"/> will be merged
        /// with any options you specify from this call.
        /// </summary>
        /// <typeparam name="TComponent">Component type</typeparam>
        /// <param name="member">Property exposing the component</param>
        /// <returns>Component reference builder</returns>
        public ReferenceComponentPart<TComponent> Component<TComponent>(Expression<Func<T, TComponent>> member)
        {
            var part = new ReferenceComponentPart<TComponent>(member.ToMember(), typeof(T));

            components.Add(part);

            return part;
        }

        /// <summary>
        /// Maps a component
        /// </summary>
        /// <typeparam name="TComponent">Type of component</typeparam>
        /// <param name="expression">Component property</param>
        /// <param name="action">Component mapping</param>
        public ComponentPart<TComponent> Component<TComponent>(Expression<Func<T, TComponent>> expression, Action<ComponentPart<TComponent>> action)
        {
            return Component(expression.ToMember(), action);
        }

        /// <summary>
        /// Maps a component
        /// </summary>
        /// <typeparam name="TComponent">Type of component</typeparam>
        /// <param name="expression">Component property</param>
        /// <param name="action">Component mapping</param>
        public ComponentPart<TComponent> Component<TComponent>(Expression<Func<T, object>> expression, Action<ComponentPart<TComponent>> action)
        {
            return Component(expression.ToMember(), action);
        }
        
        protected virtual ComponentPart<TComponent> Component<TComponent>(Member property, Action<ComponentPart<TComponent>> action)
        {
            var part = new ComponentPart<TComponent>(typeof(T), property);

            action(part);

            components.Add(part);

            return part;
        }

        /// <summary>
        /// CreateProperties a one-to-many relationship
        /// </summary>
        /// <typeparam name="TChild">Child object type</typeparam>
        /// <typeparam name="TReturn">Property return type</typeparam>
        /// <param name="expression">Expression to get property from</param>
        /// <returns>one-to-many part</returns>
        private OneToManyPart<TChild> MapHasMany<TChild, TReturn>(Expression<Func<T, TReturn>> expression)
        {
            return HasMany<TChild>(expression.ToMember());
        }

        protected virtual OneToManyPart<TChild> HasMany<TChild>(Member member)
        {
            var part = new OneToManyPart<TChild>(EntityType, member);

            collections.Add(part);

            return part;
        }

        /// <summary>
        /// CreateProperties a one-to-many relationship
        /// </summary>
        /// <typeparam name="TChild">Child object type</typeparam>
        /// <param name="expression">Expression to get property from</param>
        /// <returns>one-to-many part</returns>
        public OneToManyPart<TChild> HasMany<TChild>(Expression<Func<T, IEnumerable<TChild>>> expression)
        {
            return MapHasMany<TChild, IEnumerable<TChild>>(expression);
        }

        /// <summary>
        /// CreateProperties a one-to-many relationship with a IDictionary
        /// </summary>
        /// <typeparam name="TKey">Dictionary key type</typeparam>
        /// <typeparam name="TChild">Child object type / Dictionary value type</typeparam>
        /// <param name="expression">Expression to get property from</param>
        /// <returns>one-to-many part</returns>
        public OneToManyPart<TChild> HasMany<TKey, TChild>(Expression<Func<T, IDictionary<TKey, TChild>>> expression)
        {
            return MapHasMany<TChild, IDictionary<TKey, TChild>>(expression);
        }

        /// <summary>
        /// CreateProperties a one-to-many relationship
        /// </summary>
        /// <typeparam name="TChild">Child object type</typeparam>
        /// <param name="expression">Expression to get property from</param>
        /// <returns>one-to-many part</returns>
        public OneToManyPart<TChild> HasMany<TChild>(Expression<Func<T, object>> expression)
        {
            return MapHasMany<TChild, object>(expression);
        }

        /// <summary>
        /// CreateProperties a many-to-many relationship
        /// </summary>
        /// <typeparam name="TChild">Child object type</typeparam>
        /// <typeparam name="TReturn">Property return type</typeparam>
        /// <param name="expression">Expression to get property from</param>
        /// <returns>many-to-many part</returns>
        private ManyToManyPart<TChild> MapHasManyToMany<TChild, TReturn>(Expression<Func<T, TReturn>> expression)
        {
            return HasManyToMany<TChild>(expression.ToMember());
        }

        protected virtual ManyToManyPart<TChild> HasManyToMany<TChild>(Member property)
        {
            var part = new ManyToManyPart<TChild>(EntityType, property);

            collections.Add(part);

            return part;
        }

        /// <summary>
        /// CreateProperties a many-to-many relationship
        /// </summary>
        /// <typeparam name="TChild">Child object type</typeparam>
        /// <param name="expression">Expression to get property from</param>
        /// <returns>many-to-many part</returns>
        public ManyToManyPart<TChild> HasManyToMany<TChild>(Expression<Func<T, IEnumerable<TChild>>> expression)
        {
            return MapHasManyToMany<TChild, IEnumerable<TChild>>(expression);
        }

	/// <summary>
        /// CreateProperties a many-to-many relationship with a IDictionary
        /// </summary>
        /// <typeparam name="TKey">Dictionary key type</typeparam>
        /// <typeparam name="TChild">Child object type / Dictionary value type</typeparam>
        /// <param name="expression">Expression to get property from</param>
        /// <returns>one-to-many part</returns>
/*	public ManyToManyPart<TChild> HasManyToMany<TKey, TChild>(Expression<Func<T, IDictionary<TKey, TChild>>> expression)
	{
		return MapHasManyToMany<TChild, IDictionary<TKey, TChild>>(expression);
	}*/

        /// <summary>
        /// CreateProperties a many-to-many relationship
        /// </summary>
        /// <typeparam name="TChild">Child object type</typeparam>
        /// <param name="expression">Expression to get property from</param>
        /// <returns>many-to-many part</returns>
        public ManyToManyPart<TChild> HasManyToMany<TChild>(Expression<Func<T, object>> expression)
        {
            return MapHasManyToMany<TChild, object>(expression);
        }

        public StoredProcedurePart SqlInsert(string innerText)
        {
            return StoredProcedure("sql-insert", innerText);
        }

        public StoredProcedurePart SqlUpdate(string innerText)
        {
            return StoredProcedure("sql-update", innerText);
        }     

        public StoredProcedurePart SqlDelete(string innerText)
        {
            return StoredProcedure("sql-delete", innerText);
        }

        public StoredProcedurePart SqlDeleteAll(string innerText)
        {
            return StoredProcedure("sql-delete-all", innerText);
        }

        protected StoredProcedurePart StoredProcedure(string element, string innerText)
        {
            var part = new StoredProcedurePart(element, innerText);
            storedProcedures.Add(part);
            return part;
        }

        protected virtual IEnumerable<IPropertyMappingProvider> Properties
		{
			get { return properties; }
		}

        protected virtual IEnumerable<IComponentMappingProvider> Components
		{
			get { return components; }
		}

        public Type EntityType
        {
            get { return typeof(T); }
        }
    }
}
