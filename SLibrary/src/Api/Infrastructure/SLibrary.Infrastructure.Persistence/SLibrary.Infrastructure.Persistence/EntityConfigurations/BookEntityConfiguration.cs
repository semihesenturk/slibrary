using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SLibrary.Api.Domain.Models;
using SLibrary.Infrastructure.Persistence.Context;

namespace SLibrary.Infrastructure.Persistence.EntityConfigurations;
public class BookEntityConfiguration : BaseEntityConfiguration<Book>
{
    public override void Configure(EntityTypeBuilder<Book> builder)
    {
        base.Configure(builder);

        builder.ToTable("book", SLibraryContext.DEFAULT_SCHEMA);


      
    }
}

