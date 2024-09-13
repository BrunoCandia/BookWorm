﻿// <auto-generated />
using System;
using System.Reflection;
using BookWorm.Catalog.Domain.BookAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#pragma warning disable 219, 612, 618
#nullable disable

namespace BookWorm.Catalog.Infrastructure.Data.CompiledModels
{
    internal partial class PriceEntityType
    {
        public static RuntimeEntityType Create(RuntimeModel model, RuntimeEntityType baseEntityType = null)
        {
            var runtimeEntityType = model.AddEntityType(
                "BookWorm.Catalog.Domain.BookAggregate.Price",
                typeof(Price),
                baseEntityType);

            var bookId = runtimeEntityType.AddProperty(
                "BookId",
                typeof(Guid),
                valueGenerated: ValueGenerated.OnAdd,
                afterSaveBehavior: PropertySaveBehavior.Throw,
                sentinel: new Guid("00000000-0000-0000-0000-000000000000"));
            bookId.TypeMapping = GuidTypeMapping.Default.Clone(
                comparer: new ValueComparer<Guid>(
                    (Guid v1, Guid v2) => v1 == v2,
                    (Guid v) => v.GetHashCode(),
                    (Guid v) => v),
                keyComparer: new ValueComparer<Guid>(
                    (Guid v1, Guid v2) => v1 == v2,
                    (Guid v) => v.GetHashCode(),
                    (Guid v) => v),
                providerValueComparer: new ValueComparer<Guid>(
                    (Guid v1, Guid v2) => v1 == v2,
                    (Guid v) => v.GetHashCode(),
                    (Guid v) => v),
                mappingInfo: new RelationalTypeMappingInfo(
                    storeTypeName: "uuid"));
            bookId.AddAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None);

            var key = runtimeEntityType.AddKey(
                new[] { bookId });
            runtimeEntityType.SetPrimaryKey(key);

            return runtimeEntityType;
        }

        public static RuntimeForeignKey CreateForeignKey1(RuntimeEntityType declaringEntityType, RuntimeEntityType principalEntityType)
        {
            var runtimeForeignKey = declaringEntityType.AddForeignKey(new[] { declaringEntityType.FindProperty("BookId") },
                principalEntityType.FindKey(new[] { principalEntityType.FindProperty("Id") }),
                principalEntityType,
                deleteBehavior: DeleteBehavior.Cascade,
                unique: true,
                required: true,
                ownership: true);

            var price = principalEntityType.AddNavigation("Price",
                runtimeForeignKey,
                onDependent: false,
                typeof(Price),
                propertyInfo: typeof(Book).GetProperty("Price", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Book).GetField("<Price>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                eagerLoaded: true);

            runtimeForeignKey.AddAnnotation("Relational:Name", "fk_books_books_id");
            return runtimeForeignKey;
        }

        public static void CreateAnnotations(RuntimeEntityType runtimeEntityType)
        {
            runtimeEntityType.AddAnnotation("Relational:ContainerColumnName", "price");
            runtimeEntityType.AddAnnotation("Relational:FunctionName", null);
            runtimeEntityType.AddAnnotation("Relational:Schema", null);
            runtimeEntityType.AddAnnotation("Relational:SqlQuery", null);
            runtimeEntityType.AddAnnotation("Relational:TableName", "books");
            runtimeEntityType.AddAnnotation("Relational:ViewName", null);
            runtimeEntityType.AddAnnotation("Relational:ViewSchema", null);

            Customize(runtimeEntityType);
        }

        static partial void Customize(RuntimeEntityType runtimeEntityType);
    }
}
