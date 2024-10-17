using BookStore.Core.Models;
using BookStore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.DataAccess.Configuration;

public class BookConfiguration : IEntityTypeConfiguration<BookEntity>
{
    public void Configure(EntityTypeBuilder<BookEntity> builder)
    {
        builder.HasKey(i => i.Id);

        builder.Property(i => i.Title)
            .HasMaxLength(Book.MAX_TITLE_LENGHT)
            .IsRequired();
        
        builder.Property(i => i.Description)
            .IsRequired();
        
        builder.Property(i => i.Price)
            .IsRequired();
    }
}