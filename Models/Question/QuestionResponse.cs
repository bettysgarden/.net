using Otvetmailru.Entities.Models;

namespace Otvetmailru.WebAPI.Models;

public class QuestionResponse 
{
    public Guid Id{get;set;}

    public Guid UserId { get; set; }
    public string QuestionText { get; set; }
    public Category Category { get; set; }
    public string AdditionInfo  { get; set; }
    public bool Status  { get; set; }

}