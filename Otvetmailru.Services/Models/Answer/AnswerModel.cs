using Otvetmailru.Entities.Models;

namespace Otvetmailru.Services.Models;

public class AnswerModel : BaseModel
{
    public Guid Id{get;set;}

    public Guid QuestionId  { get; set; }
    public Guid UserId  { get; set; }
    public string TextAnswer  { get; set; }

}