using Otvetmailru.Entities.Models;

namespace Otvetmailru.WebAPI.Models;

public class AnswerPreviewResponse
{
    public Guid Id{get;set;}
    public string TextAnswer  { get; set; }
}