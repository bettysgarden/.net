using AutoMapper;
using Otvetmailru.Entity.Models;
using Otvetmailru.Repository;
using Otvetmailru.Services.Abstract;
using Otvetmailru.Services.Models;

namespace Otvetmailru.Services.Implementation;

public class AnswerService : IAnswerService
{

    private readonly IRepository<Answer> _answerRepository;
    private readonly IMapper mapper;
    
    public AnswerService(IRepository<Answer> answerRepository, IMapper mapper)
    {
        this._answerRepository=answerRepository;
        this.mapper = mapper;
    }

    public void DeleteAnswer(Guid id)
    {
        var answerToDelete = _answerRepository.GetById(id);
        if (answerToDelete == null)
        {
            throw new Exception("Answer not found");
        }
        _answerRepository.Delete(answerToDelete);
    }

    public AnswerModel GetAnswer(Guid id)
    {
        var answer =_answerRepository.GetById(id);
        return mapper.Map<AnswerModel>(answer);
    }

    public PageModel<AnswerPreviewModel> GetAnswer(int limit = 20, int offset = 0)
    {
        var answer =_answerRepository.GetAll();
        int totalCount =answer.Count();
        var chunk=answer.OrderBy(x=>x.AmountOfLikes)
            .Skip(offset)
            .Take(limit);

        return new PageModel<AnswerPreviewModel>()
        {
            Items = mapper.Map<IEnumerable<AnswerPreviewModel>>(answer),
            TotalCount = totalCount
        };
    }

    public AnswerModel UpdateAnswer(Guid id, UpdateAnswerModel answer)
    {
        var existingAnswer = _answerRepository.GetById(id);
        if (existingAnswer == null)
        {
            throw new Exception("Answer not found");
        }
        existingAnswer.TextAnswer = answer.TextAnswer;
        existingAnswer = _answerRepository.Save(existingAnswer);
        return mapper.Map<AnswerModel>(existingAnswer);
    }
}