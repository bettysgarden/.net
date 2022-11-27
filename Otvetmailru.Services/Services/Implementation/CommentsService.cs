using AutoMapper;
using Otvetmailru.Entities.Models;
using Otvetmailru.Entity.Models;
using Otvetmailru.Repository;
using Otvetmailru.Services.Abstract;
using Otvetmailru.Services.Models;

namespace Otvetmailru.Services.Abstract;

public class CommentsService : ICommentsService
{
    private readonly IRepository<Comments> _commentsRepository;
    private readonly IMapper _mapper;
    public CommentsService(IRepository<Comments> commentsRepository, IMapper mapper)
    {
        this._commentsRepository=commentsRepository;
        this._mapper = mapper;
    }

    public void DeleteComments(Guid id)
    {
        var commentsToDelete =_commentsRepository.GetById(id);
        if (commentsToDelete == null)
        {
            throw new Exception("Comments not found");
        }
        _commentsRepository.Delete(commentsToDelete);
    }

    public CommentsModel GetComments(Guid id)
    {
        var comments =_commentsRepository.GetById(id);
        return _mapper.Map<CommentsModel>(comments);
    }

    public PageModel<CommentsPreviewModel> GetComments(int limit = 20, int offset = 0)
    {
        var comments =_commentsRepository.GetAll();
        int totalCount =comments.Count();
        var chunk=comments.OrderBy(x=>x.User)
            .Skip(offset)
            .Take(limit);

        return new PageModel<CommentsPreviewModel>()
        {
            Items = _mapper.Map<IEnumerable<CommentsPreviewModel>>(chunk),
            TotalCount = totalCount
        };
    }

    public CommentsModel UpdateComments(Guid id, UpdateCommentsModel comments)
    {
        var existingComments = _commentsRepository.GetById(id);
        if (existingComments == null)
        {
            throw new Exception("Comments not found");
        }
        existingComments.TextComment=comments.TextComment;
        existingComments = _commentsRepository.Save(existingComments);
        return _mapper.Map<CommentsModel>(existingComments);
    }
}