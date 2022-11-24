using Otvetmailru.Entity.Models;

namespace Otvetmailru.Entities.Models;

public class CommentHasAttachment  : BaseEntity
{
    public Guid QuestionId  { get; set; }
    public virtual Question Question { get; set; }
    
    public Guid CommentId  { get; set; }
    public virtual Comments Comments { get; set; }
    
    public Guid UserId  { get; set; }
    public virtual User User { get; set; } 
    
    public Guid AttachmentsId  { get; set; }
    public virtual Attachments Attachments { get; set; } 
}