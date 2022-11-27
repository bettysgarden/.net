using Otvetmailru.Entities.Models;

namespace Otvetmailru.WebAPI.Models;

public class QuestionPreviewResponse
{
    public Guid Id{get;set;}

    public Guid UserId { get; set; }
    public string QuestionText { get; set; }
    public bool Status  { get; set; }
}