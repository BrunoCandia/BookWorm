﻿using BookWorm.Basket.Exceptions;

namespace BookWorm.Basket.Features.Create;

public sealed record CreateBasketCommand(List<BasketItemRequest> Items) : ICommand<string>;

public sealed class CreateBasketHandler(
    IBasketRepository basketRepository,
    ClaimsPrincipal claimsPrincipal
) : ICommandHandler<CreateBasketCommand, string>
{
    public async Task<string> Handle(
        CreateBasketCommand request,
        CancellationToken cancellationToken
    )
    {
        var sub = claimsPrincipal.GetClaimValue(KeycloakClaimTypes.Subject);

        var userId = Guard.Against.NotAuthenticated(sub);

        var basket = new CustomerBasket(userId, request.Items.ToBasketItem());

        var result = await basketRepository.UpdateBasketAsync(basket);

        if (result?.Id is null)
        {
            throw new BasketCreatedException("An error occurred while creating the basket.");
        }

        return result.Id;
    }
}
