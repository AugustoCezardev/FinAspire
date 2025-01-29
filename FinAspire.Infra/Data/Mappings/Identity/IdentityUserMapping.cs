using FinAspire.Infra.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinAspire.Infra.Data.Mappings.Identity;

public class IdentityUserMapping: IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> b)
    {
        b.ToTable("User");
        b.HasKey(x => x.Id);
        
        b.HasIndex(u => u.NormalizedEmail).IsUnique();
        b.HasIndex(u => u.NormalizedUserName).IsUnique();
        
        b.Property(x => x.Email).HasMaxLength(180);
        b.Property(x => x.NormalizedEmail).HasMaxLength(180);
        b.Property(x => x.NormalizedUserName).HasMaxLength(180);
        b.Property(x => x.UserName).HasMaxLength(180);
        b.Property(x => x.PhoneNumber).HasMaxLength(20);
        b.Property(x => x.ConcurrencyStamp).IsConcurrencyToken();
        
        b.HasMany<IdentityUserRole<long>>().WithOne().HasForeignKey(x => x.UserId).IsRequired();
        b.HasMany<IdentityUserClaim<long>>().WithOne().HasForeignKey(x => x.UserId).IsRequired();
        b.HasMany<IdentityUserLogin<long>>().WithOne().HasForeignKey(x => x.UserId).IsRequired();
        b.HasMany<IdentityUserToken<long>>().WithOne().HasForeignKey(x => x.UserId).IsRequired();
    }
}