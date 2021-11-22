using System;
using System.Linq.Expressions;
using RentApplication.DAL.Models;

namespace RentApplication.BLL.Services.Specifications
{
    public class IsActiveSpecification : PropertySpecification<Request>
    {
        private readonly int _isActive;

        public IsActiveSpecification(int isActive)
        {
            _isActive = isActive;
        }

        protected override Expression<Func<Request, bool>> ToExpression()
        {
            return request => request.IsActive <= _isActive;
        }
    }
}