using CommanderGQL.Data;
using CommanderGQL.Models;

namespace CommanderGQL.GraphQL 
{
    #region Create
    public class CreateChatGroupInput
    {
        [GraphQLNonNullType]
        public string? Title { get; set; }
    }

    public class CreateChatGroupPayload
    {
        public CreateChatGroupPayload(ChatGroup chatGroup) 
        {
            ChatGroup = chatGroup;
        }

        public ChatGroup ChatGroup { get; set; }
    }    
    #endregion

    #region Update/SoftDelete
    public class UpdateChatGroupInput
    {
        [GraphQLNonNullType]
        public int? Id { get; set; }

        [GraphQLNonNullType]
        public string? Title { get; set; }
    }

    public class SoftDeleteChatGroupInput
    {
        [GraphQLNonNullType]
        public int? Id { get; set; }
    }

    public class UpdateChatGroupPayload
    {
        public UpdateChatGroupPayload()
        {            
        }

        public UpdateChatGroupPayload(ChatGroup chatGroup) 
        {
            ChatGroup = chatGroup;
        }

        public ChatGroup? ChatGroup { get; set; }
    }
    #endregion
}