using Otvetmailru.Services.Models;
namespace Otvetmailru.Services.Abstract;

public interface ICommentsService
{
    CommentsModel GetComments(Guid id);

    CommentsModel UpdateComments(Guid id, UpdateCommentsModel comments);

    void DeleteComments(Guid id);

    PageModel<CommentsPreviewModel> GetComments(int limit = 20, int offset = 0);
}