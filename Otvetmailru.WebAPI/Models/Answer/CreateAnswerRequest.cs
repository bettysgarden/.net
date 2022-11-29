namespace Otvetmailru.WebAPI.Models;

public class CreateAnswerRequest
{
    public Guid QuestionId  { get; set; }
    public Guid UserId  { get; set; }
}