using Otvetmailru.Entities.Models;

namespace Otvetmailru.WebAPI.Models;

public class QuizPreviewResponse
{
    public Guid Id { get; set; }
    // public Guid QuestionId  { get; set; }
    public DateTime FinishDate  { get; set; }
}