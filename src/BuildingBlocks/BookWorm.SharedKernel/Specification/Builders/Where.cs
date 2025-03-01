﻿using System.Linq.Expressions;
using BookWorm.SharedKernel.Specification.Expressions;

namespace BookWorm.SharedKernel.Specification.Builders;

public static partial class SpecificationBuilderExtensions
{
    public static ISpecificationBuilder<T> Where<T>(
        this ISpecificationBuilder<T> builder,
        Expression<Func<T, bool>> predicate
    )
        where T : class
    {
        var expr = new WhereExpression<T>(predicate);
        builder.Specification.Add(expr);
        return builder;
    }
}
