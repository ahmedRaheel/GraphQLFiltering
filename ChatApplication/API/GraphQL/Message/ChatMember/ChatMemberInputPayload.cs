using CommanderGQL.Data;
using CommanderGQL.Models;

namespace CommanderGQL.GraphQL 
{
    public class CreateChatMemberInput
    {                        
        [GraphQLNonNullType]
        public string? Name { get; set; }
    }

    public class CreateChatMemberPayload
    {
        public CreateChatMemberPayload()
        {
        }

        public CreateChatMemberPayload(ChatMember chatMember) 
        {            
            ChatMember = chatMember;
        }

        public ChatMember? ChatMember { get; set; }
    }        
}