using CommanderGQL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CommanderGQL.Data.Configurations 
{

    public class ChatMemberConfiguration : IEntityTypeConfiguration<ChatMember> 
    {
        public void Configure (EntityTypeBuilder<ChatMember> builder) 
        {
            //Table configurations
            // builder.ToTable ("chat_member");
            builder.HasMany(x=>x.ChatGroups).WithOne(x=> x.Member).HasForeignKey(x=>x.ChatMemberId);
            // builder.HasKey (e => e.Id);

            // builder.Property (e => e.Id)
            //     .HasColumnName ("chat_member_id")
            //     .IsRequired (true)
            //     .HasColumnOrder (1);
        }
    }
}