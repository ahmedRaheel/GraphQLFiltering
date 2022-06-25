using CommanderGQL.Data;
using CommanderGQL.Models;
using Microsoft.EntityFrameworkCore;

namespace CommanderGQL.GraphQL
{
    public partial class Query
    {        
        [UseDbContext(typeof(WebAppContext))]        
        [UsePaging]
        public async Task<IQueryable<ChatMessage>?> GetChatMessage(
            [ScopedService] WebAppContext dbContext, 
            [ID, GraphQLNonNullType, GraphQLDescription("Chat group id")] int chatGroupId,
            [ID, GraphQLNonNullType, GraphQLDescription("Chat memeber id")] int chatMemberId
        )
        {
            var emptyMessages = Enumerable.Empty<ChatMessage> ().AsQueryable ();

            if (dbContext.ChatMessages == null) return emptyMessages;

            if (dbContext.ChatGroupMembers == null) return emptyMessages;

            var chatGroupMember = await dbContext
                .ChatGroupMembers
                .Where(e => e.ChatGroupId == chatGroupId && e.ChatMemberId == chatMemberId)
                .FirstOrDefaultAsync();

            if(chatGroupMember == null) return emptyMessages;
            
            return dbContext.ChatMessages.Where(c => c.ChatGroupMemberId == chatGroupMember.Id);
        }

        [UseDbContext(typeof(WebAppContext))]        
        [UseOffsetPaging]
        public async Task<IQueryable<ChatMessage>?> GetOffsetMessages(
            [ScopedService] WebAppContext dbContext, 
            [ID, GraphQLNonNullType, GraphQLDescription("Chat group id")] int chatGroupId,
            [ID, GraphQLNonNullType, GraphQLDescription("Chat memeber id")] int chatMemberId
        )
        {
            var emptyMessages = Enumerable.Empty<ChatMessage> ().AsQueryable ();

            if (dbContext.ChatMessages == null) return emptyMessages;

            if (dbContext.ChatGroupMembers == null) return emptyMessages;

            var chatGroupMember = await dbContext
                .ChatGroupMembers
                .Where(e => e.ChatGroupId == chatGroupId && e.ChatMemberId == chatMemberId)
                .FirstOrDefaultAsync();

            if(chatGroupMember == null) return emptyMessages;
            
            return dbContext.ChatMessages.Where(c => c.ChatGroupMemberId == chatGroupMember.Id);
        }
    }
}