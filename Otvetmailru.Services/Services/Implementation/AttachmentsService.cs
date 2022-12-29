using AutoMapper;
using Otvetmailru.Entity.Models;
using Otvetmailru.Repository;
using Otvetmailru.Services.Models;

namespace Otvetmailru.Services.Abstract;

public class AttachmentsService : IAttachmentsService
{

    private readonly IRepository<Attachments> _attachmentsRepository;
    private readonly IMapper _mapper;
    
    public AttachmentsService(IRepository<Attachments> attachmentsRepository, IMapper mapper)
    {
        this._attachmentsRepository=attachmentsRepository;
        this._mapper = mapper;
    }

    public void DeleteAttachments(Guid id)
    {
        var attachmentsToDelete = _attachmentsRepository.GetById(id);
        if (attachmentsToDelete == null)
        {
            throw new Exception("Attachments not found");
        }
        _attachmentsRepository.Delete(attachmentsToDelete);
    }

    public AttachmentsModel GetAttachments(Guid id)
    {
        var attachments =_attachmentsRepository.GetById(id);
        return _mapper.Map<AttachmentsModel>(attachments);
    }

    public PageModel<AttachmentsPreviewModel> GetAttachments(int limit = 20, int offset = 0)
    {
        var attachments = _attachmentsRepository.GetAll();
        int totalCount = attachments.Count();
        var chunk = attachments.OrderBy(x=>x.Name)
            .Skip(offset)
            .Take(limit);

        return new PageModel<AttachmentsPreviewModel>()
        {
            Items = _mapper.Map<IEnumerable<AttachmentsPreviewModel>>(chunk),
            TotalCount = totalCount
        };
    }

    public AttachmentsModel UpdateAttachments(Guid id, UpdateAttachmentsModel attachments)
    {
        var existingAttachments = _attachmentsRepository.GetById(id);
        if (existingAttachments == null)
        {
            throw new Exception("Attachments not found");
        }
        existingAttachments.Name= attachments.Name;
        existingAttachments = _attachmentsRepository.Save(existingAttachments);
        return _mapper.Map<AttachmentsModel>(existingAttachments);
    }
}