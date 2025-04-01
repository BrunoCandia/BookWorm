﻿namespace BookWorm.Basket.Features.Delete;

public sealed record DeleteBasketCommand : ICommand;

public sealed class DeleteBasketHandler(
    IBasketRepository basketRepository,
    ClaimsPrincipal claimsPrincipal
) : ICommandHandler<DeleteBasketCommand>
{
    public async Task<Unit> Handle(DeleteBasketCommand request, CancellationToken cancellationToken)
    {
        var sub = claimsPrincipal.GetClaimValue(KeycloakClaimTypes.Subject);

        var userId = Guard.Against.NotAuthenticated(sub);

        var basket = await basketRepository.GetBasketAsync(userId);

        Guard.Against.NotFound(basket, $"Basket with id {userId} not found.");

        await basketRepository.DeleteBasketAsync(userId);

        return Unit.Value;
    }
}
