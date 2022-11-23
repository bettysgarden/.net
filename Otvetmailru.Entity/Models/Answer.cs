namespace Otvetmailru.Entities.Models;

public class Answer : BaseEntity
{
    public Guid QuestionId  { get; set; }
    public virtual Question Question { get; set; }
    
    public Guid UserId  { get; set; }
    public virtual User User { get; set; }
    
    public string TextAnswer  { get; set; }
    public int AmountOfLikes  { get; set; }
}