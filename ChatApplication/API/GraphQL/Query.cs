using CommanderGQL.Data;
using CommanderGQL.Models;
using Newtonsoft.Json;
using System.Text;
using UseFilteringAttribute = HotChocolate.Data.UseFilteringAttribute;
using UseSortingAttribute = HotChocolate.Data.UseSortingAttribute;

namespace CommanderGQL.GraphQL
{
    public partial class Query
    {
        // Naming convention: "Get" keyword and the resource that you want to return
        // Hotchocolate recommend to inject the DBContext in each method instead of the constructor of the class
        [UseDbContext(typeof(WebAppContext))]
        // UseProjection fetch child objects, if you use resolvers, you should remove the [UseProjection] annotation
        // [UseProjection]
        // HotChocolate filtering implementation
        [UseFiltering]
        // HotChocolate sorting implementation
        [UseSorting]
        public IQueryable<Platform>? GetPlatform([ScopedService] WebAppContext dbContext)
        {
            return dbContext.Platforms;
        }

        [UseDbContext(typeof(WebAppContext))]
        // [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Command>? GetCommand([ScopedService] WebAppContext dbContext)
        {
            return dbContext.Commands;
        }

        [UseFiltering]
        [UseSorting]
        public async Task<IEnumerable<Post>> GetPost()
        {
            try
            {
                List<Post> posts = new List<Post>();
                using (HttpClient client = new HttpClient())
                {
                    string apiBaseUrl = "https://jsonplaceholder.typicode.com";
                    //StringContent content = new StringContent(JsonConvert.SerializeObject(post), Encoding.UTF8, "application/json");
                    string endpoint = apiBaseUrl + "/posts";
                    using (var Response = await client.GetAsync(endpoint))
                    {
                        using (HttpContent responceContent = Response.Content)
                        {
                            Task<string> result = responceContent.ReadAsStringAsync();
                            posts.AddRange(JsonConvert.DeserializeObject<List<Post>>(result.Result));
                        }
                    }
                }
                return posts;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
