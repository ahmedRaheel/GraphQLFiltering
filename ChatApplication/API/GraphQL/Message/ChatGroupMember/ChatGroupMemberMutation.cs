using System.Text;
using CommanderGQL.Data;
using CommanderGQL.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace CommanderGQL.GraphQL 
{
    public partial class Mutation
    {        
        [UseDbContext (typeof (WebAppContext))]
        public async Task<ServerPayload> AddChatMemberToGroup (AddChatMemberToGroupInput input, [ScopedService] WebAppContext dbContext) 
        {
            if (dbContext.ChatMembers == null || dbContext.ChatGroups == null || dbContext.ChatGroupMembers == null) 
            {
                throw new Exception ("Null dbContext.ChatMembers in Mutation:AddChatMemberToGroup");
            }

            var chatGroup = await dbContext
                .ChatGroups
                .Include(c => c.Members)
                .Where(c => c.Id == input.ChatGroupId && c.Deleted == null)
                .FirstOrDefaultAsync();

            var chatMember = await dbContext 
                .ChatMembers
                .Where(c => c.Id == input.ChatMemberId)
                .FirstOrDefaultAsync();  

            if(chatGroup == null || chatMember == null) {
                return new ServerPayload (404);
            }

            var currentChatGroupMember = await dbContext 
                .ChatGroupMembers
                .Where(c => c.ChatMemberId == input.ChatMemberId && c.ChatGroupId == input.ChatGroupId)
                .FirstOrDefaultAsync();  

            if(currentChatGroupMember != null && currentChatGroupMember.Deleted == null) {
                return new ServerPayload (400, "chatGroupMember already exists");
            }
            

            if(currentChatGroupMember != null && currentChatGroupMember.Deleted != null) {
                currentChatGroupMember.Deleted = null;
                dbContext.ChatGroups.Update(chatGroup);
            }else {
                var chatGroupMember = new ChatGroupMember {
                    ChatGroupId = chatGroup.Id,
                    ChatMemberId = chatMember.Id,
                    HasBeenRead = true,
                };
                
                await dbContext.ChatGroupMembers.AddAsync(chatGroupMember);
            }

            await dbContext.SaveChangesAsync ();            

            return new ServerPayload (200);
        }

        [UseDbContext (typeof (WebAppContext))]
        public async Task<ServerPayload> RemoveChatMemberFromGroup (RemoveChatMemberFromGroupInput input, [ScopedService] WebAppContext dbContext) 
        {
            if (dbContext.ChatMembers == null || dbContext.ChatGroups == null || dbContext.ChatGroupMembers == null) 
            {
                throw new Exception ("Null dbContext.ChatMembers in Mutation:AddChatMemberToGroup");
            }

            var chatGroup = await dbContext
                .ChatGroups
                .Include(c => c.Members)
                .Where(c => c.Id == input.ChatGroupId && c.Deleted == null)
                .FirstOrDefaultAsync();

            var chatMember = await dbContext 
                .ChatMembers
                .Where(c => c.Id == input.ChatMemberId)
                .FirstOrDefaultAsync();  

            if(chatGroup == null || chatMember == null) {
                return new ServerPayload (404);
            }

            var chatGroupMember = await dbContext 
                .ChatGroupMembers
                .Where(c => c.ChatMemberId == input.ChatMemberId && c.ChatGroupId == input.ChatGroupId && c.Deleted == null)
                .FirstOrDefaultAsync();

            if(chatGroupMember == null) {
                return new ServerPayload (404);
            }
            
            chatGroupMember.Deleted = DateTime.UtcNow;

            dbContext.ChatGroups.Update(chatGroup);
            await dbContext.SaveChangesAsync ();            

            return new ServerPayload (200);
        }
    }
}