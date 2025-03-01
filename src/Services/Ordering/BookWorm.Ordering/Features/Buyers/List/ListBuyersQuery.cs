﻿using System.ComponentModel;
using BookWorm.Ordering.Domain.AggregatesModel.BuyerAggregate.Specifications;

namespace BookWorm.Ordering.Features.Buyers.List;

public sealed record ListBuyersQuery(
    [property: Description("Number of items to return in a single page of results")]
    [property: DefaultValue(Pagination.DefaultPageIndex)]
        int PageIndex = Pagination.DefaultPageIndex,
    [property: Description("Number of items to return in a single page of results")]
    [property: DefaultValue(Pagination.DefaultPageSize)]
        int PageSize = Pagination.DefaultPageSize
) : IQuery<PagedResult<BuyerDto>>;

public sealed class ListBuyersQueryHandler(IBuyerRepository repository)
    : IQueryHandler<ListBuyersQuery, PagedResult<BuyerDto>>
{
    public async Task<PagedResult<BuyerDto>> Handle(
        ListBuyersQuery request,
        CancellationToken cancellationToken
    )
    {
        var buyers = await repository.ListAsync(
            new BuyerFilterSpec(request.PageIndex, request.PageSize),
            cancellationToken
        );

        var totalItems = await repository.CountAsync(cancellationToken);

        var totalPages = (int)Math.Ceiling(totalItems / (double)request.PageSize);

        return new(
            buyers.ToBuyerDtos(),
            request.PageIndex,
            request.PageSize,
            totalItems,
            totalPages
        );
    }
}
