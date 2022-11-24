using Otvetmailru.Entity.Models;

namespace Otvetmailru.Entities.Models;

public class Comments : BaseEntity
{
    public Guid QuestionId  { get; set; }
    public virtual Question Question { get; set; }
    
    public Guid UserId  { get; set; }
    public virtual User User { get; set; }
    
    public Guid AnswerId  { get; set; }
    public virtual Answer Answer { get; set; }
    
    public string TextComment   { get; set; }
    
    public virtual ICollection<CommentHasAttachment> Attachments { get; set; }

}