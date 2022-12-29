using Otvetmailru.Services.Models;

namespace Otvetmailru.Services.Abstract;

public interface IAttachmentsService
{
    AttachmentsModel GetAttachments(Guid id);

    AttachmentsModel UpdateAttachments(Guid id, UpdateAttachmentsModel attachments);

    void DeleteAttachments(Guid id);

    PageModel<AttachmentsPreviewModel> GetAttachments(int limit = 20, int offset = 0);
}