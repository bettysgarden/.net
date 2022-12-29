namespace Otvetmailru.WebAPI.Models;

public class CreateAnswerRequest : UpdateAnswerRequest
{
    public Guid QuestionId  { get; set; }
    public Guid UserId  { get; set; }
}