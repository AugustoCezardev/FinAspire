﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinAspire.Infra.Data.Mappings.Identity;

public class IdentityUserRoleMapping: IEntityTypeConfiguration<IdentityUserRole<long>>
{
    public void Configure(EntityTypeBuilder<IdentityUserRole<long>> builder)
    {
        builder.ToTable("UserRole");
        
        builder.HasKey(x => new { x.UserId, x.RoleId });
    }
}