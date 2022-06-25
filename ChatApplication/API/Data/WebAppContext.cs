using CommanderGQL.Data.Configurations;
using CommanderGQL.Models;
using Microsoft.EntityFrameworkCore;

namespace CommanderGQL.Data {
    public class WebAppContext : DbContext {
        public WebAppContext (DbContextOptions options) : base (options) {

        }
        
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Command> Commands { get; set; }
        public DbSet<ChatGroup> ChatGroups { get; set; }
        public DbSet<ChatMessage> ChatMessages { get; set; }        
        public DbSet<ChatMember>  ChatMembers { get; set; }
        public DbSet<ChatGroupMember> ? ChatGroupMembers { get; set; }

        protected override void OnModelCreating (ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfiguration (new PlatformConfiguration ());
            modelBuilder.ApplyConfiguration (new CommandConfiguration ());
            modelBuilder.ApplyConfiguration (new ChatGroupMemberConfiguration ());
            modelBuilder.ApplyConfiguration (new ChatGroupConfiguration ());
            modelBuilder.ApplyConfiguration (new ChatMessageConfiguration ());
            modelBuilder.ApplyConfiguration (new ChatMemberConfiguration ());            

            base.OnModelCreating (modelBuilder);
        }
    }
}