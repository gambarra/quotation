using System;
using System.Collections.Generic;
using System.Text;

namespace Quotation.Helper {
    /// <summary>
    
    public abstract class CompositeSpecification<T> : Specification<T> where T : class {

        #region Properties

        /// <summary>
        /// Left side specification for this composite element
        /// </summary>
        public abstract ISpecification<T> LeftSideSpecification { get; }

        /// <summary>
        /// Right side specification for this composite element
        /// </summary>
        public abstract ISpecification<T> RightSideSpecification { get; }

        #endregion
    }
}
