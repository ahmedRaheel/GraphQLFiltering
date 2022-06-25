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
        public async Task<CreateChatMemberPayload> CreateChatMember (CreateChatMemberInput input, [ScopedService] WebAppContext dbContext) 
        {
            if (dbContext.ChatMembers == null) 
            {
                throw new Exception ("Null dbContext.ChatMembers in Mutation:CreateChats");
            }

            var chatMember = new ChatMember
            {                
                Name = input.Name,
            };

            await dbContext.ChatMembers.AddAsync (chatMember);
            await dbContext.SaveChangesAsync ();
            return new CreateChatMemberPayload (chatMember);
        }        
    }
}