using Otvetmailru.Entities.Models;

namespace Otvetmailru.WebAPI.Models;

public class CommentsPreviewResponse
{
    public Guid Id{get;set;}
    public Guid UserId { get; set; }
    public string TextComment   { get; set; }

}