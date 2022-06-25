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
        public async Task<CreateChatMessagePayload> CreateChatMessage (CreateChatMessageInput input, [ScopedService] WebAppContext dbContext) 
        {
            if (dbContext.ChatMessages == null || dbContext.ChatGroupMembers == null) 
            {
                throw new Exception ("Null dbContext.ChatMessages in Mutation:CreateChatMessage");
            }            

            var chatGroupMember = await dbContext
                .ChatGroupMembers
                .Where(e => e.ChatGroupId == input.ChatGroupId && e.ChatMemberId == input.ChatMemberId && e.Deleted == null)
                .FirstOrDefaultAsync();

            if(chatGroupMember == null) {
                return new CreateChatMessagePayload();
            }

            var chatMessage = new ChatMessage
            {                
                ChatGroupMemberId = chatGroupMember.Id,
                Content = input.Content,
            };            

            await dbContext.ChatMessages.AddAsync (chatMessage);

            var chatGroupMemberList = await dbContext
                .ChatGroupMembers
                .Where(e => e.ChatGroupId == input.ChatGroupId && e.Deleted == null)
                .ToListAsync();
            
            var currentMember = chatGroupMemberList.Where(e => e.ChatMemberId == input.ChatMemberId).FirstOrDefault();

            chatGroupMemberList.Remove(currentMember);

            foreach (var item in chatGroupMemberList)
            {
                item.HasBeenRead = false;
                dbContext.ChatGroupMembers.Update(item);
            }


            await dbContext.SaveChangesAsync ();
            return new CreateChatMessagePayload (chatMessage);
        }  

        [UseDbContext (typeof (WebAppContext))]
        public async Task<CreateChatMessagePayload> DeleteChatMessage (DeleteChatMessageInput input, [ScopedService] WebAppContext dbContext) 
        {
            if (dbContext.ChatMessages == null) 
            {
                throw new Exception ("Null dbContext.ChatMessages in Mutation:DeleteChatMessage");
            }            

            var chatMessage = await dbContext
                .ChatMessages
                .Where(e => e.Id == input.ChatId && e.Deleted == null)
                .FirstOrDefaultAsync();

            if(chatMessage != null) {
                dbContext.ChatMessages.Remove (chatMessage);
                await dbContext.SaveChangesAsync ();
                return new CreateChatMessagePayload (chatMessage);
            }            

            return new CreateChatMessagePayload ();
        }        
    }
}