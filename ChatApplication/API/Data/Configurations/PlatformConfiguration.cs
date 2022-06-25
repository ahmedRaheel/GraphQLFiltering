using CommanderGQL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CommanderGQL.Data.Configurations {

    public class PlatformConfiguration : IEntityTypeConfiguration<Platform> {
        public void Configure (EntityTypeBuilder<Platform> builder) {
            //Table configurations
            builder.ToTable ("platform");

            builder.HasKey (e => e.Id);

            builder.Property (e => e.Id)
                .HasColumnName ("platform_id")
                .IsRequired (true)
                .HasColumnOrder (1);

            builder.Property (e => e.Name)
                .IsRequired (true);

            builder.HasMany (e => e.Commands)
                .WithOne (c => c.Platform)
                .HasForeignKey (e => e.PlatformId);
        }
    }
}