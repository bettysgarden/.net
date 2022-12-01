using Otvetmailru.Services.Models;
namespace Otvetmailru.Services.Abstract;

public interface ILikesService
{
    LikesModel CreateLikes(CreateLikesModel likesModel);

    LikesModel GetLikes(Guid id);

    LikesModel UpdateLikes(Guid id, UpdateLikesModel likes);

    void DeleteLikes(Guid id);

    PageModel<LikesPreviewModel> GetLikes(int limit = 20, int offset = 0);
}