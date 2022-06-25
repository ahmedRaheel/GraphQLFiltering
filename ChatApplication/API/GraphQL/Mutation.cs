using CommanderGQL.Data;
using CommanderGQL.Models;
using Newtonsoft.Json;
using System.Text;

namespace CommanderGQL.GraphQL {
    public partial class Mutation 
    {
        private readonly List<User> _users;
        public Mutation()
        {
            _users = new List<User>();
        }

        [UseDbContext (typeof (WebAppContext))]
        public async Task<AddPlatformPayload> AddPlatformAsync (AddPlatformInput input, [ScopedService] WebAppContext dbContext) {
            if (dbContext.Platforms == null) {
                throw new Exception ("Null dbContext.Platforms in Mutation:AddPlatformAsync");
            }

            var platform = new Platform {
                Name = input.Name,
            };

            await dbContext.Platforms.AddAsync (platform);
            await dbContext.SaveChangesAsync ();
            return new AddPlatformPayload (platform);
        }

        public async Task<Post> CreatePost(Post post)
        {
            try
            {
                Post GeneratedPost = new Post();
                using (HttpClient client = new HttpClient())
                {
                    string apiBaseUrl = "https://jsonplaceholder.typicode.com";
                    StringContent content = new StringContent(JsonConvert.SerializeObject(post), Encoding.UTF8, "application/json");
                    string endpoint = apiBaseUrl + "/posts";
                    using (var Response = await client.PostAsync(endpoint,content))
                    {
                        using (HttpContent responceContent = Response.Content)
                        {
                            Task<string> result = responceContent.ReadAsStringAsync();
                            GeneratedPost = JsonConvert.DeserializeObject<Post>(result.Result);
                        }
                    }
                }
                return GeneratedPost;
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }        
    }
}