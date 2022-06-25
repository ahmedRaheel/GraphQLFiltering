using System.Text;
using CommanderGQL.Data;
using CommanderGQL.Models;
using HotChocolate.Data.Filters;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace CommanderGQL.GraphQL 
{
    public partial class Query
    {

        [UseProjection]
        [UseFiltering]       
        [UseSorting]
        public IQueryable<ChatGroup> GetChatGroups(WebAppContext webAppContext) =>
            webAppContext.ChatGroups;
        
        [UseProjection]
        [UseFiltering]       
        [UseSorting]
        public ChatGroup FirstChatGroups(ChatGroupService chatGroupService) =>
            chatGroupService.GetFirstChatGroup();


        // [UseDbContext (typeof (WebAppContext))]
        [UseProjection]
        [UseFiltering]       
        [UseSorting]
        public async Task<ChatGroup?> GetChatGroup (
            [ID, GraphQLNonNullType, GraphQLDescription("Group chat id")] int groupChatId, 
            WebAppContext dbContext
        ) 
        {
            if (dbContext.ChatGroups == null) return null;
            
                return await dbContext
                    .ChatGroups              
                    .Where(c => c.Id == groupChatId && c.Deleted == null)
                    .FirstOrDefaultAsync();
        }

        public ChatGroup GetTestChatGroup () 
        {
            return new ChatGroup {
                Id = 1,
                Title = "Test title",
            };
        }
    }  

  
    public class ChatGroupService : IAsyncDisposable
    {
    private readonly WebAppContext _dbContext;

    public ChatGroupService(IDbContextFactory<WebAppContext> dbContextFactory)
    {
        _dbContext = dbContextFactory.CreateDbContext();
    }

    public ChatGroup GetFirstChatGroup()
        => _dbContext.ChatGroups.FirstOrDefault();

    public ValueTask DisposeAsync()
    {
        return _dbContext.DisposeAsync();
    }
  }
}

