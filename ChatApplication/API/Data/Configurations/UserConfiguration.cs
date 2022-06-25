using CommanderGQL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CommanderGQL.Data.Configurations 
{

    public class UserConfiguration : IEntityTypeConfiguration<User> 
    {
        public void Configure (EntityTypeBuilder<User> builder) 
        {
            //Table configurations
            builder.ToTable ("user");

            builder.HasKey (e => e.Id);

            builder.Property (e => e.Id)
                .HasColumnName ("user_id")
                .IsRequired (true)
                .HasColumnOrder (1);
        }
    }
}