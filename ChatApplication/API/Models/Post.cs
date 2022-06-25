using System.Text.Json.Serialization;

namespace CommanderGQL.Models
{
    public class Post
    {
        public int? id { get; set; }

        public string title { get; set; } = String.Empty;
        
        public string body { get; set; } = String.Empty;

        public int userId { get; set; }
    }
}
