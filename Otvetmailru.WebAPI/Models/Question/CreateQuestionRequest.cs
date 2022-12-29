namespace Otvetmailru.WebAPI.Models;

public class CreateQuestionRequest : UpdateAnswerRequest
{
    public Guid UserId { get; set; }

}