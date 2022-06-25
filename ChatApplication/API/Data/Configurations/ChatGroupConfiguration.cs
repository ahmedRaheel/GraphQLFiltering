using CommanderGQL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CommanderGQL.Data.Configurations {

    public class ChatGroupConfiguration : IEntityTypeConfiguration<ChatGroup> 
    {
        public void Configure (EntityTypeBuilder<ChatGroup> builder) 
        {
            //Table configurations
            // builder.ToTable ("chat_group");

            // builder.HasKey (e => e.Id);

            // builder.Property (e => e.Id)
            //     .HasColumnName ("chat_group_id")
            //     .IsRequired (true)
            //     .HasColumnOrder (1);
          
            builder
                .HasMany(x=>x.Members).WithOne(x=> x.ChatGroup).HasForeignKey(x=>x.ChatGroupId);
            // builder
            builder.HasMany(x=>x.Messages).WithOne(x=> x.ChatGroup).HasForeignKey(x=>x.ChatGroupId);
            builder.Property (e => e.Title)
                   .IsRequired (true);
        }
    }
}