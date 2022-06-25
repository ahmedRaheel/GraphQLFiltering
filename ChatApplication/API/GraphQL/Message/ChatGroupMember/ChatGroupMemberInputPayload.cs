using CommanderGQL.Data;
using CommanderGQL.Models;

namespace CommanderGQL.GraphQL 
{    
    public class AddChatMemberToGroupInput
    {
        [GraphQLNonNullType]
        public int? ChatGroupId { get; set; }

        [GraphQLNonNullType]
        public int? ChatMemberId { get; set; }
    }

    public class RemoveChatMemberFromGroupInput
    {
        [GraphQLNonNullType]
        public int? ChatGroupId { get; set; }

        [GraphQLNonNullType]
        public int? ChatMemberId { get; set; }
    }
}