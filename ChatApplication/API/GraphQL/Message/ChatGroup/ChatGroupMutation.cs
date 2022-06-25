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
        public async Task<CreateChatGroupPayload> CreateChatGroup (CreateChatGroupInput input, [ScopedService] WebAppContext dbContext) 
        {
            if (dbContext.ChatGroups == null)
            {
                throw new Exception ("Null dbContext.GroupChats in Mutation:CreateGroupChat");
            }

            var chatGroup = new ChatGroup 
            {
                Title = input.Title,
            };

            await dbContext.ChatGroups.AddAsync (chatGroup);
            await dbContext.SaveChangesAsync ();
            return new CreateChatGroupPayload (chatGroup);
        }

        [UseDbContext (typeof (WebAppContext))]
        public async Task<UpdateChatGroupPayload> UpdateChatGroup (UpdateChatGroupInput input, [ScopedService] WebAppContext dbContext) 
        {
            if (dbContext.ChatGroups == null)
            {
                throw new Exception ("Null dbContext.GroupChats in Mutation:UpdateChatGroupInput");
            }

            var chatGroup = await dbContext.ChatGroups.Where(e => e.Id == input.Id).FirstOrDefaultAsync();

            if(chatGroup != null) {
                chatGroup.Title = input.Title;

                dbContext.Update(chatGroup);
                await dbContext.SaveChangesAsync ();

                return new UpdateChatGroupPayload (chatGroup);
            }            

            return new UpdateChatGroupPayload ();
        }

        [UseDbContext (typeof (WebAppContext))]
        public async Task<UpdateChatGroupPayload> SoftDeleteChatGroup (SoftDeleteChatGroupInput input, [ScopedService] WebAppContext dbContext) 
        {
            if (dbContext.ChatGroups == null)
            {
                throw new Exception ("Null dbContext.GroupChats in Mutation:UpdateChatGroupInput");
            }

            var chatGroup = await dbContext
                .ChatGroups
                .Where(e => e.Id == input.Id && e.Deleted == null)
                .FirstOrDefaultAsync();

            if(chatGroup != null) {
                chatGroup.Deleted = DateTime.UtcNow;

                dbContext.ChatGroups.Update(chatGroup);
                await dbContext.SaveChangesAsync ();

                return new UpdateChatGroupPayload (chatGroup);
            }            

            return new UpdateChatGroupPayload ();
        }
    }
}