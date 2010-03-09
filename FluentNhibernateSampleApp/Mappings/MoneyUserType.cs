using NHibernate;
using System.Data;
using NHibernate.SqlTypes;

namespace FluentNhibernateSampleApp
{
    /// <summary>
    /// From http://darrell.mozingo.net/2009/02/10/generic-nhibernate-user-type-base-class/
    /// </summary>
    public class MoneyUserType : BaseImmutableUserType<Money>
    {
        public override SqlType[] SqlTypes
        {
            get
            {
                return new[] { NHibernateUtil.Decimal.SqlType };
            }
        }

        public override object NullSafeGet(IDataReader rs, string[] names, object owner)
        {
            var value = NHibernateUtil.Decimal.NullSafeGet(rs, names[0]) as decimal?;
            return new Money() { Value = value };

        }

        public override void NullSafeSet(IDbCommand cmd, object value, int index)
        {
            var moneyObject = value as Money;

            object valueToSet;

            if (moneyObject == null)
            {
                valueToSet = null;
            }
            else
            {
                valueToSet = moneyObject.Value;
            }

            NHibernateUtil.Decimal.NullSafeSet(cmd, valueToSet, 0);
        }
    }
}
