using System;
using System.Linq.Expressions;
using Web.Interfaces;

namespace Web.Models.Specs
{
    public class AndSpecification<T> : ISpecification<T>
    {
        private readonly ISpecification<T> _leftSpecification;
        private readonly ISpecification<T> _rightSpecification;

        public AndSpecification(ISpecification<T> leftSpecification,
            ISpecification<T> rightSpecification)
        {
            _leftSpecification = leftSpecification;
            _rightSpecification = rightSpecification;
        }

        public Expression<Func<T, bool>> Criteria
        {
            get
            {
                // http://www.albahari.com/nutshell/predicatebuilder.aspx
                return _leftSpecification.Criteria.And(_rightSpecification.Criteria);
            }
        }
    }
    public class OrSpecification<T> : ISpecification<T>
    {
        private readonly ISpecification<T> _leftSpecification;
        private readonly ISpecification<T> _rightSpecification;

        public OrSpecification(ISpecification<T> leftSpecification,
            ISpecification<T> rightSpecification)
        {
            _leftSpecification = leftSpecification;
            _rightSpecification = rightSpecification;
        }

        public Expression<Func<T, bool>> Criteria
        {
            get
            {
                // http://www.albahari.com/nutshell/predicatebuilder.aspx
                return _leftSpecification.Criteria.Or(_rightSpecification.Criteria);
            }
        }
    }
}