using System;
using System.Linq.Expressions;

namespace RentApplication.BLL.Services.Specifications
{
    public abstract class PropertySpecification<T>
    {
        protected abstract Expression<Func<T, bool>> ToExpression();

        public bool IsSatisfiedBy(T entity)
        {
            var predicate = ToExpression().Compile();
            return predicate(entity);
        }
    }
}