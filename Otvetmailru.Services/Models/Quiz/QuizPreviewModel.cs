using Otvetmailru.Entities.Models;

namespace Otvetmailru.Services.Models;

public class QuizPreviewModel
{
    public Guid Id { get; set; }
    // public Guid QuestionId  { get; set; }
    public DateTime FinishDate  { get; set; }
}