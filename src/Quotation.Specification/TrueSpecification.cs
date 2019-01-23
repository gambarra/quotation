using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Quotation.Helper {
    /// <summary>
    /// True specification
    /// </summary>
    /// <typeparam name="T">Type of entity in this specification</typeparam>
    public sealed class TrueSpecification<T> : Specification<T> where T : class {

        #region Specification overrides
        public override System.Linq.Expressions.Expression<Func<T, bool>> SatisfiedBy() {

            bool result = true;

            Expression<Func<T, bool>> trueExpression = t => result;
            return trueExpression;
        }

        #endregion
    }
}
