using Otvetmailru.Entities.Models;

namespace Otvetmailru.Services.Models;

public class LikesModel : BaseModel
{
    // public Guid Id{get;set;}
    public Guid AnswerId  { get; set; }
    public Guid UserId  { get; set; }
}