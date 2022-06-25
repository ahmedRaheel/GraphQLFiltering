using CommanderGQL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CommanderGQL.Data.Configurations {

    public class CommandConfiguration : IEntityTypeConfiguration<Command> {
        public void Configure (EntityTypeBuilder<Command> builder) {
            //Table configurations
            builder.ToTable ("command");

            builder.HasKey (e => e.Id);

            builder.Property (e => e.Id)
                .HasColumnName ("command_id")
                .IsRequired (true)
                .HasColumnOrder (1);

            builder.Property (e => e.HowTo)
                .IsRequired (true);

            builder.Property (e => e.CommandLine)
                .IsRequired (true);

            builder.Property (e => e.PlatformId)
                .IsRequired (true);

            builder.HasOne (e => e.Platform)
                .WithMany (e => e.Commands)
                .HasForeignKey (e => e.PlatformId);
        }
    }
}