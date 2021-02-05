using PMS.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace PMS.DataEFCore.Extension
{
    public static class ConvertExtensions
    {
        public static IEnumerable<TTarget> ConvertAll<TSource, TTarget>(
            this IEnumerable<IConvertModel<TSource, TTarget>> values)
            => values.Select(value => value.Convert());
    }
}
