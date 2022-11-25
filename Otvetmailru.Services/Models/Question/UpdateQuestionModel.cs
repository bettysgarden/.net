using Otvetmailru.Entities.Models;

namespace Otvetmailru.Services.Models;

public class UpdateQuestionModel
{
    public string QuestionText { get; set; }
    public Category Category { get; set; }
    public string AdditionInfo  { get; set; }
}