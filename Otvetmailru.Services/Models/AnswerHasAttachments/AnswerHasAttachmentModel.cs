using Otvetmailru.Entities.Models;

namespace Otvetmailru.Services.Models;

public class AnswerHasAttachmentModel : BaseModel
{
    public Guid Id{get;set;}
    public Guid QuestionId  { get; set; }
    public Guid AnswerId  { get; set; }
    public Guid UserId  { get; set; }
    public Guid AttachmentsId  { get; set; }
}