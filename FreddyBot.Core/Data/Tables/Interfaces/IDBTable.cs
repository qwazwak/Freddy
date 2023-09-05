#define uglyConfig
#if uglyConfig
using Microsoft.EntityFrameworkCore.Metadata.Builders;
#endif
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace FreddyBot.Core.Data.Tables.Interfaces;

public interface IDBTable
{
    static abstract string TableName { get; }
}

#if uglyConfig
internal static class ModelBuilderExtensions
{
    public static EntityTypeBuilder<TEntity> SelfConfigure<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties | DynamicallyAccessedMemberTypes.Interfaces)] TEntity>(this ModelBuilder modelBuilder)
    where TEntity : class, IDBTable, IConfigurableDBTable<TEntity>
    {
        EntityTypeBuilder<TEntity> builder = modelBuilder.Entity<TEntity>();
        TEntity.Configure(builder);
        return builder;
    }
}

public interface IConfigurableDBTable<TSelf> : IDBTable where TSelf : class, IConfigurableDBTable<TSelf>
{
    static abstract void Configure(EntityTypeBuilder<TSelf> builder);
}
#endif