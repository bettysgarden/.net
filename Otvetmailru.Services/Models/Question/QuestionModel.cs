using Otvetmailru.Entities.Models;

namespace Otvetmailru.Services.Models;

public class QuestionModel : BaseModel
{

    // public Guid UserId { get; set; }
    public string QuestionText { get; set; }
    public Category Category { get; set; }
    public string AdditionInfo  { get; set; }
    public bool Status  { get; set; }
}