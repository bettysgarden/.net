namespace Otvetmailru.Entities.Models;

public class Likes : BaseEntity
{
    public Guid AnswerId  { get; set; }
    public virtual Answer Answer { get; set; }
    
    public Guid UserId  { get; set; }
    public virtual User User { get; set; }


}