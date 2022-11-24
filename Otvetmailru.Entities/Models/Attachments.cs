using Otvetmailru.Entities.Models;

namespace Otvetmailru.Entity.Models;

public class Attachments : BaseEntity
{
    public string Name { get; set; }
    public string TypeOfFile  { get; set; }
    
    public virtual ICollection<QuestionHasAttachment> QuestionHasAttachments { get; set; }    
    public virtual ICollection<CommentHasAttachment> CommentHasAttachments { get; set; }
    public virtual ICollection<AnswerHasAttachment> AnswerHasAttachments { get; set; }


}