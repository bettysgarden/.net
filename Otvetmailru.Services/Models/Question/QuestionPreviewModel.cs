using Otvetmailru.Entities.Models;

namespace Otvetmailru.Services.Models;

public class QuestionPreviewModel
{
    public Guid Id{get;set;}

    public Guid UserId { get; set; }
    public string QuestionText { get; set; }
    public bool Status  { get; set; }

}