using Otvetmailru.Entities.Models;

namespace Otvetmailru.Services.Models;

public class CommentsPreviewModel
{
    public Guid Id{get;set;}
    public Guid UserId { get; set; }
    public string TextComment   { get; set; }

}