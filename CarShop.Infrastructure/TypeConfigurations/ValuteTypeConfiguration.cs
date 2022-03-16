using CarShop.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarShop.Infrastructure.TypeConfigurations
{
    public class ValuteTypeConfiguration : IEntityTypeConfiguration<Valute>
    {
        public void Configure(EntityTypeBuilder<Valute> builder)
        {
            builder.ToTable("Valutes");
            builder.HasKey(x => x.Id);
        }
    }
}
