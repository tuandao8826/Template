using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Application.Common.Extensions;

public static class FluentValidationExtension
{
    private static readonly string[] sourceArray = [".jpg", ".jpeg", ".png", ".gif", ".webp"];

    public static IRuleBuilderOptions<T, IFormFile?> MustBeImage<T>(this IRuleBuilder<T, IFormFile?> builder, string[]? sources = null)
        => builder.Must(file => file is null || (sources ?? sourceArray).Contains(Path.GetExtension(file.FileName).ToLower()));

    public static IRuleBuilderOptions<T, IEnumerable<TProperty>?> NotDuplicate<T, TProperty>(this IRuleBuilder<T, IEnumerable<TProperty>?> builder)
        => builder.Must(collection =>
        {
            return collection is null || collection.Distinct().Count() == collection.Count();
        });
}
