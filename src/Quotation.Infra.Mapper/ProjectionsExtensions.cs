using System.Collections;
using System.Collections.Generic;

namespace Quotation.Infra.Mapper {
    public static class ProjectionsExtensions {

   
        public static TProjection ProjectedAs<TProjection>(this object item) where TProjection : class {
            var adapter = TypeAdapterFactory.CreateAdapter();
            return adapter.Adapt<TProjection>(item);
        }

  
        public static List<TProjection> ProjectedAsCollection<TProjection>(this IEnumerable<object> items) where TProjection : class {
            var adapter = TypeAdapterFactory.CreateAdapter();
            return adapter.Adapt<List<TProjection>>(items);
        }

        public static List<TProjection> ProjectedAsCollection<TProjection>(this IEnumerable items) where TProjection : class {
            var adapter = TypeAdapterFactory.CreateAdapter();
            return adapter.Adapt<List<TProjection>>(items);
        }
    }
}
