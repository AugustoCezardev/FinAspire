﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinAspire.Infra.Data.Mappings.Identity;

public class IdentityUserLoginMapping: IEntityTypeConfiguration<IdentityUserLogin<long>>
{
    public void Configure(EntityTypeBuilder<IdentityUserLogin<long>> builder)
    {
        builder.ToTable("UserLogin");
        builder.HasKey(l => new { l.LoginProvider, l.ProviderKey });
        builder.Property(l => l.LoginProvider).HasMaxLength(128);
        builder.Property(l => l.ProviderKey).HasMaxLength(128);
        builder.Property(l => l.ProviderDisplayName).HasMaxLength(255);
    }
}