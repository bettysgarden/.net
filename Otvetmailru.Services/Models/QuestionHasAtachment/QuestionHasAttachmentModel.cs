using Otvetmailru.Entities.Models;

namespace Otvetmailru.Services.Models;

public class QuestionHasAttachmentModel : BaseModel
{

    public Guid Id { get; set; }
    public Guid QuestionId  { get; set; }
    public Guid UserId  { get; set; }
    public Guid AttachmentsId  { get; set; }
}