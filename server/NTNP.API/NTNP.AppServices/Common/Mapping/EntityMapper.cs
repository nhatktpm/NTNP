﻿using AutoMapper;

namespace NTNP.AppServices.Common.Mapping
{
    public static class EntityMapper
    {
        public static TDestination Map<TSource1, TSource2, TDestination>(
    this IMapper mapper, TSource1 source1, TSource2 source2)
        {
            var destination = mapper.Map<TSource1, TDestination>(source1);
            return mapper.Map(source2, destination);
        }
    }
}
