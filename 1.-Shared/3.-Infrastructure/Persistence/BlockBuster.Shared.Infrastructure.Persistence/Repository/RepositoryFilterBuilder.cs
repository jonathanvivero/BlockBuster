using BlockBuster.Shared.Domain.ValueObjects;
using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BlockBuster.Shared.Infrastructure.Persistence.Repository
{
    public abstract class RepositoryFilterBuilder<T> : IRepositoryFilterBuilder<T>
    {        
        private IList<ExpressionStarter<T>> _predicateList = new List<ExpressionStarter<T>>();

        public abstract ExpressionStarter<T> BuildFilter(IDictionary<string, string[]> filter);

        protected ExpressionStarter<T> BuildAndReturn()
        {
            var predicate = PredicateBuilder.New<T>();

            if (!_predicateList.Any())
                return predicate.Or(p => true);

            foreach (var p in _predicateList)
                predicate.And(p);
            
            return predicate;
        }

        protected void Add(
           IDictionary<string, string[]> filter,
           string entry,
           Func<string[], ExpressionStarter<T>> addPredicate)
        {
            if (filter.ContainsKey(entry) && filter[entry].Any())
                _predicateList.Add(addPredicate(filter[entry]));
        }

        protected void Add(
           IDictionary<string, string[]> filter,
           string entry,
           Func<string[], string, ExpressionStarter<T>> addPredicate, 
           string field)
        {
            if (filter.ContainsKey(entry) && filter[entry].Any())
                _predicateList.Add(addPredicate(filter[entry], field));
        }

        protected ExpressionStarter<T> AddStringValueEqualsPredicate(string[] filterValues, string field)
        {
            var predicate = PredicateBuilder.New<T>();
            foreach (var val in filterValues)
                predicate.Or(w => ApplyEquals(w, field ,val));

            return predicate;
        }
        protected ExpressionStarter<T> AddStringValueContainsPredicate(string[] filterValues, string field)
        {
            var predicate = PredicateBuilder.New<T>();
            foreach (var val in filterValues)
                predicate.Or(w => ApplyEquals(w, field, val));

            return predicate;
        }

        private bool ApplyEquals(T entity, string field, string val)
        {
            MethodInfo methodInfo = typeof(T).GetMethod(field);
            var result = methodInfo.Invoke(entity, null) as StringValueObject;
            return result.GetValue().Equals(val);
        }

        private bool ApplyContains(T entity, string field, string val)
        {
            MethodInfo methodInfo = typeof(T).GetMethod(field);
            var result = methodInfo.Invoke(entity, null) as StringValueObject;
            return result.GetValue().Contains(val);
        }

    }

}
