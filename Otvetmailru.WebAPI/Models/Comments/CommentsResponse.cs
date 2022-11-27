using Otvetmailru.Entities.Models;

namespace Otvetmailru.WebAPI.Models;

public class CommentsResponse
{
    public Guid Id{get;set;}
    public Guid QuestionId  { get; set; }
    public Guid UserId  { get; set; }
    public Guid AnswerId  { get; set; }
    public string TextComment   { get; set; }

}