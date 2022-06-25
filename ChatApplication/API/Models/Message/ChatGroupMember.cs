using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommanderGQL.Models 
{
    public class ChatGroupMember
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public bool HasBeenRead { get; set; }        
        public DateTime? Deleted { get; set; }
        public int? ChatGroupId { get; set; }
        public virtual ChatGroup? ChatGroup { get; set; }
        public int? ChatMemberId { get; set; }
        public virtual ChatMember? Member { get; set; }
    }
}