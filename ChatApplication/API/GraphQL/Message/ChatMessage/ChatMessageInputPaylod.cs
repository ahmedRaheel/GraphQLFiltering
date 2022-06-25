using CommanderGQL.Data;
using CommanderGQL.Models;

namespace CommanderGQL.GraphQL 
{
    public class CreateChatMessageInput
    {        
        [GraphQLNonNullType]
        public int? ChatGroupId { get; set; }

        [GraphQLNonNullType]
        public int? ChatMemberId { get; set; }
        
        [GraphQLNonNullType]
        public string? Content { get; set; }
    }

    public class CreateChatMessagePayload
    {
        public CreateChatMessagePayload()
        {
        }

        public CreateChatMessagePayload(ChatMessage chatMessage) 
        {            
            ChatMessage = chatMessage;
        }

        public ChatMessage? ChatMessage { get; set; }
    }

    public class DeleteChatMessageInput
    {        
        [GraphQLNonNullType]
        public int? ChatId { get; set; }                
    }
}