﻿using System.Net.Mime;

namespace BookWorm.Catalog.Features.Books.Create;

public sealed class CreateBookValidator : AbstractValidator<CreateBookCommand>
{
    private const int MaxFileSize = 1048576;

    public CreateBookValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(DataSchemaLength.Medium);

        RuleFor(x => x.Description).MaximumLength(DataSchemaLength.SuperLarge);

        RuleFor(x => x.Price).GreaterThan(0);

        RuleFor(x => x.PriceSale).GreaterThan(0).LessThanOrEqualTo(x => x.Price);

        RuleFor(x => x.CategoryId).NotEmpty();

        RuleFor(x => x.PublisherId).NotEmpty();

        RuleFor(x => x.AuthorIds).NotEmpty();

        When(
            IsHasFiles,
            () =>
            {
                RuleFor(x => x.Image!)
                    .ChildRules(image =>
                    {
                        image
                            .RuleFor(x => x.Length)
                            .LessThanOrEqualTo(MaxFileSize)
                            .WithMessage(
                                $"The file size should not exceed {MaxFileSize / 1024} KB."
                            );
                        image
                            .RuleFor(x => x.ContentType)
                            .Must(x => x is MediaTypeNames.Image.Jpeg or MediaTypeNames.Image.Png)
                            .WithMessage(
                                "File type is not allowed. Allowed file types are JPEG and PNG."
                            );
                    });
            }
        );
    }

    private static bool IsHasFiles(CreateBookCommand command)
    {
        return command.Image is not null;
    }
}
