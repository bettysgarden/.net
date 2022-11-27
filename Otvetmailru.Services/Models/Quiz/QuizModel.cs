using Otvetmailru.Entities.Models;

namespace Otvetmailru.Services.Models;

public class QuizModel : BaseModel
{
    // public Guid Id{get;set;}
    public string TextQuiz { get; set; }
    public Guid UserId  { get; set; }
    public Guid QuestionId  { get; set; }
    public DateTime FinishDate  { get; set; }  

}