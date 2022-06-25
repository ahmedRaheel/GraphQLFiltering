using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommanderGQL.Models 
{
    public class ChatMessage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }        
        public string? Content { get; set; } 
        public DateTime? Deleted { get; set; }          
        public int? ChatGroupId  { get;set; }
        public virtual ChatGroup? ChatGroup  {get;set;}
        public int? ChatGroupMemberId { get; set; }
        public virtual ChatGroupMember? ChatGroupMember { get; set; }
    }
}