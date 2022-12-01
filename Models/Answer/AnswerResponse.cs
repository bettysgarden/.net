using Otvetmailru.Entities.Models;

namespace Otvetmailru.WebAPI.Models;

public class AnswerResponse
{
    public Guid Id{get;set;}

    public Guid QuestionId  { get; set; }
    public Guid UserId  { get; set; }
    public string TextAnswer  { get; set; }
}