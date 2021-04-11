using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlockBuster.Shared.Domain.ValueObjects
{
    public abstract class ValueObject<T>
    {
        protected T _value;

        public ValueObject(T value)
        {
            _value = value;
        }
        protected IEnumerable<object> GetAtomicValues()
        {
            yield return _value;
        }

    public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
            {
                return false;
            }

            ValueObject<T> other = (ValueObject<T>)obj;
            IEnumerator<object> thisValues = GetAtomicValues().GetEnumerator();
            IEnumerator<object> otherValues = other.GetAtomicValues().GetEnumerator();
            while (thisValues.MoveNext() && otherValues.MoveNext())
            {
                if (ReferenceEquals(thisValues.Current, null) ^
                    ReferenceEquals(otherValues.Current, null))
                {
                    return false;
                }

                if (thisValues.Current != null &&
                    !thisValues.Current.Equals(otherValues.Current))
                {
                    return false;
                }
            }
            return !thisValues.MoveNext() && !otherValues.MoveNext();
        }

        public override int GetHashCode()
        {
            return GetAtomicValues()
             .Select(x => x != null ? x.GetHashCode() : 0)
             .Aggregate((x, y) => x ^ y);
        }

        public T GetValue()
        {
            return _value;
        }
    }
}
