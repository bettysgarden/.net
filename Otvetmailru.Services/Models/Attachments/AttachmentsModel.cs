using Otvetmailru.Entities.Models;

namespace Otvetmailru.Services.Models;

public class AttachmentsModel : BaseModel
{
    public Guid Id{get;set;}

    public string Name { get; set; }
    public string TypeOfFile  { get; set; }
}