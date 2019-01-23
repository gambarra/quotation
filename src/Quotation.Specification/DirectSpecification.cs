using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Quotation.Helper {
    
    public sealed class DirectSpecification<T> : Specification<T> where T : class {

        #region Members

        Expression<Func<T, bool>> _MatchingCriteria;

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor for Direct Specification
        /// </summary>
        /// <param name="matchingCriteria">A Matching Criteria</param>
        public DirectSpecification(Expression<Func<T, bool>> matchingCriteria) {
            if (matchingCriteria == (Expression<Func<T, bool>>)null)
                throw new ArgumentNullException("matchingCriteria");

            _MatchingCriteria = matchingCriteria;
        }

        #endregion

        #region Override

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override Expression<Func<T, bool>> SatisfiedBy() {
            return _MatchingCriteria;
        }

        #endregion

        public static DirectSpecification<T> Build(Expression<Func<T, bool>> matchingCriteria) =>
            new DirectSpecification<T>(matchingCriteria); 
    }
}
