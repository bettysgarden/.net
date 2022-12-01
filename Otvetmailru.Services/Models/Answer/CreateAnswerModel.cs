namespace Otvetmailru.Services.Models;

public class CreateAnswerModel
{
    public Guid QuestionId  { get; set; }
    public Guid UserId  { get; set; }
    public string TextAnswer  { get; set; }

}