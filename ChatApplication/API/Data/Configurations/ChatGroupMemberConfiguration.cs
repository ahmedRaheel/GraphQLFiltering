using CommanderGQL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CommanderGQL.Data.Configurations 
{

    public class ChatGroupMemberConfiguration : IEntityTypeConfiguration<ChatGroupMember> 
    {
        public void Configure (EntityTypeBuilder<ChatGroupMember> builder) 
        {
            //Table configurations
            //builder.ToTable ("chat_group_member");

            builder.HasKey (e => e.Id);

            // builder.Property (e => e.Id)
            //     .HasColumnName ("chat_group_member_id")
            //     .IsRequired (true)
            //     .HasColumnOrder (1);                            
        }
    }
}