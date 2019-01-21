namespace Quotation.Infra.Mapper {
    class AutoMapperTypeAdapter : ITypeAdapter {


        public TTarget Adapt<TTarget>(object source) where TTarget : class {
            return AutoMapper.Mapper.Map(source, source.GetType(), typeof(TTarget)) as TTarget;
        }

        public TTarget Adapt<TSource, TTarget>(TSource source) where TSource : class where TTarget : class {
            return AutoMapper.Mapper.Map<TSource, TTarget>(source);
        }
    }
}
