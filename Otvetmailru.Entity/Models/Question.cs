using Otvetmailru.Entity.Models;

namespace Otvetmailru.Entities.Models;

public class Question : BaseEntity
{
    public Guid UserId { get; set; }
    public virtual User User { get; set; }

    public string QuestionText { get; set; }
    public Category Category { get; set; }
    public string AdditionInfo  { get; set; }
    public bool Status  { get; set; }
    public Quiz? Quiz { get; set; }
    
    public virtual ICollection<Answer> Answers { get; set; }
    // public virtual ICollection<Comments> Comments { get; set; }
    public virtual ICollection<QuestionHasAttachment> Attachments { get; set; }




}