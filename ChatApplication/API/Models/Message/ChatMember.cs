using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommanderGQL.Models 
{
    public class ChatMember
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Name { get; set; }
        public virtual  ICollection<ChatGroupMember> ChatGroups { get; set; } = new List<ChatGroupMember> ();
    }
}