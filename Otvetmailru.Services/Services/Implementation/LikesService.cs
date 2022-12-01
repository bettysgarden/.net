using AutoMapper;
using Otvetmailru.Entity.Models;
using Otvetmailru.Entities.Models;
using Otvetmailru.Repository;
using Otvetmailru.Services.Abstract;
using Otvetmailru.Services.Models;

namespace Otvetmailru.Services.Abstract;

public class LikesService : ILikesService
{
    private readonly IRepository<Likes> _likesRepository;
    private readonly IMapper _mapper;
    public LikesService(IRepository<Likes> likesRepository, IMapper mapper)
    {
        this._likesRepository=likesRepository;
        this._mapper = mapper;
    }

    public void DeleteLikes(Guid id)
    {
        var likesToDelete =_likesRepository.GetById(id);
        if (likesToDelete == null)
        {
            throw new Exception("Likes not found");
        }
        _likesRepository.Delete(likesToDelete);
    }

    public LikesModel CreateLikes(CreateLikesModel likesModel)
    {
        Likes likes = _mapper.Map<Likes>(likesModel);
        return _mapper.Map<LikesModel>(_likesRepository.Save(likes));
    }

    public LikesModel GetLikes(Guid id)
    {
        var likes =_likesRepository.GetById(id);
        return _mapper.Map<LikesModel>(likes);
    }

    public PageModel<LikesPreviewModel> GetLikes(int limit = 20, int offset = 0)
    {
        var likes =_likesRepository.GetAll();
        int totalCount =likes.Count();
        var chunk=likes.OrderBy(x=>x.Id)
            .Skip(offset)
            .Take(limit);

        return new PageModel<LikesPreviewModel>()
        {
            Items = _mapper.Map<IEnumerable<LikesPreviewModel>>(chunk),
            TotalCount = totalCount
        };
    }

    public LikesModel UpdateLikes(Guid id, UpdateLikesModel likes)
    {
        var existingLikes = _likesRepository.GetById(id);
        if (existingLikes == null)
        {
            throw new Exception("Likes not found");
        }
        existingLikes = _likesRepository.Save(existingLikes);
        return _mapper.Map<LikesModel>(existingLikes);
    }
}