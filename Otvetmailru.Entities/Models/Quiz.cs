namespace Otvetmailru.Entities.Models;

public class Quiz : BaseEntity
{
    public Guid QuestionId  { get; set; }
    public virtual Question Question { get; set; }
    
    public Guid UserId  { get; set; }
    public virtual User User { get; set; } 
    
    public DateTime FinishDate  { get; set; }  
}