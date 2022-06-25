using CommanderGQL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CommanderGQL.Data.Configurations 
{

    public class ChatMessageConfiguration : IEntityTypeConfiguration<ChatMessage> 
    {
        public void Configure (EntityTypeBuilder<ChatMessage> builder) 
        {
            //Table configurations
            // builder.ToTable ("chat_message");

            // builder.HasKey (e => e.Id);

            // builder.Property (e => e.Id)
            //     .HasColumnName ("chat_message_id")
            //     .IsRequired (true)
            //     // .HasColumnOrder (1);                                  
        }
    }
}