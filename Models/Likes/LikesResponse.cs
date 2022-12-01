using Otvetmailru.Entities.Models;

namespace Otvetmailru.WebAPI.Models;

public class LikesResponse 
{
    public Guid Id{get;set;}
    public Guid AnswerId  { get; set; }
    public Guid UserId  { get; set; }
}