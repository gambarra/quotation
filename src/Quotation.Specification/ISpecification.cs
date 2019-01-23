using System;
using System.Linq.Expressions;

namespace Quotation.Helper {

    public interface ISpecification<T> where T : class {

 
        Expression<Func<T, bool>> SatisfiedBy();
    }
}
