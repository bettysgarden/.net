using Otvetmailru.Entities.Models;

namespace Otvetmailru.Entity.Models;

public class Answer : BaseEntity
{
    public Guid QuestionId  { get; set; }
    public virtual Question Question { get; set; }
    public Guid UserId  { get; set; }
    public virtual User User { get; set; }
    public string TextAnswer  { get; set; }
    public Guid? ParentAnswerId { get; set; }
    public virtual Answer? ParentAnswer { get; set; }
    public virtual ICollection<Answer> ChildrenAnswers { get; set; }
    public virtual ICollection<Likes> AmountOfLikes  { get; set; }
    public virtual ICollection<AnswerHasAttachment> Attachments { get; set; }

}